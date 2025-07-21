using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Relatorios;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmNovoServico : Form
    {
        //variáveis globais
        Conexao con = new Conexao();


        public FrmNovoServico()
        {
            InitializeComponent();
        }

        private void FrmNovoServico_Load(object sender, EventArgs e)
        {
            HabilitarCampos(false);
            ListarNovosServicos();
            dtBuscarServicos.Value = DateTime.Today;
            CarregarCBoxServicos();
            CarregarCBquartos();
        }

        //MÉTODOS
        private void MsgOk(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MsgErro(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void LimparCampos()
        {
            txtHospede.Clear();
            txtQuant.Clear();
            txtValor.Clear();

        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {
                txtHospede.Enabled = true;
                txtQuant.Enabled = true;
                txtValor.Enabled = true;
                cBQuartos.Enabled = true;
                cBServicos.Enabled = true;
                btAddHospedes.Enabled = true;
                txtQuant.Focus();
            }
            else
            {
                txtHospede.Enabled = false;
                txtQuant.Enabled = false;
                txtValor.Enabled = false;
                cBQuartos.Enabled = false;
                cBServicos.Enabled = false;
                btAddHospedes.Enabled = false;
                txtQuant.Focus();
            }
        }

        //Carregar ComboBox de serviços
        private void CarregarCBoxServicos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();

                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spListarServicos";
                Cmd3.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Cmd3;
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                cBServicos.DataSource = Dt;
                cBServicos.DisplayMember = "Servico";

                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao carregar os serviços: " + ex.Message);
            }
        }

        //Carregar combobox de Quartos
        private void CarregarCBquartos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd4 = new MySqlCommand();

                Cmd4.Connection = con.Con;
                Cmd4.CommandText = "spListarQuartos";
                Cmd4.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Cmd4;
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                cBQuartos.DataSource = Dt;
                cBQuartos.DisplayMember = "Quarto";
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao carregar os quartos: " + ex.Message);
            }
        }


        //Método Listar serviços
        private void ListarNovosServicos()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd0 = new MySqlCommand();

                Cmd0.Connection = con.Con;
                Cmd0.CommandText = "spListarNovosServicos";
                Cmd0.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = Cmd0;
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                gridNovoServico.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao listar serviços: " + ex.Message);
            }
        }

        //BOTÕES

        //botão NOVO
        private void BtNovo_Click(object sender, EventArgs e)
        {
            if (cBServicos.Text == string.Empty)
            {
                MsgErro("È preciso cadastrar um Serviço!");
                Close();
            }

            if (cBQuartos.Text == string.Empty)
            {
                MsgErro("È preciso cadastrar um Quarto!");
                Close();
            }
            HabilitarCampos(true);
            btSalvar.Enabled = true;
            btNovo.Enabled = false;
        }

        //botão SALVAR
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtHospede.Text == string.Empty)
            {
                MsgErro("Insira um Hóspede!");
                btAddHospedes.Focus();
                return;
            }
            if (txtQuant.Text == string.Empty)
            {
                MsgErro("Insira uma quantidade!");
                txtQuant.Focus();
                return;
            }
            if (txtValor.Text == string.Empty)
            {
                MsgErro("Insira o valor do serviço!");
                txtValor.Focus();
                return;
            }

            //Cód p/ salvar
            con.AbrirCon();
            MySqlCommand Cmd1 = new MySqlCommand();
            Cmd1.Connection = con.Con;
            Cmd1.CommandText = "spInserirNovosServicos";
            Cmd1.CommandType = CommandType.StoredProcedure;
            Cmd1.Parameters.AddWithValue("@Hospede", txtHospede.Text);
            Cmd1.Parameters.AddWithValue("@Servico", cBServicos.Text);
            Cmd1.Parameters.AddWithValue("@Quarto", cBQuartos.Text);
            Cmd1.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtQuant.Text) * Convert.ToDecimal(txtValor.Text));
            Cmd1.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);

            Cmd1.ExecuteNonQuery();
            con.FecharCon();

            //recuperar ultimo Id do serviço
            MySqlCommand CmdVerificar = new MySqlCommand();
            con.AbrirCon();
            CmdVerificar.Connection = con.Con;
            CmdVerificar.CommandText = "spRecuperarUltimoIdServico";
            CmdVerificar.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader;
            reader = CmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //extraindo informações da consulta do login
                while (reader.Read())
                {
                    Globais.ultimoIdServico = Convert.ToString(reader["IdNovoServico"]);
                }
            }

            //salvar o serviço na tabela de movimentações
            con.AbrirCon();
            MySqlCommand Cmd2 = new MySqlCommand();
            Cmd2.Connection = con.Con;
            Cmd2.CommandText = "spInserirServicosMovimentacoes";
            Cmd2.CommandType = CommandType.StoredProcedure;
            Cmd2.Parameters.AddWithValue("@Tipo", "Entrada");
            Cmd2.Parameters.AddWithValue("@Movimento", "Servico");
            Cmd2.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text) * Convert.ToDecimal(txtQuant.Text));
            Cmd2.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            Cmd2.Parameters.AddWithValue("@Id_Movimento", Globais.ultimoIdServico);
            Cmd2.ExecuteNonQuery();
            con.FecharCon();

            MsgOk("Serviço salvo com sucesso!");
            btNovo.Enabled = true;
            btSalvar.Enabled = false;
            LimparCampos();
            HabilitarCampos(false);
            ListarNovosServicos();

        }

        //botão EDITAR
        private void BtEditar_Click(object sender, EventArgs e)
        {

        }

        //botão EXCLUIR
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (Globais.cargoUsuario == "Gerente")
            {
                var result = MessageBox.Show("Deseja excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    try
                    {
                        con.AbrirCon();
                        MySqlCommand Cmd5 = new MySqlCommand();
                        Cmd5.Connection = con.Con;
                        Cmd5.CommandText = "spExcluirNovosServicos";
                        Cmd5.CommandType = CommandType.StoredProcedure;
                        Cmd5.Parameters.AddWithValue("@IdNovoServico", Globais.idNovoServico);
                        Cmd5.ExecuteNonQuery();
                        con.FecharCon();
                        MsgOk("Registro excluido com sucesso! ");

                        //exclusão do serviço no Movimento
                        con.AbrirCon();
                        MySqlCommand Cmd6 = new MySqlCommand();
                        Cmd6.Connection = con.Con;
                        Cmd6.CommandText = "spExcluirNovoServicoMovimentacao";
                        Cmd6.CommandType = CommandType.StoredProcedure;
                        Cmd6.Parameters.AddWithValue("@Id_Movimento", Globais.idNovoServico);
                        Cmd6.Parameters.AddWithValue("@Movimento", "Servico");
                        Cmd6.ExecuteNonQuery();
                        con.FecharCon();

                        btNovo.Enabled = true;
                        btExcluir.Enabled = false;
                        LimparCampos();
                        HabilitarCampos(false);
                        ListarNovosServicos();

                    }
                    catch (Exception ex)
                    {

                        MsgErro("Erro ao excluir servico: " + ex.Message);
                    }

                }
            }
            else
            {
                MsgErro("Somente um Gerente pode excluir um serviço!");
            }
        }

        //botão HOSPEDE
        //buscando o hospede através do FrmHospede
        private void BtAddHospedes_Click(object sender, EventArgs e)
        {
            Globais.chamadaHospedes = "hospedes";
            FrmHospedes frmHospedes = new FrmHospedes();
            frmHospedes.Show();
        }

        private void FrmNovoServico_Activated(object sender, EventArgs e)
        {
            txtHospede.Text = Globais.nomeHospede;
        }

        //evento p/ selecionar os dados do comboBox de Serviços
        private void CBServicos_SelectedValueChanged(object sender, EventArgs e)
        {
            con.AbrirCon();

            MySqlCommand CmdVerificar = new MySqlCommand();
            CmdVerificar.Connection = con.Con;
            CmdVerificar.CommandText = "spListarServicosValor";
            CmdVerificar.CommandType = CommandType.StoredProcedure;
            CmdVerificar.Parameters.AddWithValue("@Servico", cBServicos.Text);

            MySqlDataReader reader;
            reader = CmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Globais.valorServico = Convert.ToString(reader["Valor"]);

                }
                txtValor.Text = Globais.valorServico;
            }

            con.FecharCon();
        }

        //Grid
        private void GridNovoServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btExcluir.Enabled = true;
            btSalvar.Enabled = false;
            btRelatorios.Enabled = true;
            HabilitarCampos(true);

            Globais.idNovoServico = gridNovoServico.CurrentRow.Cells[0].Value.ToString();
            Globais.idNovoServico = Globais.idNovoServico;
        }

        //botão RELATÓRIO
        private void BtRelatorios_Click(object sender, EventArgs e)
        {
            btRelatorios.Enabled = false;
            FrmRelComprovanteServicos frm = new FrmRelComprovanteServicos();
            frm.Show();
        }
    }
}
