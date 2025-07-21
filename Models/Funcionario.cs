using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaHotel.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        public int IdFunc { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public string Observacoes { get; set; }

        public DateTime? DataCadastro { get; set; }
    }
}
