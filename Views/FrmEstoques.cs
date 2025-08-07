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
                string.IsNullOrWhiteSpace(txtQuant.Text))
            {
                MessageBox.Show("Todos os campos são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validação de formato numérico com tentativa de conversão segura
            if (!decimal.TryParse(txtEstoque.Text, out decimal preco))
            {
                MessageBox.Show("Digite um valor válido para o preço.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuant.Text, out int quantidade))
            {
                MessageBox.Show("Digite uma quantidade válida (somente números inteiros).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Atualiza o estoque e valor de compra do produto fornecedor
                int idProduto = int.Parse(Globais.idProduto);
                decimal estoqueAtual = Convert.ToDecimal(txtEstoque.Text);
                decimal quant = Convert.ToDecimal(txtQuant.Text);
                decimal valorCompra = Convert.ToDecimal(txtVrCompra.Text);
                int idFornecedor = Convert.ToInt32(cBFornecedor.SelectedValue);

                _dao.AlterarProdutoFornecedor(idProduto, estoqueAtual, quantidade, valorCompra, idFornecedor);

                // Insere o gasto da compra de produtos
                string descricao = "Compra de Produtos";
                string funcionario = Globais.nomeUsuario;
                decimal valorGasto = valorCompra * quantidade;
                _dao.InserirGasto(descricao, funcionario, valorGasto);

                // Recupera o último Id do gasto
                string ultimoIdGasto = _dao.RecuperarUltimoIdGasto();
                Globais.ultimoIdGasto = ultimoIdGasto;

                // Insere movimentação de gasto
                _dao.InserirMovimentacaoGasto("Saída", "Gastos", valorGasto, funcionario, ultimoIdGasto);

                SucessoMensageService.ShowSuccess("Lançamento feito com sucesso!");
                ControlHelper.ClearAndFocus(btAddProdutos, txtEstoque, txtQuant, txtVrCompra, txtProduto);
                EnableHelper.SetEnabled(false, txtProduto, txtEstoque, txtQuant, txtVrCompra, cBFornecedor, btSalvar);

            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao salvar: " + ex.Message);
            }
        }


        //evento que ativa o formulário p/ buscar de informações
        private void FrmEstoques_Activated(object sender, EventArgs e)
        {
            //variáveis globais
            //está passando também o IdProduto,que não é necessário mostrar em tela

            txtEstoque.Text = Globais.estoqueProduto;
            txtProduto.Text = Globais.nomeProduto;
            txtVrCompra.Text = Globais.VrCompra;
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
