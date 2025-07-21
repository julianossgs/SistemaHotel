using SistemaHotel.Repositories.quartoDAO;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmQuartos : Form
    {

        //Conexao con = new Conexao();

        private quartoDAO _dao = new quartoDAO();

        public FrmQuartos()
        {
            InitializeComponent();
        }

        private void FrmQuartos_Load(object sender, EventArgs e)
        {
            ListarQuartos();
            EnableHelper.SetEnabled(false, txtCod, txtQuarto, txtPessoas, txtDescricao, txtValor);
        }

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtQuarto, txtPessoas, txtDescricao, txtValor, btEditar, btExcluir, btSalvar);
        }

        // Listar quartos na grid
        private void ListarQuartos()
        {
            try
            {
                gridQUARTOS.DataSource = _dao.ListarQuartos();
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao Listar Quartos: " + ex.Message);
            }
        }

        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtQuarto.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtQuarto, txtPessoas, txtDescricao, txtValor);

            EnableHelper.SetEnabled(true, txtQuarto, txtPessoas, txtDescricao, txtValor);

            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        //Botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o nome/identificação do Quarto!");
                ControlHelper.ClearAndFocus(txtQuarto, txtQuarto);
                return;
            }
            if (txtPessoas.Text.Trim() == string.Empty)
            {
                ErroMensageService("Informe a quantidade de pessoas do quarto!");
                ControlHelper.ClearAndFocus(txtPessoas, txtPessoas);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService("Informe o valor do quarto corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }
            if (_dao.ExisteQuarto(txtQuarto.Text))
            {
                ErroMensageService("Quarto já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtQuarto, txtQuarto);
                return;
            }

            try
            {
                _dao.InserirQuarto(
                    txtQuarto.Text,
                    txtPessoas.Text,
                    txtDescricao.Text,
                    valor
                );

                ControlHelper.ClearAndFocus(txtCod, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(false, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarQuartos();
                SucessoMensageService.ShowSuccess("Quarto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtQuarto);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService("Informe o valor do quarto corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }

            try
            {
                _dao.EditarQuarto(
                    Convert.ToInt32(txtCod.Text),
                    txtQuarto.Text,
                    txtPessoas.Text,
                    txtDescricao.Text,
                    valor
                );

                ControlHelper.ClearAndFocus(txtCod, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(false, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarQuartos();
                SucessoMensageService.ShowSuccess("Quarto alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para excluir!");
                txtQuarto.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirQuarto(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtQuarto, txtPessoas, txtDescricao, txtValor);
                HabilitarCampos(true);
                ListarQuartos();
                SucessoMensageService.ShowSuccess("Quarto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        private void GridQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableHelper.SetEnabled(true, txtQuarto, txtPessoas, txtDescricao, txtValor);
            EnableHelper.SetEnabled(false, txtCod); // Id desabilitado

            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            txtCod.Text = gridQUARTOS.CurrentRow.Cells[0].Value.ToString();
            txtQuarto.Text = gridQUARTOS.CurrentRow.Cells[1].Value.ToString();
            txtPessoas.Text = gridQUARTOS.CurrentRow.Cells[2].Value.ToString();
            txtDescricao.Text = gridQUARTOS.CurrentRow.Cells[3].Value.ToString();
            txtValor.Text = gridQUARTOS.CurrentRow.Cells[4].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
