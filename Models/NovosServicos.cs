using System;

namespace SistemaHotel.Models
{
    public class NovosServicos
    {
        public int IdNovoServico { get; set; }
        public string Hospede { get; set; }
        public string Servico { get; set; }
        public string Quarto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public string Funcionario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
