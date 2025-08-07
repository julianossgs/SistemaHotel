using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using SistemaHotel.Services;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            CarregarRelatorio();

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void CarregarRelatorio()
        {
            try
            {
                // 1. Conexão
                string connStr = "server=localhost;user=root;password=juliano71@;database=bdHappyInHotel";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 2. Consulta
                    // 2. Consulta com JOIN para trazer o nome do fornecedor
                    string sql = @"
                SELECT 
                    p.IdProduto,
                    p.Nome,
                    p.Descricao,
                    p.ValorUnit,
                    p.ValorCompra,
                    p.Estoque,
                    p.DataCadastro AS Data,
                    p.Imagem,
                    f.Nome AS NomeFornecedor
                FROM TblProdutos p
                LEFT JOIN TblFornecedores f ON p.IdFornec = f.IdFornec";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // 3. Adaptador e DataTable
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 4. Caminho dinâmico para o arquivo RDLC
                    string reportPath = Path.Combine(Application.StartupPath, @"Relatorios\RelProdutos.rdlc");

                    // 5. Configurando o ReportViewer
                    reportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("DataSetProdutos_1", dt); // Verifique se esse é o nome correto no .rdlc
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.LocalReport.ReportPath = reportPath;

                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao carregar relatório: " + ex.Message);
            }
        }
    }
}
