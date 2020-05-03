using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Role { get; set; }
    }
}