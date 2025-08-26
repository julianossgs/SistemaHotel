namespace SistemaHotel.Models
{
    public class DetalhesVenda
    {
        public int IdDetalhe { get; set; }
        public string Produto { get; set; }
        public decimal ValorUnit { get; set; }
        public decimal ValorTotal { get; set; }
        public int Quant { get; set; }
        public int Id_Venda { get; set; }
        public string Funcionario { get; set; }
        public int Id_Produto { get; set; }
    }
}
