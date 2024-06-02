using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }


        [Required]
        [Column("Password")]
        public string Password { get; set; }


        public ICollection<Evento> Eventos { get; set; }

    }
}
