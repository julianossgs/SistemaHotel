using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.cargoDAO
{
    public class cargoDAO
    {
        public DataTable ListarCargos()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarCargos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Cargos.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Cargos");
                return new DataTable();
            }

        }

        public DataTable BuscarCargoPorNome(string cargo)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                // Não existe procedure de busca por nome, mas pode ser criada ou feita consulta direta.
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblCargos WHERE Cargo LIKE @cargo", con.Con);
                cmd.Parameters.AddWithValue("@cargo", "%" + cargo + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Cargo Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"Buscar Cargo Por Nome");
                return new DataTable();
            }

        }

        public bool ExisteCargo(string cargo)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblCargos WHERE Cargo = @cargo", con.Con);
                cmd.Parameters.AddWithValue("@cargo", cargo);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Existe Cargo.");
                return dt.Rows.Count > 0;

            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe Cargo");
                return false;
            }

        }

        public void InserirCargo(string cargo)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spInserirCargos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pCargo", cargo);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Registro inserido com sucesso.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Registro");
            }

        }

        public void EditarCargo(int idCargo, string cargo)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spAlterarCargos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdCargo", idCargo);
                cmd.Parameters.AddWithValue("pCargo", cargo);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Registro alterado com sucesso.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Alterar Registro");
            }

        }

        public void ExcluirCargo(int idCargo)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirCargos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdCargo", idCargo);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                // Log de sucesso
                LogService.LogSucesso($"Registro excluído com sucesso.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Registro");
            }

        }
    }
}
