using API_VT.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace API_VT.Models
{
    public class DespesaFuncionario
    {
        [Key]
        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }
        [Key]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int DiasTrabalhados { get; set; }
        public double CustoIndividual { get; set; }

        public DespesaFuncionario() { }

        public DespesaFuncionario(Despesa despesa, Funcionario funcionario, int diasTrabalhados, double custoIndividual)
        {
            Despesa = despesa;
            DespesaId = despesa.Id;
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
            DiasTrabalhados = diasTrabalhados;
            CustoIndividual = custoIndividual;
        }
    }
}
