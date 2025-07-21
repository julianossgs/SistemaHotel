using System;

namespace SistemaHotel.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Cargo { get; set; }

        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
