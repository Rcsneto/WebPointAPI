using System.ComponentModel.DataAnnotations;

namespace WebPointAPI.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int PrimeiroAcesso { get; set; }

    }
}
