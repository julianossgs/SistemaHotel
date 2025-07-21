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
    public partial class FrmRelMovGerais : Form
    {
        public FrmRelMovGerais()
        {
            InitializeComponent();
        }

        private void FrmRelMovGerais_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarDatas();
        }

        private void BuscarDatas()
        {
            //recuperando os parametros de datas
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));
            this.movimentacoesGeraisTableAdapter.Fill(this.hotelDataSet.movimentacoesGerais, Convert.ToString(dtInicial.Text), Convert.ToString(dtFinal.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }
    }
}
