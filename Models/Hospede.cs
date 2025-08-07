using System;

namespace SistemaHotel.Models
{
    public class Hospede
    {
        public int IdHospede { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; } // CHAR(2)

        public string CEP { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Empresa { get; set; }

        public string PlacaVeiculo { get; set; }

        public string Funcionario { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
