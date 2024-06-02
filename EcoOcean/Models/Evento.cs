using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    [Table("Evento")]
    public class Evento
    {      
        [Key]
        public int Id { get; set; }

        [Required]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area? Area { get; set; }

        [Required]
        public int AdministradorId { get; set; }

        [ForeignKey("AdministradorId")]
        public Administrador? Administrador { get; set; }

        [Required]
        [Column("Nome_evento")]
        public string NomeEvento { get; set; }


        [Required]
        [Column("Data_Inicio")]
        public DateTime DataInicio { get; set; } = System.DateTime.Now;

  
        [Required]
        [Column("Data_fim")]
        public DateTime? DataFim { get; set; } 

        [Required]
        [Column("Status")]
        public string Status { get; set; } = "Andamento";


        public ICollection<Voluntario> Voluntarios { get; set; }



    }
}
