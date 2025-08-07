using System;

namespace SistemaHotel.Models
{
    public class Vendas
    {
        public int IdVenda { get; set; }

        public string Hospede { get; set; }

        public decimal ValorTotal { get; set; }

        public string Funcionario { get; set; }

        public string Stauts { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
