using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class CadastroAreaDTO
    {

        [Required]

        public string Cep { get; set; }

        [Required]

        public string Cidade { get; set; }

        [Required]
   
        public string Estado { get; set; }

        [Required]
     
        public string Rua { get; set; }

        [Required]
  
        public string Descricao { get; set; }
    }
}
