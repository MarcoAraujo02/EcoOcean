using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class LoginVoluntarioDTO
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
