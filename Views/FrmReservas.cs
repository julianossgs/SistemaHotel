using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmReservas : Form
    {
        Conexao con = new Conexao();

        //variáveis globais

        public FrmReservas()
        {
            InitializeComponent();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {

            int mes = DateTime.Now.Month;
            cBMes.Text = mes.ToString();
            int ano = DateTime.Now.Year;

            cBAno.Text = ano.ToString();
            CarregarComboBox();
            cBMes.SelectedIndex = 0;
            cBQuarto.SelectedIndex = 0;

            DesabilitarCampos();
            ListarOcupacoes();

            verificarDias31();
            verificarOcupacoes();

        }

        //Método de carregar comboBox dos quartos
        private void CarregarComboBox()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = con.Con;
            Cmd.CommandText = "spListarQuartos";
            Cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = Cmd;
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBQuarto.DataSource = Dt;
            cBQuarto.DisplayMember = "Quarto";
            con.FecharCon();
        }

        //evento no combo box p/ selecione 1 quarto e o seu preço
        private void cBQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.AbrirCon();
            MySqlCommand CmdVerificar = new MySqlCommand();
            MySqlDataReader reader;
            CmdVerificar.Connection = con.Con;
            CmdVerificar.CommandText = "spPreencherCBQuartos";
            CmdVerificar.CommandType = CommandType.StoredProcedure;
            CmdVerificar.Parameters.AddWithValue("@Quarto", cBQuarto.Text);
            reader = CmdVerificar.ExecuteReader();

            //extraindo as informações da consulta
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Globais.valorQuarto = Convert.ToString(reader["Valor"]);
                }
                txtValorDiario.Text = Globais.valorQuarto;
            }
            con.FecharCon();
            verificarOcupacoes();

        }

        //Método p/ listar ocupações
        private void ListarOcupacoes()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = con.Con;
            Cmd.CommandText = "spListarOcupacoes";
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdReserva", "0");
            Cmd.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = Cmd;
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            gridOcupacoes.DataSource = Dt;

            con.FecharCon();

        }

        //Método de Habilitar Campos
        private void HabilitarCampos()
        {
            txtHospede.Enabled = true;
            // txtValorDiario.Enabled = true;
            txtDia.Enabled = true;
            cBAno.Enabled = true;
            cBMes.Enabled = true;
            cBQuarto.Enabled = true;
            maskTelefone.Enabled = true;
            btRemover.Enabled = true;
            btSalvar.Enabled = true;
            txtHospede.Focus();
        }

        //Método de Desabilitar Campos
        private void DesabilitarCampos()
        {
            txtHospede.Enabled = false;
            // txtValorDiario.Enabled = false;
            txtDia.Enabled = false;
            cBAno.Enabled = false;
            cBMes.Enabled = false;
            cBQuarto.Enabled = false;
            maskTelefone.Enabled = false;
            btRemover.Enabled = false;
            btSalvar.Enabled = false;
            txtHospede.Focus();
        }

        //Método de limpar campos
        private void LimparCampos()
        {
            txtHospede.Clear();
            txtDia.Text = "0";
            maskTelefone.Clear();
        }

        //Método p/ verificar os meses c/ dia 31
        private void verificarDias31()
        {
            if (cBMes.Text == "01" || cBMes.Text == "1")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "02" || cBMes.Text == "2")
            {
                panel31.Visible = false;
                panel30.Visible = false;
                panel29.Visible = false;
                Globais.diasMes = 28;


                //lógica p/ anos bissextos
                if (cBAno.Text == "2020" || cBAno.Text == "2024" || cBAno.Text == "2028")
                {
                    panel29.Visible = true;
                    Globais.diasMes = 29;
                }

            }

            if (cBMes.Text == "03" || cBMes.Text == "3")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "04" || cBMes.Text == "4")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 30;
            }

            if (cBMes.Text == "05" || cBMes.Text == "5")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "06" || cBMes.Text == "6")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 30;
            }

            if (cBMes.Text == "07" || cBMes.Text == "7")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "08" || cBMes.Text == "8")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "09" || cBMes.Text == "9")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 30;
            }

            if (cBMes.Text == "10")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

            if (cBMes.Text == "11")
            {
                panel31.Visible = false;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 30;
            }

            if (cBMes.Text == "12")
            {
                panel31.Visible = true;
                panel30.Visible = true;
                panel29.Visible = true;
                Globais.diasMes = 31;
            }

        }

        //combo box p/ verificar mes
        private void cBMes_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        //botão NOVO
        private void btNovo_Click(object sender, EventArgs e)
        {

            if (cBQuarto.Text == string.Empty)
            {
                MessageBox.Show("Cadastre antes um Quarto!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            HabilitarCampos();
            btSalvar.Enabled = true;
            btNovo.Enabled = false;
        }

        //combo box p/ verificar ano
        private void cBAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarDias31();
            verificarOcupacoes();
        }





        //Método p/ verificar os quartos que estão ocupados
        private void verificarOcupacoes()
        {
            AtualizarOcupacoes();
            string data;

            for (int i = 1; i <= Globais.diasMes; i += 1)
            {

                if (i < 10)
                {

                    data = 0 + i.ToString() + "/" + cBMes.Text + "/" + cBAno.Text;
                    //MessageBox.Show(data);
                }

                else
                {
                    data = i + "/" + cBMes.Text + "/" + cBAno.Text;
                }
                // MessageBox.Show(data);

                con.AbrirCon();
                MySqlCommand Cmd = new MySqlCommand();
                Cmd.Connection = con.Con;
                Cmd.CommandText = "spVerificarOcupacoes";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Data", Convert.ToDateTime(data));
                Cmd.Parameters.AddWithValue("@Quarto", cBQuarto.Text);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Cmd;
                DataTable Dt = new DataTable();
                da.Fill(Dt);


                if (i == 1 && Dt.Rows.Count > 0)
                {
                    panel1.BackColor = Color.Tomato;
                    panel1.Enabled = false;

                }

                if (i == 2 && Dt.Rows.Count > 0)
                {
                    panel2.BackColor = Color.Tomato;
                    panel2.Enabled = false;
                }

                if (i == 3 && Dt.Rows.Count > 0)
                {
                    panel3.BackColor = Color.Tomato;
                    panel3.Enabled = false;
                }

                if (i == 4 && Dt.Rows.Count > 0)
                {
                    panel4.BackColor = Color.Tomato;
                    panel4.Enabled = false;
                }

                if (i == 5 && Dt.Rows.Count > 0)
                {
                    panel5.BackColor = Color.Tomato;
                    panel5.Enabled = false;
                }

                if (i == 6 && Dt.Rows.Count > 0)
                {
                    panel6.BackColor = Color.Tomato;
                    panel6.Enabled = false;
                }

                if (i == 7 && Dt.Rows.Count > 0)
                {
                    panel7.BackColor = Color.Tomato;
                    panel7.Enabled = false;
                }

                if (i == 8 && Dt.Rows.Count > 0)
                {
                    panel8.BackColor = Color.Tomato;
                    panel8.Enabled = false;
                }

                if (i == 9 && Dt.Rows.Count > 0)
                {
                    panel9.BackColor = Color.Tomato;
                    panel9.Enabled = false;
                }

                if (i == 10 && Dt.Rows.Count > 0)
                {
                    panel10.BackColor = Color.Tomato;
                    panel10.Enabled = false;
                }

                if (i == 11 && Dt.Rows.Count > 0)
                {
                    panel11.BackColor = Color.Tomato;
                    panel11.Enabled = false;
                }

                if (i == 12 && Dt.Rows.Count > 0)
                {
                    panel12.BackColor = Color.Tomato;
                    panel12.Enabled = false;
                }

                if (i == 13 && Dt.Rows.Count > 0)
                {
                    panel13.BackColor = Color.Tomato;
                    panel13.Enabled = false;
                }

                if (i == 14 && Dt.Rows.Count > 0)
                {
                    panel14.BackColor = Color.Tomato;
                    panel14.Enabled = false;
                }

                if (i == 15 && Dt.Rows.Count > 0)
                {
                    panel15.BackColor = Color.Tomato;
                    panel15.Enabled = false;
                }

                if (i == 16 && Dt.Rows.Count > 0)
                {
                    panel16.BackColor = Color.Tomato;
                    panel16.Enabled = false;
                }

                if (i == 17 && Dt.Rows.Count > 0)
                {
                    panel17.BackColor = Color.Tomato;
                    panel17.Enabled = false;
                }

                if (i == 18 && Dt.Rows.Count > 0)
                {
                    panel18.BackColor = Color.Tomato;
                    panel18.Enabled = false;
                }

                if (i == 19 && Dt.Rows.Count > 0)
                {
                    panel19.BackColor = Color.Tomato;
                    panel19.Enabled = false;
                }

                if (i == 20 && Dt.Rows.Count > 0)
                {
                    panel20.BackColor = Color.Tomato;
                    panel20.Enabled = false;
                }

                if (i == 21 && Dt.Rows.Count > 0)
                {
                    panel21.BackColor = Color.Tomato;
                    panel21.Enabled = false;
                }

                if (i == 22 && Dt.Rows.Count > 0)
                {
                    panel22.BackColor = Color.Tomato;
                    panel22.Enabled = false;
                }

                if (i == 23 && Dt.Rows.Count > 0)
                {
                    panel23.BackColor = Color.Tomato;
                    panel23.Enabled = false;
                }

                if (i == 24 && Dt.Rows.Count > 0)
                {
                    panel24.BackColor = Color.Tomato;
                    panel24.Enabled = false;
                }

                if (i == 25 && Dt.Rows.Count > 0)
                {
                    panel25.BackColor = Color.Tomato;
                    panel25.Enabled = false;
                }

                if (i == 26 && Dt.Rows.Count > 0)
                {
                    panel26.BackColor = Color.Tomato;
                    panel26.Enabled = false;
                }

                if (i == 27 && Dt.Rows.Count > 0)
                {
                    panel27.BackColor = Color.Tomato;
                    panel27.Enabled = false;
                }

                if (i == 28 && Dt.Rows.Count > 0)
                {
                    panel28.BackColor = Color.Tomato;
                    panel28.Enabled = false;
                }

                if (i == 29 && Dt.Rows.Count > 0)
                {
                    panel29.BackColor = Color.Tomato;
                    panel29.Enabled = false;
                }

                if (i == 30 && Dt.Rows.Count > 0)
                {
                    panel30.BackColor = Color.Tomato;
                    panel30.Enabled = false;
                }

                if (i == 31 && Dt.Rows.Count > 0)
                {
                    panel31.BackColor = Color.Tomato;
                    panel31.Enabled = false;
                }
                con.FecharCon();

            }
        }

        //Método de atualizar ocupações
        private void AtualizarOcupacoes()
        {
            panel1.BackColor = Color.PaleGreen;
            panel1.Enabled = true;

            panel2.BackColor = Color.PaleGreen;
            panel2.Enabled = true;

            panel3.BackColor = Color.PaleGreen;
            panel3.Enabled = true;

            panel4.BackColor = Color.PaleGreen;
            panel4.Enabled = true;

            panel5.BackColor = Color.PaleGreen;
            panel5.Enabled = true;

            panel6.BackColor = Color.PaleGreen;
            panel6.Enabled = true;

            panel7.BackColor = Color.PaleGreen;
            panel7.Enabled = true;

            panel8.BackColor = Color.PaleGreen;
            panel8.Enabled = true;

            panel9.BackColor = Color.PaleGreen;
            panel9.Enabled = true;

            panel10.BackColor = Color.PaleGreen;
            panel10.Enabled = true;

            panel11.BackColor = Color.PaleGreen;
            panel11.Enabled = true;

            panel12.BackColor = Color.PaleGreen;
            panel12.Enabled = true;

            panel13.BackColor = Color.PaleGreen;
            panel13.Enabled = true;

            panel14.BackColor = Color.PaleGreen;
            panel14.Enabled = true;

            panel15.BackColor = Color.PaleGreen;
            panel15.Enabled = true;

            panel16.BackColor = Color.PaleGreen;
            panel16.Enabled = true;

            panel17.BackColor = Color.PaleGreen;
            panel17.Enabled = true;

            panel18.BackColor = Color.PaleGreen;
            panel18.Enabled = true;

            panel19.BackColor = Color.PaleGreen;
            panel19.Enabled = true;

            panel20.BackColor = Color.PaleGreen;
            panel20.Enabled = true;

            panel21.BackColor = Color.PaleGreen;
            panel21.Enabled = true;

            panel22.BackColor = Color.PaleGreen;
            panel22.Enabled = true;

            panel23.BackColor = Color.PaleGreen;
            panel23.Enabled = true;

            panel24.BackColor = Color.PaleGreen;
            panel24.Enabled = true;

            panel25.BackColor = Color.PaleGreen;
            panel25.Enabled = true;

            panel26.BackColor = Color.PaleGreen;
            panel26.Enabled = true;

            panel27.BackColor = Color.PaleGreen;
            panel27.Enabled = true;

            panel28.BackColor = Color.PaleGreen;
            panel28.Enabled = true;

            panel29.BackColor = Color.PaleGreen;
            panel29.Enabled = true;

            panel30.BackColor = Color.PaleGreen;
            panel30.Enabled = true;

            panel31.BackColor = Color.PaleGreen;
            panel31.Enabled = true;

        }

        private void cBMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            Globais.mes = Convert.ToInt32(cBMes.Text);
            verificarDias31();
            verificarOcupacoes(); //--
        }

        //Método p/ salvar as ocupações
        private void SalvarOcupacoes()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand();
            Globais.sql = "insert into TblOcupacoes(Quarto,Data,Funcionario) values(@Quarto,@Data,@Funcionario)";
            Cmd = new MySqlCommand(Globais.sql, con.Con);
            Cmd.Parameters.AddWithValue("@Quarto", cBQuarto.Text);
            Cmd.Parameters.AddWithValue("@Data", Convert.ToDateTime(Globais.dataPainel));
            Cmd.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            Cmd.ExecuteNonQuery();
            con.FecharCon();
            verificarOcupacoes();
            cBQuarto.Enabled = false;
            ListarOcupacoes();
            AtualizarTotalReservas();
        }

        private void panel3_Click(object sender, EventArgs e)
        {

            if (Globais.mes < 10)
            {
                Globais.dataPainel = label03.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label03.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void cBAno_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            verificarDias31();
            verificarOcupacoes();
        }

        //botão Remover Ocupação
        private void btRemover_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = con.Con;
            Cmd.CommandText = "spExcluirOcupacoes";
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@IdOcupacao", Globais.idOcupacao);
            Cmd.ExecuteNonQuery();
            con.FecharCon();
            verificarOcupacoes();
            AbaterTotalReservas();
            ListarOcupacoes();
        }

        //Evento no datagrid

        private void gridOcupacoes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btRemover.Enabled = true;
            Globais.idOcupacao = gridOcupacoes.CurrentRow.Cells[0].Value.ToString();
            // dataInicial = gridOcupacoes.Rows[0].Cells[1].Value.ToString();
            // dataFinal = gridOcupacoes.Rows[gridOcupacoes.Rows.Count - 1].Cells[1].Value.ToString();
        }

        //Método de autalizar as reservas
        private void AtualizarTotalReservas()
        {
            Globais.diasReserva += 1;
            txtDia.Text = Globais.diasReserva.ToString();
            Globais.valorTotal = Globais.diasReserva * Convert.ToDecimal(txtValorDiario.Text);
            lblTotal.Text = string.Format("{0:c2}", Globais.valorTotal);
        }

        //Método de abater as reservas
        private void AbaterTotalReservas()
        {
            Globais.diasReserva -= 1;
            txtDia.Text = Globais.diasReserva.ToString();
            Globais.valorTotal = Globais.diasReserva * Convert.ToDecimal(txtValorDiario.Text);
            lblTotal.Text = string.Format("{0:c2}", Globais.valorTotal);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label01.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label01.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label02.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label02.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label04.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label04.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label05.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label05.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel6_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label06.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label06.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label07.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label07.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label8.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label8.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label9.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label9.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel10_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label10.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label10.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel11_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label11.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label11.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel12_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label12.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label12.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel13_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label13.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label13.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel14_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label14.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label14.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel15_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label15.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label15.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel16_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label16.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label16.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel17_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label17.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label17.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel18_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label18.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label18.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel19_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label19.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label19.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel20_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label20.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label20.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel21_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label21.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label21.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel22_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label22.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label22.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel23_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label23.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label23.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel24_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label24.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label24.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel25_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label25.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label25.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel26_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label26.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label26.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel27_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label27.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label27.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel28_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label28.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label28.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel29_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label29.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label29.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel30_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label30.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label30.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void panel31_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label31.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label31.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        //Evento de click nas labels
        private void label01_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label01.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label01.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label02_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label02.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label02.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label03_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label03.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label03.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label04_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label04.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label04.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label05_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label05.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label05.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label06_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label06.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label06.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label07_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label07.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label07.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label8.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label8.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label9.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label9.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label10.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label10.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label11.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label11.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label12.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label12.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label13.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label13.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label14.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label14.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label15.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label15.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label16.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label16.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label17.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label17.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label18.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label18.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label19.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label19.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label20.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label20.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label21.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label21.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label22.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label22.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label23_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label23.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label23.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label24_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label24.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label24.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label25_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label25.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label25.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label26_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label26.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label26.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label27_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label27.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label27.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label28_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label28.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label28.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label29_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label29.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label29.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label30_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label30.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label30.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void label31_Click(object sender, EventArgs e)
        {
            if (Globais.mes < 10)
            {
                Globais.dataPainel = label31.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            else
            {
                Globais.dataPainel = label31.Text + "/" + cBMes.Text + "/" + cBAno.Text;

            }

            SalvarOcupacoes();

        }

        private void FrmReservas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globais.valorTotal != 0)
            {
                MessageBox.Show("A reserva possui datas selecionadas,remova as datas antes de sair ou salvar a reserva!", "ATENÇÃO!");
                e.Cancel = true;
            }
        }

        //botão de SALVAR AS RESERVAS
        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (txtHospede.Text == string.Empty)
            {
                MessageBox.Show("Preencha o campo Hospede!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHospede.Focus();
                return;
            }

            if (Globais.valorTotal > 0)
            {
                Globais.dataInicial = gridOcupacoes.Rows[0].Cells[1].Value.ToString();
                Globais.dataFinal = gridOcupacoes.Rows[gridOcupacoes.Rows.Count - 1].Cells[1].ToString();

                var result = MessageBox.Show("Deseja confirmar as reservas nas datas do dia" + Convert.ToDateTime(Globais.dataInicial).ToString("dd/MM/yyyy") + "até" + Convert.ToDateTime(Globais.dataFinal).ToString("dd/MM/yyyy") + " ?", "Confirmar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    con.AbrirCon();
                    MySqlCommand Cmd = new MySqlCommand();
                    Cmd.Connection = con.Con;
                    Cmd.CommandText = "spInserirReservas";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Hospede", txtHospede.Text);
                    Cmd.Parameters.AddWithValue("@Quarto", cBQuarto.Text);
                    Cmd.Parameters.AddWithValue("@Valor", Globais.valorTotal);
                    Cmd.Parameters.AddWithValue("@Telefone", maskTelefone.Text);
                    Cmd.Parameters.AddWithValue("@Dias", txtDia.Text);
                    Cmd.Parameters.AddWithValue("@dataEntrada", Convert.ToDateTime(Globais.dataInicial));
                    Cmd.Parameters.AddWithValue("@dataSaida", Convert.ToDateTime(Globais.dataFinal));
                    Cmd.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                    Cmd.ExecuteNonQuery();
                    con.FecharCon();

                    //recuperar o Id da Reserva
                    con.AbrirCon();
                    MySqlCommand CmdVerificar = new MySqlCommand();
                    CmdVerificar.Connection = con.Con;
                    CmdVerificar.CommandText = "spRecuperarUltimoIdReserva";
                    CmdVerificar.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader;
                    reader = CmdVerificar.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //extraindo informações da consulta
                        while (reader.Read())
                        {
                            Globais.ultimoIdReserva = Convert.ToString(reader["IdReserva"]);
                        }
                    }

                    //Relacionar a ocupação com a reserva
                    con.AbrirCon();
                    MySqlCommand Cmd1 = new MySqlCommand();
                    Cmd1.Connection = con.Con;
                    Cmd1.CommandText = "spRelacionarOcupacaoReserva";
                    Cmd1.CommandType = CommandType.StoredProcedure;
                    Cmd1.Parameters.AddWithValue("@IdReserva", "0");
                    Cmd1.Parameters.AddWithValue("@Id_Reserva", Globais.ultimoIdReserva);
                    Cmd1.ExecuteNonQuery();

                    con.FecharCon();

                    MessageBox.Show("Reserva efetuada com sucesso!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btNovo.Enabled = true;
                    btSalvar.Enabled = false;
                    LimparCampos();
                    DesabilitarCampos();
                    ListarOcupacoes();
                    Globais.valorTotal = 0;
                    lblTotal.Text = "0";
                    txtDia.Text = "0";
                    Globais.diasReserva = 0;


                }
                else
                {
                    MessageBox.Show("A Reserva não possui datas!");
                }
            }
        }
    }
}
