using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.movimentacaoDAO
{
    public class movimentacaoDAO
    {
        public DataTable ListarMovimentacoes()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarMovimentacoes", con.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.FecharCon();
                LogService.LogSucesso($"Listar Movimentacoes.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Movimentacoes");
                return new DataTable();
            }

        }

        public DataTable BuscarMovimentacoesPorDatas(DateTime dataInicial, DateTime dataFinal)
        {
            try
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
                LogService.LogSucesso($"Buscar Movimentacoes PorDatas.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Movimentacoes Por Datas");
                return new DataTable();
            }

        }

        public DataTable BuscarMovimentacoesPorDatasETipo(DateTime dataInicial, DateTime dataFinal, string tipo)
        {
            try
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
                LogService.LogSucesso($"Buscar Movimentacoes Por Datas e Tipo.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Movimentacoes Por Datas e Tipo(tipo: {tipo})");
                return new DataTable();
            }

        }

        public DataTable BuscarMovimentacoesPorTipo(string tipo)
        {
            try
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
                LogService.LogSucesso($"Buscar Movimentacoes por Tipo.");
                return dt;

            }

            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Movimentacoes Por Tipo(tipo: {tipo})");
                return new DataTable();

            }

        }

        public void InserirMovimentacao(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            try
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
                LogService.LogSucesso($"Inserir Movimentacao.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Movimentacao '{movimento}");
            }

        }

        public void InserirMovimentacaoGastos(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            try
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
                LogService.LogSucesso($"Inserir Movimentacao Gasto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Movimentacao Gasto '{movimento}'");
            }

        }

        public void ExcluirMovimentacao(string movimento, int idVenda)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirMovimentacoes", con.Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.Parameters.AddWithValue("@pIdVenda", idVenda);
                cmd.ExecuteNonQuery();

                con.FecharCon();

                // Log de sucesso
                LogService.LogSucesso($"Movimentação '{movimento}' da venda {idVenda} excluída com sucesso.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir movimentação '{movimento}' da venda {idVenda}");
            }

        }
    }
}
