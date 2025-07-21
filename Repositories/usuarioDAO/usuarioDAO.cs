using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
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
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_Nome", nome);
            cmd.Parameters.AddWithValue("p_Cargo", cargo);
            cmd.Parameters.AddWithValue("p_Usuario", usuario);
            cmd.Parameters.AddWithValue("p_Senha", senha);
            cmd.Parameters.AddWithValue("p_DataCadastro", dataCadastro);
            //cmd.Parameters.AddWithValue("pDataCadastro", func.DataCadastro.HasValue ? func.DataCadastro.Value : DateTime.Now);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarUsuario(int idUsuario, string nome, string cargo, string usuario, string senha)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pCargo", cargo);
            cmd.Parameters.AddWithValue("pUsuario", usuario);
            cmd.Parameters.AddWithValue("pSenha", senha);
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
            cmd.Parameters.AddWithValue("pSenha", senha);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        //Método de verificação de duplicidade p/ senha
        public bool ExisteSenha(string senha)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblUsuarios WHERE Senha = @senha", con.Con);
            cmd.Parameters.AddWithValue("@senha", senha);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }
    }
}
