using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System.Data;

namespace SistemaHotel.Repositories.servicoDAO
{
    public class servicoDAO
    {
        public DataTable ListarServicos()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarServicos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public DataTable BuscarServicoPorNome(string servico)
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
            return dt;
        }

        public bool ExisteServico(string servico)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblServicos WHERE Servico = @servico", con.Con);
            cmd.Parameters.AddWithValue("@servico", servico);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        public void InserirServico(string servico, decimal valor)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirServicos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pServico", servico);
            cmd.Parameters.AddWithValue("pValor", valor);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarServico(int idServico, string servico, decimal valor)
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
        }

        public void ExcluirServico(int idServico)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirServicos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdServico", idServico);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public DataTable BuscarServicoValor(string servico)
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
            return dt;
        }
    }
}
