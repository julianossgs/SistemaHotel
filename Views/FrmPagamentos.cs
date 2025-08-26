using SistemaHotel.Dados;
using SistemaHotel.Models;
using SistemaHotel.Repositories.vendaDAO;
using SistemaHotel.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmPagamentos : Form
    {
        Conexao con = new Conexao();
        VendasDAO _dao = new VendasDAO();

        Hospede hospede = new Hospede();
        DataTable carrinho = new DataTable();
        DateTime dataAtual = DateTime.Now;



        public FrmPagamentos(Hospede hospede, DataTable carrinho, DateTime dataAtual)
        {
            this.hospede = hospede;
            this.carrinho = carrinho;
            InitializeComponent();
            this.dataAtual = dataAtual;
        }

        private void FrmPagamentos_Load(object sender, EventArgs e)
        {
            txtCartao.Text = "0,00";
            txtDinheiro.Text = "0,00";
            txtPix.Text = "0,00";
            txtTroco.Text = "0,00";

            ControlHelper.ClearAndFocus(btFinalizarVendas);
            EnableHelper.SetEnabled(true, btFinalizarVendas, txtPix, txtDinheiro, txtCartao);
        }

        private void txtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }

        private void txtCartao_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }

        private void txtPix_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputValidator.OnlyNumericInput(sender, e);
        }


        //Botão de finalizar vendas
        private void btFinalizarVendas_Click(object sender, EventArgs e)
        {
            try
            {
                //Finalizar a venda
                decimal dinheiro,
                    cartao,
                    pix,
                    troco,
                    totalPago,
                    total;

                dinheiro = string.IsNullOrEmpty(txtDinheiro.Text) ? 0 : Convert.ToDecimal(txtDinheiro.Text);
                cartao = string.IsNullOrEmpty(txtCartao.Text) ? 0 : Convert.ToDecimal(txtCartao.Text);
                pix = string.IsNullOrEmpty(txtPix.Text) ? 0 : Convert.ToDecimal(txtPix.Text);
                troco = string.IsNullOrEmpty(txtTroco.Text) ? 0 : Convert.ToDecimal(txtTroco.Text);
                total = Convert.ToDecimal(txtTotal.Text);

                //calcular o total pago
                totalPago = dinheiro + cartao + pix;

                if (totalPago <= total)
                {
                    ErroMensageService.ShowError("O total PAGO é menor que o valor total da VENDA!");
                }
                else
                {
                    troco = totalPago - total;
                    txtTroco.Text = troco.ToString("N2");

                    Vendas vendas = new Vendas();

                    vendas.Hospede = hospede.IdHospede.ToString();
                    vendas.DataCadastro = dataAtual;
                    vendas.ValorTotal = total;

                    //Método p/ salvar a venda
                    _dao.InserirVendas(vendas);

                    txtTroco.Text = troco.ToString("N2");
                }





                //método de ultimo IdVenda
                // _dao.UltimoIdVenda();

                //Método p/ salvar os itens da venda
                // _dao.InserirItensVendas();

                //Método p/ salvar a movimentação no Frm de movimentações
                //_dao.InserirMovimentacoes();

                //método de relacionar itens da venda
                // _dao.RelacionarItensVendas();

                SucessoMensageService.ShowSuccess("Venda finalizada com sucesso!");
            }
            catch (Exception)
            {
                ErroMensageService.ShowError("Erro ao finalizar a venda. Por favor, tente novamente.");

            }
        }
    }
}
