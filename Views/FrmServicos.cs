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

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                ErroMensageService("Erro ao Listar Serviços: " + ex.Message);
            }
        }

        // Buscar serviços por nome
        //private void BuscarServicoNome()
        //{
        //    try
        //    {
        //        gridServicos.DataSource = _dao.BuscarServicoPorNome(txtBuscarServico.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErroMensageService("Erro ao Buscar: " + ex.Message);
        //    }
        //}

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
                ErroMensageService("Insira o nome do Serviço!");
                ControlHelper.ClearAndFocus(txtServico, txtServico);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService("Informe o valor do serviço corretamente!");
                ControlHelper.ClearAndFocus(txtValor, txtValor);
                return;
            }
            if (_dao.ExisteServico(txtServico.Text))
            {
                ErroMensageService("Serviço já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtServico, txtServico);
                return;
            }

            try
            {
                _dao.InserirServico(txtServico.Text, valor);

                ControlHelper.ClearAndFocus(txtCod, txtServico, txtValor);

                EnableHelper.SetEnabled(false, txtServico, txtValor);

                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarServicos();
                SucessoMensageService.ShowSuccess("Serviço salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtServico.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtServico);
                return;
            }
            if (txtValor.Text.Trim() == string.Empty || !decimal.TryParse(txtValor.Text, out decimal valor))
            {
                ErroMensageService("Informe o valor do serviço corretamente!");
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
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtServico.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para excluir!");
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
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        // Busca dinâmica por nome
        //private void TxtBuscarServico_TextChanged(object sender, EventArgs e)
        //{
        //    BuscarServicoNome();
        //}

        private void GridServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableHelper.SetEnabled(true, txtServico, txtValor);
            EnableHelper.SetEnabled(false, txtCod); // Id desabilitado

            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            txtCod.Text = gridServicos.CurrentRow.Cells[0].Value.ToString();
            txtServico.Text = gridServicos.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = gridServicos.CurrentRow.Cells[2].Value.ToString();
        }
    }
}