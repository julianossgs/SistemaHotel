namespace SistemaHotel.Views
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.cBFornecedor = new System.Windows.Forms.ComboBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.IdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagem = new System.Windows.Forms.DataGridViewImageColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVrVenda = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.txtVrCompra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btRemoverImagem = new System.Windows.Forms.Button();
            this.btAddImagem = new System.Windows.Forms.Button();
            this.pBoxProdutos = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.toolTipProdutos = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarProdutoEdicao = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(83, 100);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(278, 22);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtProduto
            // 
            this.txtProduto.Enabled = false;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(82, 57);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(279, 22);
            this.txtProduto.TabIndex = 1;
            // 
            // cBFornecedor
            // 
            this.cBFornecedor.Enabled = false;
            this.cBFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBFornecedor.FormattingEnabled = true;
            this.cBFornecedor.Location = new System.Drawing.Point(760, 145);
            this.cBFornecedor.Name = "cBFornecedor";
            this.cBFornecedor.Size = new System.Drawing.Size(186, 24);
            this.cBFornecedor.TabIndex = 6;
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Location = new System.Drawing.Point(19, 54);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(179, 21);
            this.txtBuscarNome.TabIndex = 9;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.TxtBuscarNome_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "BUSCAR ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBuscarNome);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(398, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 96);
            this.panel1.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Digite o Nome do Produto";
            // 
            // gridProdutos
            // 
            this.gridProdutos.AllowUserToAddRows = false;
            this.gridProdutos.AllowUserToDeleteRows = false;
            this.gridProdutos.AllowUserToOrderColumns = true;
            this.gridProdutos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProduto,
            this.Nome,
            this.Descricao,
            this.Estoque,
            this.ValorCompra,
            this.ValorUnit,
            this.Imagem,
            this.Data,
            this.Fornecedor});
            this.gridProdutos.Location = new System.Drawing.Point(20, 184);
            this.gridProdutos.MultiSelect = false;
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.ReadOnly = true;
            this.gridProdutos.RowTemplate.Height = 26;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.Size = new System.Drawing.Size(951, 226);
            this.gridProdutos.TabIndex = 27;
            this.gridProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellClick_1);
            this.gridProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellDoubleClick_1);
            // 
            // IdProduto
            // 
            this.IdProduto.DataPropertyName = "IdProduto";
            dataGridViewCellStyle1.Format = "#,##0";
            this.IdProduto.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdProduto.HeaderText = "IdProduto";
            this.IdProduto.Name = "IdProduto";
            this.IdProduto.ReadOnly = true;
            this.IdProduto.Visible = false;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Produto";
            this.Nome.HeaderText = "Produto";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nome.Width = 200;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descricao";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Descricao.Width = 210;
            // 
            // Estoque
            // 
            this.Estoque.DataPropertyName = "Estoque";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Estoque.DefaultCellStyle = dataGridViewCellStyle2;
            this.Estoque.HeaderText = "Estoque";
            this.Estoque.Name = "Estoque";
            this.Estoque.ReadOnly = true;
            this.Estoque.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Estoque.Width = 80;
            // 
            // ValorCompra
            // 
            this.ValorCompra.DataPropertyName = "ValorCompra";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ValorCompra.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorCompra.HeaderText = "Valor da Compra";
            this.ValorCompra.Name = "ValorCompra";
            this.ValorCompra.ReadOnly = true;
            this.ValorCompra.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorCompra.Width = 130;
            // 
            // ValorUnit
            // 
            this.ValorUnit.DataPropertyName = "ValorUnit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorUnit.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorUnit.HeaderText = "Valor Venda";
            this.ValorUnit.Name = "ValorUnit";
            this.ValorUnit.ReadOnly = true;
            this.ValorUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Imagem
            // 
            this.Imagem.DataPropertyName = "Imagem";
            this.Imagem.HeaderText = "Imagem";
            this.Imagem.Name = "Imagem";
            this.Imagem.ReadOnly = true;
            this.Imagem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Imagem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Imagem.Visible = false;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataCadastro";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle5;
            this.Data.HeaderText = "Data / Cadastro";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Visible = false;
            this.Data.Width = 120;
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fornecedor.Width = 180;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(82, 16);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(79, 22);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Valor Unit R$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Estoque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(684, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fornecedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Código";
            // 
            // txtVrVenda
            // 
            this.txtVrVenda.Enabled = false;
            this.txtVrVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVrVenda.Location = new System.Drawing.Point(353, 144);
            this.txtVrVenda.Name = "txtVrVenda";
            this.txtVrVenda.Size = new System.Drawing.Size(100, 24);
            this.txtVrVenda.TabIndex = 4;
            this.txtVrVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVrVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVrVenda_KeyPress);
            // 
            // txtEstoque
            // 
            this.txtEstoque.Enabled = false;
            this.txtEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoque.Location = new System.Drawing.Point(549, 143);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(100, 24);
            this.txtEstoque.TabIndex = 5;
            this.txtEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVrCompra
            // 
            this.txtVrCompra.Enabled = false;
            this.txtVrCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVrCompra.Location = new System.Drawing.Point(140, 145);
            this.txtVrCompra.Name = "txtVrCompra";
            this.txtVrCompra.Size = new System.Drawing.Size(100, 24);
            this.txtVrCompra.TabIndex = 43;
            this.txtVrCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVrCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVrCompra_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 15);
            this.label9.TabIndex = 44;
            this.label9.Text = "Valor da Compra";
            // 
            // btRemoverImagem
            // 
            this.btRemoverImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemoverImagem.Enabled = false;
            this.btRemoverImagem.Image = global::SistemaHotel.Properties.Resources._1481313424_minus;
            this.btRemoverImagem.Location = new System.Drawing.Point(899, 79);
            this.btRemoverImagem.Name = "btRemoverImagem";
            this.btRemoverImagem.Size = new System.Drawing.Size(47, 42);
            this.btRemoverImagem.TabIndex = 42;
            this.btRemoverImagem.UseVisualStyleBackColor = true;
            this.btRemoverImagem.Click += new System.EventHandler(this.BtRemoverImagem_Click);
            // 
            // btAddImagem
            // 
            this.btAddImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddImagem.Enabled = false;
            this.btAddImagem.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddImagem.Location = new System.Drawing.Point(899, 4);
            this.btAddImagem.Name = "btAddImagem";
            this.btAddImagem.Size = new System.Drawing.Size(47, 40);
            this.btAddImagem.TabIndex = 6;
            this.btAddImagem.UseVisualStyleBackColor = true;
            this.btAddImagem.Click += new System.EventHandler(this.BtAddImagem_Click);
            // 
            // pBoxProdutos
            // 
            this.pBoxProdutos.Location = new System.Drawing.Point(759, 1);
            this.pBoxProdutos.Name = "pBoxProdutos";
            this.pBoxProdutos.Size = new System.Drawing.Size(120, 120);
            this.pBoxProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxProdutos.TabIndex = 40;
            this.pBoxProdutos.TabStop = false;
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(722, 441);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 0;
            this.toolTipProdutos.SetToolTip(this.btExcluir, "EXCLUIR REGISTRO");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(607, 441);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 0;
            this.toolTipProdutos.SetToolTip(this.btEditar, "ALTERAR REGISTRO");
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(488, 441);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 7;
            this.toolTipProdutos.SetToolTip(this.btSalvar, "INSERIR REGISTRO");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(369, 441);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 0;
            this.toolTipProdutos.SetToolTip(this.btNovo, "NOVO REGISTRO");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // toolTipProdutos
            // 
            this.toolTipProdutos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnSelecionarProdutoEdicao
            // 
            this.btnSelecionarProdutoEdicao.AllowDrop = true;
            this.btnSelecionarProdutoEdicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionarProdutoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarProdutoEdicao.FlatAppearance.BorderSize = 2;
            this.btnSelecionarProdutoEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarProdutoEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarProdutoEdicao.Location = new System.Drawing.Point(977, 184);
            this.btnSelecionarProdutoEdicao.Name = "btnSelecionarProdutoEdicao";
            this.btnSelecionarProdutoEdicao.Size = new System.Drawing.Size(183, 38);
            this.btnSelecionarProdutoEdicao.TabIndex = 57;
            this.btnSelecionarProdutoEdicao.Text = "Selecionar Produto";
            this.toolTipProdutos.SetToolTip(this.btnSelecionarProdutoEdicao, "Selecione para alteração/exclusão");
            this.btnSelecionarProdutoEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarProdutoEdicao.Click += new System.EventHandler(this.btnSelecionarProdutoEdicao_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(352, 509);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "NOVO REGISTRO";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(463, 509);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "INSERIR REGISTRO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(582, 509);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "ALTERAR REGISTRO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(703, 509);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "EXCLUIR REGISTRO";
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1166, 533);
            this.Controls.Add(this.btnSelecionarProdutoEdicao);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVrCompra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btRemoverImagem);
            this.Controls.Add(this.btAddImagem);
            this.Controls.Add(this.pBoxProdutos);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.txtVrVenda);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.cBFornecedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridProdutos);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE PRODUTOS";
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.ComboBox cBFornecedor;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVrVenda;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.PictureBox pBoxProdutos;
        private System.Windows.Forms.Button btAddImagem;
        private System.Windows.Forms.Button btRemoverImagem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVrCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnit;
        private System.Windows.Forms.DataGridViewImageColumn Imagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.ToolTip toolTipProdutos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSelecionarProdutoEdicao;
    }
}