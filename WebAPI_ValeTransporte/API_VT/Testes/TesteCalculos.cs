using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_VT.Data;
using API_VT.Models.Entities;
using API_VT.Services;
using API_VT.Utils;
using NUnit.Framework;

namespace Testes
{
    public class Tests
    {
        private DateTime _dataInicial;
        private DateTime _dataFinal;

        private Funcionario _f1;
        private Funcionario _f2;
        private Funcionario _f3;
        private Funcionario _f4;

        private Escala _e1;
        private Escala _e2;
        private Escala _e3;
        private Escala _e4;

        private Setor _s1;
        private Setor _s2;
        private Setor _s3;
        private Setor _s4;

        List<Funcionario> _lista;

        [SetUp]
        public void Setup()
        {
            _dataInicial = new DateTime(2019, 11, 1);
            _dataFinal = new DateTime(2019, 12, 31);

            _e1 = new Escala(1, "5x2");
            _e2 = new Escala(2, "6x1");
            _e3 = new Escala(3, "6x2");
            _e4 = new Escala(4, "12x36");

            _s1 = new Setor(1, "Vendas");
            _s2 = new Setor(2, "Manutenção");
            _s3 = new Setor(3, "Limpeza");
            _s4 = new Setor(4, "Segurança");

            _f1 = new Funcionario(1, "João", "Paulo", new DateTime(2019, 11, 1), 10.00, 1, 1);
            _f2 = new Funcionario(2, "Antônio", "Figueiredo", new DateTime(2019, 11, 1), 5.00, 2, 2);
            _f3 = new Funcionario(3, "Mariana", "Silva", new DateTime(2019, 11, 1), 10.00, 3, 3);
            _f4 = new Funcionario(5, "Fábio", "Torres", new DateTime(2018, 02, 20), 12.10, 4, 4);

            _f1.Escala = _e1;
            _f1.Setor = _s1;
            _f2.Escala = _e2;
            _f2.Setor = _s2;
            _f3.Escala = _e3;
            _f3.Setor = _s3;
            _f4.Escala = _e4;
            _f4.Setor = _s4;

            _lista = new List<Funcionario>() { _f1, _f2, _f3, _f4 };
        }

        [Test]
        public void Test1()
        {
            Dictionary<Funcionario, int> esperado = new Dictionary<Funcionario, int>();
            esperado.Add(_f1, 43);
            esperado.Add(_f2, 50);
            esperado.Add(_f3, 46);
            esperado.Add(_f4, 29);
            Assert.AreEqual(esperado, DiasTrabalhados(_dataInicial, _dataFinal));

        }

        public Dictionary<Funcionario, int> DiasTrabalhados(DateTime dataInicial, DateTime dataFinal)
        {
            int diasNoPeriodo = dataFinal.AddDays(1).Subtract(dataInicial).Days;
            Dictionary<Funcionario, int> funcionarioDiasMes = new Dictionary<Funcionario, int>();
            int diasTrabalhadosPeriodo;

            foreach (Funcionario f in _lista)
            {
                if (f.DataAdmissao <= dataFinal)
                {
                    List<DateTime> diasDescanso = new List<DateTime>();
                    int diasTrabalhados = dataFinal.Subtract(f.DataAdmissao).Days;
                    string[] spl = f.Escala.EscalaTrabalho.ToUpper().Split('X');
                    int escalaT;
                    int escalaF;
                    if (int.Parse(spl[0]) == 12)
                    {
                        escalaT = 1;
                        escalaF = 1;
                    }
                    else
                    {
                        escalaT = int.Parse(spl[0]);
                        escalaF = int.Parse(spl[1]);
                    }

                    for (int i = f.DataAdmissao.Day - 1 + escalaT; i <= diasTrabalhados; i += escalaT)
                    {
                        for (int j = 1; j <= escalaF; j++)
                        {
                            diasDescanso.Add(f.DataAdmissao.AddDays(i));
                            i += 1;
                        }
                    }
                    List<DateTime> folgasPeriodo = diasDescanso.FindAll(x => x >= dataInicial && x <= dataFinal);
                    List<DateTime> totalFolgas = folgasPeriodo.Union(Feriados.FeriadosMes(dataInicial, dataFinal)).ToList();
                    diasTrabalhadosPeriodo = diasNoPeriodo - totalFolgas.Count;
                    funcionarioDiasMes.Add(f, diasTrabalhadosPeriodo);
                }
                else
                {
                    funcionarioDiasMes.Add(f, 0);
                }
            }
            return funcionarioDiasMes;
        }
    }
}