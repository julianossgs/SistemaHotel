using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.funcionarioDAO
{
    public class FuncionarioDAO
    {
        public DataTable ListarFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarFuncionarios", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Funcionários.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Funcionários.");
                return new DataTable();
            }

        }

        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarFuncionarioNome", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNome", nome);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Funcionario Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Funcionario Por Nome.");
                return new DataTable();

            }

        }

        public DataTable BuscarFuncionarioPorCpf(string cpf)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarFuncionarioCpf", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pCpf", cpf);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Funcionario Por CPF.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Funcionario Por CPF.");
                return new DataTable();
            }

        }

        public bool ExisteCpf(string cpf)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spVerificarCpfFuncionario", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pcpf", cpf);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Existe CPF.");
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe CPF.");
                return false;
            }

        }

        public void InserirFuncionario(Funcionario func)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spInserirFuncionarios", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", func.Nome);
                cmd.Parameters.AddWithValue("pCpf", func.Cpf);
                cmd.Parameters.AddWithValue("pEndereco", func.Endereco ?? "");
                cmd.Parameters.AddWithValue("pTelefone", func.Telefone ?? "");
                cmd.Parameters.AddWithValue("pEmail", func.Email ?? "");
                cmd.Parameters.AddWithValue("pCargo", func.Cargo);
                cmd.Parameters.AddWithValue("pObservacoes", func.Observacoes ?? "");
                cmd.Parameters.AddWithValue("pDataCadastro", func.DataCadastro.HasValue ? func.DataCadastro.Value : DateTime.Now);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Inserir Funcionario.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Funcionario.");

            }

        }

        public void EditarFuncionario(Funcionario func)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spAlterarFuncionarios", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdFunc", func.IdFunc);
                cmd.Parameters.AddWithValue("pNome", func.Nome);
                cmd.Parameters.AddWithValue("pCpf", func.Cpf);
                cmd.Parameters.AddWithValue("pEndereco", func.Endereco ?? "");
                cmd.Parameters.AddWithValue("pTelefone", func.Telefone ?? "");
                cmd.Parameters.AddWithValue("pEmail", func.Email ?? "");
                cmd.Parameters.AddWithValue("pCargo", func.Cargo);
                cmd.Parameters.AddWithValue("pObservacoes", func.Observacoes ?? "");
                cmd.Parameters.AddWithValue("@pDataCadastro", func.DataCadastro.HasValue ? func.DataCadastro.Value : DateTime.Now);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Editar Funcionario.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Editar Funcionario.");
            }

        }

        public void ExcluirFuncionario(int idFunc)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirFuncionarios", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdFunc", idFunc);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Excluir Funcionario.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe CPF.");

            }

        }
    }
}
