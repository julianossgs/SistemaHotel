namespace SistemaHotel.Models
{
    public class Quarto
    {
        /// <summary>
        /// Identificador interno do quarto (chave primária do banco).
        /// </summary>
        public int IdQuarto { get; set; }

        /// <summary>
        /// Número ou identificador físico do quarto (ex: 101, 202A).
        /// </summary>
        public string NumeroQuarto { get; set; }

        /// <summary>
        /// Categoria ou nome do quarto (ex: "Suíte Luxo").
        /// </summary>
        public string QuartoNome { get; set; }

        /// <summary>
        /// Capacidade máxima de pessoas no quarto.
        /// </summary>
        public string Pessoas { get; set; }

        /// <summary>
        /// Descrição detalhada do quarto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor da diária do quarto.
        /// </summary>
        public decimal Valor { get; set; }
    }
}
