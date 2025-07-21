namespace SistemaHotel.Views
{
    partial class FrmVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVrVenda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHospedes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtBuscarVendas = new System.Windows.Forms.DateTimePicker();
            this.gridVendas = new System.Windows.Forms.DataGridView();
            this.IdVenda1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetalhesVendas = new System.Windows.Forms.DataGridView();
            this.IdDetalhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionario1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdVenda = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btExcluir = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.btRel = new System.Windows.Forms.Button();
            this.btFecharGrid = new System.Windows.Forms.Button();
            this.btRemoverItens = new System.Windows.Forms.Button();
            this.btAddItens = new System.Windows.Forms.Button();
            this.btAddHospedes = new System.Windows.Forms.Button();
            this.btAddProdutos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalVendas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalhesVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuant
            // 
            this.txtQuant.Enabled = false;
            this.txtQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuant.Location = new System.Drawing.Point(337, 142);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(101, 22);
            this.txtQuant.TabIndex = 59;
            this.txtQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 63;
            this.label1.Text = "Quant";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Enabled = false;
            this.txtEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoque.Location = new System.Drawing.Point(145, 142);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(100, 22);
            this.txtEstoque.TabIndex = 57;
            this.txtEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Estoque Atual";
            // 
            // txtVrVenda
            // 
            this.txtVrVenda.Enabled = false;
            this.txtVrVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVrVenda.Location = new System.Drawing.Point(560, 139);
            this.txtVrVenda.Name = "txtVrVenda";
            this.txtVrVenda.Size = new System.Drawing.Size(102, 24);
            this.txtVrVenda.TabIndex = 58;
            this.txtVrVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 61;
            this.label9.Text = "Valor R$";
            // 
            // txtProduto
            // 
            this.txtProduto.Enabled = false;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(145, 103);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(330, 22);
            this.txtProduto.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Produto";
            // 
            // txtHospedes
            // 
            this.txtHospedes.Enabled = false;
            this.txtHospedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHospedes.Location = new System.Drawing.Point(145, 53);
            this.txtHospedes.Name = "txtHospedes";
            this.txtHospedes.Size = new System.Drawing.Size(332, 22);
            this.txtHospedes.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "Hóspedes/Clientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 67;
            this.label4.Text = "Buscar Vendas";
            // 
            // dtBuscarVendas
            // 
            this.dtBuscarVendas.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBuscarVendas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarVendas.Location = new System.Drawing.Point(686, 35);
            this.dtBuscarVendas.Name = "dtBuscarVendas";
            this.dtBuscarVendas.Size = new System.Drawing.Size(137, 21);
            this.dtBuscarVendas.TabIndex = 68;
            this.dtBuscarVendas.ValueChanged += new System.EventHandler(this.DtBuscarVendas_ValueChanged);
            // 
            // gridVendas
            // 
            this.gridVendas.AllowUserToAddRows = false;
            this.gridVendas.AllowUserToDeleteRows = false;
            this.gridVendas.AllowUserToOrderColumns = true;
            this.gridVendas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenda1,
            this.Data,
            this.ValorTotal,
            this.Status,
            this.Funcionario});
            this.gridVendas.Location = new System.Drawing.Point(23, 183);
            this.gridVendas.MultiSelect = false;
            this.gridVendas.Name = "gridVendas";
            this.gridVendas.ReadOnly = true;
            this.gridVendas.RowTemplate.Height = 26;
            this.gridVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendas.Size = new System.Drawing.Size(689, 249);
            this.gridVendas.TabIndex = 69;
            this.gridVendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVendas_CellClick);
            // 
            // IdVenda1
            // 
            this.IdVenda1.DataPropertyName = "IdVenda";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "#,##0";
            this.IdVenda1.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdVenda1.HeaderText = "Nº/Venda";
            this.IdVenda1.Name = "IdVenda1";
            this.IdVenda1.ReadOnly = true;
            this.IdVenda1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IdVenda1.Width = 110;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.Width = 120;
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorTotal.Width = 120;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.Width = 145;
            // 
            // Funcionario
            // 
            this.Funcionario.DataPropertyName = "Funcionario";
            this.Funcionario.HeaderText = "Funcionário";
            this.Funcionario.Name = "Funcionario";
            this.Funcionario.ReadOnly = true;
            this.Funcionario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Funcionario.Width = 145;
            // 
            // gridDetalhesVendas
            // 
            this.gridDetalhesVendas.AllowUserToAddRows = false;
            this.gridDetalhesVendas.AllowUserToDeleteRows = false;
            this.gridDetalhesVendas.AllowUserToOrderColumns = true;
            this.gridDetalhesVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalhesVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDetalhe,
            this.Produto,
            this.Quant,
            this.ValorUnit,
            this.ValorTotal1,
            this.Id_Venda,
            this.Funcionario1,
            this.Id_Produto});
            this.gridDetalhesVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridDetalhesVendas.Location = new System.Drawing.Point(23, 183);
            this.gridDetalhesVendas.MultiSelect = false;
            this.gridDetalhesVendas.Name = "gridDetalhesVendas";
            this.gridDetalhesVendas.ReadOnly = true;
            this.gridDetalhesVendas.RowTemplate.Height = 26;
            this.gridDetalhesVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetalhesVendas.Size = new System.Drawing.Size(695, 249);
            this.gridDetalhesVendas.TabIndex = 76;
            this.gridDetalhesVendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetalhesVendas_CellClick);
            this.gridDetalhesVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDetalhesVendas_CellContentClick);
            // 
            // IdDetalhe
            // 
            this.IdDetalhe.DataPropertyName = "IdDetalhe";
            dataGridViewCellStyle4.Format = "#,##0";
            dataGridViewCellStyle4.NullValue = null;
            this.IdDetalhe.DefaultCellStyle = dataGridViewCellStyle4;
            this.IdDetalhe.HeaderText = "IdDetalhe";
            this.IdDetalhe.Name = "IdDetalhe";
            this.IdDetalhe.ReadOnly = true;
            this.IdDetalhe.Visible = false;
            // 
            // Produto
            // 
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Produto.Width = 230;
            // 
            // Quant
            // 
            this.Quant.DataPropertyName = "Quant";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Quant.DefaultCellStyle = dataGridViewCellStyle5;
            this.Quant.HeaderText = "Quant";
            this.Quant.Name = "Quant";
            this.Quant.ReadOnly = true;
            this.Quant.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ValorUnit
            // 
            this.ValorUnit.DataPropertyName = "ValorUnit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.ValorUnit.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValorUnit.HeaderText = "Unit";
            this.ValorUnit.Name = "ValorUnit";
            this.ValorUnit.ReadOnly = true;
            this.ValorUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorUnit.Width = 120;
            // 
            // ValorTotal1
            // 
            this.ValorTotal1.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.ValorTotal1.DefaultCellStyle = dataGridViewCellStyle7;
            this.ValorTotal1.HeaderText = "Total";
            this.ValorTotal1.Name = "ValorTotal1";
            this.ValorTotal1.ReadOnly = true;
            this.ValorTotal1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorTotal1.Width = 130;
            // 
            // Id_Venda
            // 
            this.Id_Venda.DataPropertyName = "Id_Venda";
            dataGridViewCellStyle8.Format = "#,##0";
            this.Id_Venda.DefaultCellStyle = dataGridViewCellStyle8;
            this.Id_Venda.HeaderText = "Id_Venda";
            this.Id_Venda.Name = "Id_Venda";
            this.Id_Venda.ReadOnly = true;
            this.Id_Venda.Visible = false;
            // 
            // Funcionario1
            // 
            this.Funcionario1.DataPropertyName = "Funcionario";
            this.Funcionario1.HeaderText = "Funcionario";
            this.Funcionario1.Name = "Funcionario1";
            this.Funcionario1.ReadOnly = true;
            this.Funcionario1.Visible = false;
            // 
            // Id_Produto
            // 
            this.Id_Produto.DataPropertyName = "Id_Produto";
            dataGridViewCellStyle9.Format = "#,##0";
            this.Id_Produto.DefaultCellStyle = dataGridViewCellStyle9;
            this.Id_Produto.HeaderText = "Id_Produto";
            this.Id_Produto.Name = "Id_Produto";
            this.Id_Produto.ReadOnly = true;
            this.Id_Produto.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 77;
            this.label6.Text = "Nº Venda";
            // 
            // txtIdVenda
            // 
            this.txtIdVenda.Enabled = false;
            this.txtIdVenda.Location = new System.Drawing.Point(145, 12);
            this.txtIdVenda.Name = "txtIdVenda";
            this.txtIdVenda.Size = new System.Drawing.Size(100, 21);
            this.txtIdVenda.TabIndex = 78;
            this.txtIdVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Location = new System.Drawing.Point(483, 513);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(102, 52);
            this.btExcluir.TabIndex = 72;
            this.btExcluir.Text = "Cancelar a Venda";
            this.toolTip1.SetToolTip(this.btExcluir, "Cancelar a Venda");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Location = new System.Drawing.Point(360, 513);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(98, 52);
            this.btSalvar.TabIndex = 75;
            this.btSalvar.Text = "Finalizar a Venda";
            this.toolTip1.SetToolTip(this.btSalvar, "Finalizar a Venda");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Location = new System.Drawing.Point(225, 513);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(109, 52);
            this.btNovo.TabIndex = 74;
            this.btNovo.Text = "Nova Venda";
            this.toolTip1.SetToolTip(this.btNovo, "Nova Venda");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // btRel
            // 
            this.btRel.Enabled = false;
            this.btRel.Location = new System.Drawing.Point(610, 513);
            this.btRel.Name = "btRel";
            this.btRel.Size = new System.Drawing.Size(102, 52);
            this.btRel.TabIndex = 82;
            this.btRel.Text = "Relatório da Venda";
            this.toolTip1.SetToolTip(this.btRel, "Cancelar a Venda");
            this.btRel.UseVisualStyleBackColor = true;
            this.btRel.Click += new System.EventHandler(this.BtRel_Click);
            // 
            // btFecharGrid
            // 
            this.btFecharGrid.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btFecharGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFecharGrid.Image = global::SistemaHotel.Properties.Resources.sair_20x20;
            this.btFecharGrid.Location = new System.Drawing.Point(735, 183);
            this.btFecharGrid.Name = "btFecharGrid";
            this.btFecharGrid.Size = new System.Drawing.Size(47, 28);
            this.btFecharGrid.TabIndex = 81;
            this.toolTip1.SetToolTip(this.btFecharGrid, "Fechar o Formulário");
            this.btFecharGrid.UseVisualStyleBackColor = false;
            this.btFecharGrid.Click += new System.EventHandler(this.BtFecharGrid_Click);
            // 
            // btRemoverItens
            // 
            this.btRemoverItens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemoverItens.Enabled = false;
            this.btRemoverItens.Image = global::SistemaHotel.Properties.Resources._1481313424_minus;
            this.btRemoverItens.Location = new System.Drawing.Point(682, 438);
            this.btRemoverItens.Name = "btRemoverItens";
            this.btRemoverItens.Size = new System.Drawing.Size(47, 40);
            this.btRemoverItens.TabIndex = 71;
            this.toolTip1.SetToolTip(this.btRemoverItens, "Remova itens da Venda");
            this.btRemoverItens.UseVisualStyleBackColor = true;
            this.btRemoverItens.Click += new System.EventHandler(this.BtRemoverItens_Click);
            // 
            // btAddItens
            // 
            this.btAddItens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddItens.Enabled = false;
            this.btAddItens.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddItens.Location = new System.Drawing.Point(629, 437);
            this.btAddItens.Name = "btAddItens";
            this.btAddItens.Size = new System.Drawing.Size(47, 40);
            this.btAddItens.TabIndex = 70;
            this.toolTip1.SetToolTip(this.btAddItens, "Adicione itens a Venda");
            this.btAddItens.UseVisualStyleBackColor = true;
            this.btAddItens.Click += new System.EventHandler(this.BtAddItens_Click);
            // 
            // btAddHospedes
            // 
            this.btAddHospedes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddHospedes.Enabled = false;
            this.btAddHospedes.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddHospedes.Location = new System.Drawing.Point(483, 34);
            this.btAddHospedes.Name = "btAddHospedes";
            this.btAddHospedes.Size = new System.Drawing.Size(47, 40);
            this.btAddHospedes.TabIndex = 65;
            this.toolTip1.SetToolTip(this.btAddHospedes, "Selecione um Cliente");
            this.btAddHospedes.UseVisualStyleBackColor = true;
            this.btAddHospedes.Click += new System.EventHandler(this.BtAddHospedes_Click);
            // 
            // btAddProdutos
            // 
            this.btAddProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddProdutos.Enabled = false;
            this.btAddProdutos.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddProdutos.Location = new System.Drawing.Point(483, 84);
            this.btAddProdutos.Name = "btAddProdutos";
            this.btAddProdutos.Size = new System.Drawing.Size(47, 40);
            this.btAddProdutos.TabIndex = 56;
            this.toolTip1.SetToolTip(this.btAddProdutos, "Selecione um Produto");
            this.btAddProdutos.UseVisualStyleBackColor = true;
            this.btAddProdutos.Click += new System.EventHandler(this.BtAddProdutos_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 15);
            this.label7.TabIndex = 79;
            this.label7.Text = "Total das Vendas ";
            // 
            // lblTotalVendas
            // 
            this.lblTotalVendas.AutoSize = true;
            this.lblTotalVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendas.Location = new System.Drawing.Point(166, 449);
            this.lblTotalVendas.Name = "lblTotalVendas";
            this.lblTotalVendas.Size = new System.Drawing.Size(0, 18);
            this.lblTotalVendas.TabIndex = 80;
            // 
            // FrmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(825, 577);
            this.Controls.Add(this.btRel);
            this.Controls.Add(this.btFecharGrid);
            this.Controls.Add(this.lblTotalVendas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gridDetalhesVendas);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btRemoverItens);
            this.Controls.Add(this.btAddItens);
            this.Controls.Add(this.gridVendas);
            this.Controls.Add(this.dtBuscarVendas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAddHospedes);
            this.Controls.Add(this.txtHospedes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btAddProdutos);
            this.Controls.Add(this.txtVrVenda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TELA DE VENDAS";
            this.Activated += new System.EventHandler(this.FrmVendas_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVendas_FormClosing);
            this.Load += new System.EventHandler(this.FrmVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalhesVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAddProdutos;
        private System.Windows.Forms.TextBox txtVrVenda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAddHospedes;
        private System.Windows.Forms.TextBox txtHospedes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtBuscarVendas;
        private System.Windows.Forms.DataGridView gridVendas;
        private System.Windows.Forms.Button btAddItens;
        private System.Windows.Forms.Button btRemoverItens;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.DataGridView gridDetalhesVendas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdVenda;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.Button btFecharGrid;
        private System.Windows.Forms.Button btRel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenda1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Venda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionario1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Produto;
    }
}