using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelComprovanteServicos : Form
    {
        public FrmRelComprovanteServicos()
        {
            InitializeComponent();
        }

        private void FrmRelComprovanteServicos_Load(object sender, EventArgs e)
        {
            this.comprovanteServicoTableAdapter.Fill(this.hotelDataSet.comprovanteServico, Convert.ToInt32(Globais.idNovoServico));
            this.reportViewer1.RefreshReport();
        }
    }
}
