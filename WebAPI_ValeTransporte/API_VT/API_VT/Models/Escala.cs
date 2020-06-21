using System.ComponentModel.DataAnnotations;

namespace API_VT.Models.Entities
{
    public class Escala
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EscalaTrabalho { get; set; }

        public Escala() { }
        public Escala(int id, string escala)
        {
            Id = id;
            EscalaTrabalho = escala;
        }
    }
}
