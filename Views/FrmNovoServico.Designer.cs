namespace SistemaHotel.Views
{
    partial class FrmNovoServico
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
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.txtHospede = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridNovoServico = new System.Windows.Forms.DataGridView();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.cBQuartos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBServicos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtBuscarServicos = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btAddHospedes = new System.Windows.Forms.Button();
            this.btRelatorios = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSelecionarNovoServicoEdicao = new System.Windows.Forms.Button();
            this.toolTipNovosServicos = new System.Windows.Forms.ToolTip(this.components);
            this.dateNovoServico = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.IdNovoServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hospede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridNovoServico)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuant
            // 
            this.txtQuant.Enabled = false;
            this.txtQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuant.Location = new System.Drawing.Point(296, 112);
            this.txtQuant.MaxLength = 4;
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(90, 22);
            this.txtQuant.TabIndex = 3;
            this.txtQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuant_KeyPress);
            // 
            // txtHospede
            // 
            this.txtHospede.Enabled = false;
            this.txtHospede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHospede.Location = new System.Drawing.Point(106, 24);
            this.txtHospede.Name = "txtHospede";
            this.txtHospede.Size = new System.Drawing.Size(304, 22);
            this.txtHospede.TabIndex = 1;
            this.txtHospede.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Quant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Hóspede";
            // 
            // gridNovoServico
            // 
            this.gridNovoServico.AllowUserToAddRows = false;
            this.gridNovoServico.AllowUserToDeleteRows = false;
            this.gridNovoServico.AllowUserToOrderColumns = true;
            this.gridNovoServico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridNovoServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNovoServico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdNovoServico,
            this.Data,
            this.Hospede,
            this.Servico,
            this.Quarto,
            this.Quant,
            this.Valor,
            this.ValorTotal,
            this.Funcionario});
            this.gridNovoServico.Location = new System.Drawing.Point(106, 142);
            this.gridNovoServico.MultiSelect = false;
            this.gridNovoServico.Name = "gridNovoServico";
            this.gridNovoServico.ReadOnly = true;
            this.gridNovoServico.RowTemplate.Height = 26;
            this.gridNovoServico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNovoServico.Size = new System.Drawing.Size(987, 264);
            this.gridNovoServico.TabIndex = 38;
            this.gridNovoServico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridNovoServico_CellClick);
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(1151, 282);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 42;
            this.toolTipNovosServicos.SetToolTip(this.btExcluir, "EXCLUIR REGISTRO");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(1151, 186);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 41;
            this.toolTipNovosServicos.SetToolTip(this.btEditar, "ALTERAR REGISTRO");
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Visible = false;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(513, 455);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 39;
            this.toolTipNovosServicos.SetToolTip(this.btNovo, "NOVO REGISTRO");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(639, 455);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 40;
            this.toolTipNovosServicos.SetToolTip(this.btSalvar, "INSERIR REGISTRO");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // cBQuartos
            // 
            this.cBQuartos.Enabled = false;
            this.cBQuartos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBQuartos.FormattingEnabled = true;
            this.cBQuartos.Location = new System.Drawing.Point(907, 110);
            this.cBQuartos.Name = "cBQuartos";
            this.cBQuartos.Size = new System.Drawing.Size(186, 24);
            this.cBQuartos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(851, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "Quartos";
            // 
            // cBServicos
            // 
            this.cBServicos.Enabled = false;
            this.cBServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBServicos.FormattingEnabled = true;
            this.cBServicos.Location = new System.Drawing.Point(106, 68);
            this.cBServicos.Name = "cBServicos";
            this.cBServicos.Size = new System.Drawing.Size(304, 24);
            this.cBServicos.TabIndex = 2;
            this.cBServicos.SelectedValueChanged += new System.EventHandler(this.CBServicos_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Serviços";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(479, 110);
            this.txtValor.MaxLength = 15;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(99, 24);
            this.txtValor.TabIndex = 0;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 47;
            this.label5.Text = "Unit";
            // 
            // dtBuscarServicos
            // 
            this.dtBuscarServicos.Enabled = false;
            this.dtBuscarServicos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarServicos.Location = new System.Drawing.Point(1023, 25);
            this.dtBuscarServicos.Name = "dtBuscarServicos";
            this.dtBuscarServicos.Size = new System.Drawing.Size(137, 21);
            this.dtBuscarServicos.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(972, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Buscar";
            // 
            // btAddHospedes
            // 
            this.btAddHospedes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddHospedes.Enabled = false;
            this.btAddHospedes.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddHospedes.Location = new System.Drawing.Point(416, 5);
            this.btAddHospedes.Name = "btAddHospedes";
            this.btAddHospedes.Size = new System.Drawing.Size(47, 40);
            this.btAddHospedes.TabIndex = 69;
            this.toolTipNovosServicos.SetToolTip(this.btAddHospedes, "Selecione um hóspede");
            this.btAddHospedes.UseVisualStyleBackColor = true;
            this.btAddHospedes.Click += new System.EventHandler(this.BtAddHospedes_Click);
            // 
            // btRelatorios
            // 
            this.btRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRelatorios.Enabled = false;
            this.btRelatorios.Image = global::SistemaHotel.Properties.Resources.relatorio_64_x_64;
            this.btRelatorios.Location = new System.Drawing.Point(766, 455);
            this.btRelatorios.Name = "btRelatorios";
            this.btRelatorios.Size = new System.Drawing.Size(65, 65);
            this.btRelatorios.TabIndex = 72;
            this.toolTipNovosServicos.SetToolTip(this.btRelatorios, "EXIBIR RELATÓRIO");
            this.btRelatorios.UseVisualStyleBackColor = true;
            this.btRelatorios.Click += new System.EventHandler(this.BtRelatorios_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(614, 523);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "INSERIR REGISTRO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(493, 523);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "NOVO REGISTRO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1131, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "EXCLUIR REGISTRO";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(745, 523);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "EXIBIR RELATÓRIO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(1124, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "ALTERAR REGISTRO";
            this.label10.Visible = false;
            // 
            // btnSelecionarNovoServicoEdicao
            // 
            this.btnSelecionarNovoServicoEdicao.AllowDrop = true;
            this.btnSelecionarNovoServicoEdicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionarNovoServicoEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarNovoServicoEdicao.FlatAppearance.BorderSize = 2;
            this.btnSelecionarNovoServicoEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarNovoServicoEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarNovoServicoEdicao.Location = new System.Drawing.Point(1099, 142);
            this.btnSelecionarNovoServicoEdicao.Name = "btnSelecionarNovoServicoEdicao";
            this.btnSelecionarNovoServicoEdicao.Size = new System.Drawing.Size(183, 38);
            this.btnSelecionarNovoServicoEdicao.TabIndex = 78;
            this.btnSelecionarNovoServicoEdicao.Text = "Selecionar Serviço";
            this.toolTipNovosServicos.SetToolTip(this.btnSelecionarNovoServicoEdicao, "Selecione um registro para alteração/exclusão");
            this.btnSelecionarNovoServicoEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarNovoServicoEdicao.Click += new System.EventHandler(this.btnSelecionarNovoServicoEdicao_Click);
            // 
            // toolTipNovosServicos
            // 
            this.toolTipNovosServicos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // dateNovoServico
            // 
            this.dateNovoServico.Enabled = false;
            this.dateNovoServico.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNovoServico.Location = new System.Drawing.Point(106, 114);
            this.dateNovoServico.Name = "dateNovoServico";
            this.dateNovoServico.Size = new System.Drawing.Size(103, 21);
            this.dateNovoServico.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 80;
            this.label12.Text = "Data";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(681, 110);
            this.txtTotal.MaxLength = 15;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(99, 26);
            this.txtTotal.TabIndex = 81;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(641, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 82;
            this.label13.Text = "Total";
            // 
            // IdNovoServico
            // 
            this.IdNovoServico.DataPropertyName = "IdNovoServico";
            dataGridViewCellStyle1.Format = "#,##0";
            this.IdNovoServico.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdNovoServico.HeaderText = "Id";
            this.IdNovoServico.Name = "IdNovoServico";
            this.IdNovoServico.ReadOnly = true;
            this.IdNovoServico.Visible = false;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataCadastro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.Width = 80;
            // 
            // Hospede
            // 
            this.Hospede.DataPropertyName = "Hospede";
            this.Hospede.HeaderText = "Hospede";
            this.Hospede.Name = "Hospede";
            this.Hospede.ReadOnly = true;
            this.Hospede.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Hospede.Width = 210;
            // 
            // Servico
            // 
            this.Servico.DataPropertyName = "Servico";
            this.Servico.HeaderText = "Serviços";
            this.Servico.Name = "Servico";
            this.Servico.ReadOnly = true;
            this.Servico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Servico.Width = 190;
            // 
            // Quarto
            // 
            this.Quarto.DataPropertyName = "Quarto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quarto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quarto.HeaderText = "Quarto";
            this.Quarto.Name = "Quarto";
            this.Quarto.ReadOnly = true;
            this.Quarto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Quarto.Width = 110;
            // 
            // Quant
            // 
            this.Quant.DataPropertyName = "Quantidade";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quant.DefaultCellStyle = dataGridViewCellStyle4;
            this.Quant.HeaderText = "Quant";
            this.Quant.MaxInputLength = 5;
            this.Quant.Name = "Quant";
            this.Quant.ReadOnly = true;
            this.Quant.Width = 60;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle5;
            this.Valor.HeaderText = "Unit";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Valor.Width = 70;
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Width = 90;
            // 
            // Funcionario
            // 
            this.Funcionario.DataPropertyName = "Funcionario";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Funcionario.DefaultCellStyle = dataGridViewCellStyle7;
            this.Funcionario.HeaderText = "Funcionário";
            this.Funcionario.Name = "Funcionario";
            this.Funcionario.ReadOnly = true;
            this.Funcionario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Funcionario.Width = 130;
            // 
            // FrmNovoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1287, 547);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateNovoServico);
            this.Controls.Add(this.btnSelecionarNovoServicoEdicao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btRelatorios);
            this.Controls.Add(this.dtBuscarServicos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btAddHospedes);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cBServicos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBQuartos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.gridNovoServico);
            this.Controls.Add(this.txtQuant);
            this.Controls.Add(this.txtHospede);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmNovoServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serviços";
            this.Activated += new System.EventHandler(this.FrmNovoServico_Activated);
            this.Load += new System.EventHandler(this.FrmNovoServico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridNovoServico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.TextBox txtHospede;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridNovoServico;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.ComboBox cBQuartos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBServicos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtBuscarServicos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAddHospedes;
        private System.Windows.Forms.Button btRelatorios;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSelecionarNovoServicoEdicao;
        private System.Windows.Forms.ToolTip toolTipNovosServicos;
        private System.Windows.Forms.DateTimePicker dateNovoServico;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNovoServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hospede;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionario;
    }
}