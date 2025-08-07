using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;
using System.Data;

namespace SistemaHotel.Repositories.gastoDAO
{
    public class gastoDAO
    {
        public DataTable ListarGastos()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }

        public void InserirGasto(string descricao, decimal valor, string funcionario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pDescricao", descricao);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public string RecuperarUltimoIdGasto()
        {
            string ultimoId = null;
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spRecuperarUltimoIdGasto", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
            return ultimoId;
        }

        public void LancarGastosMovimentacoes(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spLancarGastosMovimentacoes", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pTipo", tipo);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void EditarGasto(int idGasto, string descricao, decimal valor, string funcionario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
            cmd.Parameters.AddWithValue("@pDescricao", descricao);
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void AtualizarValorMovimentacao(decimal valor, string funcionario, int idMovimento, string movimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAtualizarValorMovimentacao", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pValor", valor);
            cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
            cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void ExcluirGasto(int idGasto)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirGastos", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public void ExcluirMovGasto(int idGasto, string movimento)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirMovGasto", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pIdGasto", idGasto);
            cmd.Parameters.AddWithValue("@pMovimento", movimento);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }

        public DataTable BuscarGastosData(DateTime data)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spBuscarGastosData", con.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pData", data);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.FecharCon();
            return dt;
        }
    }
}
