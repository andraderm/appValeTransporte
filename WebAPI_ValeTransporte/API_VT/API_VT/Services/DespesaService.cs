using API_VT.Data;
using API_VT.Models;
using API_VT.Models.Entities;
using API_VT.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Services
{
    public class DespesaService
    {
        private readonly DataContext _context;
        private readonly FuncionarioService _funcionarioService;

        public DespesaService(DataContext context, FuncionarioService funcionarioService)
        {
            _context = context;
            _funcionarioService = funcionarioService;
        }

        public async Task<List<Despesa>> FindAllAsync()
        {
            return await _context.Despesas.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Despesa> FindDespesaByData(DateTime dataInicial, DateTime dataFinal)
        {
            return await _context.Despesas.FirstOrDefaultAsync(x => x.DataInicial == dataInicial && x.DataFinal == dataFinal);
        }

        public async Task<List<DespesaFuncionario>> FindDespesasFuncionarios()
        {
            return await _context.DespesasFuncionarios.OrderBy(x => x.DespesaId).ToListAsync();
        }

        public async Task InsertAsync(DateTime dataInicial, DateTime dataFinal)
        {
            bool existe = await _context.Despesas.AnyAsync(x => x.DataInicial == dataInicial && x.DataFinal == dataFinal);
            try
            {
                if (!existe)
                {
                    Despesa despesa = new Despesa();
                    despesa.DataInicial = dataInicial;
                    despesa.DataFinal = dataFinal;
                    Dictionary<Funcionario, int> funcionarioDiasMes = await DiasTrabalhados(dataInicial, dataFinal);
                    double subtotal = 0.0;
                    foreach (Funcionario f in funcionarioDiasMes.Keys)
                    {
                        subtotal += f.CustoDiarioVT * funcionarioDiasMes[f];
                    }
                    despesa.ValorTotal = subtotal;
                    _context.Despesas.Add(despesa);

                    foreach (Funcionario f in funcionarioDiasMes.Keys)
                    {
                        DespesaFuncionario despesaFuncionario = new DespesaFuncionario(despesa, f, funcionarioDiasMes[f], funcionarioDiasMes[f] * f.CustoDiarioVT);
                        _context.DespesasFuncionarios.Add(despesaFuncionario);
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    Despesa despesa = await _context.Despesas.FirstOrDefaultAsync(x => x.DataInicial == dataInicial && x.DataFinal == dataFinal);
                    List<DespesaFuncionario> despesaFuncionario = await _context.DespesasFuncionarios.OrderBy(x => x.DespesaId).Where(x => x.DespesaId == despesa.Id).ToListAsync();
                    Dictionary<Funcionario, int> funcionarioDiasMes = await DiasTrabalhados(dataInicial, dataFinal);
                    double subtotal = 0.0;
                    foreach (Funcionario f in funcionarioDiasMes.Keys)
                    {
                        subtotal += f.CustoDiarioVT * funcionarioDiasMes[f];
                    }
                    despesa.ValorTotal = subtotal;
                    _context.Despesas.Update(despesa);

                    foreach (Funcionario f in funcionarioDiasMes.Keys)
                    {
                        DespesaFuncionario df = despesaFuncionario.Find(x => x.FuncionarioId == f.Id);
                        if (df == null)
                        {
                            _context.DespesasFuncionarios.Add(new DespesaFuncionario(despesa, f, funcionarioDiasMes[f], funcionarioDiasMes[f] * f.CustoDiarioVT));
                        }
                        else
                        {
                            _context.DespesasFuncionarios.Update(df);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var despesa = await _context.Despesas.FindAsync(dataInicial, dataFinal);
                _context.Despesas.Remove(despesa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public async Task<Dictionary<Funcionario, int>> DiasTrabalhados(DateTime dataInicial, DateTime dataFinal)
        {
            int diasNoPeriodo = dataFinal.AddDays(1).Subtract(dataInicial).Days;
            List<Funcionario> funcionarios = await _funcionarioService.FindAllAsync();
            Dictionary<Funcionario, int> funcionarioDiasMes = new Dictionary<Funcionario, int>();
            int diasTrabalhadosPeriodo;

            foreach (Funcionario f in funcionarios)
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
