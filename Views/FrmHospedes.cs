using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Repositories.hospedeDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmHospedes : Form
    {
        Conexao con = new Conexao();
        private hospedeDAO _dao = new hospedeDAO();

        public FrmHospedes()
        {
            InitializeComponent();
        }

        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            tabControlHospedes.SelectedTab = tabPage2; // Seleciona a aba de listagem ao abrir o formulário
            ListarHospedes();
            PreencherCBox();
            rBNome.Checked = true;
            ListarHospedes();
            EnableHelper.SetEnabled(false, txtCod, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

            // Verifica de onde FrmHospedes foi chamado para configurar visibilidade dos botões
            if (Globais.chamadaHospedes == "hospedes")
            {
                // Chamado por FrmVendas
                btnSelecionar.Visible = true;
                btSelecionarHospedeServico.Visible = false;
                btnSelecionarHospedeEdicao.Visible = false;
            }
            else if (Globais.chamadaHospedes == "servicos")
            {
                // Chamado por FrmNovoServico
                btnSelecionar.Visible = false;
                btSelecionarHospedeServico.Visible = true;
                btnSelecionarHospedeEdicao.Visible = false;
            }
            else
            {
                // Uso direto (modo edição)
                btnSelecionar.Visible = false;
                btSelecionarHospedeServico.Visible = false;
                btnSelecionarHospedeEdicao.Visible = true;
            }

        }

        //Métodos

        //Método de carregar o combo box de cargos
        private void PreencherCBox()
        {

            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand
            {
                Connection = con.Con,
                CommandText = "spListarFuncionarios",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = Cmd
            };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cbBoxFuncionario.DataSource = Dt;
            cbBoxFuncionario.ValueMember = "IdFunc";
            cbBoxFuncionario.DisplayMember = "Nome";
        }

        //Método de listar hóspede
        private void ListarHospedes()
        {
            try
            {
                gridHospedes.DataSource = _dao.ListarHospedes();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Listar Hóspedes: " + ex.Message);
            }
        }

        //Método de buscar por nome
        private void BuscarNomeHospede()
        {
            try
            {
                gridHospedes.DataSource = _dao.BuscarHospedePorNome(txtBuscarNome.Text);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Buscar: " + ex.Message);
            }
        }

        //Método de buscar pelo CPF
        private void BuscarHospedeCPF()
        {
            try
            {
                gridHospedes.DataSource = _dao.BuscarHospedePorCPF(maskBuscarCPF.Text);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Buscar: " + ex.Message);
            }
        }

        //Método p/ salvar hospedes
        //Método não foi usado
        private void SalvarHospedes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();
                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spInserirHospedes";
                Cmd3.CommandType = CommandType.StoredProcedure;
                Cmd3.Parameters.AddWithValue("@Nome", txtNome.Text);
                Cmd3.Parameters.AddWithValue("@CPF", maskCpf.Text);
                Cmd3.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                Cmd3.Parameters.AddWithValue("@Tel", maskTelefone.Text);
                Cmd3.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd3.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao salvar hospedes: " + ex.Message);
            }
        }

        //Método p/ verificar se existe o CPF do hóspede já está cadastrado
        //Método não foi usado
        private void VerificarCPF()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand CmdVerificar = new MySqlCommand();
                CmdVerificar.Connection = con.Con;
                CmdVerificar.CommandText = "spVerificarCPF";
                CmdVerificar.CommandType = CommandType.StoredProcedure;
                CmdVerificar.Parameters.AddWithValue("@CPF", maskCpf.Text);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = CmdVerificar;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    ErroMensageService.ShowError("CPF já registrado ! Erro ao salvar!");
                    maskCpf.Clear();
                    maskCpf.Focus();
                    return;
                }
                CmdVerificar.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao verificar o CPF do hóspede: " + ex.Message);
            }
        }

        //Método p/ EXCLUIR hospedes
        private void ExcluirHospedes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd5 = new MySqlCommand();
                Cmd5.Connection = con.Con;
                Cmd5.CommandText = "spExcluirHospedes";
                Cmd5.CommandType = CommandType.StoredProcedure;
                Cmd5.Parameters.AddWithValue("@IdHospede", Globais.idHospede);
                Cmd5.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao excluir hospedes: " + ex.Message);
            }
        }

        //**********************************************************
        //botões

        //botão NOVO
        string op;
        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            ControlHelper.ClearAndFocus(txtCod, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

            // Habilita campos
            EnableHelper.SetEnabled(true, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

            // Habilita "Salvar", desabilita "Editar", "Excluir" e "Novo"
            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);

            maskCpf.Focus();
        }

        //botão SALVAR
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty || maskCpf.Text.Trim() == string.Empty || cbBoxFuncionario.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Preencha os campos obrigatórios: Nome, CPF e Funcionário!");
                ControlHelper.ClearAndFocus(txtNome, maskCpf, cbBoxFuncionario);
                return;
            }

            // 2. CPF válido
            if (!CpfHelper.IsValidCpf(maskCpf.Text))
            {
                ErroMensageService.ShowError("CNPJ inválido! Verifique e tente novamente.");
                ControlHelper.ClearAndFocus(maskCpf, maskCpf);
                return;
            }

            // 3. CNPJ único
            if (_dao.ExisteHospedeCPF(Regex.Replace(maskCpf.Text, "[^0-9]", ""))) // remove máscara para comparar
            {
                ErroMensageService.ShowError("CNPJ já cadastrado! Não é possível salvar duplicado.");
                ControlHelper.ClearAndFocus(maskCpf, maskCpf);
                return;
            }

            //Validação do Email
            if (!EmailHelper.IsValidEmail(txtEmail.Text))
            {
                ErroMensageService.ShowError("E-mail inválido! Insira um e-mail válido.");
                ControlHelper.ClearAndFocus(txtEmail, txtEmail);
                return;
            }

            // 4. Placa de veículo válida
            if (!PlacaService.IsPlacaValida(makPlacaVeiculo.Text))
            {
                ErroMensageService.ShowError("Placa de veículo inválida! Informe uma placa válida (antiga ou Mercosul).");
                ControlHelper.ClearAndFocus(makPlacaVeiculo, makPlacaVeiculo);
                return;
            }

            try
            {
                _dao.InserirHospede(
                    txtNome.Text, maskCpf.Text, txtEndereco.Text, txtBairro.Text, txtCidade.Text,
                    cbUF.Text, maskCEP.Text, maskTelefone.Text, maskCelular.Text, txtEmail.Text,
                    txtEmpresa.Text, makPlacaVeiculo.Text, cbBoxFuncionario.Text);

                // Limpa os campos após salvar
                ControlHelper.ClearAndFocus(txtCod, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

                // Desabilita os campos após salvar
                EnableHelper.SetEnabled(false, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

                // Habilita botões "Novo" e "Editar", desabilita "Salvar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarHospedes();
                SucessoMensageService.ShowSuccess("Hóspede salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        //botão EDITAR
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para alterar!");
                ControlHelper.ClearAndFocus(txtCod);
                return;
            }

            //Validação do Email
            if (!EmailHelper.IsValidEmail(txtEmail.Text))
            {
                ErroMensageService.ShowError("E-mail inválido! Insira um e-mail válido.");
                ControlHelper.ClearAndFocus(txtEmail, txtEmail);
                return;
            }

            // 4. Placa de veículo válida
            if (!PlacaService.IsPlacaValida(makPlacaVeiculo.Text))
            {
                ErroMensageService.ShowError("Placa de veículo inválida! Informe uma placa válida (antiga ou Mercosul).");
                ControlHelper.ClearAndFocus(makPlacaVeiculo, makPlacaVeiculo);
                return;
            }

            try
            {
                _dao.EditarHospede(
                    Convert.ToInt32(txtCod.Text), txtNome.Text, maskCpf.Text, txtEndereco.Text, txtBairro.Text, txtCidade.Text,
                    cbUF.Text, maskCEP.Text, maskTelefone.Text, maskCelular.Text, txtEmail.Text,
                    txtEmpresa.Text, makPlacaVeiculo.Text, cbBoxFuncionario.Text);

                // Limpa os campos após a edição
                ControlHelper.ClearAndFocus(txtCod, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

                // Desabilita campos após edição
                EnableHelper.SetEnabled(false, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);

                // Habilita botões "Novo" e "Salvar", desabilita "Editar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarHospedes();
                SucessoMensageService.ShowSuccess("Hóspede alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }
        }

        //botão EXCLUIR
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text.Trim() == string.Empty)
            {
                ErroMensageService.ShowError("Selecione um registro para excluir!");
                txtCod.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirHospede(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);
                EnableHelper.SetEnabled(true, txtNome, maskCpf, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                    maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario,
                    btEditar, btExcluir, btSalvar);
                //HabilitarCampos(true);
                ListarHospedes();
                SucessoMensageService.ShowSuccess("Hóspede excluído com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
            }
        }

        //grid
        private void GridHospedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RBNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            maskBuscarCPF.Visible = false;

            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
        }

        private void RBBuscarCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            maskBuscarCPF.Visible = true;

            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
        }

        //evento do txt p/ buscar hospede por nome
        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNomeHospede();
        }

        //evento do txt p/ buscar hospede por CPF
        private void MaskBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            if (maskBuscarCPF.Text == "   .   .   -")
            {
                ListarHospedes();
            }

            else
            {
                BuscarHospedeCPF();
            }
        }

        //evento que seleciona o hospede no FrmHospedes e passa p/ o FrmNovosServiços
        private void GridHospedes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //botão Pesquisar CEP
        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
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
                ErroMensageService.ShowError($"Endereço não encontrado. Por favor, digite o CEP manualmente.\n\nDetalhe técnico: {ex.Message}");
            }
        }

        //Evento para converter a placa do veículo para maiúsculas
        private void makPlacaVeiculo_TextChanged(object sender, EventArgs e)
        {
            // Salva a posição do cursor
            int selectionStart = makPlacaVeiculo.SelectionStart;

            // Converte o texto para maiúsculo
            makPlacaVeiculo.Text = makPlacaVeiculo.Text.ToUpper();

            // Restaura a posição do cursor
            makPlacaVeiculo.SelectionStart = selectionStart;
        }

        public string NomeSelecionado { get; private set; } = null;


        private void gridHospedes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        //Botão de selecionar hóspede p/ outra tela (como FrmVendas)
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (gridHospedes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um hóspede.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (gridHospedes.CurrentRow != null)
            {
                // Atribui o valor à propriedade pública
                NomeSelecionado = gridHospedes.CurrentRow.Cells[1].Value.ToString();

                // Define que o diálogo foi concluído com sucesso
                this.DialogResult = DialogResult.OK;

                // Fecha o formulário
                this.Close();
            }
        }


        //Botão de selecionar hóspede na tela de edição (FrmHospedes)
        private void btnSelecionarHospedeEdicao_Click(object sender, EventArgs e)
        {
            if (gridHospedes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um hóspede.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gridHospedes.CurrentRow == null)
                return;

            tabControlHospedes.SelectedTab = tabPage1;

            txtCod.Text = gridHospedes.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridHospedes.CurrentRow.Cells[1].Value.ToString();
            maskCpf.Text = gridHospedes.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = gridHospedes.CurrentRow.Cells[3].Value.ToString();
            txtBairro.Text = gridHospedes.CurrentRow.Cells[4].Value.ToString();
            txtCidade.Text = gridHospedes.CurrentRow.Cells[5].Value.ToString();
            cbUF.Text = gridHospedes.CurrentRow.Cells[6].Value.ToString();
            maskCEP.Text = gridHospedes.CurrentRow.Cells[7].Value.ToString();
            maskTelefone.Text = gridHospedes.CurrentRow.Cells[8].Value.ToString();
            maskCelular.Text = gridHospedes.CurrentRow.Cells[9].Value.ToString();
            txtEmail.Text = gridHospedes.CurrentRow.Cells[10].Value.ToString();
            txtEmpresa.Text = gridHospedes.CurrentRow.Cells[11].Value.ToString();
            makPlacaVeiculo.Text = gridHospedes.CurrentRow.Cells[12].Value.ToString();
            cbBoxFuncionario.Text = gridHospedes.CurrentRow.Cells[13].Value.ToString();

            // Desabilita campos fixos
            maskCpf.Enabled = false;
            EnableHelper.SetEnabled(true, txtNome, txtEndereco, txtBairro, txtCidade, cbUF, maskCEP,
                maskTelefone, maskCelular, txtEmail, txtEmpresa, makPlacaVeiculo, cbBoxFuncionario);
            EnableHelper.SetEnabled(false, txtCod, maskCpf);

            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            // linha para comparação futura
            Globais.cpfAntigo = gridHospedes.CurrentRow.Cells[2].Value.ToString();
        }

        // Evento para o botão de selecionar hóspede no serviço
        private void btSelecionarHospedeServico_Click(object sender, EventArgs e)
        {
            if (gridHospedes.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um hóspede.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (gridHospedes.CurrentRow != null)
            {
                // Atribui o valor à propriedade pública
                NomeSelecionado = gridHospedes.CurrentRow.Cells[1].Value.ToString();

                // Define que o diálogo foi concluído com sucesso
                this.DialogResult = DialogResult.OK;

                // Fecha o formulário
                this.Close();
            }
        }
    }
}
