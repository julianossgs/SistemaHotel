namespace SistemaHotel.Services
{
    public static class Globais
    {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// Variáveis globais do sistemas
        public static string nomeUsuario;
        public static string cargoUsuario;
        public static string chamadaProdutos;
        public static string nomeProduto;
        public static string estoqueProduto;
        public static string idProduto;
        public static string VrCompra;
        public static string VrVenda;
        public static string chamadaHospedes;
        public static string nomeHospede;

        public static string valorQuarto;
        public static int diasMes;
        public static int mes;
        public static string dataPainel;
        public static string idOcupacao;
        public static string sql;
        public static int diasReserva;
        public static decimal valorTotal;
        public static string dataInicial;
        public static string dataFinal;
        public static string ultimoIdReserva;

        public static string idquarto;
        public static string quartoAntigo;

        public static string idHospede;
        public static string cpfAntigo;

        public static string ultimoIdGastos;
        public static string idGasto;

        public static string ultimoIdGasto;

        //variável p/ ser usada na edição(comparando os Cpfs na edição)
        public static string CpfAntigo;

        public static string ultimoIdServico;
        //public static string idNovoServico;
        public static string valorServico;

        //var usada p/ especificar 1 determinada venda p/ o relatório de comprovante de serviços,é usada no Frm de NovosServicos
        public static string idNovoServico;

        //var usada p/ especificar 1 determinada venda p/ o relatório de vendas,é usada no Frm de Vendas
        public static string IdVenda;
    }
}
