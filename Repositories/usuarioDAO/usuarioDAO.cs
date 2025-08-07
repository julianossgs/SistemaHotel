using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.usuarioDAO
{
    public class usuarioDAO
    {
        public DataTable ListarUsuarios()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public DataTable BuscarUsuarioPorNome(string nome)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spBuscarUsuarioNome", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNome", nome);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public bool ExisteUsuario(string usuario)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarUsuario", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pUsuario", usuario);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        public void InserirUsuario(string nome, string cargo, string usuario, string senha, DateTime dataCadastro)
        {
            // Gera salt e hash seguro para a senha
            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(senha, salt);

            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Nome", nome);
            cmd.Parameters.AddWithValue("p_Cargo", cargo);
            cmd.Parameters.AddWithValue("p_Usuario", usuario);
            cmd.Parameters.AddWithValue("p_SenhaHash", hash);
            cmd.Parameters.AddWithValue("p_SenhaSalt", salt);
            cmd.Parameters.AddWithValue("p_DataCadastro", dataCadastro);
            //cmd.Parameters.AddWithValue("pDataCadastro", func.DataCadastro.HasValue ? func.DataCadastro.Value : DateTime.Now);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarUsuario(int idUsuario, string nome, string cargo, string usuario, string senha)
        {
            // Gera salt e hash seguro para a senha
            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(senha, salt);

            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pCargo", cargo);
            cmd.Parameters.AddWithValue("pUsuario", usuario);
            cmd.Parameters.AddWithValue("pSenhaHash", hash);
            cmd.Parameters.AddWithValue("pSenhaSalt", salt);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void ExcluirUsuario(int idUsuario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        //Método de verificação de duplicidade p/ usuário
        public bool ExisteUsuarioSenha(string usuario, string senha)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarLogin", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pUsuario", usuario);
            //cmd.Parameters.AddWithValue("pSenha", senha);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            if (dt.Rows.Count == 0)
                return false;

            string hashBanco = dt.Rows[0]["SenhaHash"].ToString();
            string saltBanco = dt.Rows[0]["SenhaSalt"].ToString();

            // Compara hash gerado da senha informada com o hash salvo
            return PasswordHelper.VerifyPassword(senha, hashBanco, saltBanco);
        }

        //Método de verificação de duplicidade p/ senha
        public bool ExisteSenha(string senha)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            // Busca todos os salts e hashes cadastrados
            MySqlCommand cmd = new MySqlCommand("SELECT SenhaHash, SenhaSalt FROM TblUsuarios", con.Con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();

            foreach (DataRow row in dt.Rows)
            {
                string hashBanco = row["SenhaHash"].ToString();
                string saltBanco = row["SenhaSalt"].ToString();

                // Se a senha informada gerar o mesmo hash com o salt, existe duplicidade
                if (PasswordHelper.VerifyPassword(senha, hashBanco, saltBanco))
                    return true;
            }

            return false;
        }

    }
}
