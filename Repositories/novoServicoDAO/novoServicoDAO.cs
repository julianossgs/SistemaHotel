using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Repositories.novoServicoDAO
{
    public class novoServicoDAO
    {
        private MySqlConnection con;

        public novoServicoDAO()
        {

        }

        // Listar todos os serviços
        public DataTable Listar()
        {
            DataTable tabela = new DataTable();
            try
            {
                DataTable dt = new DataTable();
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spListarNovosServicos()";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabela);

                con.Con.Close();
                return tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar serviços: " + ex.Message);
            }
            return tabela;
        }

        // Inserir novo serviço
        public int Inserir(NovosServicos servico)
        {
            int idGerado = 0;
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spInserirNovosServicos(@pHospede, @pServico, @pQuarto, @pValor, @pQuantidade, @pValorTotal, @pFuncionario, @pDataCadastro)";

                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@pHospede", servico.Hospede);
                cmd.Parameters.AddWithValue("@pServico", servico.Servico);
                cmd.Parameters.AddWithValue("@pQuarto", servico.Quarto);
                cmd.Parameters.AddWithValue("@pValor", servico.Valor);
                cmd.Parameters.AddWithValue("@pQuantidade", servico.Quantidade);
                cmd.Parameters.AddWithValue("@pValorTotal", servico.ValorTotal);
                cmd.Parameters.AddWithValue("@pFuncionario", servico.Funcionario);
                cmd.Parameters.AddWithValue("@pDataCadastro", servico.DataCadastro);
                //cmd.Parameters.AddWithValue("@pValor", servico.Total);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idGerado = Convert.ToInt32(reader["Retorno"]);
                }
                reader.Close();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir serviço: " + ex.Message);
            }
            return idGerado;
        }

        // Recuperar último ID inserido
        public int RecuperarUltimoId()
        {
            int id = 0;
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spRecuperarUltimoIdServico()";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["IdNovoServico"]);
                }
                reader.Close();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar último ID: " + ex.Message);
            }
            return id;
        }

        // Excluir serviço por ID
        public void Excluir(int idServico)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spExcluirNovosServicos(@pIdNovoServico)";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@pIdNovoServico", idServico);
                cmd.ExecuteNonQuery();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir serviço: " + ex.Message);
            }
        }

        // Inserir serviço na tabela de movimentações
        public int InserirMovimentacao(string tipo, string movimento, decimal valor, string funcionario, int idMovimento)
        {
            int idGerado = 0;
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spInserirServicosMovimentacoes(@pTipo, @pMovimento, @pValor, @pFuncionario, @pId_Movimento)";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@pTipo", tipo);
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pFuncionario", funcionario);
                cmd.Parameters.AddWithValue("@pId_Movimento", idMovimento);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    idGerado = Convert.ToInt32(reader["Retorno"]);
                }
                reader.Close();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir movimentação: " + ex.Message);
            }
            return idGerado;
        }

        // Excluir movimentação de serviço
        public void ExcluirMovimentacao(int idMovimento, string movimento)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();
                string sql = "CALL spExcluirNovoServicoMovimentacao(@Id, @Movimento)";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@pId", idMovimento);
                cmd.Parameters.AddWithValue("@pMovimento", movimento);
                cmd.ExecuteNonQuery();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir movimentação: " + ex.Message);
            }
        }

        // Alterar serviço existente
        public void Alterar(int idServico, DateTime data, string hospede, string servico, string quarto, decimal valor, int Quantidade, decimal ValorTotal)
        {
            try
            {
                Conexao con = new Conexao();
                con.AbrirCon();

                string sql = "CALL spAlterarNovosServicos(@pIdNovoServico,@pHospede, @pServico, @pQuarto, @pValor, @pQuantidade, @pValorTotal, @pFuncionario, @pDataCadastro)";

                //string sql = "CALL spAlterarNovosServicos(@pIdNovoServico, @pDataCadastro, @pHospede, @pServico, @pQuarto, @pValor)";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@pIdNovoServico", idServico);
                cmd.Parameters.AddWithValue("@pDataCadastro", data);
                cmd.Parameters.AddWithValue("@pHospede", hospede);
                cmd.Parameters.AddWithValue("@pServico", servico);
                cmd.Parameters.AddWithValue("@pQuarto", quarto);
                cmd.Parameters.AddWithValue("@pValor", valor);
                cmd.Parameters.AddWithValue("@pQuantidade", Quantidade);
                cmd.Parameters.AddWithValue("@pValorTotal", ValorTotal);
                cmd.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario); // <<< FALTOU ISSO

                //cmd.Parameters.AddWithValue("@pTotal", total);

                cmd.ExecuteNonQuery();
                con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar serviço: " + ex.Message);
            }
        }

    }
}
