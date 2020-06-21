using System.ComponentModel.DataAnnotations;

namespace API_VT.Models.Entities
{
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        public Setor() { }
        public Setor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
