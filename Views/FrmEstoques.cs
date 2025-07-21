using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmEstoques : Form
    {

        public FrmEstoques()
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

        private void FrmEstoques_Load(object sender, EventArgs e)
        {
            HabilitarCampos(false);
            PreencherCBoxFornecedor();
        }

        private void LimparCampos()
        {
            txtEstoque.Clear();
            txtQuant.Clear();
            txtVrCompra.Clear();
            txtProduto.Clear();
        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {
                txtEstoque.Enabled = true;
                txtQuant.Enabled = true;
                txtVrCompra.Enabled = true;
                cBFornecedor.Enabled = true;
                btSalvar.Enabled = true;
            }
            else
            {
                txtEstoque.Enabled = false;
                txtQuant.Enabled = false;
                txtVrCompra.Enabled = false;
                cBFornecedor.Enabled = false;
                btSalvar.Enabled = false;
            }
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
            HabilitarCampos(true);
            LimparCampos();
            //variável global criada na classe Program
            Globais.chamadaProdutos = "estoque";

            //abrindo o Frm de Produtos
            FrmProdutos frm = new FrmProdutos();
            frm.Show();
        }

        //botão salvar
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text.ToString().Trim() == string.Empty)
            {
                txtProduto.Clear();
                MsgErro("Selecione um Produto!");
                txtProduto.Focus();
                return;
            }
            if (txtQuant.Text == string.Empty)
            {
                txtQuant.Clear();
                MsgErro("Informe a Quantidade!");
                txtQuant.Focus();
                return;
            }
            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd2 = new MySqlCommand();
            Cmd2.Connection = con.Con;
            Cmd2.CommandText = "spAlteraProdutoFornecedor";
            Cmd2.CommandType = CommandType.StoredProcedure;
            Cmd2.Parameters.AddWithValue("@IdProduto", Globais.idProduto);

            Cmd2.Parameters.AddWithValue("@Estoque", Convert.ToDecimal(txtQuant.Text) + Convert.ToDecimal(txtEstoque.Text));
            Cmd2.Parameters.AddWithValue("@ValorCompra", Convert.ToDecimal(txtVrCompra.Text));
            Cmd2.Parameters.AddWithValue("@Id_Fornec", cBFornecedor.SelectedValue);
            Cmd2.ExecuteNonQuery();
            con.FecharCon();
            MsgOk("Lançamento feito com sucesso!");

            //lançar o valor do pedido nos gastos
            con.AbrirCon();
            MySqlCommand Cmdg = new MySqlCommand();
            Cmdg.Connection = con.Con;
            Cmdg.CommandText = "spInserirGastos";
            Cmdg.CommandType = CommandType.StoredProcedure;
            Cmdg.Parameters.AddWithValue("@Descricao", "Compra de Produtos");
            Cmdg.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            Cmdg.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtVrCompra.Text) * Convert.ToDecimal(txtQuant.Text));
            Cmdg.ExecuteNonQuery();
            con.FecharCon();

            //recuperar ultimo Id do gasto
            con.AbrirCon();
            MySqlCommand Cmdt = new MySqlCommand();
            Cmdt.Connection = con.Con;
            Cmdt.CommandText = "spRecuperarUltimoIdGasto";
            Cmdt.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader;
            reader = Cmdt.ExecuteReader();

            if (reader.HasRows)
            {
                //extraindo informações da consulta
                while (reader.Read())
                {
                    Globais.ultimoIdGasto = Convert.ToString(reader["IdGasto"]);
                }

            }

            //lançar o valor do pedido nas movimentações
            con.AbrirCon();
            MySqlCommand Cmd3 = new MySqlCommand();
            Cmd3.Connection = con.Con;
            Cmd3.CommandText = "spInserirMovimentacoesGastos";
            Cmd3.CommandType = CommandType.StoredProcedure;
            Cmd3.Parameters.AddWithValue("@Tipo", "Saída");
            Cmd3.Parameters.AddWithValue("@Movimento", "Gastos");
            Cmd3.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtVrCompra.Text) * Convert.ToDecimal(txtQuant.Text));
            Cmd3.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
            Cmd3.Parameters.AddWithValue("@Id_Movimento", Globais.ultimoIdGasto);
            Cmd3.ExecuteNonQuery();
            con.FecharCon();
            LimparCampos();
            HabilitarCampos(false);
        }


        //evento que ativa o formulário p/ buscar de informações
        private void FrmEstoques_Activated(object sender, EventArgs e)
        {
            //variáveis globais criadas na classe Program
            //está passando também o IdProduto,que não é necessário mostrar em tela
            txtEstoque.Text = Globais.estoqueProduto;
            txtProduto.Text = Globais.nomeProduto;
            txtVrCompra.Text = Globais.VrCompra;
        }
    }
}
