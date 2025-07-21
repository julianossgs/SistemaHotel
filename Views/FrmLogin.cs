using SistemaHotel.Repositories.loginDAO;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;


namespace SistemaHotel.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }


        private void BtAcesso_Click(object sender, EventArgs e)
        {
            // Validação dos campos de texto (frontend)
            if (txtUsuario.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Informe o Nome do Usuário!");
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario, txtSenha);
                return;
            }
            if (txtSenha.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Informe a Senha!");
                ControlHelper.ClearAndFocus(txtSenha, txtUsuario, txtSenha);
                return;
            }

            // Acesso ao banco via DAO
            loginDAO dao = new loginDAO();
            var resultado = dao.VerificarLogin(txtUsuario.Text, txtSenha.Text);

            if (resultado.sucesso)
            {
                Globais.nomeUsuario = resultado.nome;
                Globais.cargoUsuario = resultado.cargo;

                ErroMensageService.ShowError("BEM VINDO  " + Globais.nomeUsuario);
                FrmPrincipal frm = new FrmPrincipal();
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario, txtSenha);
                ControlHelper.ClearAndFocus(txtSenha, txtUsuario, txtSenha);
                this.Hide();
                frm.Show();
            }
            else
            {
                ErroMensageService.ShowError("Erro ao acessar! Usuário e Senha inválidos");
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario, txtSenha);
                ControlHelper.ClearAndFocus(txtSenha, txtUsuario, txtSenha);
                ControlHelper.ClearAndFocus(txtUsuario, txtUsuario, txtSenha);
                return;
            }
        }



        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        //Código p/ acionar a tecla enter nos comandos do formulário
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginDAO dao = new loginDAO();
                var resultado = dao.VerificarLogin(txtUsuario.Text, txtSenha.Text);
            }
        }

    }
}
