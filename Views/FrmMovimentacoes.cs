using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmMovimentacoes : Form
    {
        Conexao con = new Conexao();
        decimal totalEntrada, totalSaida;//variáveis usadas nos méts de totalizar

        public FrmMovimentacoes()
        {
            InitializeComponent();
        }

        private void MsgOk(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MsgErro(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }


        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            cBBuscar.SelectedIndex = 0;
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarDatas();
        }



        //Método de listar movimentações(método não foi usado)
        private void ListarMovimentacoes()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd1 = new MySqlCommand();
                Cmd1.Connection = con.Con;
                Cmd1.CommandText = "spListarMovimentacoes";
                Cmd1.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd1;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridMovimentacoes.DataSource = Dt;
                con.FecharCon();

            }
            catch (Exception ex)
            {

                MsgErro("Erro ao Listar as Movimentações: " + ex.Message);
            }
        }

        //Método de buscar por datas

        string sql;
        MySqlCommand Cmd2 = new MySqlCommand();
        private void BuscarDatas()
        {
            try
            {
                con.AbrirCon();
                if (cBBuscar.SelectedIndex == 0)
                {
                    sql = "SELECT * From TblMovimentacoes where Data >= @DataInicial and Data <= @DataFinal order by Data desc";
                    Cmd2 = new MySqlCommand(sql, con.Con);
                }
                else
                {
                    sql = "SELECT * From TblMovimentacoes where Data >= @DataInicial and Data <= @DataFinal and Tipo = @Tipo order by Data desc";
                    Cmd2 = new MySqlCommand(sql, con.Con);
                    Cmd2.Parameters.AddWithValue("@Tipo", cBBuscar.Text);
                }

                Cmd2.Parameters.AddWithValue("@DataInicial", Convert.ToDateTime(dtInicial.Text));
                Cmd2.Parameters.AddWithValue("@DataFinal", Convert.ToDateTime(dtFinal.Text));
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd2;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridMovimentacoes.DataSource = Dt;
                con.FecharCon();
                TotalizarEntradas();
                TotalizarSaidas();
                Totalizar();

            }
            catch (Exception ex)
            {

                MsgErro("Erro ao buscar entre datas: " + ex.Message);
            }
        }

        //Método de buscar por Tipos(Método não foi usado)
        private void BuscarTipo()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();
                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spBuscarTipo";
                Cmd3.CommandType = CommandType.StoredProcedure;
                Cmd3.Parameters.AddWithValue("@Tipo", cBBuscar.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd3;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridMovimentacoes.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao buscar por tipo: " + ex.Message);
            }
        }

        //evento de buscar por data inicial
        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        //evento de buscar por data final
        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        //evento de buscar no combo box
        private void CBBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatas();
        }

        //Método de totalizar o valor das saídas
        private void TotalizarSaidas()
        {
            decimal total = 0;
            foreach (DataGridViewRow linha in gridMovimentacoes.Rows)
            {
                if (linha.Cells["Tipo"].Value.ToString() == "Saída")
                {
                    total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
            }
            totalSaida = total;
            lblSaidas.Text = Convert.ToDecimal(total).ToString("C2");
        }

        //Método de totalizar o valor das entradas
        private void TotalizarEntradas()
        {
            decimal total = 0;
            foreach (DataGridViewRow linha in gridMovimentacoes.Rows)
            {
                if (linha.Cells["Tipo"].Value.ToString() == "Entrada")
                {
                    total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
            }
            totalEntrada = total;
            lblEntradas.Text = Convert.ToDecimal(total).ToString("C2");
        }

        //Método de totalizar
        private void Totalizar()
        {
            decimal total = 0;
            foreach (DataGridViewRow linha in gridMovimentacoes.Rows)
            {
                total = totalEntrada - totalSaida;
            }
            lblTotal.Text = Convert.ToDecimal(total).ToString("C2");

            if (total >= 0)
            {
                lblTotal.ForeColor = Color.Green;
            }

            else
            {
                lblTotal.ForeColor = Color.Red;
            }
        }
    }
}
