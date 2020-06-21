using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_VT.Models.Entities
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DataInicial { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DataFinal { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        public List<DespesaFuncionario> DespesasFuncionarios { get; set; }
    }
}
