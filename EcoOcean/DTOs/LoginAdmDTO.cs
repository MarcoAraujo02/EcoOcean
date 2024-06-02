using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoOcean.DTOs
{
    public class LoginAdmDTO
    {
       

        [Required]
      
        public string Email { get; set; }


        [Required]
  
        public string Password { get; set; }

    }
}
