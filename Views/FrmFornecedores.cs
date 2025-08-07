using SistemaHotel.Repositories.fornecedorDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.IO;
using System.Linq;
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

        //private void ErroMensageService(string msg)
        //{
        //    MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //}

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
                ErroMensageService.ShowError("Erro ao Listar Fornecedores: " + ex.Message);
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
                ErroMensageService.ShowError("Erro ao Buscar: " + ex.Message);
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
            string nome = txtNome.Text.Trim();
            string uf = cbUF.Text.Trim();

            // Validações
            if (string.IsNullOrEmpty(cnpj))
            {
                ErroMensageService.ShowError("Insira o CNPJ do Fornecedor!");
                ControlHelper.ClearAndFocus(maskCNPJ); return;
            }

            if (!CnpjHelper.IsValidCNPJ(cnpj))
            {
                ErroMensageService.ShowError("CNPJ inválido! Verifique e tente novamente.");
                ControlHelper.ClearAndFocus(maskCNPJ); return;
            }

            if (string.IsNullOrEmpty(nome))
            {
                ErroMensageService.ShowError("Insira o nome do Fornecedor!");
                ControlHelper.ClearAndFocus(txtNome); return;
            }

            if (string.IsNullOrEmpty(uf) || uf.Length != 2 || !Regex.IsMatch(uf, "^[A-Za-z]{2}$"))
            {
                ErroMensageService.ShowError("UF inválido! Insira apenas duas letras.");
                ControlHelper.ClearAndFocus(cbUF); return;
            }

            if (!EmailHelper.IsValidEmail(txtEmail.Text))
            {
                ErroMensageService.ShowError("E-mail inválido!");
                ControlHelper.ClearAndFocus(txtEmail); return;
            }

            try
            {
                bool isEdicao = !string.IsNullOrWhiteSpace(txtCod.Text);
                string cnpjLimpo = Regex.Replace(cnpj, "[^0-9]", "");

                if (isEdicao)
                {
                    _dao.AtualizarFornecedor(
                        Convert.ToInt32(txtCod.Text),
                        cnpjLimpo,
                        nome,
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

                    SucessoMensageService.ShowSuccess("Fornecedor atualizado com sucesso!");
                }
                else
                {
                    if (_dao.ExisteCNPJ(cnpjLimpo))
                    {
                        ErroMensageService.ShowError("CNPJ já cadastrado!");
                        ControlHelper.ClearAndFocus(maskCNPJ); return;
                    }

                    if (_dao.ExisteFornecedor(nome))
                    {
                        ErroMensageService.ShowError("Fornecedor já registrado!");
                        ControlHelper.ClearAndFocus(txtNome); return;
                    }

                    _dao.InserirFornecedor(
                        cnpjLimpo,
                        nome,
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

                    SucessoMensageService.ShowSuccess("Fornecedor salvo com sucesso!");
                }

                // Pós-operação
                ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                EnableHelper.SetEnabled(false, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarFornecedores();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message);
            }
        }

        #region Código não utilizado
        //botão Editar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtNome);
                return;
            }
            if (maskCNPJ.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Insira o CNPJ do Fornecedor!");
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

                EnableHelper.SetEnabled(false, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);

                EnableHelper.SetEnabled(true, maskCNPJ, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarFornecedores();
                SucessoMensageService.ShowSuccess("Fornecedor alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        //botão Excluir
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para excluir!");
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
                EnableHelper.SetEnabled(true, btNovo, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
            }
        }
        #endregion


        //botão Pesquisar CEP
        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            // Evento do botão "Pesquisar CEP" - versão síncrona, sem async/await

            // 1. Limpa e valida o CEP informado
            string cep = maskCEP.Text.Trim().Replace("-", "").Replace(".", "");
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !cep.All(char.IsDigit))
            {
                MessageBox.Show("Digite um CEP válido (8 dígitos numéricos).");
                maskCEP.Focus();
                return;
            }

            // 2. Monta a URL para consulta ViaCEP em formato XML
            string url = $"https://viacep.com.br/ws/{cep}/xml/";

            try
            {
                // 3. Cria requisição web síncrona para buscar o XML
                var request = System.Net.WebRequest.Create(url);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new System.IO.StreamReader(stream))
                {
                    string xmlString = reader.ReadToEnd();

                    // 4. Carrega o XML em um DataSet para fácil acesso aos campos
                    DataSet ds = new DataSet();
                    using (StringReader sr = new StringReader(xmlString))
                    {
                        ds.ReadXml(sr);
                    }

                    // 5. Verifica se o DataSet está preenchido corretamente e se não há erro de CEP inexistente
                    if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Columns.Contains("erro"))
                    {
                        throw new Exception("CEP não encontrado.");
                    }

                    // 6. Preenche os campos do formulário com as informações retornadas
                    var row = ds.Tables[0].Rows[0];
                    txtEndereco.Text = row["logradouro"].ToString();
                    txtBairro.Text = row["bairro"].ToString();
                    txtCidade.Text = row["localidade"].ToString();
                    cbUF.Text = row["uf"].ToString();
                }
            }
            catch (Exception ex)
            {
                // 7. Em caso de qualquer erro: limpa o campo, foca novamente e avisa o usuário
                maskCEP.Clear();
                maskCEP.Focus();
                MessageBox.Show($"Endereço não encontrado. Por favor, digite o CEP manualmente.\n\nDetalhe técnico: {ex.Message}");
            }
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarFornecedorNome();
        }

        // Botão Selecionar Fornecedor
        private void btnSelecionarFornecEdicao_Click(object sender, EventArgs e)
        {
            if (gridFornecedores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um fornecedor na grade para alterar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este fornecedor? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.Cancel) return;

            // Preenche os campos com os dados da linha selecionada
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
            txtObs.Text = gridFornecedores.CurrentRow.Cells[13].Value.ToString();

            if (resposta == DialogResult.Yes) // Edição
            {
                EnableHelper.SetEnabled(true, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                EnableHelper.SetEnabled(false, txtCod, btNovo);
                EnableHelper.SetEnabled(true, btSalvar);

                MessageBox.Show("Edite o campo desejado e clique em 'INSERIR REGISTRO' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resposta == DialogResult.No) // Exclusão
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja EXCLUIR este fornecedor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    try
                    {
                        _dao.ExcluirFornecedor(Convert.ToInt32(txtCod.Text));
                        ListarFornecedores();
                        ControlHelper.ClearAndFocus(txtCod, maskCNPJ, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP, maskTel, maskCelular, txtEmail, txtContato, txtObs);
                        EnableHelper.SetEnabled(true, btNovo);
                        EnableHelper.SetEnabled(false, btSalvar);
                        SucessoMensageService.ShowSuccess("Fornecedor excluído com sucesso!");
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
