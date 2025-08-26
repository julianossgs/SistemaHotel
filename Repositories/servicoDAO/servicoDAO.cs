using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.servicoDAO
{
    public class servicoDAO
    {
        public DataTable ListarServicos()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarServicos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Servicos.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Servicos");
                return new DataTable();
            }

        }

        public DataTable BuscarServicoPorNome(string servico)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                // Não existe procedure, então faz consulta direta
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblServicos WHERE Servico LIKE @servico", con.Con);
                cmd.Parameters.AddWithValue("@servico", "%" + servico + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Servico Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Servico Por Nome");
                return new DataTable();
            }

        }

        public bool ExisteServico(string servico)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblServicos WHERE Servico = @servico", con.Con);
                cmd.Parameters.AddWithValue("@servico", servico);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Existe Servico.");
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe Servico");
                return false;
            }

        }

        public void InserirServico(string servico, decimal valor)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spInserirServicos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pServico", servico);
                cmd.Parameters.AddWithValue("pValor", valor);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Inserir Servico.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Servico");

            }

        }

        public void EditarServico(int idServico, string servico, decimal valor)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spAlterarServicos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdServico", idServico);
                cmd.Parameters.AddWithValue("pServico", servico);
                cmd.Parameters.AddWithValue("pValor", valor);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Editar Servico.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Editar Servico");
            }

        }

        public void ExcluirServico(int idServico)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirServicos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdServico", idServico);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Excluir Servico.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Servico");
            }

        }

        public DataTable BuscarServicoValor(string servico)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarServicosValor", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pServico", servico);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Servico Valor.");
                return dt;
            }
            catch (Exception ex)
            {


                LogService.LogError(ex, $"Buscar Servico Valor");
                return new DataTable();
            }

        }
    }
}
