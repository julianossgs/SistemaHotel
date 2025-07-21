using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelComprovante : Form
    {
        public FrmRelComprovante()
        {
            InitializeComponent();
        }

        private void FrmRelComprovante_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.TblProdutos'. Você pode movê-la ou removê-la conforme necessário.
            this.vendasPorIdTableAdapter.Fill(this.hotelDataSet.vendasPorId, Convert.ToInt32(Globais.IdVenda));
            this.detalhes_venda_idTableAdapter.Fill(this.hotelDataSet.detalhes_venda_id, Convert.ToInt32(Globais.IdVenda));

            this.reportViewer1.RefreshReport();
        }
    }
}
