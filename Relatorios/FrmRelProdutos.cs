using System;
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
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.ProdutosFornecedores'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosFornecedoresTableAdapter.Fill(this.hotelDataSet.ProdutosFornecedores);
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.TblProdutos'. Você pode movê-la ou removê-la conforme necessário.
            this.tblProdutosTableAdapter.Fill(this.hotelDataSet.TblProdutos);

            this.reportViewer1.RefreshReport();
        }
    }
}
