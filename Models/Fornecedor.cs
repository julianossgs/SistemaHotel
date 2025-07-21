using System;

namespace SistemaHotel.Models
{
    public class Fornecedor
    {
        public int IdFornec { get; set; }
        public string NomeFornecedor { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacoes { get; set; }
    }
}
