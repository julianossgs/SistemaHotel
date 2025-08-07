using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
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

        string totalVenda;//var usada no método TotalizarEstoque
        string IdDetVenda;//var usada no método Remover itens dos detalhes da venda
        string idProduto;//var usada p/ devolver o produto ao estoque
        string exclusaoVenda;
        string ultimoIdVenda;
        string IdVenda;



        public FrmVendas()
        {
            InitializeComponent();

        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            ListarVendas();
            EnableHelper.SetEnabled(false, btSalvar, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens, btExcluir, txtQuant);
            ControlHelper.ClearAndFocus(txtQuant);
            FormatarDGVendas();
            FormatarDGDetalhesVenda();
            totalVenda = "0";
            dtBuscarVendas.Value = DateTime.Today;

        }

        //************* MÉTODOS ************************


        private void LimparCampos()
        {
            txtProduto.Clear();
            txtHospedes.Clear();
            txtQuant.Clear();
            txtEstoque.Clear();
            lblTotalVendas.Text = "0";
            txtVrVenda.Clear();
        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {
                txtQuant.Enabled = true;
                txtQuant.Focus();
                btAddHospedes.Enabled = true;
                btAddProdutos.Enabled = true;
                btRemoverItens.Enabled = true;
                btAddItens.Enabled = true;
                btExcluir.Enabled = true;
                btSalvar.Enabled = true;

            }
            else
            {
                txtQuant.Enabled = false;
                txtQuant.Focus();
                btAddHospedes.Enabled = false;
                btAddProdutos.Enabled = false;
                btRemoverItens.Enabled = false;
                btAddItens.Enabled = false;
                btExcluir.Enabled = false;
                btSalvar.Enabled = false;

            }
        }

        //Método de formatar data grid de vendas
        private void FormatarDGVendas()
        {
            gridVendas.Columns[0].HeaderText = "Nº da Venda";
            gridVendas.Columns[1].HeaderText = "Data/Venda";
            gridVendas.Columns[2].HeaderText = "Total da Venda";
            gridVendas.Columns[3].HeaderText = "Status";
            gridVendas.Columns[4].HeaderText = "Funcionário";

            gridVendas.Columns[2].DefaultCellStyle.Format = "C2";
            gridVendas.Columns[0].Width = 110;
            gridVendas.Columns[1].Width = 110;
            gridVendas.Columns[2].Width = 110;
            gridVendas.Columns[3].Width = 130;
            gridVendas.Columns[4].Width = 130;

        }

        //Método de formatar data grid de detalhes de vendas
        private void FormatarDGDetalhesVenda()
        {
            gridDetalhesVendas.Columns[0].HeaderText = "Id";
            gridDetalhesVendas.Columns[1].HeaderText = "Cód/Venda";
            gridDetalhesVendas.Columns[2].HeaderText = "Produto";
            gridDetalhesVendas.Columns[3].HeaderText = "Quant";
            gridDetalhesVendas.Columns[4].HeaderText = "Unit";
            gridDetalhesVendas.Columns[5].HeaderText = "Total";
            gridDetalhesVendas.Columns[6].HeaderText = "Funcionário";
            gridDetalhesVendas.Columns[7].HeaderText = "Id Produto";

            gridDetalhesVendas.Columns[4].DefaultCellStyle.Format = "C2";
            gridDetalhesVendas.Columns[5].DefaultCellStyle.Format = "C2";

            gridDetalhesVendas.Columns[0].Visible = false;
            gridDetalhesVendas.Columns[1].Visible = false;
            gridDetalhesVendas.Columns[7].Visible = false;
        }

        //Método atualizar estoque(abater no estoque)
        private void AtualizarEstoque()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd6 = new MySqlCommand();
                Cmd6.Connection = con.Con;
                Cmd6.CommandText = "spAtualizarEstoque";
                Cmd6.CommandType = CommandType.StoredProcedure;
                Cmd6.Parameters.AddWithValue("@pIdProduto", Globais.idProduto);
                Cmd6.Parameters.AddWithValue("@pEstoque", Convert.ToDecimal(txtEstoque.Text) - Convert.ToDecimal(txtQuant.Text));
                Cmd6.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                SucessoMensageService.ShowSuccess("Erro ao atualizar o estoque: " + ex.Message);
            }

        }

        //Método p/ devolver quantidade ao estoque
        private void DevolverQuantEstoque()
        {

            con.AbrirCon();
            MySqlCommand Cmd5 = new MySqlCommand();
            Cmd5.Connection = con.Con;
            Cmd5.CommandText = "spDevolverQuantEstoque";
            Cmd5.CommandType = CommandType.StoredProcedure;
            Cmd5.Parameters.AddWithValue("@pIdProduto", idProduto);
            Cmd5.Parameters.AddWithValue("@pEstoque", Convert.ToDecimal(txtEstoque.Text) + Convert.ToDecimal(txtQuant.Text));
            Cmd5.ExecuteNonQuery();
            con.FecharCon();
        }

        //Método p/ recuper o último IdVenda
        private void UltimoIdVenda()
        {

            con.AbrirCon();
            MySqlCommand Cmd4 = new MySqlCommand();
            Cmd4.Connection = con.Con;
            Cmd4.CommandText = "spUltimoIdVenda";
            Cmd4.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader;
            reader = Cmd4.ExecuteReader();

            if (reader.HasRows)
            {
                //extraindo informações da consulta
                while (reader.Read())
                {
                    ultimoIdVenda = reader.GetInt32("IdVenda").ToString();

                }

            }

            con.FecharCon();
        }

        //Método de Relacionar itens com a venda
        private void RelacionarItensVendas()
        {

            con.AbrirCon();
            MySqlCommand Cmd7 = new MySqlCommand();
            Cmd7.Connection = con.Con;
            Cmd7.CommandText = "spRelacionarItensVendas";
            Cmd7.CommandType = CommandType.StoredProcedure;
            Cmd7.Parameters.AddWithValue("@pIdDetalhe", 1);
            Cmd7.Parameters.AddWithValue("@pId_Venda", ultimoIdVenda);
            Cmd7.ExecuteNonQuery();
            con.FecharCon();
        }

        //Método de remover item das vendas
        private void RemoverItenVenda()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd8 = new MySqlCommand();
                Cmd8.Connection = con.Con;
                Cmd8.CommandText = "spRemoverItenVenda";
                Cmd8.CommandType = CommandType.StoredProcedure;
                Cmd8.Parameters.AddWithValue("@pIdDetalhe", IdDetVenda);

                Cmd8.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao remover item da venda: " + ex.Message);
            }

        }



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
                gridVendas.DataSource = Dt;
                con.FecharCon();

                gridDetalhesVendas.Visible = false;
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
                gridDetalhesVendas.DataSource = Dt;

                con.FecharCon();

                gridDetalhesVendas.Visible = true;
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
                gridDetalhesVendas.DataSource = Dt;

                con.FecharCon();
                gridDetalhesVendas.Visible = true;
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao buscar detalhes da venda: " + ex.Message);
            }
        }

        //Método de inserir/salvar vendas
        private void InserirVendas()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd11 = new MySqlCommand();
                Cmd11.Connection = con.Con;
                Cmd11.CommandText = "spInserirVendas";
                Cmd11.CommandType = CommandType.StoredProcedure;
                Cmd11.Parameters.AddWithValue("@pValorTotal", Convert.ToDecimal(totalVenda));
                Cmd11.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                Cmd11.Parameters.AddWithValue("@pStatus", "EFETUADA");
                ultimoIdVenda = Convert.ToString(Cmd11.ExecuteScalar());

                //Cmd11.ExecuteNonQuery();
                con.FecharCon();

            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao salvar vendas: " + ex.Message);
            }
        }

        //Método de inserir movimentações
        private void InserirMovimentacoes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd12 = new MySqlCommand();
                Cmd12.Connection = con.Con;
                Cmd12.CommandText = "spInserirMovimentacoes";
                Cmd12.CommandType = CommandType.StoredProcedure;
                Cmd12.Parameters.AddWithValue("@pTipo", "Entrada");
                Cmd12.Parameters.AddWithValue("@pMovimento", "Venda");
                Cmd12.Parameters.AddWithValue("@pValor", Convert.ToDecimal(totalVenda));
                Cmd12.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                Cmd12.Parameters.AddWithValue("@pId_Movimento", ultimoIdVenda);
                Cmd12.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao inserir movimentações: " + ex.Message);
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

        //Método que busca vendas por data
        private void BuscarVendaData()
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd15 = new MySqlCommand();
                Cmd15.Connection = con.Con;
                Cmd15.CommandText = "spBuscarVendaData";
                Cmd15.CommandType = CommandType.StoredProcedure;
                Cmd15.Parameters.AddWithValue("@pDataCadastro", Convert.ToDateTime(dtBuscarVendas.Text));
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd15;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridVendas.DataSource = Dt;

                con.FecharCon();


            }
            catch (Exception ex)
            {

                ErroMensageService.ShowError("Erro ao buscar data por vendas" + ex.Message);
            }
        }

        //Método de recuperar a quant em estoque de 1 produto
        private void RecuperarEstoqueProduto()
        {

            con.AbrirCon();
            MySqlCommand Cmd16 = new MySqlCommand();
            Cmd16.Connection = con.Con;
            Cmd16.CommandText = "spRecuperarEstoque";
            Cmd16.CommandType = CommandType.StoredProcedure;
            Cmd16.Parameters.AddWithValue("@pIdProduto", idProduto);

            MySqlDataReader reader;
            reader = Cmd16.ExecuteReader();

            if (reader.HasRows)
            {
                //extraindo informações da consulta
                while (reader.Read())
                {
                    txtEstoque.Text = Convert.ToString(reader["estoque"]);
                }

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

        //botão Salvar Vendas
        private void BtSalvar_Click(object sender, EventArgs e)
        {
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

            //Método p/ salvar a venda
            InserirVendas();

            //método de ultimo IdVenda
            UltimoIdVenda();

            //Método p/ salvar a movimentação no Frm de movimentações
            InserirMovimentacoes();

            //método de relacionar itens da venda
            RelacionarItensVendas();

            SucessoMensageService.ShowSuccess("Venda salva com sucesso!");

            EnableHelper.SetEnabled(true, btSalvar, btNovo, txtQuant, btAddHospedes, btAddProdutos, btAddItens);
            ControlHelper.ClearAndFocus(txtQuant);
            EnableHelper.SetEnabled(false, txtQuant, btAddHospedes, btAddProdutos, btAddItens, btRemoverItens, btExcluir, btSalvar);
            //btNovo.Enabled = true;
            //btSalvar.Enabled = false;
            //LimparCampos();
            //HabilitarCampos(false);
            ListarVendas();
            totalVenda = "0";
            btFecharGrid.Visible = false;

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
                    btNovo.Enabled = true;
                    btExcluir.Enabled = false;
                    LimparCampos();
                    HabilitarCampos(false);
                    ListarVendas();
                    totalVenda = "0";
                    exclusaoVenda = "";
                    btFecharGrid.Visible = false;
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
            Globais.chamadaProdutos = "estoque";
            FrmProdutos frmProdutos = new FrmProdutos();
            frmProdutos.Show();
        }

        //evento que executa quando o Frm é ativado
        private void FrmVendas_Activated(object sender, EventArgs e)
        {
            txtEstoque.Text = Globais.estoqueProduto;//estoque do produto
            txtProduto.Text = Globais.nomeProduto;//nome do produto
            txtVrVenda.Text = Globais.VrVenda;//valor de venda do produto
        }

        //botão de add itens(produtos) a venda
        private void BtAddItens_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuant.Text))
            {
                ErroMensageService.ShowError("Insira uma Quantidade! Campo vazio!");
                txtQuant.Focus();
                return;
            }

            // 🔢 Tentativas de conversão com segurança usando cultura BR
            decimal quantidade;
            decimal valorUnitario;
            decimal estoqueAtual;
            decimal totalVendaDecimal;

            bool quantValida = decimal.TryParse(txtQuant.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out quantidade);
            bool valorValido = decimal.TryParse(txtVrVenda.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out valorUnitario);
            bool estoqueValido = decimal.TryParse(txtEstoque.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out estoqueAtual);

            if (!quantValida || !valorValido || !estoqueValido)
            {
                ErroMensageService.ShowError("Campos de valor ou quantidade inválidos!");
                return;
            }

            // 🚫 VERIFICA ESTOQUE
            if (estoqueAtual < quantidade)
            {
                ErroMensageService.ShowError("Não há produtos suficientes no estoque!");
                txtQuant.Clear();
                txtQuant.Focus();
                return;
            }

            // ✅ INSERIR DETALHES DA VENDA
            con.AbrirCon();
            using (MySqlCommand Cmd1 = new MySqlCommand("spInserirDetalhesVendas", con.Con))
            {
                Cmd1.CommandType = CommandType.StoredProcedure;
                Cmd1.Parameters.AddWithValue("@pProduto", txtProduto.Text);
                Cmd1.Parameters.AddWithValue("@pQuant", quantidade);
                Cmd1.Parameters.AddWithValue("@pValorUnit", valorUnitario);
                Cmd1.Parameters.AddWithValue("@pValorTotal", quantidade * valorUnitario);
                Cmd1.Parameters.AddWithValue("@pId_Venda", "0"); // pode ser alterado futuramente com venda em aberto
                Cmd1.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                Cmd1.Parameters.AddWithValue("@pId_Produto", Globais.idProduto);

                Cmd1.ExecuteNonQuery();
            }
            con.FecharCon();

            // 🔄 ATUALIZA ESTOQUE (baixa no estoque atual)
            con.AbrirCon();
            using (MySqlCommand Cmd2 = new MySqlCommand("spAtualizarEstoque", con.Con))
            {
                Cmd2.CommandType = CommandType.StoredProcedure;
                Cmd2.Parameters.AddWithValue("@pIdProduto", Globais.idProduto);
                Cmd2.Parameters.AddWithValue("@pEstoque", estoqueAtual - quantidade);

                Cmd2.ExecuteNonQuery();
            }
            con.FecharCon();

            // 💰 CALCULA TOTAL DE VENDA ATUAL
            // Inicializa como zero se for nulo ou vazio
            if (!decimal.TryParse(totalVenda, NumberStyles.Any, CultureInfo.CurrentCulture, out totalVendaDecimal))
                totalVendaDecimal = 0;

            decimal total = totalVendaDecimal + (valorUnitario * quantidade);
            totalVenda = total.ToString("F2", CultureInfo.InvariantCulture); // guarda como padrão interno
            lblTotalVendas.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", total); // exibe como moeda

            // 🧹 LIMPA CAMPOS PARA PRÓXIMA INSERÇÃO
            txtQuant.Clear();
            txtProduto.Clear();
            txtEstoque.Text = "0";
            txtVrVenda.Clear();
            IdDetVenda = "";

            // 🔁 ATUALIZA LISTA DE ITENS VENDIDOS
            ListarDetalhesVenda();

        }

        //grid Detalhes da Venda
        private void GridDetalhesVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdDetVenda = gridDetalhesVendas.CurrentRow.Cells[0].Value.ToString();
            txtProduto.Text = gridDetalhesVendas.CurrentRow.Cells[1].Value.ToString();
            txtQuant.Text = gridDetalhesVendas.CurrentRow.Cells[2].Value.ToString();
            txtVrVenda.Text = gridDetalhesVendas.CurrentRow.Cells[4].Value.ToString();
            idProduto = gridDetalhesVendas.CurrentRow.Cells[7].Value.ToString();
            RecuperarEstoqueProduto();

        }



        //botão Remover itens da venda
        private void BtRemoverItens_Click(object sender, EventArgs e)
        {
            if (IdDetVenda == "")
            {
                ErroMensageService.ShowError("Selecione um Produto para remover");
                return;
            }

            //Método de remover/deletar itens da venda

            con.AbrirCon();
            MySqlCommand Cmdr = new MySqlCommand();
            Cmdr.Connection = con.Con;
            Cmdr.CommandText = "spRemoverItenVenda";
            Cmdr.CommandType = CommandType.StoredProcedure;
            Cmdr.Parameters.AddWithValue("@pIdDetalhe", IdDetVenda);

            Cmdr.ExecuteNonQuery();
            con.FecharCon();


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
            decimal total;
            total = Convert.ToDecimal(totalVenda) - Convert.ToDecimal(txtVrVenda.Text) * Convert.ToDecimal(txtQuant.Text);
            totalVenda = total.ToString();
            lblTotalVendas.Text = string.Format("{0:c2}", total);

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
        private void GridVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridVendas.Rows[e.RowIndex];

                IdVenda = row.Cells[0].Value?.ToString();
                Globais.IdVenda = IdVenda;

                totalVenda = row.Cells[2].Value?.ToString();
                lblTotalVendas.Text = string.Format("{0:c2}", totalVenda);

                BuscarDetalhesVenda();
                btFecharGrid.Visible = true;
                btAddItens.Enabled = true;
                btRemoverItens.Enabled = true;
                btExcluir.Enabled = true;
                exclusaoVenda = "1";
                btRel.Enabled = true;
            }

        }

        //botão p/ fechar o grid de Detalhes de vendas
        private void BtFecharGrid_Click(object sender, EventArgs e)
        {
            gridDetalhesVendas.Visible = false;
            btFecharGrid.Visible = false;
            totalVenda = "0";
            lblTotalVendas.Text = "0";
        }

        private void GridDetalhesVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Evento que busca as vendas por data
        private void DtBuscarVendas_ValueChanged(object sender, EventArgs e)
        {
            BuscarVendaData();
        }

        private void BtRel_Click(object sender, EventArgs e)
        {
            // FrmRelComprovante frmRelComprovante = new FrmRelComprovante();
            // frmRelComprovante.Show();
        }

        //Evento de validação dos campos para somente números inteiros
        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyIntegerInput(sender, e);
        }
    }

}

