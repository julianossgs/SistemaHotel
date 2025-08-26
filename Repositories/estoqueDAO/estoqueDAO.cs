using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;

namespace SistemaHotel.Repositories.estoqueDAO
{
    public class estoqueDAO
    {
        // Atualiza o estoque e valor de compra do produto fornecedor
        public void AlterarProdutoFornecedor(int idProduto, decimal estoqueAtual, decimal quantidade, decimal valorCompra, int idFornecedor)
        {
            try
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
                LogService.LogSucesso($"Alterar Produto Fornecedor.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Alterar Produto Fornecedor.");
            }

        }

        // Insere novo gasto relacionado à compra de produtos
        public void InserirGasto(string descricao, string funcionario, decimal valor)
        {
            try
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
                LogService.LogSucesso($"Inserir Gasto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Gasto.");
            }

        }

        // Recupera o último Id do gasto inserido
        public string RecuperarUltimoIdGasto()
        {
            try
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
                LogService.LogSucesso($"Recuperar Ultimo IdGasto.");
                return ultimoId;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Recuperar Ultimo IdGasto");
                return null;

            }

        }

        // Insere movimentação de gasto
        public void InserirMovimentacaoGasto(string tipo, string movimento, decimal valor, string funcionario, string idMovimento)
        {
            try
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
                LogService.LogSucesso($"Inserir Movimentacao Gasto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Movimentacao Gasto");
            }

        }

        // Recupera o estoque atual de um produto
        public decimal ObterEstoque(int idProduto)
        {
            try
            {
                decimal estoqueAtual = 0;
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spObterEstoque", con.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdProduto", idProduto);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        estoqueAtual = reader["Estoque"] != DBNull.Value
                            ? Convert.ToDecimal(reader["Estoque"])
                            : 0;
                    }
                }

                reader.Close();
                con.FecharCon();

                LogService.LogSucesso($"Obter estoque do produto Id={idProduto}.");
                return estoqueAtual;
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"Obter estoque do produto Id={idProduto}.");
                return 0;
            }
        }


    }
}
