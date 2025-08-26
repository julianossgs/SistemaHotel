using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.hospedeDAO
{
    public class hospedeDAO
    {
        public DataTable ListarHospedes()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarHospedes", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Hospedes.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Hospedes");
                return new DataTable();
            }

        }

        public DataTable BuscarHospedePorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarNomeHospede", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", nome);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Hospede Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Hospede Por Nome");
                return new DataTable();
            }

        }

        public DataTable BuscarHospedePorCPF(string cpf)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarCPF", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pCPF", cpf);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Hospede Por CPF.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Hospede Por CPF");
                return new DataTable();
            }

        }

        public bool ExisteHospedeCPF(string cpf)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spVerificarCPF", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pCPF", cpf);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Existe Hospede CPF.");
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Hospede Por CPF");
                return false;
            }

        }

        public void InserirHospede(
            string nome, string cpf, string endereco, string bairro, string cidade,
            string estado, string cep, string telefone, string celular, string email,
            string empresa, string placaVeiculo, string funcionario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirHospedes", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pCPF", cpf);
            cmd.Parameters.AddWithValue("pEndereco", endereco);
            cmd.Parameters.AddWithValue("pBairro", bairro);
            cmd.Parameters.AddWithValue("pCidade", cidade);
            cmd.Parameters.AddWithValue("pEstado", estado);
            cmd.Parameters.AddWithValue("pCEP", cep);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pCelular", celular);
            cmd.Parameters.AddWithValue("pEmail", email);
            cmd.Parameters.AddWithValue("pEmpresa", empresa);
            cmd.Parameters.AddWithValue("pPlacaVeiculo", placaVeiculo);
            cmd.Parameters.AddWithValue("pFuncionario", funcionario);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarHospede(
            int idHospede, string nome, string cpf, string endereco, string bairro, string cidade,
            string estado, string cep, string telefone, string celular, string email,
            string empresa, string placaVeiculo, string funcionario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarHospedes", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdHospede", idHospede);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pCPF", cpf);
            cmd.Parameters.AddWithValue("pEndereco", endereco);
            cmd.Parameters.AddWithValue("pBairro", bairro);
            cmd.Parameters.AddWithValue("pCidade", cidade);
            cmd.Parameters.AddWithValue("pEstado", estado);
            cmd.Parameters.AddWithValue("pCEP", cep);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pCelular", celular);
            cmd.Parameters.AddWithValue("pEmail", email);
            cmd.Parameters.AddWithValue("pEmpresa", empresa);
            cmd.Parameters.AddWithValue("pPlacaVeiculo", placaVeiculo);
            cmd.Parameters.AddWithValue("pFuncionario", funcionario);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void ExcluirHospede(int idHospede)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirHospedes", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pIdHospede", idHospede);
                cmd.ExecuteNonQuery();

                con.Con.Close();
                LogService.LogSucesso($"Excluir Hospede.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Hospede");
            }

        }
    }
}
