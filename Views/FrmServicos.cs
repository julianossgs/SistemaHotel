using SistemaHotel.Repositories.servicoDAO;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmServicos : Form
    {
        private servicoDAO _dao = new servicoDAO();

        public FrmServicos()
        {
            InitializeComponent();
        }

        private void FrmServicos_Load(object sender, EventArgs e)
        {
            ListarServicos();
            EnableHelper.SetEnabled(false, txtCod, txtServico, txtValor);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtServico, txtValor, btEditar, btExcluir, btSalvar);
        }

        // Listar serviços na grid
        private void ListarServicos()
        {
            try
            {
                gridServicos.DataSource = _dao.ListarServicos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Listar Serviços: " + ex.Message);
            }
        }


        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtServico.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);

            EnableHelper.SetEnabled(true, txtServico, txtValor);

            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtServico.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Insira o nome do Serviço!");
                ControlHelper.ClearAndFocus(txtServico, txtServico);
                return;
            }

            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService.ShowError("Informe o valor do serviço corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtCod.Text)) // INSERIR
                {
                    if (_dao.ExisteServico(txtServico.Text))
                    {
                        ErroMensageService.ShowError("Serviço já registrado! Erro ao salvar!");
                        ControlHelper.ClearAndFocus(txtServico, txtServico);
                        return;
                    }

                    _dao.InserirServico(txtServico.Text, valor);
                    SucessoMensageService.ShowSuccess("Serviço salvo com sucesso!");
                    ListarServicos();
                }
                else // EDITAR
                {
                    int id = Convert.ToInt32(txtCod.Text);
                    _dao.EditarServico(id, txtServico.Text, valor);
                    SucessoMensageService.ShowSuccess("Serviço alterado com sucesso!");
                    ListarServicos();
                }

                // Limpar e reorganizar componentes após salvar
                ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);
                EnableHelper.SetEnabled(false, txtServico, txtValor, txtCod);
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btSalvar, btEditar, btExcluir);

                ListarServicos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message + ex.StackTrace);
            }
        }

        #region Código não utilizado
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtServico.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtServico);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService.ShowError("Informe o valor do serviço corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }

            try
            {
                _dao.EditarServico(Convert.ToInt32(txtCod.Text), txtServico.Text, valor);

                ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);

                EnableHelper.SetEnabled(false, txtServico, txtValor);

                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarServicos();
                SucessoMensageService.ShowSuccess("Serviço alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtServico.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para excluir!");
                txtServico.Focus();
                return;
            }

            var result = MessageBox.Show(
                        "Deseja Excluir?",
                        "Atenção",
                         MessageBoxButtons.OKCancel,
                         MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button2
                                                         );

            if (result == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                _dao.ExcluirServico(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);
                HabilitarCampos(true);
                ListarServicos();
                SucessoMensageService.ShowSuccess("Serviço excluído com sucesso!");
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
            }
        }

        private void GridServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        //Evento de validação dos campos para somente números/valores monetários
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }


        private void btnSelecionarServicoEdicao_Click(object sender, EventArgs e)
        {
            if (gridServicos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um serviço na grade para alterar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este serviço? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resposta == DialogResult.Cancel) return;

            // Preenche os campos com os dados da linha selecionada
            txtCod.Text = gridServicos.CurrentRow.Cells[0].Value.ToString();
            txtServico.Text = gridServicos.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = gridServicos.CurrentRow.Cells[2].Value.ToString();

            if (resposta == DialogResult.Yes) // ALTERAR
            {
                EnableHelper.SetEnabled(true, txtServico, txtValor, btSalvar);
                ControlHelper.ClearAndFocus(txtServico);
                EnableHelper.SetEnabled(false, txtCod, btNovo);

                MessageBox.Show("Edite o campo desejado e clique em 'INSERIR REGISTRO' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resposta == DialogResult.No) // EXCLUIR
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja EXCLUIR este serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        _dao.ExcluirServico(Convert.ToInt32(txtCod.Text));
                        ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);
                        EnableHelper.SetEnabled(true, btNovo);
                        EnableHelper.SetEnabled(false, btSalvar);
                        ListarServicos();
                        SucessoMensageService.ShowSuccess("Serviço excluído com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
                    }
                }
            }
        }
    }
}