using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Repositories.usuarioDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmUsuarios : Form
    {
        public string UsuarioAntigo;
        private usuarioDAO _dao = new usuarioDAO();

        public FrmUsuarios()
        {
            InitializeComponent();
            PreencherCBox();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            EnableHelper.SetEnabled(false, txtCod, txtNome, txtUsuario, txtSenha, cBCargos);
        }

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtNome, txtUsuario, txtSenha, cBCargos, btEditar, btExcluir, btSalvar);
        }

        //Método de carregar o combo box de cargos
        private void PreencherCBox()
        {

            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand
            {
                Connection = con.Con,
                CommandText = "spListarCargos",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = Cmd
            };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBCargos.DataSource = Dt;
            cBCargos.ValueMember = "IdCargo";
            cBCargos.DisplayMember = "Cargo";
        }

        // Listar usuários na grid
        private void ListarUsuarios()
        {
            try
            {
                gridUsuarios.DataSource = _dao.ListarUsuarios();
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao Listar Usuários: " + ex.Message);
            }
        }

        // Buscar usuários por nome
        private void BuscarUsuarioNome()
        {
            try
            {
                gridUsuarios.DataSource = _dao.BuscarUsuarioPorNome(txtBuscarNome.Text);
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao Buscar: " + ex.Message);
            }
        }

        string op = "";

        //Botão Novo
        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtNome.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtNome, txtUsuario, txtSenha);

            EnableHelper.SetEnabled(true, txtNome, txtUsuario, txtSenha, cBCargos);

            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        //Botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o nome do Usuário!");
                ControlHelper.ClearAndFocus(txtNome, txtNome);
                return;
            }

            // Nova validação: máximo de 6 caracteres
            if (txtSenha.Text.Length > 6)
            {
                ErroMensageService("A senha deve ter no máximo 6 dígitos!");
                ControlHelper.ClearAndFocus(txtSenha, txtSenha);
                return;
            }
            // Nova validação: apenas números
            if (!txtSenha.Text.All(char.IsDigit))
            {
                ErroMensageService("A senha deve conter somente números!");
                ControlHelper.ClearAndFocus(txtSenha, txtSenha);
                return;
            }


            if (txtUsuario.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o login do Usuário!");
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario);
                return;
            }
            if (txtSenha.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira a senha do Usuário!");
                ControlHelper.ClearAndFocus(txtSenha, txtSenha);
                return;
            }
            if (_dao.ExisteUsuario(txtUsuario.Text))
            {
                ErroMensageService("Usuário já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario);
                return;
            }

            // NOVA VERIFICAÇÃO: usuário iguais já cadastrados
            if (_dao.ExisteUsuario(txtUsuario.Text))
            {
                ErroMensageService("Usuário já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario);
                return;
            }

            // NOVA VERIFICAÇÃO: senha já cadastrada para outro usuário
            if (_dao.ExisteSenha(txtSenha.Text))
            {
                ErroMensageService("Esta senha já está sendo utilizada por outro usuário. Por favor, escolha uma senha diferente!");
                ControlHelper.ClearAndFocus(txtSenha, txtSenha);
                return;
            }

            try
            {
                _dao.InserirUsuario(
                    txtNome.Text,
                    cBCargos.Text,
                    txtUsuario.Text,
                    txtSenha.Text,
                    DateTime.Now
                );

                ControlHelper.ClearAndFocus(txtCod, txtNome, txtUsuario, txtSenha);

                EnableHelper.SetEnabled(false, txtNome, txtUsuario, txtSenha, cBCargos);

                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarUsuarios();
                SucessoMensageService.ShowSuccess("Usuário salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        //Botão Editar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtNome);
                return;
            }
            if (txtUsuario.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtUsuario);
                return;
            }

            try
            {
                _dao.EditarUsuario(
                    Convert.ToInt32(txtCod.Text),
                    txtNome.Text,
                    cBCargos.Text,
                    txtUsuario.Text,
                    txtSenha.Text
                );

                ControlHelper.ClearAndFocus(txtCod, txtNome, txtUsuario, txtSenha);

                EnableHelper.SetEnabled(false, txtNome, txtUsuario, txtSenha, cBCargos);

                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarUsuarios();
                SucessoMensageService.ShowSuccess("Usuário alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para excluir!");
                txtNome.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirUsuario(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtNome, txtUsuario, txtSenha);
                HabilitarCampos(true);
                ListarUsuarios();
                SucessoMensageService.ShowSuccess("Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuarioNome();
        }

        private void GridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableHelper.SetEnabled(true, txtNome, txtUsuario, txtSenha, cBCargos);
            EnableHelper.SetEnabled(false, txtCod); // Id desabilitado

            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            txtCod.Text = gridUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridUsuarios.CurrentRow.Cells[1].Value.ToString();
            cBCargos.Text = gridUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = gridUsuarios.CurrentRow.Cells[3].Value.ToString();
            txtSenha.Text = gridUsuarios.CurrentRow.Cells[4].Value.ToString();
        }

        //Evento do teclado
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite somente dígitos e teclas de controle (Backspace etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // Limita a 6 caracteres
            if (txtSenha.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
