using System;

namespace SistemaHotel.Models
{
    public class Movimentacao
    {
        public int IdMovimentacao { get; set; }
        public string Tipo { get; set; }
        public string Movimento { get; set; }
        public decimal Valor { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
        public int Id_Movimento { get; set; }
    }
}
