using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Properties;
using SistemaHotel.Repositories.produtoDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmProdutos : Form
    {
        private produtoDAO _dao = new produtoDAO();
        private string op = "";
        public string foto = "";
        private byte[] imagemOriginal;

        public FrmProdutos()
        {
            InitializeComponent();
            gridProdutos.AutoGenerateColumns = false;
            EnableHelper.SetEnabled(false, txtCod, txtProduto, txtDescricao, cBFornecedor, txtVrCompra, txtVrVenda);
        }



        private void LimparCampos()
        {
            // Utiliza helper para limpar todos os campos de texto
            ControlHelper.ClearAndFocus(txtCod, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, txtEstoque);
            txtEstoque.Text = "0";

            // Limpa imagem
            pBoxProdutos.Image = Resources.sem_foto;
            foto = "";
        }

        private void HabilitarCampos(bool vr)
        {
            // Usa helper para habilitar/desabilitar todos os campos relevantes
            EnableHelper.SetEnabled(vr, txtProduto, txtDescricao, txtVrVenda, txtVrCompra, cBFornecedor, btEditar, btExcluir, btSalvar, btAddImagem, btRemoverImagem, pBoxProdutos);

            // O campo de estoque permanece sempre desabilitado (alteração só via movimentação)
            EnableHelper.SetEnabled(false, txtEstoque);
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
                    LimparCampos();
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
                    HabilitarCampos(true);
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
                            ListarProdutos();
                            LimparCampos();
                            HabilitarCampos(false);
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
                            LimparCampos();
                            HabilitarCampos(false);
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
                            LimparCampos();
                            HabilitarCampos(false);
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
            LimparCampos();
            op = "Novo";
            IniciarOp();
            txtProduto.Focus();
            EnableHelper.SetEnabled(false, btEditar, btExcluir);
        }

        // Botão Salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text))
            {
                ErroMensageService.ShowError("Insira um Produto!");
                txtProduto.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVrVenda.Text))
            {
                ErroMensageService.ShowError("Insira um valor para o Produto!");
                txtVrVenda.Focus();
                return;
            }
            if (cBFornecedor.SelectedValue == null)
            {
                ErroMensageService.ShowError("Selecione um Fornecedor!");
                cBFornecedor.Focus();
                return;
            }

            //op = "Salvar";
            // Defina op com base no contexto
            // Se txtCod.Text está vazio, é novo registro
            // Se txtCod.Text tem valor, é edição
            op = string.IsNullOrWhiteSpace(txtCod.Text) ? "Salvar" : "Editar";
            IniciarOp();
        }

        // Botão Editar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtCod.Text))
            {
                ErroMensageService.ShowError("Selecione um Registro para Alterar!");
                txtProduto.Focus();
                return;
            }
            op = "Editar";
            HabilitarCampos(true); // Só habilita campos para edição
            txtProduto.Focus();
            IniciarOp();
        }

        // Botão Excluir
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduto.Text) || string.IsNullOrWhiteSpace(txtCod.Text))
            {
                ErroMensageService.ShowError("Selecione um Registro para excluir!");
                txtProduto.Focus();
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
            //pBoxProdutos.Image = Resources.sem_foto;
            foto = "";
        }

        // Evento Load do formulário
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparFoto();
            ListarProdutos();
            PreencherCBox();
            LimparCampos();
            HabilitarCampos(false);
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

        }

        // Evento de duplo clique na grid para seleção de produto para estoque
        private void gridProdutos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (Globais.chamadaProdutos == "estoque")
            {
                Globais.idProduto = gridProdutos.CurrentRow.Cells[0].Value.ToString();
                Globais.nomeProduto = gridProdutos.CurrentRow.Cells[1].Value.ToString();
                Globais.estoqueProduto = gridProdutos.CurrentRow.Cells[3].Value.ToString();
                Globais.VrCompra = gridProdutos.CurrentRow.Cells[4].Value.ToString();
                Globais.VrVenda = gridProdutos.CurrentRow.Cells[5].Value.ToString();
                Close();
            }
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
            // Habilita campos
            EnableHelper.SetEnabled(true, txtProduto, txtDescricao, cBFornecedor, txtVrCompra, txtVrVenda);



            // Habilita "Editar" e "Excluir", desabilita "Novo" e "Salvar"
            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            // Protege contra seleção inválida
            if (gridProdutos.CurrentRow == null) return;

            // Garante que há pelo menos 9 colunas (ajuste conforme sua grid)
            if (gridProdutos.CurrentRow.Cells.Count < 9) return;

            // Garante que a célula do código do produto não é nula
            if (gridProdutos.CurrentRow.Cells[0].Value == null) return;

            // Preenche os campos de texto com os valores das células
            txtCod.Text = gridProdutos.CurrentRow.Cells["IdProduto"].Value?.ToString() ?? "";
            txtProduto.Text = gridProdutos.CurrentRow.Cells["Nome"].Value?.ToString() ?? "";
            txtDescricao.Text = gridProdutos.CurrentRow.Cells["Descricao"].Value?.ToString() ?? "";
            txtEstoque.Text = gridProdutos.CurrentRow.Cells["Estoque"].Value?.ToString() ?? "";
            txtVrCompra.Text = gridProdutos.CurrentRow.Cells["ValorCompra"].Value?.ToString() ?? "";
            txtVrVenda.Text = gridProdutos.CurrentRow.Cells["ValorUnit"].Value?.ToString() ?? "";

            // Preenche o ComboBox de fornecedor
            // OBS: Use sempre o nome da coluna, nunca o índice, para evitar erros caso a ordem do grid mude!
            if (gridProdutos.CurrentRow.Cells["Fornecedor"].Value != null)
                cBFornecedor.Text = gridProdutos.CurrentRow.Cells["Fornecedor"].Value.ToString();
            else
                cBFornecedor.SelectedIndex = -1; // Limpa seleção caso não tenha fornecedor

            // Preenche a imagem do produto
            // Mesmo com coluna "Imagem" invisível, acesse pelo nome!
            var imgCell = gridProdutos.CurrentRow.Cells["Imagem"];
            if (imgCell != null && imgCell.Value != null && imgCell.Value != DBNull.Value)
            {
                try
                {
                    byte[] imagemBuffer = (byte[])imgCell.Value;
                    imagemOriginal = imagemBuffer; // <--- Guarda a imagem original 

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
                        // Imagem vazia: mostra imagem padrão
                        pBoxProdutos.Image = Resources.sem_foto;
                    }
                }
                catch
                {
                    // Se der erro ao converter imagem, mostra imagem padrão
                    pBoxProdutos.Image = Resources.sem_foto;
                }
            }
            else
            {
                // Se não houver imagem, mostra imagem padrão
                pBoxProdutos.Image = Resources.sem_foto;
            }

        }
    }
}
