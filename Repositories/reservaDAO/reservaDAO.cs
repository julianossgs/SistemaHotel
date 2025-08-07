using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System;
using System.Data;

namespace SistemaHotel.Repositories.reservaDAO
{

    public class ReservaDAO
    {
        public int InserirReserva(string hospede, string telefone, DateTime dataEntrada, DateTime dataSaida, int dias, string quarto, decimal total, string funcionario)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirReservas", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pHospede", hospede);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pDataEntrada", dataEntrada);
            cmd.Parameters.AddWithValue("pDataSaida", dataSaida);
            cmd.Parameters.AddWithValue("pDias", dias);
            cmd.Parameters.AddWithValue("pQuarto", quarto);
            cmd.Parameters.AddWithValue("pTotal", total);
            cmd.Parameters.AddWithValue("pFuncionario", funcionario);

            var reader = cmd.ExecuteReader();
            int idReserva = 0;
            if (reader.Read())
            {
                idReserva = Convert.ToInt32(reader["Retorno"]);
            }

            con.FecharCon();
            return idReserva;
        }

        public int RecuperarUltimoIdReserva()
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spRecuperarUltimoIdReserva", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();
            int idReserva = 0;

            if (reader.Read())
            {
                idReserva = Convert.ToInt32(reader["IdReserva"]);
            }

            con.FecharCon();
            return idReserva;
        }

        public void RelacionarOcupacaoReserva(int idReservaOriginal, int idReservaFinal)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spRelacionarOcupacaoReserva", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdReserva", idReservaOriginal);
            cmd.Parameters.AddWithValue("pId_Reserva", idReservaFinal);
            cmd.ExecuteNonQuery();

            con.FecharCon();
        }
    }
}




