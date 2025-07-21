using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmHospedes : Form
    {
        Conexao con = new Conexao();

        public FrmHospedes()
        {
            InitializeComponent();
        }

        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            ListarHospedes();
            rBNome.Checked = true;
        }

        //Métodos
        private void MsgOk(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MsgErro(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {
                txtNome.Enabled = true;
                txtEndereco.Enabled = true;
                maskCpf.Enabled = true;
                maskTelefone.Enabled = true;
            }
            else
            {
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                maskCpf.Enabled = false;
                maskTelefone.Enabled = false;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEndereco.Clear();
            maskTelefone.Clear();
            maskCpf.Clear();
        }

        //Método de listar hóspede
        private void ListarHospedes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd0 = new MySqlCommand();
                Cmd0.Connection = con.Con;
                Cmd0.CommandText = "spListarHospedes";
                Cmd0.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd0;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridHospedes.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao listar hóspedes: " + ex.Message);
            }
        }

        //Método de buscar por nome
        private void BuscarNomeHospede()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd1 = new MySqlCommand();
                Cmd1.Connection = con.Con;
                Cmd1.CommandText = "spBuscarNomeHospede";
                Cmd1.CommandType = CommandType.StoredProcedure;
                Cmd1.Parameters.AddWithValue("@Nome", txtBuscarNome.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd1;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridHospedes.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao buscar pelo nome: " + ex.Message);
            }
        }

        //Método de buscar pelo CPF
        private void BuscarCPF()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd2 = new MySqlCommand();
                Cmd2.Connection = con.Con;
                Cmd2.CommandText = "spBuscarCPF";
                Cmd2.CommandType = CommandType.StoredProcedure;
                Cmd2.Parameters.AddWithValue("@CPF", maskBuscarCPF.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd2;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridHospedes.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao buscar por CPF: " + ex.Message);
            }
        }

        //Método p/ salvar hospedes
        //Método não foi usado
        private void SalvarHospedes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();
                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spInserirHospedes";
                Cmd3.CommandType = CommandType.StoredProcedure;
                Cmd3.Parameters.AddWithValue("@Nome", txtNome.Text);
                Cmd3.Parameters.AddWithValue("@CPF", maskCpf.Text);
                Cmd3.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                Cmd3.Parameters.AddWithValue("@Tel", maskTelefone.Text);
                Cmd3.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd3.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MsgErro("Erro ao salvar hospedes: " + ex.Message);
            }
        }

        //Método p/ verificar se existe o CPF do hóspede já está cadastrado
        //Método não foi usado
        private void VerificarCPF()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand CmdVerificar = new MySqlCommand();
                CmdVerificar.Connection = con.Con;
                CmdVerificar.CommandText = "spVerificarCPF";
                CmdVerificar.CommandType = CommandType.StoredProcedure;
                CmdVerificar.Parameters.AddWithValue("@CPF", maskCpf.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = CmdVerificar;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    MsgErro("CPF já registrado ! Erro ao salvar!");
                    maskCpf.Clear();
                    maskCpf.Focus();
                    return;
                }
                CmdVerificar.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {

                MsgErro("Erro ao verificar o CPF do hóspede: " + ex.Message);
            }
        }

        //Método p/ EXCLUIR hospedes
        private void ExcluirHospedes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd5 = new MySqlCommand();
                Cmd5.Connection = con.Con;
                Cmd5.CommandText = "spExcluirHospedes";
                Cmd5.CommandType = CommandType.StoredProcedure;
                Cmd5.Parameters.AddWithValue("@IdHospede", Globais.idHospede);
                Cmd5.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao excluir hospedes: " + ex.Message);
            }
        }

        //**********************************************************
        //botões

        //botão NOVO
        private void BtNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            btSalvar.Enabled = true;
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
        }

        //botão SALVAR
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                MsgErro("Preencha o campo Nome!");
                txtNome.Focus();
                return;
            }
            if (maskCpf.Text == "   .   .   -")
            {
                MsgErro("Preencha o campo CPF!");
                maskCpf.Focus();
                return;
            }

            //Cód p/ salvar
            con.AbrirCon();
            MySqlCommand Cmd3 = new MySqlCommand();
            Cmd3.Connection = con.Con;
            Cmd3.CommandText = "spInserirHospedes";
            Cmd3.CommandType = CommandType.StoredProcedure;
            Cmd3.Parameters.AddWithValue("@Nome", txtNome.Text);
            Cmd3.Parameters.AddWithValue("@CPF", maskCpf.Text);
            Cmd3.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
            Cmd3.Parameters.AddWithValue("@Tel", maskTelefone.Text);
            Cmd3.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);

            //Cód p/ verificar se o cpf já existe
            con.AbrirCon();
            MySqlCommand CmdVerificar = new MySqlCommand();
            CmdVerificar.Connection = con.Con;
            CmdVerificar.CommandText = "spVerificarCPF";
            CmdVerificar.CommandType = CommandType.StoredProcedure;
            CmdVerificar.Parameters.AddWithValue("@CPF", maskCpf.Text);
            MySqlDataAdapter Da = new MySqlDataAdapter();
            Da.SelectCommand = CmdVerificar;
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                MsgErro("CPF já registrado ! Erro ao salvar!");
                maskCpf.Clear();
                maskCpf.Focus();
                return;
            }
            Cmd3.ExecuteNonQuery();
            con.FecharCon();

            LimparCampos();
            HabilitarCampos(true);
            ListarHospedes();
            MsgOk("Registro salvo com sucesso!");
        }

        //botão EDITAR
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty)
            {
                MsgErro("Preencha o campo Nome!");
                txtNome.Focus();
                return;
            }

            if (maskCpf.Text == "   .   .   -")
            {
                MsgErro("Preencha o campo CPF!");
                maskCpf.Focus();
                return;
            }

            //Cód p/ EDITAR
            con.AbrirCon();
            MySqlCommand Cmd4 = new MySqlCommand();
            Cmd4.Connection = con.Con;
            Cmd4.CommandText = "spAlterarHospedes";
            Cmd4.CommandType = CommandType.StoredProcedure;
            Cmd4.Parameters.AddWithValue("@Nome", txtNome.Text);
            Cmd4.Parameters.AddWithValue("@CPF", maskCpf.Text);
            Cmd4.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
            Cmd4.Parameters.AddWithValue("@Tel", maskTelefone.Text);
            Cmd4.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            Cmd4.Parameters.AddWithValue("@IdHospede", Globais.idHospede);

            //Cód p/ verificar se o CPF já existe no banco
            if (maskCpf.Text != Globais.cpfAntigo)
            {
                con.AbrirCon();
                MySqlCommand CmdVerificar = new MySqlCommand();
                CmdVerificar.Connection = con.Con;
                CmdVerificar.CommandText = "spVerificarCPF";
                CmdVerificar.CommandType = CommandType.StoredProcedure;
                CmdVerificar.Parameters.AddWithValue("@CPF", maskCpf.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = CmdVerificar;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    MsgErro("CPF já registrado !");
                    maskCpf.Clear();
                    maskCpf.Focus();
                    return;
                }
            }

            Cmd4.ExecuteNonQuery();
            con.FecharCon();

            btNovo.Enabled = true;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            LimparCampos();
            HabilitarCampos(false);
            ListarHospedes();
            MsgOk("Registro alterado com sucesso!");
        }

        //botão EXCLUIR
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ExcluirHospedes();

                btNovo.Enabled = true;
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                LimparCampos();
                HabilitarCampos(false);
                MsgOk("Registro excluido com sucesso!");
                ListarHospedes();
            }
        }

        //grid
        private void GridHospedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btSalvar.Enabled = false;
            HabilitarCampos(true);

            Globais.idHospede = gridHospedes.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridHospedes.CurrentRow.Cells[1].Value.ToString();
            maskCpf.Text = gridHospedes.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = gridHospedes.CurrentRow.Cells[3].Value.ToString();
            maskTelefone.Text = gridHospedes.CurrentRow.Cells[4].Value.ToString();

            //linha p/ comparar se o cpf já é cadastrado
            Globais.cpfAntigo = gridHospedes.CurrentRow.Cells[2].Value.ToString();
        }

        private void RBNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            maskBuscarCPF.Visible = false;

            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
        }

        private void RBBuscarCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            maskBuscarCPF.Visible = true;

            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
        }

        //evento do txt p/ buscar hospede por nome
        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeHospede();
        }

        //evento do txt p/ buscar hospede por CPF
        private void MaskBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            if (maskBuscarCPF.Text == "   .   .   -")
            {
                ListarHospedes();
            }

            else
            {
                BuscarCPF();
            }
        }

        //evento que seleciona o hospede no FrmHospedes e passa p/ o FrmNovosServiços
        private void GridHospedes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Globais.chamadaHospedes == "hospedes")
            {
                Globais.nomeHospede = gridHospedes.CurrentRow.Cells[1].Value.ToString();
                Close();
            }
        }
    }
}
