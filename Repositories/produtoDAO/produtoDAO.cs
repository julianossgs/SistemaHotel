using SistemaHotel.Dados;
using SistemaHotel.Models;

namespace SistemaHotel.Repositories.produtoDAO
{
    public class produtoDAO
    {
        private Conexao _conexao = new Conexao();

        /// <summary>
        /// Lista todos os produtos cadastrados no sistema, com nome do fornecedor.
        /// </summary>
        public System.Data.DataTable ListarProdutos()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            _conexao.AbrirCon();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spListarProdutos", _conexao.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(dt);

            _conexao.Con.Close();
            return dt;
        }

        /// <summary>
        /// Busca um ou mais produtos pelo nome (filtro LIKE).
        /// </summary>
        public System.Data.DataTable BuscarProdutoPorNome(string nome)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            _conexao.AbrirCon();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("spBuscarProdutoNome", _conexao.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNome", nome);
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(dt);

            _conexao.Con.Close();
            return dt;
        }

        /// <summary>
        /// Insere um novo produto no banco.
        /// </summary>
        public int InserirProduto(Produto produto)
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
            return retorno;
        }

        /// <summary>
        /// Altera os dados de um produto existente.
        /// </summary>
        public bool AlterarProduto(Produto produto)
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
            return sucesso;
        }

        /// <summary>
        /// Exclui um produto pelo ID.
        /// </summary>
        public bool ExcluirProduto(int idProduto)
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
            return sucesso;
        }

        /// <summary>
        /// Atualiza o estoque de um produto.
        /// </summary>
        public bool AtualizarEstoque(int idProduto, decimal novoEstoque)
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
            return sucesso;
        }

        /// <summary>
        /// Recupera os dados completos de um produto por ID.
        /// </summary>
        public Produto RecuperarProdutoPorId(int idProduto)
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
            return produto;
        }
    }
}
