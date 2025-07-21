using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Properties;
using SistemaHotel.Services;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void MsgOk(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MsgErro(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void LimparCampos()
        {

            txtCod.Clear();
            txtProduto.Clear();
            txtDescricao.Clear();
            txtVrVenda.Clear();
            txtVrCompra.Clear();
            pBoxProdutos.Image = Resources.sem_foto;

        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {

                txtProduto.Enabled = true;
                txtDescricao.Enabled = true;
                txtVrVenda.Enabled = true;
                txtEstoque.Text = "0";
                cBFornecedor.Enabled = true;
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
                btSalvar.Enabled = true;
                btAddImagem.Enabled = true;
                btRemoverImagem.Enabled = true;
                pBoxProdutos.Enabled = true;

            }
            else
            {
                txtProduto.Enabled = false;
                txtDescricao.Enabled = false;
                txtVrVenda.Enabled = false;
                txtEstoque.Enabled = false;
                cBFornecedor.Enabled = false;
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                btSalvar.Enabled = false;
                btAddImagem.Enabled = false;
                btRemoverImagem.Enabled = false;
                pBoxProdutos.Enabled = false;
            }
        }

        //Método de carregar o combo box de fornecedores
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
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = Cmd
            };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBFornecedor.DataSource = Dt;
            cBFornecedor.ValueMember = "IdFornec";
            cBFornecedor.DisplayMember = "Nome";
        }

        //Método de Listar produtos na grid
        private void ListarProdutos()
        {

            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();
                MySqlCommand Cmd = new MySqlCommand
                {
                    Connection = con.Con,
                    CommandText = "spListarProdutos",
                    CommandType = CommandType.StoredProcedure
                };
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = Cmd
                };
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                gridProdutos.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao Listar: " + ex.Message);
            }
        }

        //Método de buscar produtos por nome
        private void BuscarProdutoNome()
        {

            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();
                MySqlCommand Cmd = new MySqlCommand
                {
                    Connection = con.Con,
                    CommandText = "spBuscarProdutoNome",
                    CommandType = CommandType.StoredProcedure
                };
                Cmd.Parameters.AddWithValue("@Nome", txtBuscarNome.Text);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    SelectCommand = Cmd
                };
                DataTable Dt = new DataTable();
                da.Fill(Dt);
                gridProdutos.DataSource = Dt;
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao Buscar: " + ex.Message);
            }
        }


        //Método p/ os botões
        string op = "";
        private void IniciarOp()
        {
            Conexao con = new Conexao();
            MySqlCommand Cmd = new MySqlCommand();
            switch (op)
            {
                case "Novo":
                    txtProduto.Focus();
                    HabilitarCampos(true);
                    break;

                case "Salvar":
                    try
                    {

                        con.AbrirCon();
                        Cmd.Connection = con.Con;
                        Cmd.CommandText = "spInserirProdutos";
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@Nome", txtProduto.Text);
                        Cmd.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                        Cmd.Parameters.AddWithValue("@ValorUnit", Convert.ToDecimal(txtVrVenda.Text));
                        Cmd.Parameters.AddWithValue("@Imagem", Img());
                        Cmd.Parameters.AddWithValue("@Id_Fornec", cBFornecedor.SelectedValue);
                        Cmd.ExecuteNonQuery();
                        con.FecharCon();
                    }
                    catch (Exception ex)
                    {

                        MsgErro("Erro ao salvar: " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        con.AbrirCon();
                        Cmd.Connection = con.Con;
                        Cmd.CommandText = "spAlterarProdutos";
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@IdProduto", Convert.ToInt32(txtCod.Text));
                        Cmd.Parameters.AddWithValue("@Nome", txtProduto.Text);
                        Cmd.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                        Cmd.Parameters.AddWithValue("@ValorUnit", Convert.ToDecimal(txtVrVenda.Text));
                        Cmd.Parameters.AddWithValue("@Imagem", Img());
                        Cmd.Parameters.AddWithValue("@Id_Fornec", cBFornecedor.SelectedValue);
                        Cmd.ExecuteNonQuery();
                        con.FecharCon();
                    }
                    catch (Exception ex)
                    {

                        MsgErro("Erro ao editar: " + ex.Message);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        con.AbrirCon();
                        Cmd.Connection = con.Con;
                        Cmd.CommandText = "spExcluirProdutos";
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@IdProduto", txtCod.Text);
                        Cmd.ExecuteNonQuery();
                        con.FecharCon();
                    }
                    catch (Exception ex)
                    {

                        MsgErro("Erro ao excluir: " + ex.Message);
                    }
                    break;

                default:
                    break;
            }
        }

        private void BtNovo_Click(object sender, EventArgs e)
        {
            if (cBFornecedor.Text.Trim() == string.Empty)
            {
                MsgErro("Cadastre um Produto!");
                Close();

            }
            LimparCampos();
            op = "Novo";
            IniciarOp();

        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text.Trim() == string.Empty)
            {
                MsgErro("Insira um Produto!");
                txtProduto.Focus();
                return;
            }
            if (txtVrVenda.Text.Trim() == string.Empty)
            {
                MsgErro("Insira uma valor para o Produto!");
                txtVrVenda.Focus();
                return;
            }

            op = "Salvar";
            IniciarOp();

            HabilitarCampos(true);
            ListarProdutos();
            MsgOk("Registro salvo com sucesso!");
        }

        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text.Trim() == string.Empty)
            {
                MsgErro("Selecione um Registro para Alterar!");
                txtProduto.Focus();
                return;
            }
            op = "Editar";
            IniciarOp();

            HabilitarCampos(true);
            ListarProdutos();
            MsgOk("Registro alterado com sucesso!");
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text.Trim() == string.Empty)
            {
                MsgErro("Selecione um Registro para excluir!");
                txtProduto.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            txtProduto.Focus();
            op = "Excluir";
            IniciarOp();
            LimparCampos();
            HabilitarCampos(true);
            ListarProdutos();
            MsgOk("Registro excluido com sucesso!");
        }

        private void BtAddImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagem(*.jpg;*.png)|*.jpg;*.png|Todos os arquivos(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                pBoxProdutos.ImageLocation = foto;
            }
        }

        private void BtRemoverImagem_Click(object sender, EventArgs e)
        {
            LimparFoto();
        }

        //Método de Limpar foto

        public string foto;
        private void LimparFoto()
        {
            pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;
            // pBoxProdutos.Image = Resources.sem_foto;
            foto = "Imagem/sem-foto.jpg";

        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparFoto();
            ListarProdutos();
            PreencherCBox();
        }

        //Método de conversão do arquivo de imagem p/ enviar ao banco
        private byte[] Img()
        {
            byte[] imagemByte = null;
            if (foto == string.Empty)
            {
                return null;
            }
            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagemByte = br.ReadBytes((int)fs.Length);
            return imagemByte;
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarProdutoNome();
        }

        private void GridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarCampos(true);
            txtCod.Text = gridProdutos.CurrentRow.Cells[0].Value.ToString();
            txtProduto.Text = gridProdutos.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = gridProdutos.CurrentRow.Cells[2].Value.ToString();
            txtEstoque.Text = gridProdutos.CurrentRow.Cells[3].Value.ToString();
            txtVrCompra.Text = gridProdutos.CurrentRow.Cells[4].Value.ToString();
            txtVrVenda.Text = gridProdutos.CurrentRow.Cells[5].Value.ToString();

            //Cód que informa ao grid que vai receber imagem recuperada do Banco
            //cria-se uma variável do tipo byte[]
            byte[] imagemBuffer = (byte[])gridProdutos.CurrentRow.Cells[7].Value;

            System.IO.MemoryStream ms = new MemoryStream(imagemBuffer);
            pBoxProdutos.Image = System.Drawing.Image.FromStream(ms);
            pBoxProdutos.SizeMode = PictureBoxSizeMode.StretchImage;

            cBFornecedor.Text = gridProdutos.CurrentRow.Cells[8].Value.ToString();
        }

        //evento de duplo click na grid p/ buscar o Id,nome do produto e a quant em estoque
        private void GridFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
