using MySql.Data.MySqlClient;
using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Repositories.funcionarioDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmFuncionarios : Form
    {
        private FuncionarioDAO _dao = new FuncionarioDAO();

        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            rBNome.Checked = true;
            ListarFuncionarios();
            PreencherCBox();
            EnableHelper.SetEnabled(false, txtCod, txtNome, txtEndereco, maskTelefone, cBCargos, txtEmail, txtObs);
        }

        private void ErroMensageService(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }


        private void HabilitarCampos(bool vr)
        {
            EnableHelper.SetEnabled(vr, txtNome, txtEndereco, maskTelefone, cBCargos, btEditar, btExcluir, btSalvar);
        }

        //Método de carregar o combo box de cargos
        private void PreencherCBox()
        {

            Conexao con = new Conexao();
            con.AbrirCon();
            MySqlCommand Cmd = new MySqlCommand
            {
                Connection = con.Con,
                CommandText = "spListarCargos",
                CommandType = CommandType.StoredProcedure
            };
            MySqlDataAdapter da = new MySqlDataAdapter
            {
                SelectCommand = Cmd
            };
            DataTable Dt = new DataTable();
            da.Fill(Dt);
            cBCargos.DataSource = Dt;
            cBCargos.ValueMember = "IdCargo";
            cBCargos.DisplayMember = "Cargo";
        }

        //Método de Listar funcionarios na grid
        private void ListarFuncionarios()
        {

            try
            {
                gridFuncionarios.DataSource = _dao.ListarFuncionarios();
            }
            catch (Exception ex)
            {

                ErroMensageService("Erro ao Listar Funcionários: " + ex.Message);
            }
        }

        //Método de buscar funcionarios por nome
        private void BuscarFuncionarioNome()
        {

            try
            {
                gridFuncionarios.DataSource = _dao.BuscarFuncionarioPorNome(txtBuscarNome.Text);
            }
            catch (Exception ex)
            {

                ErroMensageService("Erro ao Buscar: " + ex.Message);
            }
        }

        //Método de buscar funcionários por Cpf
        private void BuscarFuncionarioCpf()
        {

            try
            {
                gridFuncionarios.DataSource = _dao.BuscarFuncionarioPorCpf(maskBuscarCPF.Text);
            }
            catch (Exception ex)
            {

                ErroMensageService("Erro ao Buscar: " + ex.Message);
            }
        }


        //Método p/ os botões
        string op = "";

        private void BtNovo_Click(object sender, EventArgs e)
        {
            op = "Novo";
            txtNome.Focus();
            ControlHelper.ClearAndFocus(txtCod, txtEmail, txtEndereco, txtNome, txtObs, maskCpf);

            // Habilita campos
            EnableHelper.SetEnabled(true, txtNome, txtEndereco, maskTelefone, cBCargos, txtEmail, txtObs, maskCpf);

            // Habilita "Salvar", desabilita "Editar", "Excluir" e "Novo"
            EnableHelper.SetEnabled(true, btSalvar);
            EnableHelper.SetEnabled(false, btEditar, btExcluir, btNovo);
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Insira o Nome do Funcionário!");
                ControlHelper.ClearAndFocus(txtNome, txtNome);
                return;
            }
            if (maskCpf.Text == "   .   .   -")
            {
                ErroMensageService("Insira o CPF do Funcionário!");
                ControlHelper.ClearAndFocus(maskCpf);
                return;
            }

            //Validação do CPF
            if (!CpfHelper.IsValidCpf(maskCpf.Text))
            {
                ErroMensageService("CPF inválido! Insira um CPF válido.");
                ControlHelper.ClearAndFocus(maskCpf, maskCpf);
                return;
            }

            //Validação do Email
            if (!EmailHelper.IsValidEmail(txtEmail.Text))
            {
                ErroMensageService("E-mail inválido! Insira um e-mail válido.");
                ControlHelper.ClearAndFocus(txtEmail, txtEmail);
                return;
            }

            //verificar se o cpf do funcionário já existe no banco

            if (_dao.ExisteCpf(maskCpf.Text))
            {
                ErroMensageService("CPF já registrado ! Erro ao salvar!");
                ControlHelper.ClearAndFocus(maskCpf, maskCpf);
                return;
            }

            Funcionario func = new Funcionario
            {
                Nome = txtNome.Text,
                Cpf = maskCpf.Text,
                Endereco = txtEndereco.Text,
                Telefone = maskTelefone.Text,
                Email = txtEmail.Text,
                Cargo = cBCargos.Text,
                Observacoes = txtObs.Text
            };

            try
            {
                _dao.InserirFuncionario(func);

                // Limpa os campos após a edição
                ControlHelper.ClearAndFocus(txtCod, txtEmail, txtEndereco, txtNome, txtObs, maskCpf, maskTelefone);

                // Desabilita os campos após salvar
                EnableHelper.SetEnabled(false, txtNome, txtEndereco, maskTelefone, cBCargos, txtEmail, txtObs, maskCpf);

                // Habilita botões "Novo" e "Editar", desabilita "Salvar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btEditar);
                EnableHelper.SetEnabled(false, btSalvar, btExcluir);

                ListarFuncionarios();
                SucessoMensageService.ShowSuccess("Registro salvo com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao cadastrar: " + ex.Message + ex.StackTrace);
            }
        }

        //Botão Editar/Alterar
        private void BtEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um Registro para Alterar!");
                ControlHelper.ClearAndFocus(txtNome);
                return;
            }
            // Verifica se o CPF foi alterado e se já existe
            if (maskCpf.Text != Globais.CpfAntigo && _dao.ExisteCpf(maskCpf.Text))
            {
                ErroMensageService("CPF já registrado ! Erro ao alterar!");
                maskCpf.Clear();
                maskCpf.Focus();
                return;
            }

            Funcionario func = new Funcionario
            {
                IdFunc = Convert.ToInt32(txtCod.Text),
                Nome = txtNome.Text,
                Cpf = maskCpf.Text,
                Endereco = txtEndereco.Text,
                Telefone = maskTelefone.Text,
                Email = txtEmail.Text,
                Cargo = cBCargos.Text,
                Observacoes = txtObs.Text
            };

            try
            {
                _dao.EditarFuncionario(func);

                // Limpa os campos após a edição
                ControlHelper.ClearAndFocus(txtCod, txtEmail, txtEndereco, txtNome, txtObs, maskCpf, maskTelefone);

                // Desabilita campos após edição
                EnableHelper.SetEnabled(false, txtNome, txtEndereco, maskTelefone, cBCargos, txtEmail, txtObs, maskCpf);


                // Habilita botões "Novo" e "Salvar", desabilita "Editar" e "Excluir"
                EnableHelper.SetEnabled(true, btNovo, btSalvar);
                EnableHelper.SetEnabled(false, btEditar, btExcluir);

                ListarFuncionarios();
                SucessoMensageService.ShowSuccess("Registro alterado com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao alterar: " + ex.Message + ex.StackTrace);
            }

        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                ErroMensageService("Selecione um Registro para excluir!");
                txtNome.Focus();
                return;
            }
            if (MessageBox.Show("Deseja Excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                _dao.ExcluirFuncionario(Convert.ToInt32(txtCod.Text));
                ControlHelper.ClearAndFocus(txtCod, txtEmail, txtEndereco, txtNome, txtObs);
                HabilitarCampos(true);
                ListarFuncionarios();
                SucessoMensageService.ShowSuccess("Registro excluido com sucesso!");
            }
            catch (Exception ex)
            {
                ErroMensageService("Erro ao excluir: " + ex.Message);
            }
        }

        private void RBNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            maskBuscarCPF.Visible = false;
            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
            txtBuscarNome.Focus();

        }

        private void RBBuscarCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            maskBuscarCPF.Visible = true;
            txtBuscarNome.Clear();
            maskBuscarCPF.Clear();
            maskBuscarCPF.Focus();
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarFuncionarioNome();
        }

        private void MaskBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            BuscarFuncionarioCpf();
        }

        private void GridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Habilita campos
            EnableHelper.SetEnabled(true, txtNome, txtEndereco, maskTelefone, cBCargos, txtEmail, txtObs, maskCpf);
            EnableHelper.SetEnabled(false, maskCpf); // CPF desabilitado


            // Habilita "Editar" e "Excluir", desabilita "Novo" e "Salvar"
            EnableHelper.SetEnabled(true, btEditar, btExcluir);
            EnableHelper.SetEnabled(false, btNovo, btSalvar);

            txtCod.Text = gridFuncionarios.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridFuncionarios.CurrentRow.Cells[1].Value.ToString();
            maskCpf.Text = gridFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = gridFuncionarios.CurrentRow.Cells[3].Value.ToString();
            maskTelefone.Text = gridFuncionarios.CurrentRow.Cells[4].Value.ToString();
            cBCargos.Text = gridFuncionarios.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = gridFuncionarios.CurrentRow.Cells[5].Value.ToString();
            txtObs.Text = gridFuncionarios.CurrentRow.Cells[7].Value.ToString();

            //extraindo a valor do cpf no grid
            Globais.CpfAntigo = gridFuncionarios.CurrentRow.Cells[2].Value.ToString();

        }

        private void maskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
