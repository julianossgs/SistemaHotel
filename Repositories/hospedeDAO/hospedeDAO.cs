using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System.Data;

namespace SistemaHotel.Repositories.hospedeDAO
{
    public class hospedeDAO
    {
        public DataTable ListarHospedes()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarHospedes", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public DataTable BuscarHospedePorNome(string nome)
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
            return dt;
        }

        public DataTable BuscarHospedePorCPF(string cpf)
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
            return dt;
        }

        public bool ExisteHospedeCPF(string cpf)
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
            return dt.Rows.Count > 0;
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
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirHospedes", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdHospede", idHospede);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }
    }
}
