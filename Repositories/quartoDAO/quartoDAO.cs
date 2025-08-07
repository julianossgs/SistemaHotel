using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System.Data;

namespace SistemaHotel.Repositories.quartoDAO
{
    public class quartoDAO
    {
        public DataTable ListarQuartos()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        /// <summary>
        /// Verifica se já existe um quarto cadastrado com o mesmo número (NumeroQuarto).
        /// </summary>
        public bool ExisteQuarto(string numeroQuarto)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarQuartoCadastrado", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNumeroQuarto", numeroQuarto);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// Insere um novo quarto no banco, incluindo o número do quarto.
        /// </summary>
        public void InserirQuarto(string numeroQuarto, string quartoNome, string pessoas, string descricao, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNumeroQuarto", numeroQuarto);
            cmd.Parameters.AddWithValue("pQuarto", quartoNome);
            cmd.Parameters.AddWithValue("pPessoas", pessoas);
            cmd.Parameters.AddWithValue("pDescricao", descricao);
            cmd.Parameters.AddWithValue("pValor", valor);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        /// <summary>
        /// Edita os dados de um quarto existente, incluindo o número do quarto.
        /// </summary>
        public void EditarQuarto(int idQuarto, string numeroQuarto, string quartoNome, string pessoas, string descricao, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdQuarto", idQuarto);
            cmd.Parameters.AddWithValue("pNumeroQuarto", numeroQuarto);
            cmd.Parameters.AddWithValue("pQuarto", quartoNome);
            cmd.Parameters.AddWithValue("pPessoas", pessoas);
            cmd.Parameters.AddWithValue("pDescricao", descricao);
            cmd.Parameters.AddWithValue("pValor", valor);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        /// <summary>
        /// Exclui um quarto pelo Id.
        /// </summary>
        public void ExcluirQuarto(int idQuarto)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdQuarto", idQuarto);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }




    }
}
