using System;

namespace SistemaHotel.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string Hospede { get; set; }
        public string Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int Dias { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal Total { get; set; }
    }
}
