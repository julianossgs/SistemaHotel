using SistemaHotel.Repositories.gastoDAO;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmGastos : Form
    {


        private gastoDAO _dao = new gastoDAO();

        public FrmGastos()
        {
            InitializeComponent();
        }

        private void FrmGastos_Load(object sender, EventArgs e)
        {
            ListarGastos();
        }

        private void LimparCampos()
        {
            ControlHelper.ClearAndFocus(txtDescricao, txtDescricao, txtValor);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtDescricao, txtValor);
            if (vr) txtDescricao.Focus();
        }

        private void ListarGastos()
        {
            try
            {
                gridGastos.DataSource = _dao.ListarGastos();
                Totalizar();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao listar os gastos: " + ex.Message);
            }
        }

        private void BtNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btNovo, btEditar, btExcluir);
            LimparCampos();
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Preencha a Descrição!");
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Preencha o Valor!");
                txtValor.Focus();
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(Globais.idGasto)) // INSERÇÃO
                {
                    _dao.InserirGasto(txtDescricao.Text, Convert.ToDecimal(txtValor.Text), Globais.nomeUsuario);

                    string ultimoId = _dao.RecuperarUltimoIdGasto();
                    Globais.ultimoIdGastos = ultimoId;

                    _dao.LancarGastosMovimentacoes("Saída", "Gastos", Convert.ToDecimal(txtValor.Text), Globais.nomeUsuario, Convert.ToInt32(ultimoId));

                    SucessoMensageService.ShowSuccess("Gasto inserido com sucesso!");
                }
                else // EDIÇÃO
                {
                    _dao.EditarGasto(

                    Convert.ToInt32(Globais.idGasto),
                         txtDescricao.Text,
                         Convert.ToDecimal(txtValor.Text),
                          Globais.nomeUsuario

                    );

                    SucessoMensageService.ShowSuccess("Gasto atualizado com sucesso!");
                }

                ListarGastos();
                LimparCampos();
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btSalvar);
                HabilitarCampos(false);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message);
            }
        }

        #region Código não utilizado
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Preencha o campo Descrição!");
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Preencha o campo Valor!");
                txtValor.Focus();
                return;
            }
            try
            {
                int idGasto = Convert.ToInt32(Globais.idGasto);
                _dao.EditarGasto(idGasto, txtDescricao.Text, Convert.ToDecimal(txtValor.Text), Globais.nomeUsuario);
                _dao.AtualizarValorMovimentacao(Convert.ToDecimal(txtValor.Text), Globais.nomeUsuario, idGasto, "Gastos");

                SucessoMensageService.ShowSuccess("Registro alterado com sucesso!");
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);
                HabilitarCampos(false);
                ListarGastos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao editar gastos: " + ex.Message);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja excluir?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int idGasto = Convert.ToInt32(Globais.idGasto);
                    _dao.ExcluirGasto(idGasto);
                    _dao.ExcluirMovGasto(idGasto, "Gastos");

                    SucessoMensageService.ShowSuccess("Registro excluido com sucesso!");
                    EnableHelper.SetEnabled(true, btNovo, btEditar);
                    EnableHelper.SetEnabled(false, btExcluir);
                    LimparCampos();
                    HabilitarCampos(false);
                    ListarGastos();
                }
                catch (Exception ex)
                {
                    ErroMensageService.ShowError("Erro ao excluir gastos: " + ex.Message);
                }
            }
        }

        private void GridGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridGastos.DataSource = _dao.BuscarGastosData(dtBuscar.Value);
                Totalizar();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao buscar por data: " + ex.Message);
            }
        }

        private void Totalizar()
        {
            try
            {
                decimal total = 0;
                foreach (DataGridViewRow linha in gridGastos.Rows)
                {
                    if (linha.Cells["Valor"].Value != null)
                        total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
                lblTotal.Text = total.ToString("C2");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Totalizar: " + ex.Message);
            }
        }

        //Evento de validação dos campos para somente números/valores monetários
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }


        private void btnSelecionarGastoEdicao_Click(object sender, EventArgs e)
        {
            if (gridGastos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um gasto na grade para alterar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este gasto? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.Cancel) return;

            Globais.idGasto = gridGastos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = gridGastos.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = gridGastos.CurrentRow.Cells[3].Value.ToString();

            if (resposta == DialogResult.Yes) // ALTERAR
            {
                EnableHelper.SetEnabled(true, txtDescricao, txtValor, btSalvar);
                EnableHelper.SetEnabled(false, btNovo);

                ControlHelper.ClearAndFocus(txtDescricao);
                MessageBox.Show("Edite os campos desejados e clique em 'INSERIR REGISTRO' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resposta == DialogResult.No) // EXCLUIR
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja EXCLUIR este gasto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        // _dao.ExcluirGasto(Convert.ToInt32(txtId.Text));
                        int idGasto = Convert.ToInt32(Globais.idGasto);
                        _dao.ExcluirGasto(idGasto);
                        _dao.ExcluirMovGasto(idGasto, "Gastos");

                        SucessoMensageService.ShowSuccess("Gasto excluído com sucesso!");
                        ListarGastos();
                        LimparCampos();
                        EnableHelper.SetEnabled(true, btNovo);
                        EnableHelper.SetEnabled(false, btSalvar);
                        HabilitarCampos(false);
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
