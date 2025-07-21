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

        public bool ExisteQuarto(string quarto)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarQuartoCadastrado", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pQuarto", quarto);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        public void InserirQuarto(string quarto, string pessoas, string descricao, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pQuarto", quarto);
            cmd.Parameters.AddWithValue("pPessoas", pessoas);
            cmd.Parameters.AddWithValue("pDescricao", descricao);
            cmd.Parameters.AddWithValue("pValor", valor);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarQuarto(int idQuarto, string quarto, string pessoas, string descricao, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarQuartos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdQuarto", idQuarto);
            cmd.Parameters.AddWithValue("pQuarto", quarto);
            cmd.Parameters.AddWithValue("pPessoas", pessoas);
            cmd.Parameters.AddWithValue("pDescricao", descricao);
            cmd.Parameters.AddWithValue("pValor", valor);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

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
