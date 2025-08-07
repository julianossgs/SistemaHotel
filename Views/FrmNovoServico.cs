using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Repositories.novoServicoDAO;
using SistemaHotel.Repositories.quartoDAO;
using SistemaHotel.Repositories.servicoDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmNovoServico : Form
    {
        //variáveis globais
        Conexao con = new Conexao();

        public FrmNovoServico()
        {
            InitializeComponent();
        }

        private void FrmNovoServico_Load(object sender, EventArgs e)
        {

            ControlHelper.ClearTextBoxes(txtQuant, txtTotal, txtValor, txtHospede);

            EnableHelper.SetEnabled(false, txtHospede, cBQuartos, txtValor, txtTotal, cBServicos, txtQuant, dateNovoServico);
            ListarNovosServicos();
            dtBuscarServicos.Value = DateTime.Today;
            CarregarCBoxServicos();
            CarregarCBquartos();
            txtValor.Clear();
        }

        //MÉTODOS

        //Carregar ComboBox de serviços
        private void CarregarCBoxServicos()
        {
            try
            {
                servicoDAO dao = new servicoDAO();
                cBServicos.DataSource = dao.ListarServicos();
                cBServicos.DisplayMember = "Servico";
                cBServicos.ValueMember = "IdServico";
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao carregar os serviços: " + ex.Message);
            }
        }

        //Carregar combobox de Quartos
        private void CarregarCBquartos()
        {
            try
            {
                quartoDAO dao = new quartoDAO();
                cBQuartos.DataSource = dao.ListarQuartos();
                cBQuartos.DisplayMember = "Quarto";
                cBQuartos.ValueMember = "IdQuarto";
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao carregar os quartos: " + ex.Message);
            }
        }


        //Método Listar serviços
        private void ListarNovosServicos()
        {
            try
            {
                novoServicoDAO dao = new novoServicoDAO();
                gridNovoServico.DataSource = dao.Listar();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao listar serviços: " + ex.Message);
            }
        }

        //BOTÕES

        //botão NOVO
        private void BtNovo_Click(object sender, EventArgs e)
        {
            btNovo.Enabled = false;
            ControlHelper.ClearTextBoxes(txtQuant, txtTotal, txtValor, txtHospede);
            EnableHelper.SetEnabled(false, btExcluir, btNovo);
            EnableHelper.SetEnabled(true, btSalvar, btAddHospedes, txtHospede, cBQuartos, cBServicos, txtQuant, dateNovoServico);

        }

        //botão SALVAR
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHospede.Text))
            {
                ErroMensageService.ShowError("Insira um Hóspede!");
                btAddHospedes.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuant.Text))
            {
                ErroMensageService.ShowError("Insira uma quantidade!");
                txtQuant.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                ErroMensageService.ShowError("Insira o valor do serviço!");
                txtValor.Focus();
                return;
            }

            try
            {
                NovosServicos servico = new NovosServicos();
                servico.Hospede = txtHospede.Text;
                servico.Servico = cBServicos.Text;
                servico.Quarto = cBQuartos.Text;
                servico.Quantidade = int.Parse(txtQuant.Text);
                servico.Valor = Convert.ToDecimal(txtValor.Text);
                servico.ValorTotal = Convert.ToDecimal(txtQuant.Text) * Convert.ToDecimal(txtValor.Text);

                servico.Funcionario = Globais.nomeUsuario;
                servico.DataCadastro = dateNovoServico.Value;

                novoServicoDAO dao = new novoServicoDAO();

                if (!string.IsNullOrWhiteSpace(Globais.idNovoServico))
                {
                    // ALTERAÇÃO
                    int idServico = Convert.ToInt32(Globais.idNovoServico);
                    dao.Alterar(idServico, servico.DataCadastro, servico.Hospede, servico.Servico, servico.Quarto, servico.Valor, servico.Quantidade, servico.ValorTotal);

                    ControlHelper.ClearTextBoxes(txtQuant, txtTotal, txtValor, txtHospede);

                    SucessoMensageService.ShowSuccess("Serviço alterado com sucesso!");
                }
                else
                {
                    // INSERÇÃO
                    int ultimoId = dao.Inserir(servico);
                    Globais.ultimoIdServico = ultimoId.ToString();

                    // Grava na movimentação
                    dao.InserirMovimentacao("Entrada", "Servico", servico.Valor, servico.Funcionario, ultimoId);

                    ControlHelper.ClearTextBoxes(txtQuant, txtTotal, txtValor, txtHospede);

                    SucessoMensageService.ShowSuccess("Serviço salvo com sucesso!");
                }

                // LimparCampos();
                EnableHelper.SetEnabled(true, btNovo);
                EnableHelper.SetEnabled(false, btSalvar);
                ListarNovosServicos();
                Globais.idNovoServico = ""; // limpa para voltar ao estado padrão
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar serviço: " + ex.Message);
            }

        }

        #region Código não utilizado
        //botão EDITAR
        private void BtEditar_Click(object sender, EventArgs e)
        {

        }

        //botão EXCLUIR
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (Globais.cargoUsuario != "Gerente")
            {
                ErroMensageService.ShowError("Somente um Gerente pode excluir um serviço!");
                return;
            }

            if (MessageBox.Show("Deseja excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(Globais.idNovoServico);
                    novoServicoDAO dao = new novoServicoDAO();
                    dao.Excluir(id);
                    dao.ExcluirMovimentacao(id, "Servico");

                    SucessoMensageService.ShowSuccess("Registro excluído com sucesso!");
                    btNovo.Enabled = true;
                    btExcluir.Enabled = false;
                    EnableHelper.SetEnabled(true, btNovo);
                    EnableHelper.SetEnabled(false, btNovo, btAddHospedes, txtHospede, cBQuartos, cBServicos, txtQuant, dateNovoServico);
                    //LimparCampos();
                    // HabilitarCampos(false);
                    ListarNovosServicos();
                }
                catch (Exception ex)
                {
                    ErroMensageService.ShowError("Erro ao excluir serviço: " + ex.Message);
                }
            }
        }
        #endregion

        //botão HOSPEDE
        //buscando o hospede através do FrmHospede
        private void BtAddHospedes_Click(object sender, EventArgs e)
        {

            Globais.chamadaHospedes = "hospedes";

            using (FrmHospedes frmHospedes = new FrmHospedes())
            {
                var resultado = frmHospedes.ShowDialog(); // Modal

                if (resultado == DialogResult.OK && !string.IsNullOrEmpty(frmHospedes.NomeSelecionado))
                {
                    txtHospede.Text = frmHospedes.NomeSelecionado;
                }
            }

            Globais.chamadaHospedes = "";

        }

        private void FrmNovoServico_Activated(object sender, EventArgs e)
        {
            txtHospede.Text = Globais.nomeHospede;
        }

        //evento p/ selecionar os dados do comboBox de Serviços
        private void CBServicos_SelectedValueChanged(object sender, EventArgs e)
        {
            con.AbrirCon();

            MySqlCommand CmdVerificar = new MySqlCommand();
            CmdVerificar.Connection = con.Con;
            CmdVerificar.CommandText = "spListarServicosValor";
            CmdVerificar.CommandType = CommandType.StoredProcedure;
            CmdVerificar.Parameters.AddWithValue("@pServico", cBServicos.Text);

            MySqlDataReader reader;
            reader = CmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Globais.valorServico = Convert.ToString(reader["Valor"]);

                }
                txtValor.Text = Globais.valorServico;
            }

            con.FecharCon();
        }

        //Grid
        private void GridNovoServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //botão RELATÓRIO
        private void BtRelatorios_Click(object sender, EventArgs e)
        {
            btRelatorios.Enabled = false;
            // FrmRelComprovanteServicos frm = new FrmRelComprovanteServicos();
            // frm.Show();
        }

        //botão SELECIONAR NOVO SERVIÇO PARA EDIÇÃO/EXCLUSÃO
        private void btnSelecionarNovoServicoEdicao_Click(object sender, EventArgs e)
        {
            if (gridNovoServico.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma linha no grid para editar ou excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show("Deseja ALTERAR este serviço? (Sim) ou EXCLUIR? (Não)", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (resposta == DialogResult.Cancel) return;

            // Habilita os campos para edição
            // Preenche os campos com os dados da linha selecionada
            dateNovoServico.Value = Convert.ToDateTime(gridNovoServico.CurrentRow.Cells["Data"].Value);
            txtHospede.Text = gridNovoServico.CurrentRow.Cells["Hospede"].Value.ToString();
            cBServicos.Text = gridNovoServico.CurrentRow.Cells["Servico"].Value.ToString();
            cBQuartos.Text = gridNovoServico.CurrentRow.Cells["Quarto"].Value.ToString();
            txtQuant.Text = gridNovoServico.CurrentRow.Cells["Quant"].Value.ToString();
            txtValor.Text = gridNovoServico.CurrentRow.Cells["Valor"].Value.ToString();
            txtTotal.Text = gridNovoServico.CurrentRow.Cells["ValorTotal"].Value.ToString();
            // Globais.idNovoServico = gridNovoServico.CurrentRow.Cells[0].Value.ToString();

            Globais.idNovoServico = gridNovoServico.CurrentRow.Cells["IdNovoServico"].Value.ToString();


            if (resposta == DialogResult.Yes) // ALTERAR
            {
                EnableHelper.SetEnabled(false, btNovo, txtValor);
                EnableHelper.SetEnabled(true, btAddHospedes, btSalvar, cBServicos, cBQuartos, txtQuant, dateNovoServico);

                MessageBox.Show("ALTERE os campos desejados e clique em 'Salvar' para confirmar a alteração.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHospede.Text = gridNovoServico.CurrentRow.Cells["Hospede"].Value.ToString();


            }


            else if (resposta == DialogResult.No) // EXCLUIR
            {
                DialogResult confirma = MessageBox.Show("Tem certeza que deseja excluir este serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirma == DialogResult.Yes)
                {
                    int idExcluir = Convert.ToInt32(Globais.idNovoServico);
                    novoServicoDAO dao = new novoServicoDAO();
                    dao.Excluir(idExcluir);
                    SucessoMensageService.ShowSuccess("Serviço excluído com sucesso!");
                    ListarNovosServicos();

                }
            }
        }

        // Evento para validar a entrada de números no campo Quantidade
        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }

        // Evento para validar a entrada de números no campo Valor
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }

        //
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }
    }
}
