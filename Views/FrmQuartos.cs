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
        private string op = "";

        public FrmQuartos()
        {
            InitializeComponent();
        }

        private void FrmQuartos_Load(object sender, EventArgs e)
        {
            ListarQuartos();
            EnableHelper.SetEnabled(false, txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);
        }

        //private void ErroMensageService(string msg)
        //{
        //    MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //}

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor, btEditar, btExcluir, btSalvar);
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
                ErroMensageService.ShowError("Erro ao Listar Quartos: " + ex.Message);
            }
        }

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtNumeroQuarto.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);

            EnableHelper.SetEnabled(true, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);

            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        //Botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtNumeroQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Insira o número do Quarto!");
                ControlHelper.ClearAndFocus(txtNumeroQuarto);
                return;
            }

            if (txtQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Insira a categoria/nome do Quarto!");
                ControlHelper.ClearAndFocus(txtQuarto);
                return;
            }

            if (txtPessoas.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Informe a quantidade de pessoas do quarto!");
                ControlHelper.ClearAndFocus(txtPessoas);
                return;
            }

            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService.ShowError("Informe o valor do quarto corretamente!");
                ControlHelper.ClearAndFocus(txtValor);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtCod.Text)) // INSERÇÃO
                {
                    if (_dao.ExisteQuarto(txtNumeroQuarto.Text))
                    {
                        ErroMensageService.ShowError("Número do quarto já registrado! Erro ao salvar!");
                        ControlHelper.ClearAndFocus(txtNumeroQuarto);
                        return;
                    }

                    _dao.InserirQuarto(
                        txtNumeroQuarto.Text,
                        txtQuarto.Text,
                        txtPessoas.Text,
                        txtDescricao.Text,
                        valor
                    );

                    SucessoMensageService.ShowSuccess("Quarto salvo com sucesso!");
                }
                else // EDIÇÃO
                {
                    _dao.EditarQuarto(
                        Convert.ToInt32(txtCod.Text),
                        txtNumeroQuarto.Text,
                        txtQuarto.Text,
                        txtPessoas.Text,
                        txtDescricao.Text,
                        valor
                    );

                    SucessoMensageService.ShowSuccess("Quarto alterado com sucesso!");
                }

                ControlHelper.ClearAndFocus(txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);
                EnableHelper.SetEnabled(false, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btSalvar, btEditar, btExcluir);

                ListarQuartos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNumeroQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtNumeroQuarto);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService.ShowError("Informe o valor do quarto corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }

            try
            {
                _dao.EditarQuarto(
                    Convert.ToInt32(txtCod.Text),
                    txtNumeroQuarto.Text,
                    txtQuarto.Text,
                    txtPessoas.Text,
                    txtDescricao.Text,
                    valor
                );

                ControlHelper.ClearAndFocus(txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(false, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);

                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarQuartos();
                SucessoMensageService.ShowSuccess("Quarto alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtNumeroQuarto.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para excluir!");
                txtNumeroQuarto.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirQuarto(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);
                HabilitarCampos(true);
                ListarQuartos();
                SucessoMensageService.ShowSuccess("Quarto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
            }
        }

        private void GridQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridQUARTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Botão Selecionar Quarto
        private void btnSelecionarHospedeEdicao_Click(object sender, EventArgs e)
        {
            if (gridQUARTOS.CurrentRow == null)
            {
                MessageBox.Show("Selecione um quarto na grade para alterar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este quarto? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.Cancel) return;

            txtCod.Text = gridQUARTOS.CurrentRow.Cells[0].Value.ToString();
            txtNumeroQuarto.Text = gridQUARTOS.CurrentRow.Cells[1].Value.ToString();
            txtQuarto.Text = gridQUARTOS.CurrentRow.Cells[2].Value.ToString();
            txtPessoas.Text = gridQUARTOS.CurrentRow.Cells[3].Value.ToString();
            txtDescricao.Text = gridQUARTOS.CurrentRow.Cells[4].Value.ToString();
            txtValor.Text = gridQUARTOS.CurrentRow.Cells[5].Value.ToString();

            if (resposta == DialogResult.Yes) // ALTERAR
            {
                EnableHelper.SetEnabled(true, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor, btSalvar);
                EnableHelper.SetEnabled(false, txtCod, btNovo);

                ControlHelper.ClearAndFocus(txtNumeroQuarto);

                MessageBox.Show("Edite o campo desejado e clique em 'INSERIR REGISTRO' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (resposta == DialogResult.No) // EXCLUIR
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja EXCLUIR este quarto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        _dao.ExcluirQuarto(Convert.ToInt32(txtCod.Text));

                        ControlHelper.ClearAndFocus(txtCod, txtNumeroQuarto, txtQuarto, txtPessoas, txtDescricao, txtValor);
                        EnableHelper.SetEnabled(true, btNovo);
                        EnableHelper.SetEnabled(false, btSalvar);

                        ListarQuartos();
                        SucessoMensageService.ShowSuccess("Quarto excluído com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
                    }
                }
            }
        }

        // Evento para validar a entrada de texto no campo Número do Quarto
        private void txtPessoas_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }

        // Evento para validar a entrada de texto no campo Valor
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }
    }
}
