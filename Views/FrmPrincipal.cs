using SistemaHotel.Relatorios;
using SistemaHotel.Services;
using System;
using System.Windows.Forms;

namespace SistemaHotel.Views
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        //evento que redimensiona o formulário
        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionarios frm = new FrmFuncionarios();
            frm.Show();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCargos frm = new FrmCargos();
            frm.Show();
        }

        private void NovoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos frm = new FrmProdutos();
            frm.Show();
        }

        private void BtProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos frm = new FrmProdutos();
            frm.Show();
        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Globais.nomeUsuario;
            lblCargo.Text = Globais.cargoUsuario;
        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedores frm = new FrmFornecedores();
            frm.Show();
        }

        private void EstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstoques frm = new FrmEstoques();
            frm.Show();
        }

        private void ServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNovoServico frmNovoServico = new FrmNovoServico();
            frmNovoServico.Show();
        }

        private void RelatórioDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelProdutos frm = new FrmRelProdutos();
            frm.Show();
        }

        private void NovaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendas frm = new FrmVendas();
            frm.Show();
        }

        private void RelatórioDeVendasPorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmRelVendas frmRelVendas = new FrmRelVendas();
            //frmRelVendas.Show();
        }

        private void EntradasSaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacoes frmMovimentacoes = new FrmMovimentacoes();
            frmMovimentacoes.Show();
        }

        private void GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGastos frmGastos = new FrmGastos();
            frmGastos.Show();
        }

        private void HóspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHospedes frmHospedes = new FrmHospedes();
            frmHospedes.Show();
        }

        private void QuartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuartos frmQuartos = new FrmQuartos();
            frmQuartos.Show();
        }

        private void ServicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicos frmServicos = new FrmServicos();
            frmServicos.Show();
        }

        private void RelatórioDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmRelServicos frmRelServicos = new FrmRelServicos();
            //frmRelServicos.Show();
        }

        private void RelatórioDeMovimentaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmRelMovimentacoes frmRelMovimentacoes = new FrmRelMovimentacoes();
            //frmRelMovimentacoes.Show();
        }

        private void RelatórioDeMovimentaçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //// FrmRelMovGerais frmRelMovGerais = new FrmRelMovGerais();
            //frmRelMovGerais.Show();
        }

        private void MenuRelatorios_Click(object sender, EventArgs e)
        {

        }

        private void novaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReservas frmReservas = new FrmReservas();
            frmReservas.Show();
        }
    }
}
