using System;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelVendas : Form
    {
        public FrmRelVendas()
        {
            InitializeComponent();
        }

        private void FrmRelVendas_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            cBStatus.SelectedIndex = 0;
            BuscarData();
        }

        //Método de buscar Data inicial,final e Status e atualizar o Frm
        private void BuscarData()
        {
            //recuperando os parametros de datas
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));

            this.vendasPorDataTableAdapter.Fill(this.hotelDataSet.vendasPorData, Convert.ToString(dtInicial.Value), Convert.ToString(dtFinal.Text),cBStatus.Text);

            this.reportViewer1.RefreshReport();
        }

        //evento de buscar por data inicial
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        //evento de buscar por data final
        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        //evento de buscar por Status
        private void CBStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
