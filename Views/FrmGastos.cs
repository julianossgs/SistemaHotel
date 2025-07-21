using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmGastos : Form
    {


        Conexao con = new Conexao();
        public FrmGastos()
        {
            InitializeComponent();
        }

        private void FrmGastos_Load(object sender, EventArgs e)
        {
            ListarGastos();
        }

        //Métodos
        private void MsgOk(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void MsgErro(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            txtValor.Clear();

        }

        private void HabilitarCampos(bool vr)
        {
            if (vr)
            {
                txtDescricao.Enabled = true;
                txtDescricao.Focus();
                txtValor.Enabled = true;

            }
            else
            {
                txtDescricao.Enabled = false;
                txtValor.Enabled = false;
            }
        }

        //Método de listar os gastos
        private void ListarGastos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd1 = new MySqlCommand();
                Cmd1.Connection = con.Con;
                Cmd1.CommandText = "spListarGastos";
                Cmd1.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd1;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridGastos.DataSource = Dt;
                Totalizar();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao listar os gastos: " + ex.Message);
            }
        }

        //Método de salvar/inserir gastos
        private void InserirGastos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd2 = new MySqlCommand();
                Cmd2.Connection = con.Con;
                Cmd2.CommandText = "spInserirGastos";
                Cmd2.CommandType = CommandType.StoredProcedure;
                Cmd2.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                Cmd2.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                Cmd2.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd2.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao inserir gastos: " + ex.Message);
            }
        }

        //Método p/ recuperar último Id do gasto
        private void RecuperarUltimoIdGasto()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand CmdVerificar = new MySqlCommand();
                CmdVerificar.Connection = con.Con;
                CmdVerificar.CommandText = "spRecuperarUltimoIdGasto";
                CmdVerificar.CommandType = CommandType.StoredProcedure;

                MySqlDataReader reader;
                reader = CmdVerificar.ExecuteReader();

                if (reader.HasRows)
                {
                    //extraindo informações da consulta
                    while (reader.Read())
                    {
                        Globais.ultimoIdGastos = Convert.ToString(reader["IdGasto"]);
                    }

                }
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao recuperar ultimo id do gasto: " + ex.Message);
            }
        }

        //Método p/ lançar gastos nas movimentações
        private void LancarGastosMovimentacoes()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd3 = new MySqlCommand();
                Cmd3.Connection = con.Con;
                Cmd3.CommandText = "spLancarGastosMovimentacoes";
                Cmd3.CommandType = CommandType.StoredProcedure;
                Cmd3.Parameters.AddWithValue("@Tipo", "Saída");
                Cmd3.Parameters.AddWithValue("@Movimento", "Gastos");
                Cmd3.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                Cmd3.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd3.Parameters.AddWithValue("@Id_Movimento", Globais.ultimoIdGastos);
                Cmd3.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao lançar gastos nas movimentações: " + ex.Message);
            }
        }

        //Método p/ Editar gastos
        private void EditarGastos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd4 = new MySqlCommand();
                Cmd4.Connection = con.Con;
                Cmd4.CommandText = "spAlterarGastos";
                Cmd4.CommandType = CommandType.StoredProcedure;
                Cmd4.Parameters.AddWithValue("@Descricao", txtDescricao.Text);
                Cmd4.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                Cmd4.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd4.Parameters.AddWithValue("@IdGasto", Globais.idGasto);
                Cmd4.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao editar gastos: " + ex.Message);
            }
        }

        //Método p/ atualizar o valor na movimentação
        private void AtualizarValorMovimentacao()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd5 = new MySqlCommand();
                Cmd5.Connection = con.Con;
                Cmd5.CommandText = "spAtualizarValorMovimentacao";
                Cmd5.CommandType = CommandType.StoredProcedure;
                Cmd5.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                Cmd5.Parameters.AddWithValue("@Funcionario", Globais.nomeUsuario);
                Cmd5.Parameters.AddWithValue("@Id_Movimento", Globais.idGasto);
                Cmd5.Parameters.AddWithValue("@Movimento", "Gastos");
                Cmd5.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao atualizar o valor na movimentação: " + ex.Message);
            }
        }

        //Método p/ Excluir os gastos
        private void ExcluirGastos()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd6 = new MySqlCommand();
                Cmd6.Connection = con.Con;
                Cmd6.CommandText = "spExcluirGastos";
                Cmd6.CommandType = CommandType.StoredProcedure;
                Cmd6.Parameters.AddWithValue("@IdGasto", Globais.idGasto);
                Cmd6.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao excluir gastos: " + ex.Message);
            }
        }

        //Método de exclusão do movimento do gasto
        private void ExcluirMovGasto()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd7 = new MySqlCommand();
                Cmd7.Connection = con.Con;
                Cmd7.CommandText = "spExcluirMovGasto";
                Cmd7.CommandType = CommandType.StoredProcedure;
                Cmd7.Parameters.AddWithValue("@IdGasto", Globais.idGasto);
                Cmd7.Parameters.AddWithValue("@Movimento", "Gastos");
                Cmd7.ExecuteNonQuery();
                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao excluir movimento gasto" + ex.Message);
            }
        }

        //Método de buscar por datas
        private void BuscarGastosData()
        {
            try
            {
                con.AbrirCon();
                MySqlCommand Cmd8 = new MySqlCommand();
                Cmd8.Connection = con.Con;
                Cmd8.CommandText = "spBuscarGastosData";
                Cmd8.CommandType = CommandType.StoredProcedure;
                Cmd8.Parameters.AddWithValue("@Data", Convert.ToDateTime(dtBuscar.Text));
                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = Cmd8;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                gridGastos.DataSource = Dt;

                con.FecharCon();
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao buscar por data: " + ex.Message);
            }
        }



        //*****************BOTÕES********************
        //botão NOVO
        private void BtNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            btSalvar.Enabled = true;
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            LimparCampos();
        }

        //botão SALVAR
        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == string.Empty)
            {
                MsgErro("Preencha a Descrição!");
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.Trim() == string.Empty)
            {
                MsgErro("Preencha o Valor!");
                txtValor.Focus();
                return;
            }

            //Cód p/ salvar/inserir gastos
            InserirGastos();

            //Método p/ recuperar último Id do gasto
            RecuperarUltimoIdGasto();

            //Método p/ lançar gastos nas movimentações
            LancarGastosMovimentacoes();

            MsgOk("Registro salvo com sucesso!");
            btNovo.Enabled = true;
            btSalvar.Enabled = false;
            LimparCampos();
            HabilitarCampos(true);
            // Totalizar();
            ListarGastos();
        }


        //botão de EDITAR
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Trim() == string.Empty)
            {
                MsgErro("Preencha o campo Descrição!");
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.Trim() == string.Empty)
            {
                MsgErro("Preencha o campo Valor!");
                txtDescricao.Focus();
                return;
            }

            //Cód p/ editar
            EditarGastos();

            //Atualizar o valor na movimentação
            AtualizarValorMovimentacao();

            MsgOk("Registro alterado com sucesso!");
            btNovo.Enabled = true;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            HabilitarCampos(false);
            //Totalizar();
            ListarGastos();
        }

        //botão EXCLUIR
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja excluir?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Método p/ excluir os gastos
                ExcluirGastos();

                //Método p/ excluir do movimento gastos
                ExcluirMovGasto();

                MsgOk("Registro excluido com sucesso!");
                btNovo.Enabled = true;
                btEditar.Enabled = true;
                btExcluir.Enabled = false;
                LimparCampos();
                HabilitarCampos(false);
                // Totalizar();
                ListarGastos();
            }
        }

        //grid
        private void GridGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btSalvar.Enabled = false;
            HabilitarCampos(true);
            Globais.idGasto = gridGastos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = gridGastos.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = gridGastos.CurrentRow.Cells[3].Value.ToString();
        }

        //evento p/ buscar por datas
        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarGastosData();
            Totalizar();
        }

        //Método de totalizar
        private void Totalizar()
        {
            try
            {
                decimal total = 0;
                foreach (DataGridViewRow linha in gridGastos.Rows)
                {
                    total += Convert.ToDecimal(linha.Cells["Valor"].Value);
                }
                lblTotal.Text = Convert.ToDecimal(total).ToString("C2");
            }
            catch (Exception ex)
            {

                MsgErro("Erro ao Totalizar: " + ex.Message);
            }
        }


    }
}
