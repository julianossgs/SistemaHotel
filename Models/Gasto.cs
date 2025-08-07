using System;

namespace SistemaHotel.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Funcionario { get; set; }
    }
}
