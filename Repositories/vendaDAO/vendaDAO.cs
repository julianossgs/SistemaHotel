using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;
using System.Data;

namespace SistemaHotel.Repositories.vendaDAO
{

    public class VendasDAO
    {
        Conexao con = new Conexao();

        public DataTable ListarVendas()
        {
            MySqlCommand cmd = new MySqlCommand("spListarVendas", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.AbrirCon();
            da.Fill(dt);
            con.FecharCon();

            return dt;
        }

        public int InserirVenda(decimal valorTotal, string funcionario, string status)
        {
            MySqlCommand cmd = new MySqlCommand("spInserirVendas", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ValorTotal", valorTotal);
            cmd.Parameters.AddWithValue("@Funcionario", funcionario);
            cmd.Parameters.AddWithValue("@Status", status);

            con.AbrirCon();
            MySqlDataReader reader = cmd.ExecuteReader();

            int idVenda = 0;
            if (reader.Read())
            {
                idVenda = Convert.ToInt32(reader["Retorno"]);
            }

            con.FecharCon();
            return idVenda;
        }

        public void CancelarVenda(int idVenda)
        {
            MySqlCommand cmd = new MySqlCommand("spExcluirVendas", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVenda", idVenda);
            cmd.Parameters.AddWithValue("@Status", "CANCELADA");

            con.AbrirCon();
            cmd.ExecuteNonQuery();
            con.FecharCon();
        }

        public DataTable BuscarVendasPorData(DateTime data)
        {
            MySqlCommand cmd = new MySqlCommand("spBuscarVendaData", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DataCadastro", data);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.AbrirCon();
            da.Fill(dt);
            con.FecharCon();

            return dt;
        }

        public int ObterUltimoIdVenda()
        {
            MySqlCommand cmd = new MySqlCommand("spUltimoIdVenda", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.AbrirCon();
            MySqlDataReader reader = cmd.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader["IdVenda"]);
            }

            con.FecharCon();
            return id;
        }
    }
}

