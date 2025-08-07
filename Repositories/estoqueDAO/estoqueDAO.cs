using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;

namespace SistemaHotel.Repositories.estoqueDAO
{
    public class estoqueDAO
    {
        // Atualiza o estoque e valor de compra do produto fornecedor
        public void AlterarProdutoFornecedor(int idProduto, decimal estoqueAtual, decimal quantidade, decimal valorCompra, int idFornecedor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlteraProdutoFornecedor", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pIdProduto", idProduto);
            cmd.Parameters.AddWithValue("@pEstoque", estoqueAtual + quantidade);
            cmd.Parameters.AddWithValue("@pValorCompra", valorCompra);
            cmd.Parameters.AddWithValue("@pIdFornec", idFornecedor);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        // Insere novo gasto relacionado à compra de produtos
        public void InserirGasto(string descricao, string funcionario, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pDescricao", descricao);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        // Recupera o último Id do gasto inserido
        public string RecuperarUltimoIdGasto()
        {
            string ultimoId = null;
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spRecuperarUltimoIdGasto", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ultimoId = Convert.ToString(reader["IdGasto"]);
                }
            }
            reader.Close();
            con.FecharCon();
            return ultimoId;
        }

        // Insere movimentação de gasto
        public void InserirMovimentacaoGasto(string tipo, string movimento, decimal valor, string funcionario, string idMovimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirMovimentacoesGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pTipo", tipo);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }
    }
}
