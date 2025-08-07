using SistemaHotel.Repositories.cargoDAO;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmCargos : Form
    {
        private cargoDAO _dao = new cargoDAO();

        public FrmCargos()
        {
            InitializeComponent();

        }

        private void FrmCargos_Load(object sender, EventArgs e)
        {
            ListarCargos();
            EnableHelper.SetEnabled(false, txtCod, txtCargo);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtCargo, btEditar, btExcluir, btSalvar);
        }

        // Listar cargos na grid
        private void ListarCargos()
        {
            try
            {
                gridCargos.DataSource = _dao.ListarCargos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Listar Cargos: " + ex.Message);
            }
        }

        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            //txtCargo.Focus();
            Globais.idGasto = null;

            ControlHelper.ClearAndFocus(txtCargo);

            // Habilita campos
            EnableHelper.SetEnabled(true, txtCargo);

            // Habilita "Salvar", desabilita "Editar", "Excluir" e "Novo"
            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Insira o nome do Cargo!");
                ControlHelper.ClearAndFocus(txtCargo, txtCargo);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtCod.Text)) // INSERÇÃO
                {
                    if (_dao.ExisteCargo(txtCargo.Text))
                    {
                        ErroMensageService.ShowError("Cargo já registrado! Erro ao salvar!");
                        ControlHelper.ClearAndFocus(txtCargo, txtCargo);
                        return;
                    }

                    _dao.InserirCargo(txtCargo.Text);
                    SucessoMensageService.ShowSuccess("Cargo salvo com sucesso!");
                }
                else // EDIÇÃO
                {
                    _dao.EditarCargo(Convert.ToInt32(txtCod.Text), txtCargo.Text);
                    SucessoMensageService.ShowSuccess("Cargo alterado com sucesso!");
                }

                // Após inserção ou edição:
                ControlHelper.ClearAndFocus(txtCod, txtCargo);
                EnableHelper.SetEnabled(false, txtCargo);
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btSalvar, btEditar, btExcluir);

                ListarCargos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message + ex.StackTrace);
            }
        }
        #region Código não utilizado
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtCargo);
                return;
            }

            try
            {
                _dao.EditarCargo(Convert.ToInt32(txtCod.Text), txtCargo.Text);

                // Limpa os campos após a edição
                ControlHelper.ClearAndFocus(txtCod, txtCargo);

                // Desabilita campos após edição
                EnableHelper.SetEnabled(false, txtCargo);

                // Habilita botões "Novo" e "Salvar", desabilita "Editar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarCargos();
                SucessoMensageService.ShowSuccess("Cargo alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para excluir!");
                txtCargo.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirCargo(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtCargo);
                HabilitarCampos(true);
                ListarCargos();
                SucessoMensageService.ShowSuccess("Cargo excluído com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
            }
        }

        private void GridCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #region Evento para selecionar cargo na grid para edição/exclusão
        // Evento para selecionar cargo na grid para edição/exclusão
        private void btnSelecionarCargoEdicao_Click(object sender, EventArgs e)
        {
            if (gridCargos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cargo na grade para alterar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este cargo? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resposta == DialogResult.Cancel) return;

            // Preenche os campos com os dados da linha selecionada
            txtCod.Text = gridCargos.CurrentRow.Cells[0].Value.ToString();
            txtCargo.Text = gridCargos.CurrentRow.Cells[1].Value.ToString();

            if (resposta == DialogResult.Yes) // ALTERAR
            {

                EnableHelper.SetEnabled(true, txtCargo, btSalvar);
                ControlHelper.ClearAndFocus(txtCargo); //foca no txtCargo
                EnableHelper.SetEnabled(false, txtCod, btNovo); // código não editável


                MessageBox.Show("Edite o campo desejado e clique em 'INSERIR REGISTRO' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resposta == DialogResult.No) // EXCLUIR
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja EXCLUIR este cargo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        _dao.ExcluirCargo(Convert.ToInt32(txtCod.Text));
                        ControlHelper.ClearAndFocus(txtCod, txtCargo);
                        EnableHelper.SetEnabled(true, btNovo); // reabilita o botão de novo
                        EnableHelper.SetEnabled(false, btSalvar);
                        ListarCargos();
                        SucessoMensageService.ShowSuccess("Cargo excluído com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
                    }
                }
            }
        }
        #endregion
    }
}

