using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    public class Area
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Cep")]
        public string Cep { get; set; }

        [Required]
        [Column("Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Column("Estado")]
        public string Estado { get; set;}

        [Required]
        [Column("Rua")]
        public string Rua { get; set; }

        [Required]
        [Column("Descricao")]
        public string Descricao { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
