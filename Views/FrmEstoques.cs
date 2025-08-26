using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Repositories.estoqueDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmEstoques : Form
    {
        private estoqueDAO _dao = new estoqueDAO();

        public FrmEstoques()
        {
            InitializeComponent();
        }


        private void FrmEstoques_Load(object sender, EventArgs e)
        {
            EnableHelper.SetEnabled(false, txtProduto, txtEstoque, txtQuant, txtVrCompra, cBFornecedor, btSalvar);
            PreencherCBoxFornecedor();
        }


        //carregar combox de fornecedores
        private void PreencherCBoxFornecedor()
        {
            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd1 = new MySqlCommand
            {
                Connection = con.Con,
                CommandText = "spListarFornecedores",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = Cmd1
            };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBFornecedor.DataSource = Dt;
            cBFornecedor.ValueMember = "IdFornec";
            cBFornecedor.DisplayMember = "Nome";
            con.FecharCon();
        }

        //botão de add produtos
        private void BtAddProdutos_Click(object sender, EventArgs e)
        {
            EnableHelper.SetEnabled(true, cBFornecedor, txtVrCompra, txtQuant, btSalvar);
            EnableHelper.SetEnabled(false, txtProduto);
            ControlHelper.ClearAndFocus(btAddProdutos, txtEstoque, txtQuant, txtVrCompra, txtProduto);

            Globais.chamadaProdutos = "estoque"; //variável global

            //abrindo o Frm de Produtos
            FrmProdutos frm = new FrmProdutos();
            frm.Show();
        }

        //botão salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text) ||
                string.IsNullOrWhiteSpace(txtEstoque.Text) ||
                string.IsNullOrWhiteSpace(txtQuant.Text) ||
                string.IsNullOrWhiteSpace(txtVrCompra.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtVrCompra.Text, out decimal precoUnitario))
            {
                MessageBox.Show("Digite um valor válido para o preço de compra.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuant.Text, out int quantidadeCompra))
            {
                MessageBox.Show("Digite uma quantidade válida (somente números inteiros).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idProduto = int.Parse(Globais.idProduto);
                int idFornecedor = Convert.ToInt32(cBFornecedor.SelectedValue);

                // 1️⃣ Busca estoque atual do banco
                decimal estoqueAtual = _dao.ObterEstoque(idProduto);

                // 2️⃣ Novo estoque
                decimal novoEstoque = estoqueAtual + quantidadeCompra;

                // 3️⃣ Atualiza produto e fornecedor no banco
                _dao.AlterarProdutoFornecedor(idProduto, novoEstoque, quantidadeCompra, precoUnitario, idFornecedor);

                // 4️⃣ Busca valor total anterior de compras desse produto
                //decimal totalAnterior = _dao.ObterValorTotalCompras(idProduto); // Novo método na DAO

                // 5️⃣ Calcula o valor total desta compra
                //decimal valorAtualCompra = quantidadeCompra * precoUnitario;
                //decimal totalFinal = totalAnterior + valorAtualCompra;

                //txtVrCompra.Text = totalFinal.ToString("C2");
                decimal valorAtualCompra = quantidadeCompra * precoUnitario;

                // 6️⃣ Registra gasto da compra
                string descricao = "Compra de Produtos";
                string funcionario = Globais.nomeUsuario;
                _dao.InserirGasto(descricao, funcionario, valorAtualCompra);

                // 7️⃣ Pega último ID do gasto e insere movimentação
                string ultimoIdGasto = _dao.RecuperarUltimoIdGasto();
                Globais.ultimoIdGasto = ultimoIdGasto;
                _dao.InserirMovimentacaoGasto("Saída", "Gastos", valorAtualCompra, funcionario, ultimoIdGasto);

                SucessoMensageService.ShowSuccess("Lançamento feito com sucesso! O Formulário será fechado após a confirmação do lançamento!!!");
                FrmEstoques.ActiveForm.Close();
                LogService.LogSucesso("Lançamento de estoque realizado com sucesso.");

                //ControlHelper.ClearAndFocus(btAddProdutos, txtEstoque, txtQuant, txtVrCompra, txtProduto);
                //EnableHelper.SetEnabled(false, txtProduto, txtEstoque, txtQuant, txtVrCompra, cBFornecedor, btSalvar);
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message);
            }

        }


        //evento que ativa o formulário p/ buscar de informações
        private void FrmEstoques_Activated(object sender, EventArgs e)
        {


            // Preenche os campos com valores vindos do FrmProdutos
            txtEstoque.Text = Globais.estoqueProduto;
            txtProduto.Text = Globais.nomeProduto;
            txtVrCompra.Text = Globais.VrCompra;

            // Controle de campos e botões baseado na origem da chamada
            if (Globais.chamadaProdutos == "produtos") // Veio do FrmProdutos
            {
                EnableHelper.SetEnabled(false, txtEstoque);
                ControlHelper.ClearTextBoxes(txtVrCompra);
                EnableHelper.SetEnabled(true, txtQuant, cBFornecedor, txtVrCompra, btSalvar);
                btAddProdutos.Visible = false;
            }
            else // Veio do próprio FrmEstoques
            {
                EnableHelper.SetEnabled(true, btAddProdutos);
                EnableHelper.SetEnabled(false, cBFornecedor, txtEstoque, txtQuant, btSalvar);
                btAddProdutos.Visible = true;
            }
        }


        //Eventos de validações nos campos
        private void txtVrCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }


        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }


    }
}
