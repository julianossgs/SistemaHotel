using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using System;
using System.Data;

namespace SistemaHotel.Repositories.funcionarioDAO
{
    public class FuncionarioDAO
    {
        public DataTable ListarFuncionarios()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarFuncionarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public DataTable BuscarFuncionarioPorNome(string nome)
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
            return dt;
        }

        public DataTable BuscarFuncionarioPorCpf(string cpf)
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
            return dt;
        }

        public bool ExisteCpf(string cpf)
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
            return dt.Rows.Count > 0;
        }

        public void InserirFuncionario(Funcionario func)
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
        }

        public void EditarFuncionario(Funcionario func)
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
        }

        public void ExcluirFuncionario(int idFunc)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirFuncionarios", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdFunc", idFunc);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }
    }
}
