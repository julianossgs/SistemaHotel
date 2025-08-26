using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.fornecedorDAO
{
    public class fornecedorDAO
    {
        public DataTable ListarFornecedores()
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spListarFornecedores", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Listar Fornecedores.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Fornecedores.");
                return new DataTable();
            }

        }

        public DataTable BuscarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spBuscarFornecNome", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", nome);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Buscar Fornecedor Por Nome.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Buscar Fornecedor Por Nome.");
                return new DataTable();
            }

        }

        public bool ExisteFornecedor(string nome)
        {
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                MySqlCommand cmd = new MySqlCommand("spVerificarFornec", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNome", nome);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                con.Con.Close();
                LogService.LogSucesso($"Existe Fornecedor.");
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Existe Fornecedor.");
                return false;
            }

        }

        public bool ExisteCNPJ(string cnpj)
        {
            DataTable dt = new DataTable();
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TblFornecedores WHERE Cnpj = @cnpj", con.Con);
            cmd.Parameters.AddWithValue("@cnpj", cnpj);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            con.Con.Close();
            return dt.Rows.Count > 0;
        }

        public void InserirFornecedor(
            string cnpj,
            string nome,
            string endereco,
            string bairro,
            string cidade,
            string estado,
            string cep,
            string telefone,
            string celular,
            string email,
            string contato,
            string observacoes
        )
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spInserirFornec", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("pCnpj", cnpj);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pEndereco", endereco);
            cmd.Parameters.AddWithValue("pBairro", bairro);
            cmd.Parameters.AddWithValue("pCidade", cidade);
            cmd.Parameters.AddWithValue("pEstado", estado);
            cmd.Parameters.AddWithValue("pCep", cep);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pCelular", celular);
            cmd.Parameters.AddWithValue("pEmail", email);
            cmd.Parameters.AddWithValue("pContato", contato);
            cmd.Parameters.AddWithValue("pDataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("pObservacoes", observacoes);


            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void EditarFornecedor(
            int idFornec,
            string cnpj,
            string nome,
            string endereco,
            string bairro,
            string cidade,
            string estado,
            string cep,
            string telefone,
            string celular,
            string email,
            string contato,
            string observacoes
        )
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarFornec", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("pIdFornec", idFornec);
            cmd.Parameters.AddWithValue("pCnpj", cnpj);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pEndereco", endereco);
            cmd.Parameters.AddWithValue("pBairro", bairro);
            cmd.Parameters.AddWithValue("pCidade", cidade);
            cmd.Parameters.AddWithValue("pEstado", estado);
            cmd.Parameters.AddWithValue("pCep", cep);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pCelular", celular);
            cmd.Parameters.AddWithValue("pEmail", email);
            cmd.Parameters.AddWithValue("pContato", contato);
            cmd.Parameters.AddWithValue("pDataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("pObservacoes", observacoes);


            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void ExcluirFornecedor(int idFornec)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spExcluirFornec", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pIdFornec", idFornec);
            cmd.ExecuteNonQuery();

            con.Con.Close();
        }

        public void AtualizarFornecedor(
    int idFornec,
    string cnpj,
    string nome,
    string endereco,
    string bairro,
    string cidade,
    string estado,
    string cep,
    string telefone,
    string celular,
    string email,
    string contato,
    string observacoes
)
        {
            Conexao con = new Conexao();
            con.AbrirCon();

            MySqlCommand cmd = new MySqlCommand("spAlterarFornec", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("pIdFornec", idFornec);
            cmd.Parameters.AddWithValue("pCnpj", cnpj);
            cmd.Parameters.AddWithValue("pNome", nome);
            cmd.Parameters.AddWithValue("pEndereco", endereco);
            cmd.Parameters.AddWithValue("pBairro", bairro);
            cmd.Parameters.AddWithValue("pCidade", cidade);
            cmd.Parameters.AddWithValue("pEstado", estado);
            cmd.Parameters.AddWithValue("pCep", cep);
            cmd.Parameters.AddWithValue("pTelefone", telefone);
            cmd.Parameters.AddWithValue("pCelular", celular);
            cmd.Parameters.AddWithValue("pEmail", email);
            cmd.Parameters.AddWithValue("pContato", contato);
            cmd.Parameters.AddWithValue("pDataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("pObservacoes", observacoes);

            cmd.ExecuteNonQuery();
            con.Con.Close();
        }


    }
}
