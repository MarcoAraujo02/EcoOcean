using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class CadastroColetaDTO
    {
            [Required]
            public int ParticipacaoId { get; set; }

            [Required]
            public string TipoDoLixo { get; set; }

            [Required]
            public int Quantidade { get; set; }
        


    }

}
