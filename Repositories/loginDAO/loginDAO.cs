using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System.Data;

namespace SistemaHotel.Repositories.loginDAO
{
    public class loginDAO
    {
        public (bool sucesso, string nome, string cargo) VerificarLogin(string usuario, string senha)

        {
            string nome = null;
            string cargo = null;
            bool sucesso = false;

            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarLogin", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pUsuario", usuario);
            cmd.Parameters.AddWithValue("@pSenha", senha);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                nome = reader["Nome"].ToString();
                cargo = reader["Cargo"].ToString();
                sucesso = true;
            }

            // Feche o reader e a conexão manualmente!
            reader.Close();
            con.Con.Close();

            return (sucesso, nome, cargo);
        }
    }

}
