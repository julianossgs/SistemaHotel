using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;
using System.Data;

namespace SistemaHotel.Repositories.movimentacaoDAO
{
    public class movimentacaoDAO
    {
        public DataTable ListarMovimentacoes()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarMovimentacoes", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }

        public DataTable BuscarMovimentacoesPorDatas(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            string sql = "SELECT * FROM TblMovimentacoes WHERE Data >= @DataInicial AND Data <= @DataFinal ORDER BY Data DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con.Con);
            cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
            cmd.Parameters.AddWithValue("@DataFinal", dataFinal);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }

        public DataTable BuscarMovimentacoesPorDatasETipo(DateTime dataInicial, DateTime dataFinal, string tipo)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            string sql = "SELECT * FROM TblMovimentacoes WHERE Data >= @DataInicial AND Data <= @DataFinal AND Tipo = @Tipo ORDER BY Data DESC";
            MySqlCommand cmd = new MySqlCommand(sql, con.Con);
            cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
            cmd.Parameters.AddWithValue("@DataFinal", dataFinal);
            cmd.Parameters.AddWithValue("@Tipo", tipo);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }

        public DataTable BuscarMovimentacoesPorTipo(string tipo)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spBuscarTipo", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pTipo", tipo);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }

        public void InserirMovimentacao(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirMovimentacoes", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pTipo", tipo);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void InserirMovimentacaoGastos(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirMovimentacoesGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pTipo", tipo);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void ExcluirMovimentacao(string movimento, int idVenda)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirMovimentacoes", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.Parameters.AddWithValue("@pIdVenda", idVenda);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }
    }
}
