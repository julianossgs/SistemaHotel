using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Repositories.reservaDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmReservas : Form
    {
        private ReservaDAO _reservaDAO = new ReservaDAO();
        private Conexao con = new Conexao();

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

            for (int i = 1; i <= 31; i++)
            {
                var nomeLabel = $"label{i:D2}";
                var nomePanel = $"panel{i}";

                var label = Controls.Find(nomeLabel, true).FirstOrDefault() as Label;
                var panel = Controls.Find(nomePanel, true).FirstOrDefault() as Panel;

                if (label != null) label.Click += Dia_Click;
                if (panel != null) panel.Click += Dia_Click;
            }
        }

        private void CarregarComboBox()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand("spListarQuartos", con.Con)
            {
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter(Cmd);
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBQuarto.DataSource = Dt;
            cBQuarto.DisplayMember = "Quarto";
            con.FecharCon();
        }

        private void Dia_Click(object sender, EventArgs e)
        {
            if (sender is Control controle)
            {
                string textoDia = controle is Label ? controle.Text : string.Empty;

                if (controle is Panel panel && panel.Controls.Count > 0)
                {
                    var labelFilho = panel.Controls[0] as Label;
                    if (labelFilho != null)
                        textoDia = labelFilho.Text;
                }

                if (!string.IsNullOrEmpty(textoDia))
                {
                    string dia = textoDia.PadLeft(2, '0');
                    string mes = cBMes.Text.PadLeft(2, '0');
                    string ano = cBAno.Text;
                    Globais.dataPainel = $"{dia}/{mes}/{ano}";
                    SalvarOcupacoes();
                }
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHospede.Text))
            {
                MessageBox.Show("Preencha o campo Hospede!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHospede.Focus();
                return;
            }

            if (Globais.valorTotal <= 0)
            {
                MessageBox.Show("A Reserva não possui datas!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Globais.dataInicial = gridOcupacoes.Rows[0].Cells[1].Value.ToString();
            Globais.dataFinal = gridOcupacoes.Rows[gridOcupacoes.Rows.Count - 1].Cells[1].ToString();

            var result = MessageBox.Show(
                $"Deseja confirmar as reservas de {Convert.ToDateTime(Globais.dataInicial):dd/MM/yyyy} até {Convert.ToDateTime(Globais.dataFinal):dd/MM/yyyy}?",
                "Confirmar Reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int idReserva = _reservaDAO.InserirReserva(
                    txtHospede.Text,
                    maskTelefone.Text,
                    Convert.ToDateTime(Globais.dataInicial),
                    Convert.ToDateTime(Globais.dataFinal),
                    Convert.ToInt32(txtDia.Text),
                    cBQuarto.Text,
                    Globais.valorTotal,
                    Globais.nomeUsuario
                );

                _reservaDAO.RelacionarOcupacaoReserva(0, idReserva);

                MessageBox.Show("Reserva efetuada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetarTelaAposSalvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar reserva: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetarTelaAposSalvar()
        {
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



        private void SalvarOcupacoes()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand("INSERT INTO TblOcupacoes (Quarto, Data, Funcionario) VALUES (@pQuarto, @pData, @pFuncionario)", con.Con);
            Cmd.Parameters.AddWithValue("@pQuarto", cBQuarto.Text);
            Cmd.Parameters.AddWithValue("@pData", Convert.ToDateTime(Globais.dataPainel));
            Cmd.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
            Cmd.ExecuteNonQuery();
            con.FecharCon();

            verificarOcupacoes();
            cBQuarto.Enabled = false;
            ListarOcupacoes();
            AtualizarTotalReservas();
        }

        private void AtualizarTotalReservas()
        {
            Globais.diasReserva++;
            txtDia.Text = Globais.diasReserva.ToString();
            Globais.valorTotal = Globais.diasReserva * Convert.ToDecimal(txtValorDiario.Text);
            lblTotal.Text = string.Format("{0:c2}", Globais.valorTotal);
        }

        private void verificarDias31()
        {
            int mes = int.Parse(cBMes.Text);
            int ano = int.Parse(cBAno.Text);
            int[] mesesCom31 = { 1, 3, 5, 7, 8, 10, 12 };

            panel31.Visible = mesesCom31.Contains(mes);
            panel30.Visible = mes != 2;
            panel29.Visible = mes == 2 && DateTime.IsLeapYear(ano);

            // Substituindo switch expression por if/else
            if (mes == 2)
            {
                Globais.diasMes = DateTime.IsLeapYear(ano) ? 29 : 28;
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                Globais.diasMes = 30;
            }
            else
            {
                Globais.diasMes = 31;
            }
        }


        private void verificarOcupacoes()
        {
            AtualizarOcupacoes();

            for (int i = 1; i <= Globais.diasMes; i++)
            {
                string data = new DateTime(int.Parse(cBAno.Text), int.Parse(cBMes.Text), i).ToString("dd/MM/yyyy");

                con.AbrirCon();
                MySqlCommand Cmd = new MySqlCommand("spVerificarOcupacoes", con.Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("@pData", Convert.ToDateTime(data));
                Cmd.Parameters.AddWithValue("@pQuarto", cBQuarto.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(Cmd);
                DataTable Dt = new DataTable();
                da.Fill(Dt);

                if (Dt.Rows.Count > 0)
                {
                    var panel = Controls.Find($"panel{i}", true).FirstOrDefault() as Panel;
                    if (panel != null)
                    {
                        panel.BackColor = Color.Tomato;
                        panel.Enabled = false;
                    }
                }
                con.FecharCon();
            }
        }

        private void AtualizarOcupacoes()
        {
            for (int i = 1; i <= 31; i++)
            {
                var panel = Controls.Find($"panel{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    panel.BackColor = Color.PaleGreen;
                    panel.Enabled = true;
                }
            }
        }

        private void ListarOcupacoes()
        {
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand("spListarOcupacoes", con.Con)
            {
                CommandType = CommandType.StoredProcedure
            };
            Cmd.Parameters.AddWithValue("@pIdReserva", "0");
            Cmd.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter(Cmd);
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            gridOcupacoes.DataSource = Dt;
            con.FecharCon();
        }

        private void HabilitarCampos()
        {
            txtHospede.Enabled = true;
            txtDia.Enabled = true;
            cBAno.Enabled = true;
            cBMes.Enabled = true;
            cBQuarto.Enabled = true;
            maskTelefone.Enabled = true;
            btRemover.Enabled = true;
            btSalvar.Enabled = true;
            txtHospede.Focus();
        }

        private void DesabilitarCampos()
        {
            txtHospede.Enabled = false;
            txtDia.Enabled = false;
            cBAno.Enabled = false;
            cBMes.Enabled = false;
            cBQuarto.Enabled = false;
            maskTelefone.Enabled = false;
            btRemover.Enabled = false;
            btSalvar.Enabled = false;
            txtHospede.Focus();
        }

        private void LimparCampos()
        {
            txtHospede.Clear();
            txtDia.Text = "0";
            maskTelefone.Clear();
        }

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

        //private void btNovo_Click(object sender, EventArgs e)
        //{

        //}
    }
}
