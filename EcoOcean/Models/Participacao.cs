using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    public class Participacao
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public int VoluntarioId { get; set; }


        [ForeignKey("VoluntarioId")]
        public Voluntario? Voluntario { get; set; }


        [Required]
        public int EventoId { get; set; }


        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }


        [Required]
        public int Pontuacao {  get; set; }


        public ICollection<Coleta> Coleta { get; set; }



    }
}
