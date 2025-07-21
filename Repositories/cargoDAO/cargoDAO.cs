using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using System.Data;

namespace SistemaHotel.Repositories.cargoDAO
{
    public class cargoDAO
    {
        public DataTable ListarCargos()
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spListarCargos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public DataTable BuscarCargoPorNome(string cargo)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            // Não existe procedure de busca por nome, mas pode ser criada ou feita consulta direta.
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblCargos WHERE Cargo LIKE @cargo", con.Con);
            cmd.Parameters.AddWithValue("@cargo", "%" + cargo + "%");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt;
        }

        public bool ExisteCargo(string cargo)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblCargos WHERE Cargo = @cargo", con.Con);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        public void InserirCargo(string cargo)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirCargos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pCargo", cargo);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarCargo(int idCargo, string cargo)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarCargos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdCargo", idCargo);
            cmd.Parameters.AddWithValue("pCargo", cargo);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void ExcluirCargo(int idCargo)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirCargos", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdCargo", idCargo);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }
    }
}
