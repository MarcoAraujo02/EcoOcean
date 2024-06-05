using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    public class Coleta
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public int ParticipacaoId { get; set; }


        [ForeignKey("ParticipacaoId")]
        public Participacao? Participacao { get; set;}


        [Required]
        [Column("Tipo_Do_Lixo")]
        public string TipoDoLixo { get; set; }


        [Required]
        [Column("Quantidade")]
        public float Quantidade { get; set; }





    }
}
