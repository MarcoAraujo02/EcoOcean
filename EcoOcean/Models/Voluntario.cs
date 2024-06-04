using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoOcean.Models
{
    public class Voluntario
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("UserName")]
        public string UserName { get; set; }

        [Required]
        [Column("Senha")]
        public string Senha { get; set; }

        [Required]
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }


        [Required]
        [Column("Email")]
        public string Email { get; set;} 


        [Required]
        [Column("Sexo")]
        public string Sexo { get; set;}

        public ICollection<Participacao> Participacao { get; set; }
    }
}
