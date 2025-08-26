using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Properties;
using SistemaHotel.Repositories.estoqueDAO;
using SistemaHotel.Repositories.produtoDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmProdutos : Form
    {
        private produtoDAO _dao = new produtoDAO();
        // Declaração do estoqueDAO como campo privado

        // no corpo da classe FrmProdutos
        private readonly estoqueDAO _estoqueDao = new estoqueDAO();

        private string op = "";
        public string foto = "";
        private byte[] imagemOriginal;

        public int IdProdutoSelecionado { get; private set; } = 0;
        public string NomeProdutoSelecionado { get; private set; } = null;
        public string EstoqueSelecionado { get; private set; }
        public decimal ValorCompraSelecionado { get; private set; }

        public FrmProdutos()
        {
            InitializeComponent();
            gridProdutos.AutoGenerateColumns = false;
            EnableHelper.SetEnabled(false, txtCod, txtProduto, txtDescricao, cBFornecedor, txtVrCompra, txtVrVenda);

        }


        // Carrega fornecedores no combobox
        private void PreencherCBox()
        {
            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand
            {
                Connection = con.Con,
                CommandText = "spListarFornecedores",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter { SelectCommand = Cmd };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBFornecedor.DataSource = Dt;
            cBFornecedor.ValueMember = "IdFornec";
            cBFornecedor.DisplayMember = "Nome";
            con.Con.Close();
        }

        // Lista produtos na grid
        private void ListarProdutos()
        {
            try
            {
                gridProdutos.DataSource = _dao.ListarProdutos();
            }
            catch (Exception ex)
            {
                ErroMensageService.ShowError("Erro ao Listar: " + ex.Message);
            }
        }

        // Busca produtos por nome
        private void BuscarProdutoNome()
        {
            try
            {
                // Busca os produtos filtrando pelo texto informado
                var dt = _dao.BuscarProdutoPorNome(txtBuscarNome.Text);

                // Atualiza o DataSource do DataGridView com o resultado da busca
                gridProdutos.DataSource = dt;

                // Se houver pelo menos um resultado
                if (dt.Rows.Count > 0)
                {
                    // Limpa qualquer seleção anterior
                    gridProdutos.ClearSelection();

                    // Seleciona a primeira linha do resultado
                    gridProdutos.Rows[0].Selected = true;

                    // Atualiza todos os campos do formulário conforme a linha selecionada
                    AtualizarCamposComLinhaSelecionada(gridProdutos.Rows[0]);
                }
                else
                {
                    // Caso não haja resultados, limpa todos os campos do formulário (inclusive imagem)
                    ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
                    txtEstoque.Text = "0";

                    // Limpa imagem
                    pBoxProdutos.Image = Resources.sem_foto;
                    foto = "";
                    //LimparCampos();
                }
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro padronizada usando o serviço de mensagens
                ErroMensageService.ShowError("Erro ao Buscar: " + ex.Message);
            }
        }

        // Métodos de operação CRUD
        private void IniciarOp()
        {
            switch (op)
            {
                case "Novo":
                    txtProduto.Focus();
                    EnableHelper.SetEnabled(true, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);
                    break;

                case "Salvar":
                    try
                    {
                        Produto produto = new Produto
                        {
                            Nome = txtProduto.Text,
                            Descricao = txtDescricao.Text,
                            ValorUnit = decimal.TryParse(txtVrVenda.Text, out decimal vVenda) ? vVenda : 0,
                            ValorCompra = decimal.TryParse(txtVrCompra.Text, out decimal vCompra) ? vCompra : 0,
                            Estoque = decimal.TryParse(txtEstoque.Text, out decimal estoque) ? estoque : 0,
                            Imagem = Img(),
                            IdFornec = cBFornecedor.SelectedValue != null ? Convert.ToInt32(cBFornecedor.SelectedValue) : 0
                        };

                        int id = _dao.InserirProduto(produto);
                        if (id > 0)
                        {
                            SucessoMensageService.ShowSuccess("Registro salvo com sucesso!");

                            // Lançar gasto do cadastro inicial (se houver estoque inicial e valor de compra)
                            decimal estoqueInicial = 0;
                            decimal valorCompra = 0;

                            // Tenta converter respeitando vírgula/ponto da máquina do usuário
                            decimal.TryParse(txtEstoque.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out estoqueInicial);
                            decimal.TryParse(txtVrCompra.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out valorCompra);

                            // Só lança gasto se ambos forem positivos
                            // Sempre lança gasto no cadastro inicial de produto
                            if (valorCompra >= 0)
                            {
                                decimal valorGasto = valorCompra; // Aqui considera apenas o valor unitário informado
                                string funcionario = Globais.nomeUsuario;

                                // 1) Lança em Gastos
                                _estoqueDao.InserirGasto("Compra de Produtos (cadastro inicial)", funcionario, valorGasto);

                                // 2) Recupera Id do gasto e insere a Movimentação
                                string ultimoIdGasto = _estoqueDao.RecuperarUltimoIdGasto();
                                Globais.ultimoIdGasto = ultimoIdGasto;

                                _estoqueDao.InserirMovimentacaoGasto(
                                    "Saída",
                                    "Gastos",
                                    valorGasto,
                                    funcionario,
                                    ultimoIdGasto
                                );
                            }



                            //
                            ListarProdutos();
                            ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
                            txtEstoque.Text = "0";

                            // Limpa imagem
                            pBoxProdutos.Image = Resources.sem_foto;
                            foto = "";
                            //LimparCampos();
                            EnableHelper.SetEnabled(false, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);
                        }
                        else
                        {
                            ErroMensageService.ShowError("Falha ao salvar produto!");
                        }
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao salvar: " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        Produto produto = new Produto
                        {
                            IdProduto = int.TryParse(txtCod.Text, out int idProd) ? idProd : 0,
                            Nome = txtProduto.Text,
                            Descricao = txtDescricao.Text,
                            ValorUnit = decimal.TryParse(txtVrVenda.Text, out decimal vVendaEdt) ? vVendaEdt : 0,
                            ValorCompra = decimal.TryParse(txtVrCompra.Text, out decimal vCompraEdt) ? vCompraEdt : 0,
                            Estoque = decimal.TryParse(txtEstoque.Text, out decimal estoqueEdt) ? estoqueEdt : 0,
                            //Imagem = Img(),


                            // Utiliza o método da Service para decidir se salva imagem antiga ou a nova do PictureBox
                            Imagem = CheckImageEdit.VerificarImagemEdicao(imagemOriginal, Img()),

                            IdFornec = cBFornecedor.SelectedValue != null ? Convert.ToInt32(cBFornecedor.SelectedValue) : 0
                        };

                        bool sucesso = _dao.AlterarProduto(produto);
                        if (sucesso)
                        {
                            SucessoMensageService.ShowSuccess("Registro alterado com sucesso!");
                            ListarProdutos();
                            ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
                            txtEstoque.Text = "0";

                            // Limpa imagem
                            pBoxProdutos.Image = Resources.sem_foto;
                            foto = "";

                            EnableHelper.SetEnabled(false, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);

                        }
                        else
                        {
                            ErroMensageService.ShowError("Falha ao alterar produto!");
                        }
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao editar: " + ex.Message);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        int idProduto = int.TryParse(txtCod.Text, out int idProdDel) ? idProdDel : 0;
                        bool sucesso = _dao.ExcluirProduto(idProduto);
                        if (sucesso)
                        {
                            SucessoMensageService.ShowSuccess("Registro excluído com sucesso!");
                            ListarProdutos();
                            ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
                            txtEstoque.Text = "0";

                            // Limpa imagem
                            pBoxProdutos.Image = Resources.sem_foto;
                            foto = "";

                            EnableHelper.SetEnabled(false, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);

                        }
                        else
                        {
                            ErroMensageService.ShowError("Falha ao excluir produto!");
                        }
                    }
                    catch (Exception ex)
                    {
                        ErroMensageService.ShowError("Erro ao excluir: " + ex.Message);
                    }
                    break;
            }
        }

        // Botão Novo
        private void BtNovo_Click(object sender, EventArgs e)
        {
            ControlHelper.ClearAndFocus(txtProduto, txtProduto, txtCod, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
            txtEstoque.Text = "0";

            // Limpa imagem
            pBoxProdutos.Image = Resources.sem_foto;
            foto = "";

            op = "Novo";
            IniciarOp();
            ControlHelper.ClearAndFocus(txtProduto);
            EnableHelper.SetEnabled(false, btNovo);

        }

        // Botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text))
            {
                ErroMensageService.ShowError("Insira um Produto!");
                ControlHelper.ClearAndFocus(txtProduto);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                ErroMensageService.ShowError("Insira uma descrição para o Produto!");
                ControlHelper.ClearAndFocus(txtDescricao);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVrCompra.Text))
            {
                ErroMensageService.ShowError("Insira um valor de compra para o Produto!");
                ControlHelper.ClearAndFocus(txtVrCompra);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVrVenda.Text))
            {
                ErroMensageService.ShowError("Insira um valor unitário para o Produto!");
                ControlHelper.ClearAndFocus(txtVrVenda);
                return;
            }

            if (cBFornecedor.SelectedValue == null)
            {
                ErroMensageService.ShowError("Selecione um Fornecedor!");
                ControlHelper.ClearAndFocus(cBFornecedor);
                return;
            }

            //op = "Salvar";
            // Defina op com base no contexto
            // Se txtCod.Text está vazio, é novo registro
            // Se txtCod.Text tem valor, é edição
            op = string.IsNullOrWhiteSpace(txtCod.Text) ? "Salvar" : "Editar";
            EnableHelper.SetEnabled(true, btNovo);
            IniciarOp();
        }

        // Botão Editar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtCod.Text))
            {
                ErroMensageService.ShowError("Selecione um Registro para Alterar!");
                ControlHelper.ClearAndFocus(txtProduto);
                return;
            }
            op = "Editar";
            EnableHelper.SetEnabled(true, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);
            ControlHelper.ClearAndFocus(txtProduto);
            IniciarOp();
        }

        // Botão Excluir
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtCod.Text))
            {
                ErroMensageService.ShowError("Selecione um Registro para excluir!");
                ControlHelper.ClearAndFocus(txtProduto);
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            op = "Excluir";
            IniciarOp();
        }

        // Botão Adicionar Imagem
        private void BtAddImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagem(*.jpg;*.png)|*.jpg;*.png|Todos os arquivos(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName;
                pBoxProdutos.ImageLocation = foto;
            }
        }

        // Botão Remover Imagem
        private void BtRemoverImagem_Click(object sender, EventArgs e)
        {
            LimparFoto();
        }

        // Limpa imagem do produto
        private void LimparFoto()
        {
            pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;
            pBoxProdutos.Image = Resources.sem_foto;
            foto = "";
        }

        // Evento Load do formulário
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparFoto();
            ListarProdutos();
            PreencherCBox();
            ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
            txtEstoque.Text = "0";

            // Limpa imagem
            pBoxProdutos.Image = Resources.sem_foto;
            foto = "";

            EnableHelper.SetEnabled(false, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);


            // Verifica o contexto de chamada do formulário
            if (Globais.chamadaProdutos == "vendas")
            {
                btnSelecionarProdutoVendas.Visible = true;
                btnSelecionarProdutoEdicao.Visible = false;
            }
            else
            {
                // Uso direto (edição)
                btnSelecionarProdutoVendas.Visible = false;
                btnSelecionarProdutoEdicao.Visible = true;
            }
        }

        // Converte imagem para byte[]
        private byte[] Img()
        {
            if (string.IsNullOrEmpty(foto))
                return null;
            try
            {
                using (FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        return br.ReadBytes((int)fs.Length);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        // Busca produtos por nome ao digitar
        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarProdutoNome();
        }


        // Evento de clique na grid para preencher os campos
        private void gridProdutos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Text = gridProdutos.CurrentRow.Cells["IdProduto"].Value?.ToString() ?? "";
            txtProduto.Text = gridProdutos.CurrentRow.Cells["Nome"].Value?.ToString() ?? "";
            txtDescricao.Text = gridProdutos.CurrentRow.Cells["Descricao"].Value?.ToString() ?? "";
            txtEstoque.Text = gridProdutos.CurrentRow.Cells["Estoque"].Value?.ToString() ?? "";
            txtVrCompra.Text = gridProdutos.CurrentRow.Cells["ValorCompra"].Value?.ToString() ?? "";
            txtVrVenda.Text = gridProdutos.CurrentRow.Cells["ValorUnit"].Value?.ToString() ?? "";
            cBFornecedor.Text = gridProdutos.CurrentRow.Cells["Fornecedor"].Value?.ToString() ?? "";

            // Imagem
            var imgCell = gridProdutos.CurrentRow.Cells["Imagem"];
            if (imgCell != null && imgCell.Value != null && imgCell.Value != DBNull.Value)
            {
                try
                {
                    byte[] imagemBuffer = (byte[])imgCell.Value;
                    imagemOriginal = imagemBuffer;

                    if (imagemBuffer.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imagemBuffer))
                        {
                            pBoxProdutos.Image = Image.FromStream(ms);
                            pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pBoxProdutos.Image = Resources.sem_foto;
                    }
                }
                catch
                {
                    pBoxProdutos.Image = Resources.sem_foto;
                }
            }
            else
            {
                pBoxProdutos.Image = Resources.sem_foto;
            }
        }

        // Evento de duplo clique na grid para seleção de produto para estoque
        private void gridProdutos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Evento nã usado
        }

        /// <summary>
        /// Atualiza todos os campos do formulário a partir de uma linha selecionada do DataGridView.
        /// </summary>
        /// <param name="row">A linha selecionada do DataGridView.</param>
        private void AtualizarCamposComLinhaSelecionada(DataGridViewRow row)
        {
            if (row == null) return;

            // Preenche campos de texto
            txtCod.Text = row.Cells["IdProduto"].Value?.ToString() ?? "";
            txtProduto.Text = row.Cells["Nome"].Value?.ToString() ?? "";
            txtDescricao.Text = row.Cells["Descricao"].Value?.ToString() ?? "";
            txtEstoque.Text = row.Cells["Estoque"].Value?.ToString() ?? "";
            txtVrCompra.Text = row.Cells["ValorCompra"].Value?.ToString() ?? "";
            txtVrVenda.Text = row.Cells["ValorUnit"].Value?.ToString() ?? "";

            // Preenche ComboBox de fornecedor
            if (row.Cells["Fornecedor"].Value != null)
                cBFornecedor.Text = row.Cells["Fornecedor"].Value.ToString();
            else
                cBFornecedor.SelectedIndex = -1;

            // Preenche a imagem do produto
            var imgCell = row.Cells["Imagem"];
            if (imgCell != null && imgCell.Value != null && imgCell.Value != DBNull.Value)
            {
                try
                {
                    byte[] imagemBuffer = (byte[])imgCell.Value;
                    if (imagemBuffer.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imagemBuffer))
                        {
                            pBoxProdutos.Image = Image.FromStream(ms);
                            pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pBoxProdutos.Image = Resources.sem_foto;
                    }
                }
                catch
                {
                    pBoxProdutos.Image = Resources.sem_foto;
                }
            }
            else
            {
                pBoxProdutos.Image = Resources.sem_foto;
            }
        }

        //Evento de validação dos campos para somente números/valores monetários
        private void txtVrCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }

        private void txtVrVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }


        // Evento de clique no botão de seleção de produto para edição
        private void btnSelecionarProdutoEdicao_Click(object sender, EventArgs e)
        {
            // Protege contra seleção inválida
            if (gridProdutos.CurrentRow == null || gridProdutos.CurrentRow.Cells["IdProduto"].Value == null)
                return;

            // Pergunta ao usuário o que deseja fazer
            var opcao = MessageBox.Show(
                "O que deseja fazer com este produto?\n\n" +
                "Sim = Editar\nNão = Excluir\nCancelar = Sair",
                "Selecionar Produto",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            // === EDIÇÃO ===
            if (opcao == DialogResult.Yes)
            {
                // Habilita campos para edição
                EnableHelper.SetEnabled(true, btSalvar, btAddImagem, btRemoverImagem, txtProduto, txtDescricao, cBFornecedor, txtVrCompra, txtVrVenda);
                EnableHelper.SetEnabled(false, btNovo, gridProdutos);


                // Preenche campos com dados do grid
                txtCod.Text = gridProdutos.CurrentRow.Cells["IdProduto"].Value?.ToString() ?? "";
                txtProduto.Text = gridProdutos.CurrentRow.Cells["Nome"].Value?.ToString() ?? "";
                txtDescricao.Text = gridProdutos.CurrentRow.Cells["Descricao"].Value?.ToString() ?? "";
                txtEstoque.Text = gridProdutos.CurrentRow.Cells["Estoque"].Value?.ToString() ?? "";
                txtVrCompra.Text = gridProdutos.CurrentRow.Cells["ValorCompra"].Value?.ToString() ?? "";
                txtVrVenda.Text = gridProdutos.CurrentRow.Cells["ValorUnit"].Value?.ToString() ?? "";

                // Fornecedor
                if (gridProdutos.CurrentRow.Cells["Fornecedor"].Value != null)
                    cBFornecedor.Text = gridProdutos.CurrentRow.Cells["Fornecedor"].Value.ToString();
                else
                    cBFornecedor.SelectedIndex = -1;

                // Imagem
                var imgCell = gridProdutos.CurrentRow.Cells["Imagem"];
                if (imgCell != null && imgCell.Value != null && imgCell.Value != DBNull.Value)
                {
                    try
                    {
                        byte[] imagemBuffer = (byte[])imgCell.Value;
                        imagemOriginal = imagemBuffer;

                        if (imagemBuffer.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imagemBuffer))
                            {
                                pBoxProdutos.Image = Image.FromStream(ms);
                                pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        else
                        {
                            pBoxProdutos.Image = Resources.sem_foto;
                        }
                    }
                    catch
                    {
                        pBoxProdutos.Image = Resources.sem_foto;
                    }
                }
                else
                {
                    pBoxProdutos.Image = Resources.sem_foto;
                }
            }
            // === EXCLUSÃO ===
            else if (opcao == DialogResult.No)
            {
                var confirm = MessageBox.Show(
                    "Tem certeza que deseja excluir este produto?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                EnableHelper.SetEnabled(false, btNovo, btSalvar, btAddImagem, btRemoverImagem, txtProduto, txtDescricao, cBFornecedor, txtVrCompra, txtVrVenda);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var idProduto = Convert.ToInt32(gridProdutos.CurrentRow.Cells["IdProduto"].Value);
                        var dao = new produtoDAO();
                        dao.ExcluirProduto(idProduto);

                        MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProdutos(); // Atualiza grid
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // === CANCELAR ===
            else
            {
                return;
            }

            EnableHelper.SetEnabled(true, btNovo, gridProdutos);

        }

        // Evento de clique no botão de seleção de produto para vendas
        private void btnSelecionarProdutoVendas_Click(object sender, EventArgs e)
        {
            if (gridProdutos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um hóspede.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (gridProdutos.CurrentRow != null)
            {
                // Atribui o valor à propriedade pública
                IdProdutoSelecionado = Convert.ToInt32(gridProdutos.CurrentRow.Cells["IdProduto"].Value);
                NomeProdutoSelecionado = gridProdutos.CurrentRow.Cells[1].Value.ToString();
                EstoqueSelecionado = gridProdutos.CurrentRow.Cells["Estoque"].Value.ToString();
                ValorCompraSelecionado = decimal.TryParse(gridProdutos.CurrentRow.Cells["ValorCompra"].Value.ToString(), out decimal valorCompra) ? valorCompra : 0;

                // Define que o diálogo foi concluído com sucesso
                this.DialogResult = DialogResult.OK;

                // Fecha o formulário
                this.Close();
            }
        }

        private void btnSelecionarProdutoEstoque_Click(object sender, EventArgs e)
        {
            if (gridProdutos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Armazena os dados do produto nos globais
            Globais.idProduto = gridProdutos.CurrentRow.Cells["IdProduto"].Value.ToString();
            Globais.nomeProduto = gridProdutos.CurrentRow.Cells["Nome"].Value.ToString();
            Globais.estoqueProduto = gridProdutos.CurrentRow.Cells["Estoque"].Value.ToString();
            Globais.VrCompra = gridProdutos.CurrentRow.Cells["ValorCompra"].Value.ToString();
            Globais.VrVenda = gridProdutos.CurrentRow.Cells["ValorUnit"].Value.ToString();
            Globais.chamadaProdutos = "produtos";

            // Verifica se o FrmEstoques já está aberto
            foreach (Form frmAberto in Application.OpenForms)
            {
                if (frmAberto is FrmEstoques)
                {
                    frmAberto.Activate(); // Traz para frente
                    this.Close();         // Fecha o FrmProdutos
                    return;
                }
            }

            // Se não existir aberto, cria um novo
            FrmEstoques frmEstoque = new FrmEstoques();
            frmEstoque.Show();
            this.Close(); // Fecha o FrmProdutos


        }
    }
}
