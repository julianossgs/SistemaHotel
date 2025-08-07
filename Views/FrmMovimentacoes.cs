using SistemaHotel.Repositories.movimentacaoDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmMovimentacoes : Form
    {
        private movimentacaoDAO _dao = new movimentacaoDAO();
        private decimal totalEntrada, totalSaida;

        public FrmMovimentacoes()
        {
            InitializeComponent();
        }


        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            cBBuscar.SelectedIndex = 0;
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarDatas();
            //BuscarTipo();
        }

        private void BuscarDatas()
        {
            try
            {
                DataTable dt;
                if (cBBuscar.SelectedIndex == 0)
                {
                    dt = _dao.BuscarMovimentacoesPorDatas(dtInicial.Value, dtFinal.Value);
                }
                else
                {
                    dt = _dao.BuscarMovimentacoesPorDatasETipo(dtInicial.Value, dtFinal.Value, cBBuscar.Text);
                }
                gridMovimentacoes.DataSource = dt;
                TotalizarEntradas();
                TotalizarSaidas();
                Totalizar();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao buscar entre datas: " + ex.Message);
            }
        }


        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        private void CBBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatas();
            //BuscarTipo();
        }

        private void TotalizarSaidas()
        {
            decimal total = 0;
            foreach (DataGridViewRow linha in gridMovimentacoes.Rows)
            {
                if (linha.Cells["Tipo"].Value?.ToString() == "Saída")
                {
                    total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
            }
            totalSaida = total;
            lblSaidas.Text = total.ToString("C2");
        }

        private void TotalizarEntradas()
        {
            decimal total = 0;
            foreach (DataGridViewRow linha in gridMovimentacoes.Rows)
            {
                if (linha.Cells["Tipo"].Value?.ToString() == "Entrada")
                {
                    total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
            }
            totalEntrada = total;
            lblEntradas.Text = total.ToString("C2");
        }


        private void gridMovimentacoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            // Verifica se é a coluna "Valor"
            if (grid.Columns[e.ColumnIndex].Name == "Valor")
            {
                var tipo = grid.Rows[e.RowIndex].Cells["Tipo"].Value?.ToString();

                if (tipo == "Saída")
                {
                    e.CellStyle.ForeColor = Color.Red; // Só muda a cor da fonte da célula "Valor"
                                                       // e.CellStyle.BackColor = Color.MistyRose; // (opcional) mudar fundo
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void Totalizar()
        {
            decimal total = totalEntrada - totalSaida;
            lblTotal.Text = total.ToString("C2");

            lblTotal.ForeColor = total >= 0 ? Color.Green : Color.Red;
        }
    }
}
