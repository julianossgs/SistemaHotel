using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelMovimentacoes : Form
    {
        public FrmRelMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmRelMovimentacoes_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            cBTipo.SelectedIndex = 0;
            BuscarData();
        }

        private void BuscarData()
        {
            //recuperando os parametros de datas
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Tipo", cBTipo.Text));

            this.movimentacoesPorDataTipoTableAdapter.Fill(this.hotelDataSet.movimentacoesPorDataTipo, Convert.ToString(dtInicial.Value), Convert.ToString(dtFinal.Text), cBTipo.Text);

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

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
