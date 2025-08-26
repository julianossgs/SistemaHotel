using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.quartoDAO
{
    public class quartoDAO
    {
        public DataTable ListarQuartos()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarQuartos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Quartos.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Quartos");
                return new DataTable();
            }

        }

        /// <summary>
        /// Verifica se já existe um quarto cadastrado com o mesmo número (NumeroQuarto).
        /// </summary>
        public bool ExisteQuarto(string numeroQuarto)
        {
            try
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
                LogService.LogSucesso($"Existe Quarto.");
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe Quarto");
                return false;
            }

        }

        /// <summary>
        /// Insere um novo quarto no banco, incluindo o número do quarto.
        /// </summary>
        public void InserirQuarto(string numeroQuarto, string quartoNome, string pessoas, string descricao, decimal valor)
        {
            try
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
                LogService.LogSucesso($"Inserir Quarto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Quarto");
            }

        }

        /// <summary>
        /// Edita os dados de um quarto existente, incluindo o número do quarto.
        /// </summary>
        public void EditarQuarto(int idQuarto, string numeroQuarto, string quartoNome, string pessoas, string descricao, decimal valor)
        {
            try
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
                LogService.LogSucesso($"Editar Quarto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Editar Quarto");
            }

        }

        /// <summary>
        /// Exclui um quarto pelo Id.
        /// </summary>
        public void ExcluirQuarto(int idQuarto)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirQuartos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdQuarto", idQuarto);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Excluir Quarto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Quarto");
            }

        }




    }
}
