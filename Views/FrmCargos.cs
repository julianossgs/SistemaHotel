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

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                ErroMensageService("Erro ao Listar Cargos: " + ex.Message);
            }
        }

        // Buscar cargos por nome
        //private void BuscarCargoNome()
        //{
        //    try
        //    {
        //        gridCargos.DataSource = _dao.BuscarCargoPorNome(txtBuscarCargo.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErroMensageService("Erro ao Buscar: " + ex.Message);
        //    }
        //}

        // Botões
        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtCargo.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtCargo);

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
                ErroMensageService("Insira o nome do Cargo!");
                ControlHelper.ClearAndFocus(txtCargo, txtCargo);
                return;
            }

            // Verifica se o cargo já existe
            if (_dao.ExisteCargo(txtCargo.Text))
            {
                ErroMensageService("Cargo já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtCargo, txtCargo);
                return;
            }

            try
            {
                _dao.InserirCargo(txtCargo.Text);

                // Limpa os campos após salvar
                ControlHelper.ClearAndFocus(txtCod, txtCargo);

                // Desabilita os campos após salvar
                EnableHelper.SetEnabled(false, txtCargo);

                // Habilita botões "Novo" e "Editar", desabilita "Salvar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarCargos();
                SucessoMensageService.ShowSuccess("Cargo salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
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
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para excluir!");
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
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        // Busca dinâmica por nome
        //private void TxtBuscarCargo_TextChanged(object sender, EventArgs e)
        //{
        //    BuscarCargoNome();
        //}

        private void GridCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Habilita campos
            EnableHelper.SetEnabled(true, txtCargo);
            EnableHelper.SetEnabled(false, txtCod); // Id desabilitado

            // Habilita "Editar" e "Excluir", desabilita "Novo" e "Salvar"
            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            txtCod.Text = gridCargos.CurrentRow.Cells[0].Value.ToString();
            txtCargo.Text = gridCargos.CurrentRow.Cells[1].Value.ToString();
        }
    }
}

