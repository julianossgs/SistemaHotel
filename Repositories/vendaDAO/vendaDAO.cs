using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Services;
using System;
using System.Data;

namespace SistemaHotel.Repositories.vendaDAO
{

    public class VendasDAO
    {
        Conexao con = new Conexao();
        // FrmVendas frmVendas = new FrmVendas();

        string ultimoIdVenda;
        string totalVenda;//var usada no método TotalizarEstoque

        //Método de inserir/salvar vendas
        public void InserirVendas(Vendas obj)
        {
            try
            {

                con.AbrirCon();
                MySqlCommand Cmd11 = new MySqlCommand();
                Cmd11.Connection = con.Con;
                Cmd11.CommandText = "spInserirVendas";
                Cmd11.CommandType = CommandType.StoredProcedure;
                Cmd11.Parameters.AddWithValue("@pHospede", obj.Hospede);
                Cmd11.Parameters.AddWithValue("@pDataCadastro", obj.DataCadastro);
                Cmd11.Parameters.AddWithValue("@pValorTotal", obj.ValorTotal);
                Cmd11.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                Cmd11.Parameters.AddWithValue("@pStatus", "EFETUADA");
                // ultimoIdVenda = Convert.ToString(Cmd11.ExecuteScalar());

                Cmd11.ExecuteNonQuery();
                con.FecharCon();
                LogService.LogSucesso($"Retorna inserir vendas");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Retorna inserir vendas" + ex);
            }
        }


        public int ObterUltimoIdVenda()
        {
            try
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
                LogService.LogSucesso($"Obter Ultimo IdVenda");
                return id;

            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Obter Ultimo IdVenda" + ex);
                return 0;
            }

        }

        #region Método para cadastrar os itens da venda
        public void InserirItensVendas(DetalhesVenda obj)
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd6 = new MySqlCommand();
                Cmd6.Connection = con.Con;
                Cmd6.CommandText = "spInserirItensVendas";
                Cmd6.CommandType = CommandType.StoredProcedure;
                Cmd6.Parameters.AddWithValue("@pIdProduto", obj.Id_Produto);
                Cmd6.Parameters.AddWithValue("@pQuantidade", obj.Quant);
                Cmd6.Parameters.AddWithValue("@pValorUnit", obj.ValorUnit);
                Cmd6.Parameters.AddWithValue("@pValorTotal", obj.ValorTotal);
                Cmd6.Parameters.AddWithValue("@pId_Venda", obj.Id_Venda);
                Cmd6.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);

                Cmd6.ExecuteNonQuery();
                con.FecharCon();
                LogService.LogSucesso($"Retorna inserir itens vendas");

            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"Retorna inserir itens vendas" + ex);
            }
        }
        #endregion



        //Método p/ recuper o último IdVenda
        //public void UltimoIdVenda()
        //{
        //    try
        //    {
        //        con.AbrirCon();
        //        MySqlCommand Cmd4 = new MySqlCommand();
        //        Cmd4.Connection = con.Con;
        //        Cmd4.CommandText = "spUltimoIdVenda";
        //        Cmd4.CommandType = CommandType.StoredProcedure;
        //        MySqlDataReader reader;
        //        reader = Cmd4.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            //extraindo informações da consulta
        //            while (reader.Read())
        //            {
        //                ultimoIdVenda = reader.GetInt32("IdVenda").ToString();

        //            }

        //        }

        //        con.FecharCon();
        //        LogService.LogSucesso($"Retorna ultimo ID da venda");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogService.LogError(ex, $"Retorna ultimo ID da venda" + ex);

        //    }

        //}


        //Método de inserir movimentações
        public void InserirMovimentacoes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd12 = new MySqlCommand();
                Cmd12.Connection = con.Con;
                Cmd12.CommandText = "spInserirMovimentacoes";
                Cmd12.CommandType = CommandType.StoredProcedure;
                Cmd12.Parameters.AddWithValue("@pTipo", "Entrada");
                Cmd12.Parameters.AddWithValue("@pMovimento", "Venda");
                Cmd12.Parameters.AddWithValue("@pValor", Convert.ToDecimal(totalVenda));
                Cmd12.Parameters.AddWithValue("@pFuncionario", Globais.nomeUsuario);
                Cmd12.Parameters.AddWithValue("@pId_Movimento", ultimoIdVenda);
                Cmd12.ExecuteNonQuery();
                con.FecharCon();
                LogService.LogSucesso($"Retorna Inserir Movimentacoes");
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Retorna Inserir Movimentacoes" + ex);
            }
        }

        //Método de Relacionar itens com a venda
        public void RelacionarItensVendas()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd7 = new MySqlCommand();
                Cmd7.Connection = con.Con;
                Cmd7.CommandText = "spRelacionarItensVendas";
                Cmd7.CommandType = CommandType.StoredProcedure;
                Cmd7.Parameters.AddWithValue("@pIdDetalhe", 1);
                Cmd7.Parameters.AddWithValue("@pId_Venda", ultimoIdVenda);
                Cmd7.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Método que busca vendas por data
        //private void BuscarVendaData()
        //{
        //    try
        //    {

        //        con.AbrirCon();
        //        MySqlCommand Cmd15 = new MySqlCommand();
        //        Cmd15.Connection = con.Con;
        //        Cmd15.CommandText = "spBuscarVendaData";
        //        Cmd15.CommandType = CommandType.StoredProcedure;
        //        Cmd15.Parameters.AddWithValue("@pDataCadastro", Convert.ToDateTime(dtBuscarVendas.Text));
        //        MySqlDataAdapter Da = new MySqlDataAdapter();
        //        Da.SelectCommand = Cmd15;
        //        DataTable Dt = new DataTable();
        //        Da.Fill(Dt);
        //        // GridViewVendas.DataSource = Dt;

        //        con.FecharCon();


        //    }
        //    catch (Exception ex)
        //    {

        //        ErroMensageService.ShowError("Erro ao buscar data por vendas" + ex.Message);
        //    }
        //}

        /// <summary>
        /// //////////////////
        /// </summary>
        /// <returns></returns>

        public DataTable ListarVendas()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("spListarVendas", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.AbrirCon();
                da.Fill(dt);
                con.FecharCon();
                LogService.LogSucesso($"Inserir Vendas.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Usuários");
                return new DataTable();
            }

        }



        public void CancelarVenda(int idVenda)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("spExcluirVendas", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdVenda", idVenda);
                cmd.Parameters.AddWithValue("@Status", "CANCELADA");

                con.AbrirCon();
                cmd.ExecuteNonQuery();
                LogService.LogSucesso($"Cancelar Vendas.");
                con.FecharCon();
            }
            catch (Exception ex)
            {
                LogService.LogError(ex, $"Cancelar Vendas");

            }

        }

        public DataTable BuscarVendasPorData(DateTime data)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("spBuscarVendaData", con.Con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DataCadastro", data);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.AbrirCon();
                da.Fill(dt);
                con.FecharCon();
                LogService.LogSucesso($"Listar Usuários.");
                return dt;
            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Listar Usuários");
                return new DataTable();
            }

        }



        #region Método que retorna Serviço por Nome e ID
        public Produto retornaServicoNome(string NomeServico)
        {
            try
            {
                Produto produto = new Produto();
                string sql = "SELECT * FROM tbservicos WHERE Nome = @Nome";
                MySqlCommand cmd = new MySqlCommand(sql, con.Con);
                cmd.Parameters.AddWithValue("@Nome", NomeServico);

                con.AbrirCon();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    produto.IdProduto = reader.GetInt32("IdProduto");
                    produto.Nome = reader.GetString("Nome");
                    produto.ValorUnit = reader.GetDecimal("ValorUnit");
                    LogService.LogSucesso($"Retorna Servico Nome");
                    return produto;

                }
                else
                {

                    return null;
                }


            }
            catch (Exception ex)
            {

                LogService.LogError(ex, $"Retorna Servico Nome" + ex);
                return null;
            }
        }

        #endregion

        //Método de recuperar a quant em estoque de 1 produto
        public int idProduto;
        private void RecuperarEstoqueProduto()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd16 = new MySqlCommand();
                Cmd16.Connection = con.Con;
                Cmd16.CommandText = "spRecuperarEstoque";
                Cmd16.CommandType = CommandType.StoredProcedure;
                Cmd16.Parameters.AddWithValue("@pIdProduto", idProduto);

                MySqlDataReader reader;
                reader = Cmd16.ExecuteReader();

                if (reader.HasRows)
                {
                    //extraindo informações da consulta
                    while (reader.Read())
                    {
                        // txtEstoque.Text = Convert.ToString(reader["estoque"]);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Método atualizar estoque(abater no estoque)
        //private void AtualizarEstoque()
        //{
        //    try
        //    {
        //        con.AbrirCon();
        //        MySqlCommand Cmd6 = new MySqlCommand();
        //        Cmd6.Connection = con.Con;
        //        Cmd6.CommandText = "spAtualizarEstoque";
        //        Cmd6.CommandType = CommandType.StoredProcedure;
        //        Cmd6.Parameters.AddWithValue("@pIdProduto", Globais.idProduto);
        //        Cmd6.Parameters.AddWithValue("@pEstoque", Convert.ToDecimal(txtEstoque.Text) - Convert.ToDecimal(txtQuant.Text));
        //        Cmd6.ExecuteNonQuery();
        //        con.FecharCon();
        //    }
        //    catch (Exception ex)
        //    {

        //        SucessoMensageService.ShowSuccess("Erro ao atualizar o estoque: " + ex.Message);
        //    }

        //}

        //Método p/ devolver quantidade ao estoque
        //private void DevolverQuantEstoque()
        //{

        //    con.AbrirCon();
        //    MySqlCommand Cmd5 = new MySqlCommand();
        //    Cmd5.Connection = con.Con;
        //    Cmd5.CommandText = "spDevolverQuantEstoque";
        //    Cmd5.CommandType = CommandType.StoredProcedure;
        //    Cmd5.Parameters.AddWithValue("@pIdProduto", idProduto);
        //    Cmd5.Parameters.AddWithValue("@pEstoque", Convert.ToDecimal(txtEstoque.Text) + Convert.ToDecimal(txtQuant.Text));
        //    Cmd5.ExecuteNonQuery();
        //    con.FecharCon();
        //}



        //Método de remover item das vendas
        //private void RemoverItenVenda()
        //{
        //    try
        //    {

        //        con.AbrirCon();
        //        MySqlCommand Cmd8 = new MySqlCommand();
        //        Cmd8.Connection = con.Con;
        //        Cmd8.CommandText = "spRemoverItenVenda";
        //        Cmd8.CommandType = CommandType.StoredProcedure;
        //        Cmd8.Parameters.AddWithValue("@pIdDetalhe", IdDetVenda);

        //        Cmd8.ExecuteNonQuery();
        //        con.FecharCon();
        //    }
        //    catch (Exception ex)
        //    {

        //        ErroMensageService.ShowError("Erro ao remover item da venda: " + ex.Message);
        //    }

        //}
    }
}

