using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class CadastroColetaDTO
    {


        [Required]

        public string TipoDoLixo { get; set; }


        [Required]

        public float  Quantidade { get; set; }


    }

}
