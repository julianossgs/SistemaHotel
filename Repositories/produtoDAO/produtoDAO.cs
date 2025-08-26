using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.produtoDAO
{
    public class produtoDAO
    {
        private Conexao _conexao = new Conexao();

        /// <summary>
        /// Lista todos os produtos cadastrados no sistema, com nome do fornecedor.
        /// </summary>
        public DataTable ListarProdutos()
        {
            try
            {
                DataTable dt = new DataTable();
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spListarProdutos", _conexao.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                da.Fill(dt);

                _conexao.Con.Close();
                LogService.LogSucesso($"Listar Produtos.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Produtos");
                return new DataTable();
            }

        }

        /// <summary>
        /// Busca um ou mais produtos pelo nome (filtro LIKE).
        /// </summary>
        public DataTable BuscarProdutoPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spBuscarProdutoNome", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", nome);
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                da.Fill(dt);

                _conexao.Con.Close();
                LogService.LogSucesso($"Buscar Produto Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Produto Por Nome");
                return new DataTable();
            }

        }

        /// <summary>
        /// Insere um novo produto no banco.
        /// </summary>
        public int InserirProduto(Produto produto)
        {
            try
            {
                int retorno = 0;
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spInserirProdutos", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", produto.Nome);
                cmd.Parameters.AddWithValue("pDescricao", produto.Descricao ?? (object)System.DBNull.Value);
                cmd.Parameters.AddWithValue("pValorUnit", produto.ValorUnit);
                cmd.Parameters.AddWithValue("pValorCompra", produto.ValorCompra);
                cmd.Parameters.AddWithValue("pEstoque", produto.Estoque);
                cmd.Parameters.AddWithValue("pImagem", produto.Imagem ?? (object)System.DBNull.Value);
                cmd.Parameters.AddWithValue("pIdFornec", produto.IdFornec);

                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && int.TryParse(dr["Retorno"].ToString(), out int id))
                    retorno = id;

                dr.Close();
                _conexao.Con.Close();
                LogService.LogSucesso($"Inserir Produto.");
                return retorno;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Produto");
                return 0;

            }

        }

        /// <summary>
        /// Altera os dados de um produto existente.
        /// </summary>
        public bool AlterarProduto(Produto produto)
        {
            try
            {
                bool sucesso = false;
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spAlterarProdutos", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdProduto", produto.IdProduto);
                cmd.Parameters.AddWithValue("pNome", produto.Nome);
                cmd.Parameters.AddWithValue("pDescricao", produto.Descricao ?? (object)System.DBNull.Value);
                cmd.Parameters.AddWithValue("pValorUnit", produto.ValorUnit);
                cmd.Parameters.AddWithValue("pValorCompra", produto.ValorCompra);
                cmd.Parameters.AddWithValue("pEstoque", produto.Estoque);
                cmd.Parameters.AddWithValue("pImagem", produto.Imagem ?? (object)System.DBNull.Value);
                cmd.Parameters.AddWithValue("pIdFornec", produto.IdFornec);

                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && int.TryParse(dr["Retorno"].ToString(), out int linhasAfetadas))
                    sucesso = linhasAfetadas > 0;

                dr.Close();
                _conexao.Con.Close();
                LogService.LogSucesso($"Alterar Produto.");
                return sucesso;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Alterar Produto");
                return false;
            }

        }

        /// <summary>
        /// Exclui um produto pelo ID.
        /// </summary>
        public bool ExcluirProduto(int idProduto)
        {
            try
            {
                bool sucesso = false;
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spExcluirProdutos", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdProduto", idProduto);

                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && int.TryParse(dr["Retorno"].ToString(), out int linhasAfetadas))
                    sucesso = linhasAfetadas > 0;

                dr.Close();
                _conexao.Con.Close();
                LogService.LogSucesso($"Excluir Produto.");
                return sucesso;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Produto");
                return false;
            }

        }

        /// <summary>
        /// Atualiza o estoque de um produto.
        /// </summary>
        public bool AtualizarEstoque(int idProduto, decimal novoEstoque)
        {
            try
            {
                bool sucesso = false;
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spAtualizarEstoque", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdProduto", idProduto);
                cmd.Parameters.AddWithValue("pEstoque", novoEstoque);

                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && int.TryParse(dr["Retorno"].ToString(), out int linhasAfetadas))
                    sucesso = linhasAfetadas > 0;

                dr.Close();
                _conexao.Con.Close();
                LogService.LogSucesso($"Atualizar Estoque.");
                return sucesso;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Atualizar Estoque");
                return false;
            }

        }

        /// <summary>
        /// Recupera os dados completos de um produto por ID.
        /// </summary>
        public Produto RecuperarProdutoPorId(int idProduto)
        {
            try
            {
                Produto produto = null;
                _conexao.AbrirCon();

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spRecuperarEstoque", _conexao.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdProduto", idProduto);

                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    produto = new Produto();
                    produto.IdProduto = System.Convert.ToInt32(dr["IdProduto"]);
                    produto.Nome = dr["Nome"].ToString();
                    produto.Descricao = dr["Descricao"].ToString();
                    produto.ValorUnit = dr["ValorUnit"] != System.DBNull.Value ? System.Convert.ToDecimal(dr["ValorUnit"]) : 0;
                    produto.ValorCompra = dr["ValorCompra"] != System.DBNull.Value ? System.Convert.ToDecimal(dr["ValorCompra"]) : 0;
                    produto.Estoque = dr["Estoque"] != System.DBNull.Value ? System.Convert.ToDecimal(dr["Estoque"]) : 0;
                    produto.DataCadastro = dr["DataCadastro"] != System.DBNull.Value ? System.Convert.ToDateTime(dr["DataCadastro"]) : System.DateTime.MinValue;
                    produto.Imagem = dr["Imagem"] as byte[];
                    produto.IdFornec = dr["IdFornec"] != System.DBNull.Value ? System.Convert.ToInt32(dr["IdFornec"]) : 0;
                }

                dr.Close();
                _conexao.Con.Close();
                LogService.LogSucesso($"Atualizar Estoque.");
                return produto;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Atualizar Estoque");
                return null;
            }

        }
    }
}
