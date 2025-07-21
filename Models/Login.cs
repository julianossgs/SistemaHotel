using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaHotel.Models
{
    [Table("Login")]
    public class Login
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}
