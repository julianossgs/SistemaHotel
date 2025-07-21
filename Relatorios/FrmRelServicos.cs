using System;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelServicos : Form
    {
        public FrmRelServicos()
        {
            InitializeComponent();
        }

        private void FrmRelServicos_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarData();
        }

        //Método de buscar entre datas
        private void BuscarData()
        {
            //recuperando os parametros de datas
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));

            this.comprovanteServicoDataTableAdapter.Fill(this.hotelDataSet.comprovanteServicoData, Convert.ToString(dtInicial.Value), Convert.ToString(dtFinal.Value));

            this.reportViewer1.RefreshReport();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
