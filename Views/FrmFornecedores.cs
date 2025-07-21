using SistemaHotel.Repositories.fornecedorDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmFornecedores : Form
    {
        private fornecedorDAO _dao = new fornecedorDAO();

        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {

            EnableHelper.SetEnabled(false, txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
            ListarFornecedores();
        }

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs, btEditar, btExcluir, btSalvar);
        }

        private void ListarFornecedores()
        {
            try
            {
                gridFornecedores.DataSource = _dao.ListarFornecedores();
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao Listar Fornecedores: " + ex.Message);
            }
        }

        private void BuscarFornecedorNome()
        {
            try
            {
                gridFornecedores.DataSource = _dao.BuscarFornecedorPorNome(txtBuscarNome.Text);
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao Buscar: " + ex.Message);
            }
        }

        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            maskCNPJ.Focus();
            ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

            EnableHelper.SetEnabled(true, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        //botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            string cnpj = maskCNPJ.Text.Trim();

            // 1. CNPJ preenchido
            if (string.IsNullOrEmpty(cnpj))
            {
                ErroMensageService("Insira o CNPJ do Fornecedor!");
                ControlHelper.ClearAndFocus(maskCNPJ, maskCNPJ);
                return;
            }

            // 2. CNPJ válido
            if (!CnpjHelper.IsValidCNPJ(cnpj))
            {
                ErroMensageService("CNPJ inválido! Verifique e tente novamente.");
                ControlHelper.ClearAndFocus(maskCNPJ, maskCNPJ);
                return;
            }

            // 3. CNPJ único
            if (_dao.ExisteCNPJ(Regex.Replace(cnpj, "[^0-9]", ""))) // remove máscara para comparar
            {
                ErroMensageService("CNPJ já cadastrado! Não é possível salvar duplicado.");
                ControlHelper.ClearAndFocus(maskCNPJ, maskCNPJ);
                return;
            }

            // 4. Nome preenchido
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o nome do Fornecedor!");
                ControlHelper.ClearAndFocus(txtNome, txtNome);
                return;
            }

            // 5. Nome único (opcional, se quiser manter)
            if (_dao.ExisteFornecedor(txtNome.Text))
            {
                ErroMensageService("Fornecedor já registrado! Erro ao salvar!");
                ControlHelper.ClearAndFocus(txtNome, txtNome);
                return;
            }

            string uf = cbUF.Text.Trim();

            // Validação: só letras e exatamente 2 caracteres
            if (string.IsNullOrEmpty(uf) || uf.Length != 2 || !System.Text.RegularExpressions.Regex.IsMatch(uf, "^[A-Za-z]{2}$"))
            {
                ErroMensageService("UF inválido! Insira apenas as duas letras do estado, sem números ou espaços.");
                ControlHelper.ClearAndFocus(txtUF, txtUF);
                return;
            }

            try
            {
                _dao.InserirFornecedor(
                    cnpj,
                    txtNome.Text,
                    txtEndereco.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    cbUF.Text,
                    maskCEP.Text,
                    maskTel.Text,
                    maskCelular.Text,
                    txtEmail.Text,
                    txtContato.Text,
                    txtObs.Text
                );

                ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

                EnableHelper.SetEnabled(false, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarFornecedores();
                SucessoMensageService.ShowSuccess("Fornecedor salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        //botão Editar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtNome);
                return;
            }
            if (maskCNPJ.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o CNPJ do Fornecedor!");
                ControlHelper.ClearAndFocus(maskCNPJ);
                return;
            }

            try
            {
                _dao.EditarFornecedor(
                    Convert.ToInt32(txtCod.Text),
                    maskCNPJ.Text,
                    txtNome.Text,
                    txtEndereco.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    cbUF.Text,
                    maskCEP.Text,
                    maskTel.Text,
                    maskCelular.Text,
                    txtEmail.Text,
                    txtContato.Text,
                    txtObs.Text
                );

                ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

                EnableHelper.SetEnabled(false, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarFornecedores();
                SucessoMensageService.ShowSuccess("Fornecedor alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        //botão Excluir
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um registro para excluir!");
                txtNome.Focus();
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
                _dao.ExcluirFornecedor(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                HabilitarCampos(true);
                ListarFornecedores();
                SucessoMensageService.ShowSuccess("Fornecedor excluído com sucesso!");
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        private void TxtBuscarFornecedor_TextChanged(object sender, EventArgs e)
        {
            BuscarFornecedorNome();
        }

        private void GridFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableHelper.SetEnabled(true, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
            EnableHelper.SetEnabled(false, txtCod); // Id desabilitado

            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);



            txtCod.Text = gridFornecedores.CurrentRow.Cells[0].Value.ToString();
            maskCNPJ.Text = gridFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtNome.Text = gridFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = gridFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtBairro.Text = gridFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCidade.Text = gridFornecedores.CurrentRow.Cells[5].Value.ToString();
            cbUF.Text = gridFornecedores.CurrentRow.Cells[6].Value.ToString();
            maskCEP.Text = gridFornecedores.CurrentRow.Cells[7].Value.ToString();
            maskTel.Text = gridFornecedores.CurrentRow.Cells[8].Value.ToString();
            maskCelular.Text = gridFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtEmail.Text = gridFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtContato.Text = gridFornecedores.CurrentRow.Cells[11].Value.ToString();
        DataCadastro: gridFornecedores.CurrentRow.Cells[12].Value.ToString();
            txtObs.Text = gridFornecedores.CurrentRow.Cells[13].Value.ToString();
        }

        private void maskCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        //botão Pesquisar CEP
        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = maskCEP.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet ds = new DataSet();
                ds.ReadXml(xml);

                txtEndereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["localidade"].ToString();
                cbUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {
                maskCEP.Clear();
                maskCEP.Focus();
                MessageBox.Show("Endereço não encontrado,por favor digite o CEP manualmente.");
            }
        }
    }
}
