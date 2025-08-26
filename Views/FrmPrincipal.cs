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

        private Form _formAberto = null;

        // Método genérico para abrir formulários de forma exclusiva
        private void AbrirFormExclusivo(Form form)
        {
            if (_formAberto == null || _formAberto.IsDisposed)
            {
                _formAberto = form;
                _formAberto.FormClosed += (s, e) => _formAberto = null;
                _formAberto.Show();
            }
            else
            {
                MessageBox.Show("Feche o FORMULÁRIO aberto antes de abrir outro !!!.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _formAberto.Focus();
            }
        }

        //evento que redimensiona o formulário
        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmFuncionarios());
            // FrmFuncionarios frm = new FrmFuncionarios();
            //frm.Show();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            _podeFechar = true;
            this.Close();
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmCargos());
            // FrmCargos frm = new FrmCargos();
            // frm.Show();
        }

        private void NovoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmProdutos());
            // FrmProdutos frm = new FrmProdutos();
            //frm.Show();
        }

        private void BtProdutos_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmProdutos());
            //FrmProdutos frm = new FrmProdutos();
            //frm.Show();
        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmUsuarios());
            //FrmUsuarios frm = new FrmUsuarios();
            //frm.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Globais.nomeUsuario;
            lblCargo.Text = Globais.cargoUsuario;
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmFornecedores());
            //FrmFornecedores frm = new FrmFornecedores();
            //frm.Show();
        }

        private void EstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmEstoques());
            // FrmEstoques frm = new FrmEstoques();
            //frm.Show();
        }

        private void ServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmNovoServico());
            //FrmNovoServico frmNovoServico = new FrmNovoServico();
            //frmNovoServico.Show();
        }

        private void RelatórioDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmRelProdutos());
            //FrmRelProdutos frm = new FrmRelProdutos();
            //frm.Show();
        }

        private void NovaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmVendas());
            //FrmVendas frm = new FrmVendas();
            //frm.Show();
        }

        private void RelatórioDeVendasPorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FrmRelVendas frmRelVendas = new FrmRelVendas();
            //frmRelVendas.Show();
        }

        private void EntradasSaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmMovimentacoes());
            //FrmMovimentacoes frmMovimentacoes = new FrmMovimentacoes();
            //frmMovimentacoes.Show();
        }

        private void GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmGastos());
            //FrmGastos frmGastos = new FrmGastos();
            //frmGastos.Show();
        }

        private void HóspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmHospedes());
            //FrmHospedes frmHospedes = new FrmHospedes();
            //frmHospedes.Show();
        }

        private void QuartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmQuartos());
            //FrmQuartos frmQuartos = new FrmQuartos();
            //frmQuartos.Show();
        }

        private void ServicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmServicos());
            // FrmServicos frmServicos = new FrmServicos();
            //frmServicos.Show();
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
            //AbrirFormExclusivo(new Frm);
            //FrmRelMovGerais frmRelMovGerais = new FrmRelMovGerais();
            //frmRelMovGerais.Show();
        }

        private void MenuRelatorios_Click(object sender, EventArgs e)
        {

        }

        private void novaReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmReservas());
            //FrmReservas frmReservas = new FrmReservas();
            //frmReservas.Show();
        }

        private void btVendas_Click(object sender, EventArgs e)
        {
            AbrirFormExclusivo(new FrmVendas());
            //FrmVendas frmVendas = new FrmVendas();
            //frmVendas.Show();
        }

        //Evento de hora atualizada
        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //
        private bool _podeFechar = false;

        // Evento de clique do botão Sair
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_podeFechar)
            {
                e.Cancel = true;
                MessageBox.Show("Use o botão 'SAIR' para fechar a APLICAÇÃO !!!.");
            }
        }
    }
}
