using System.ComponentModel.DataAnnotations;

namespace WebPointAPI.Models
{
    public class Historico
    {

        public int ID { get; set; }
        [Required]

        public DateTime Data { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Nome { get; set; }
        [Required]

        public string UsuarioId { get; set; }


    }
}
