using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.loginDAO
{
    public class loginDAO
    {
        /// <summary>
        /// Cadastra um novo usuário, gerando salt e hash seguro da senha.
        /// </summary>
        public int InserirUsuario(string nome, string cargo, string usuario, string senha)
        {
            // Gera salt aleatório e hash seguro da senha
            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(senha, salt);

            // Abre conexão com banco
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirUsuarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_Nome", nome);
            cmd.Parameters.AddWithValue("@p_Cargo", cargo);
            cmd.Parameters.AddWithValue("@p_Usuario", usuario);
            cmd.Parameters.AddWithValue("@p_SenhaHash", hash);
            cmd.Parameters.AddWithValue("@p_SenhaSalt", salt);
            cmd.Parameters.AddWithValue("@p_DataCadastro", DateTime.Now);

            // Executa a procedure
            int novoId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Con.Close();
            return novoId;
        }

        /// <summary>
        /// Verifica o login do usuário, validando a senha digitada contra o hash/salt do banco.
        /// </summary>
        public (bool sucesso, string nome, string cargo) VerificarLogin(string usuario, string senha)
        {
            string nome = null;
            string cargo = null;
            bool sucesso = false;
            string senhaHash = null;
            string senhaSalt = null;

            // Abre conexão e busca usuário pelo nome
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spVerificarLogin", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pUsuario", usuario);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                nome = reader["Nome"].ToString();
                cargo = reader["Cargo"].ToString();
                senhaHash = reader["SenhaHash"].ToString();
                senhaSalt = reader["SenhaSalt"].ToString();

                // Verifica se a senha digitada gera o mesmo hash do banco
                if (PasswordHelper.VerifyPassword(senha, senhaHash, senhaSalt))
                {
                    sucesso = true;
                }
            }

            reader.Close();
            con.Con.Close();

            return (sucesso, nome, cargo);
        }
    }

}
