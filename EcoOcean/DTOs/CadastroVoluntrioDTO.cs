using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class CadastroVoluntrioDTO
    {



        [Required]
        
        public string Nome { get; set; }


        [Required]

        public string UserName { get; set; }


        [Required]
        
        public string Senha {  get; set; }

        
        [Required]

        public DateTime DataNascimento { get; set; }


        [Required]

        public string Email { get; set; }


        [Required]
        public string Sexo { get; set; }

    }
}
