using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Repositories.vendaDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;


namespace SistemaHotel.Views
{
    public partial class FrmVendas : Form
    {
        //Variáveis globais
        Conexao con = new Conexao();

        VendasDAO _dao = new VendasDAO();

        #region Variáveis globais
        string totalVenda;//var usada no método TotalizarEstoque
        string IdDetVenda;//var usada no método Remover itens dos detalhes da venda
        string idProduto;//var usada p/ devolver o produto ao estoque
        string exclusaoVenda;

        string IdVenda;
        #endregion

        #region Código do carrinho de compras
        private int qtd;
        private decimal valorUnit;
        private decimal subTotal, total;

        //Carrinho
        DataTable carrinho = new DataTable();

        Hospede Hospede = new Hospede();

        #endregion



        public FrmVendas()
        {
            InitializeComponent();

            InicializarCarrinho();

        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            ListarVendas();
            EnableHelper.SetEnabled(false, btSalvar, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens, btExcluir, txtQuant);
            ControlHelper.ClearAndFocus(txtQuant);

            // Apenas garante que o grid está ligado à tabela
            GridViewVendas.DataSource = carrinho;

            totalVenda = "0";
            dtBuscarVendas.Value = DateTime.Today;

        }

        //************* MÉTODOS ************************



        /// Inicializa o DataTable carrinho e formata o grid.
        private void InicializarCarrinho()
        {
            carrinho = new DataTable("Carrinho");

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preco", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));
            carrinho.Columns.Add("Funcionario", typeof(string));

            GridViewVendas.AutoGenerateColumns = true;
            GridViewVendas.DataSource = carrinho;

            FormatarGrid();
        }

        /// Configura formatação visual do DataGridView.
        /// </summary>
        private void FormatarGrid()
        {
            GridViewVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridViewVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewVendas.MultiSelect = false;
            GridViewVendas.AllowUserToAddRows = false;
            GridViewVendas.ReadOnly = true;


            GridViewVendas.Columns["Produto"].Width = 230;
            GridViewVendas.Columns["Qtd"].Width = 80;
            GridViewVendas.Columns["Preco"].Width = 100;
            GridViewVendas.Columns["Subtotal"].Width = 120;
            GridViewVendas.Columns["Funcionario"].Width = 200;


            GridViewVendas.Columns["Preco"].DefaultCellStyle.Format = "C2";
            GridViewVendas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";

            GridViewVendas.Columns["Funcionario"].DisplayIndex = GridViewVendas.Columns.Count - 1;


        }


        #region Métodos de AddItens ao carrinho,Remover e Atualizar total
        private void AdicionarItemAoCarrinho(int idProduto, string nome, int quantidade, decimal precoUnit)
        {
            decimal subtotal = quantidade * precoUnit;
            carrinho.Rows.Add(idProduto, nome, quantidade, precoUnit, subtotal);
            carrinho.AcceptChanges();
            AtualizarTotal();
        }

        private void RemoverItemSelecionadoDoCarrinho()
        {
            if (GridViewVendas.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item no carrinho para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int indice = GridViewVendas.CurrentRow.Index;
            if (indice < 0 || indice >= carrinho.Rows.Count) return;

            carrinho.Rows.RemoveAt(indice);
            carrinho.AcceptChanges();
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            // Recalcula a soma a partir do DataTable (robusto quando há remoções)
            object soma = carrinho.Compute("SUM(Subtotal)", null);
            total = (soma == DBNull.Value) ? 0m : Convert.ToDecimal(soma);

            // Exibição
            lblTotalVendas.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", total);

            // Manter compatibilidade com código legado (string totalVenda)
            totalVenda = total.ToString("F2", CultureInfo.InvariantCulture);
        }
        #endregion






        //Método de listar vendas
        private void ListarVendas()
        {

            try
            {

                con.AbrirCon();
                MySqlCommand Cmd9 = new MySqlCommand();
                Cmd9.Connection = con.Con;
                Cmd9.CommandText = "spListarVendas";
                Cmd9.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = Cmd9
                };
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                GridViewVendas.DataSource = Dt;
                con.FecharCon();

                //gridDetalhesVendas.Visible = false;
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao Listar as Vendas: " + ex.Message);
            }
        }

        //Método de Listar detalhes da venda
        private void ListarDetalhesVenda()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();
                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spListarDetalhesVendas";
                Cmd3.CommandType = CommandType.StoredProcedure;
                Cmd3.Parameters.AddWithValue("@pId_Venda", "0");
                Cmd3.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd3;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                //gridDetalhesVendas.DataSource = Dt;

                con.FecharCon();

                //gridDetalhesVendas.Visible = true;
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao Listar os Detalhes da Venda: " + ex.Message);
            }

        }

        //Método de buscar os detalhes da venda
        private void BuscarDetalhesVenda()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd10 = new MySqlCommand();
                Cmd10.Connection = con.Con;
                Cmd10.CommandText = "spBuscarDetalhesVenda";
                Cmd10.CommandType = CommandType.StoredProcedure;
                Cmd10.Parameters.AddWithValue("@pId_Venda", IdVenda);
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd10;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                //gridDetalhesVendas.DataSource = Dt;

                con.FecharCon();
                //gridDetalhesVendas.Visible = true;
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao buscar detalhes da venda: " + ex.Message);
            }
        }




        //Método de excluir vendas
        private void ExcluirVendas()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd13 = new MySqlCommand();
                Cmd13.Connection = con.Con;
                Cmd13.CommandText = "spExcluirVendas";
                Cmd13.CommandType = CommandType.StoredProcedure;
                Cmd13.Parameters.AddWithValue("@pStatus", "CANCELADA");
                Cmd13.Parameters.AddWithValue("@pIdVenda", IdVenda);
                Cmd13.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao excluir a venda: " + ex.Message);
            }
        }

        //Método de excluir movimentações
        private void ExcluirMovimentacoes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd14 = new MySqlCommand();
                Cmd14.Connection = con.Con;
                Cmd14.CommandText = "spExcluirMovimentacoes";
                Cmd14.CommandType = CommandType.StoredProcedure;
                Cmd14.Parameters.AddWithValue("@pIdVenda", IdVenda);
                Cmd14.Parameters.AddWithValue("@pMovimento", "Venda");
                Cmd14.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao excluir as movimentações: " + ex.Message);
            }
        }





        //***********************FIM DOS MÉTODOS**************


        //***********************BOTÕES***********************
        //botão Novo
        private void BtNovo_Click(object sender, EventArgs e)
        {
            ControlHelper.ClearAndFocus(txtProduto, txtHospedes, txtQuant, txtEstoque, txtVrVenda);
            EnableHelper.SetEnabled(false, btNovo, btExcluir);
            EnableHelper.SetEnabled(true, btSalvar, txtQuant, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens);
            lblTotalVendas.Text = "0";

        }

        //botão Salvar Vendas//botão Pagamento
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dtVendas.IsValidDate())
                {

                    return;
                }

                if (txtHospedes.Text.Trim() == string.Empty)
                {
                    ErroMensageService.ShowError("Selecione um Hóspede!");
                    ControlHelper.ClearAndFocus(btAddHospedes);
                    return;
                }

                if (lblTotalVendas.Text == "0")
                {
                    ErroMensageService.ShowError("Insira um Produto para a venda!");
                    return;
                }

                //Passagem de parâmetros p/ o FrmPagamentos
                DateTime dataAtual = dtVendas.Value;
                FrmPagamentos telaPagto = new FrmPagamentos(Hospede, carrinho, dataAtual);
                telaPagto.txtTotal.Text = lblTotalVendas.Text.ToString();
                telaPagto.ShowDialog(); // Modal

                //Método p/ salvar a venda
                // _dao.InserirVendas();

                //método de ultimo IdVenda
                // _dao.UltimoIdVenda();

                //Método p/ salvar a movimentação no Frm de movimentações
                // _dao.InserirMovimentacoes();

                //método de relacionar itens da venda
                // _dao.RelacionarItensVendas();

                SucessoMensageService.ShowSuccess("Venda salva com sucesso!");

                EnableHelper.SetEnabled(true, btSalvar, btNovo, txtQuant, btAddHospedes, btAddProdutos, btAddItens);
                ControlHelper.ClearAndFocus(txtQuant);
                EnableHelper.SetEnabled(false, txtQuant, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens, btExcluir, btSalvar);
                ListarVendas();
                // totalVenda = "0";
                btFecharGrid.Visible = false;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        //botão Excluir/Cancelar as vendas
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (totalVenda == "0")
            {
                var result = MessageBox.Show("Deseja cancelar a venda?", "Cancelar a Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    //Método de excluir as vendas
                    ExcluirVendas();

                    //Método de excluir as movimentações no Frm de movimentações
                    ExcluirMovimentacoes();

                    MessageBox.Show("Venda cancelada com sucesso!", "Registro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableHelper.SetEnabled(true, btNovo);
                    ControlHelper.ClearTextBoxes(txtEstoque, txtHospedes, txtQuant, txtVrVenda, txtProduto);
                    EnableHelper.SetEnabled(false, btSalvar, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens, btExcluir, txtQuant);
                    ListarVendas();
                    totalVenda = "0";
                    exclusaoVenda = "";

                }

            }
            else
            {
                ErroMensageService.ShowError("É necessário excluir os itens da venda para Cancelar!");
            }

        }

        //botão de adicionar os hospedes
        private void BtAddHospedes_Click(object sender, EventArgs e)
        {
            Globais.chamadaHospedes = "hospedes";

            using (FrmHospedes frmHospedes = new FrmHospedes())
            {
                var resultado = frmHospedes.ShowDialog(); // Modal

                if (resultado == DialogResult.OK && !string.IsNullOrEmpty(frmHospedes.NomeSelecionado))
                {
                    txtHospedes.Text = frmHospedes.NomeSelecionado;
                }
            }

            Globais.chamadaHospedes = "";

        }

        //botão para chamar o Frm de Produtos p/ escolher um produto
        private void BtAddProdutos_Click(object sender, EventArgs e)
        {
            Globais.chamadaProdutos = "vendas";

            using (FrmProdutos frmProdutos = new FrmProdutos())
            {
                var resultado = frmProdutos.ShowDialog(); // Modal

                if (resultado == DialogResult.OK && !string.IsNullOrEmpty(frmProdutos.NomeProdutoSelecionado))
                {
                    // Atribui os valores selecionados aos campos do formulário
                    Globais.idProduto = frmProdutos.IdProdutoSelecionado.ToString();
                    txtProduto.Text = frmProdutos.NomeProdutoSelecionado;
                    txtEstoque.Text = frmProdutos.EstoqueSelecionado.ToString();
                    txtVrVenda.Text = frmProdutos.ValorCompraSelecionado.ToString();

                }
            }

            Globais.chamadaProdutos = "";

        }


        //botão de add itens(produtos) a venda
        private void BtAddItens_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validação de quantidade
                if (string.IsNullOrWhiteSpace(txtQuant.Text))
                {
                    ErroMensageService.ShowError("Insira uma Quantidade! Campo vazio!");
                    ControlHelper.ClearAndFocus(txtQuant, txtQuant);
                    return;
                }

                if (!int.TryParse(txtQuant.Text, out int quantidade) || quantidade <= 0)
                {
                    ErroMensageService.ShowError("Quantidade inválida!");
                    ControlHelper.ClearAndFocus(txtQuant, txtQuant);
                    return;
                }

                // 2. Recupera valores
                int produtoId = Convert.ToInt32(Globais.idProduto);
                decimal valorUnit = Convert.ToDecimal(txtVrVenda.Text, CultureInfo.InvariantCulture);

                // 3. Buscar estoque atual diretamente do banco
                int estoqueAtual;
                con.AbrirCon();
                using (MySqlCommand cmdEstoque = new MySqlCommand("spObterEstoque", con.Con))
                {
                    cmdEstoque.CommandType = CommandType.StoredProcedure;
                    cmdEstoque.Parameters.AddWithValue("pIdProduto", produtoId);

                    object result = cmdEstoque.ExecuteScalar();
                    estoqueAtual = result != null ? Convert.ToInt32(result) : 0;
                }

                // 4. Valida estoque
                if (estoqueAtual < quantidade)
                {
                    ErroMensageService.ShowError("Não há produtos suficientes no estoque!");
                    ControlHelper.ClearAndFocus(txtQuant, txtQuant);
                    return;
                }

                // 5. Atualiza estoque no banco
                using (MySqlCommand cmdUpdate = new MySqlCommand("spAtualizarEstoque", con.Con))
                {
                    cmdUpdate.CommandType = CommandType.StoredProcedure;
                    cmdUpdate.Parameters.AddWithValue("@pIdProduto", produtoId);
                    cmdUpdate.Parameters.AddWithValue("@pEstoque", estoqueAtual - quantidade);
                    cmdUpdate.ExecuteNonQuery();
                }
                con.FecharCon();

                // 6. Adiciona item ao carrinho
                decimal subTotal = quantidade * valorUnit;
                total += subTotal;

                carrinho.Rows.Add(
                    produtoId,          // Código do produto
                    txtProduto.Text,    // Nome do produto
                    quantidade,         // Quantidade
                    valorUnit,          // Preço unitário
                    subTotal,           // Subtotal
                    Globais.nomeUsuario // Funcionário
                );

                lblTotalVendas.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", total);

                // 7. Limpa campos
                ControlHelper.ClearAndFocus(txtQuant, txtProduto, txtVrVenda);
                txtEstoque.Text = "0";
                IdDetVenda = "";

                // 8. Atualiza lista
                ListarDetalhesVenda();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao adicionar item: " + ex.Message);
                con.FecharCon();
            }
        }


        //botão Remover itens da venda
        private void BtRemoverItens_Click(object sender, EventArgs e)
        {
            //if (IdDetVenda == "")
            //{
            //    ErroMensageService.ShowError("Selecione um Produto para remover");
            //    return;
            //}


            decimal produtoRemovido = decimal.Parse(GridViewVendas.CurrentRow.Cells[4].Value.ToString());

            int indice = GridViewVendas.CurrentRow.Index;
            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= produtoRemovido;
            lblTotalVendas.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", total);
            SucessoMensageService.ShowSuccess("Produto removido com sucesso!");

            //Método de remover/deletar itens da venda

            //con.AbrirCon();
            //MySqlCommand Cmdr = new MySqlCommand();
            //Cmdr.Connection = con.Con;
            //Cmdr.CommandText = "spRemoverItenVenda";
            //Cmdr.CommandType = CommandType.StoredProcedure;
            //Cmdr.Parameters.AddWithValue("@pIdDetalhe", IdDetVenda);

            //Cmdr.ExecuteNonQuery();
            //con.FecharCon();


            //devolver a quantidade ao estoque
            con.AbrirCon();
            MySqlCommand Cmdd = new MySqlCommand();
            Cmdd.Connection = con.Con;
            Cmdd.CommandText = "spDevolverQuantEstoque";
            Cmdd.CommandType = CommandType.StoredProcedure;
            Cmdd.Parameters.AddWithValue("@pIdProduto", idProduto);
            Cmdd.Parameters.AddWithValue("@pEstoque", Convert.ToDecimal(txtEstoque.Text) + Convert.ToDecimal(txtQuant.Text));
            Cmdd.ExecuteNonQuery();
            con.FecharCon();

            //Método de totalizar as vendas(Subtrair)
            //decimal total;
            //total = Convert.ToDecimal(totalVenda) - Convert.ToDecimal(txtVrVenda.Text) * Convert.ToDecimal(txtQuant.Text);
            //totalVenda = total.ToString();
            //lblTotalVendas.Text = string.Format("{0:c2}", total);

            txtQuant.Clear();
            txtProduto.Clear();
            txtEstoque.Text = "0";
            txtVrVenda.Clear();
            IdDetVenda = "";

            if (exclusaoVenda == "1")
            {
                BuscarDetalhesVenda();
            }
            else
            {
                ListarDetalhesVenda();
            }
        }


        //evento que ocorre antes do fechamento do formulário
        //para não fechar o FRM com itens na venda
        private void FrmVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (totalVenda != "0")
            {
                ErroMensageService.ShowError("Finalize a venda antes de sair!");
                e.Cancel = true;
            }

        }

        //Grid de vendas
        //private void GridVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = GridViewVendas.Rows[e.RowIndex];

        //        IdVenda = row.Cells[0].Value?.ToString();
        //        Globais.IdVenda = IdVenda;

        //        totalVenda = row.Cells[2].Value?.ToString();
        //        lblTotalVendas.Text = string.Format("{0:c2}", totalVenda);

        //        BuscarDetalhesVenda();
        //        btFecharGrid.Visible = true;
        //        btAddItens.Enabled = true;
        //        btRemoverItens.Enabled = true;
        //        btExcluir.Enabled = true;
        //        exclusaoVenda = "1";
        //        btRel.Enabled = true;
        //    }

        //}

        //botão p/ fechar o grid de Detalhes de vendas
        private void BtFecharGrid_Click(object sender, EventArgs e)
        {
            //gridDetalhesVendas.Visible = false;
            btFecharGrid.Visible = false;
            totalVenda = "0";
            lblTotalVendas.Text = "0";
        }



        //Evento que busca as vendas por data
        private void DtBuscarVendas_ValueChanged(object sender, EventArgs e)
        {
            _dao.BuscarVendasPorData(Convert.ToDateTime(dtBuscarVendas.Text));
        }

        private void BtRel_Click(object sender, EventArgs e)
        {
            // FrmRelComprovante frmRelComprovante = new FrmRelComprovante();
            // frmRelComprovante.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Evento de validação dos campos para somente números inteiros
        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }



    }

}

