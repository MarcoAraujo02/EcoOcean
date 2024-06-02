using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class CadastroEventoDTO
    {

        public string NomeEvento { get; set; }

        [Required]
        public DateTime DataInicio { get; set; } = System.DateTime.Now;

        [Required]
        public DateTime? DataFim { get; set; } = null;

        [Required]
        [Column("Status")]
        public string Status { get; set; } = "Andamento";
    }
}
