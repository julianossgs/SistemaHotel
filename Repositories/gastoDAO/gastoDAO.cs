using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.gastoDAO
{
    public class gastoDAO
    {
        public DataTable ListarGastos()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarGastos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.FecharCon();
                LogService.LogSucesso($"Listar Gastos.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Gastos");
                return new DataTable();
            }

        }

        public void InserirGasto(string descricao, decimal valor, string funcionario)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spInserirGastos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pDescricao", descricao);
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($"Inserir Gasto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Inserir Gasto");
            }

        }

        public string RecuperarUltimoIdGasto()
        {
            try
            {
                string ultimoId = null;
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spRecuperarUltimoIdGasto", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ultimoId = Convert.ToString(reader["IdGasto"]);
                    }
                }
                reader.Close();
                con.FecharCon();
                LogService.LogSucesso($"Recuperar Ultimo IdGasto.");
                return ultimoId;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Recuperar Ultimo IdGasto.");
                return null;
            }

        }

        public void LancarGastosMovimentacoes(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spLancarGastosMovimentacoes", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pTipo", tipo);
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
                cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($" Lancar Gastos Movimentacoes.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $" Lancar Gastos Movimentacoes");
            }

        }

        public void EditarGasto(int idGasto, string descricao, decimal valor, string funcionario)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spAlterarGastos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
                cmd.Parameters.AddWithValue("@pDescricao", descricao);
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($"Editar Gastos.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Editar Gastos");
            }

        }

        public void AtualizarValorMovimentacao(decimal valor, string funcionario, int idMovimento, string movimento)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spAtualizarValorMovimentacao", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
                cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($"Atualizar Valor Movimentacao.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Atualizar Valor Movimentacao");
            }

        }

        public void ExcluirGasto(int idGasto)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirGastos", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($"Excluir Gastos.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Gastos");
            }

        }

        public void ExcluirMovGasto(int idGasto, string movimento)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spExcluirMovGasto", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.ExecuteNonQuery();

                con.FecharCon();
                LogService.LogSucesso($"Excluir Mov Gasto.");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Excluir Mov Gasto");
            }

        }

        public DataTable BuscarGastosData(DateTime data)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarGastosData", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pData", data);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.FecharCon();
                LogService.LogSucesso($"Buscar Gastos Data.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Gastos Data");
                return new DataTable();
            }

        }
    }
}
