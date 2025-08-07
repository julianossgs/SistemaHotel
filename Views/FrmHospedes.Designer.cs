namespace SistemaHotel.Views
{
    partial class FrmHospedes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.maskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.maskCpf = new System.Windows.Forms.MaskedTextBox();
            this.maskBuscarCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.rBBuscarCPF = new System.Windows.Forms.RadioButton();
            this.rBNome = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSalvar = new System.Windows.Forms.Button();
            this.gridHospedes = new System.Windows.Forms.DataGridView();
            this.IdFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlHospedes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.makPlacaVeiculo = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbBoxFuncionario = new System.Windows.Forms.ComboBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.maskCelular = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPesquisarCep = new System.Windows.Forms.Button();
            this.maskCEP = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSelecionarHospedeEdicao = new System.Windows.Forms.Button();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.toolTipSelecionar = new System.Windows.Forms.ToolTip(this.components);
            this.btSelecionarHospedeServico = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHospedes)).BeginInit();
            this.tabControlHospedes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btExcluir
            // 
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(720, 382);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 37;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(614, 382);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 36;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(389, 382);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 34;
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(79, 127);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(278, 22);
            this.txtEndereco.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(78, 90);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(279, 22);
            this.txtNome.TabIndex = 2;
            // 
            // maskTelefone
            // 
            this.maskTelefone.Enabled = false;
            this.maskTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskTelefone.Location = new System.Drawing.Point(79, 209);
            this.maskTelefone.Mask = "(99)9999-9999";
            this.maskTelefone.Name = "maskTelefone";
            this.maskTelefone.Size = new System.Drawing.Size(105, 22);
            this.maskTelefone.TabIndex = 8;
            // 
            // maskCpf
            // 
            this.maskCpf.Enabled = false;
            this.maskCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskCpf.Location = new System.Drawing.Point(79, 55);
            this.maskCpf.Mask = "000,000,000-00";
            this.maskCpf.Name = "maskCpf";
            this.maskCpf.Size = new System.Drawing.Size(97, 22);
            this.maskCpf.TabIndex = 1;
            // 
            // maskBuscarCPF
            // 
            this.maskBuscarCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskBuscarCPF.Location = new System.Drawing.Point(102, 56);
            this.maskBuscarCPF.Mask = "000,000,000-00";
            this.maskBuscarCPF.Name = "maskBuscarCPF";
            this.maskBuscarCPF.Size = new System.Drawing.Size(172, 22);
            this.maskBuscarCPF.TabIndex = 10;
            this.maskBuscarCPF.TextChanged += new System.EventHandler(this.MaskBuscarCPF_TextChanged);
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNome.Location = new System.Drawing.Point(102, 20);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(172, 22);
            this.txtBuscarNome.TabIndex = 9;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.TxtBuscarNome_TextChanged);
            // 
            // rBBuscarCPF
            // 
            this.rBBuscarCPF.AutoSize = true;
            this.rBBuscarCPF.Location = new System.Drawing.Point(19, 58);
            this.rBBuscarCPF.Name = "rBBuscarCPF";
            this.rBBuscarCPF.Size = new System.Drawing.Size(48, 19);
            this.rBBuscarCPF.TabIndex = 2;
            this.rBBuscarCPF.TabStop = true;
            this.rBBuscarCPF.Text = "CPF";
            this.rBBuscarCPF.UseVisualStyleBackColor = true;
            this.rBBuscarCPF.CheckedChanged += new System.EventHandler(this.RBBuscarCPF_CheckedChanged);
            // 
            // rBNome
            // 
            this.rBNome.AutoSize = true;
            this.rBNome.Location = new System.Drawing.Point(19, 22);
            this.rBNome.Name = "rBNome";
            this.rBNome.Size = new System.Drawing.Size(62, 19);
            this.rBNome.TabIndex = 1;
            this.rBNome.TabStop = true;
            this.rBNome.Text = "NOME";
            this.rBNome.UseVisualStyleBackColor = true;
            this.rBNome.CheckedChanged += new System.EventHandler(this.RBNome_CheckedChanged);
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
            this.panel1.Controls.Add(this.maskBuscarCPF);
            this.panel1.Controls.Add(this.txtBuscarNome);
            this.panel1.Controls.Add(this.rBBuscarCPF);
            this.panel1.Controls.Add(this.rBNome);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(21, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 96);
            this.panel1.TabIndex = 28;
            // 
            // btSalvar
            // 
            this.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(505, 382);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 35;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // gridHospedes
            // 
            this.gridHospedes.AllowUserToAddRows = false;
            this.gridHospedes.AllowUserToDeleteRows = false;
            this.gridHospedes.AllowUserToOrderColumns = true;
            this.gridHospedes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gridHospedes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridHospedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHospedes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFunc,
            this.Cpf,
            this.Nome,
            this.Endereco,
            this.Bairro,
            this.Cidade,
            this.Estado,
            this.Cep,
            this.Celular,
            this.Telefone,
            this.Email,
            this.Empresa,
            this.PlacaVeiculo,
            this.Cargo,
            this.Data});
            this.gridHospedes.Location = new System.Drawing.Point(21, 133);
            this.gridHospedes.MultiSelect = false;
            this.gridHospedes.Name = "gridHospedes";
            this.gridHospedes.ReadOnly = true;
            this.gridHospedes.RowTemplate.Height = 26;
            this.gridHospedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHospedes.Size = new System.Drawing.Size(1001, 282);
            this.gridHospedes.TabIndex = 27;
            this.gridHospedes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridHospedes_CellClick);
            this.gridHospedes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridHospedes_CellContentDoubleClick);
            this.gridHospedes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHospedes_CellDoubleClick);
            // 
            // IdFunc
            // 
            this.IdFunc.DataPropertyName = "IdHospede";
            dataGridViewCellStyle7.Format = "#,##0";
            this.IdFunc.DefaultCellStyle = dataGridViewCellStyle7;
            this.IdFunc.HeaderText = "Cod";
            this.IdFunc.Name = "IdFunc";
            this.IdFunc.ReadOnly = true;
            this.IdFunc.Visible = false;
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "CPF";
            this.Cpf.HeaderText = "Cpf";
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            this.Cpf.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cpf.Width = 110;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nome.Width = 200;
            // 
            // Endereco
            // 
            this.Endereco.DataPropertyName = "Endereco";
            this.Endereco.HeaderText = "Endereco";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Endereco.Visible = false;
            this.Endereco.Width = 180;
            // 
            // Bairro
            // 
            this.Bairro.DataPropertyName = "Bairro";
            this.Bairro.HeaderText = "Bairro";
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Visible = false;
            // 
            // Cidade
            // 
            this.Cidade.DataPropertyName = "Cidade";
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            // 
            // Cep
            // 
            this.Cep.DataPropertyName = "CEP";
            this.Cep.HeaderText = "Cep";
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Visible = false;
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "Celular";
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            this.Celular.Width = 120;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Telefone.Width = 130;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 130;
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Visible = false;
            // 
            // PlacaVeiculo
            // 
            this.PlacaVeiculo.DataPropertyName = "PlacaVeiculo";
            this.PlacaVeiculo.HeaderText = "Placa do Veículo";
            this.PlacaVeiculo.Name = "PlacaVeiculo";
            this.PlacaVeiculo.ReadOnly = true;
            this.PlacaVeiculo.Visible = false;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Funcionario";
            this.Cargo.HeaderText = "Funcionario";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cargo.Width = 130;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataCadastro";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle8;
            this.Data.HeaderText = "Data de Cadastro";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.Width = 110;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(79, 14);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(79, 22);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Cpf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Endereço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Código";
            // 
            // tabControlHospedes
            // 
            this.tabControlHospedes.Controls.Add(this.tabPage1);
            this.tabControlHospedes.Controls.Add(this.tabPage2);
            this.tabControlHospedes.Location = new System.Drawing.Point(22, 12);
            this.tabControlHospedes.Name = "tabControlHospedes";
            this.tabControlHospedes.SelectedIndex = 0;
            this.tabControlHospedes.Size = new System.Drawing.Size(1141, 515);
            this.tabControlHospedes.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.makPlacaVeiculo);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cbBoxFuncionario);
            this.tabPage1.Controls.Add(this.txtEmpresa);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cbUF);
            this.tabPage1.Controls.Add(this.maskCelular);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btnPesquisarCep);
            this.tabPage1.Controls.Add(this.maskCEP);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtCidade);
            this.tabPage1.Controls.Add(this.txtBairro);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btExcluir);
            this.tabPage1.Controls.Add(this.txtCod);
            this.tabPage1.Controls.Add(this.btEditar);
            this.tabPage1.Controls.Add(this.btNovo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btSalvar);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.maskCpf);
            this.tabPage1.Controls.Add(this.maskTelefone);
            this.tabPage1.Controls.Add(this.txtEndereco);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1133, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CADASTRO DE HÓSPEDES";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(705, 450);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "EXCLUIR REGISTRO";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(588, 450);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "ALTERAR REGISTRO";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(479, 450);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "INSERIR REGISTRO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(373, 450);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "NOVO REGISTRO";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 304);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 15);
            this.label15.TabIndex = 62;
            this.label15.Text = "Funcionário";
            // 
            // makPlacaVeiculo
            // 
            this.makPlacaVeiculo.Location = new System.Drawing.Point(769, 251);
            this.makPlacaVeiculo.Name = "makPlacaVeiculo";
            this.makPlacaVeiculo.Size = new System.Drawing.Size(100, 21);
            this.makPlacaVeiculo.TabIndex = 13;
            this.makPlacaVeiculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.makPlacaVeiculo.TextChanged += new System.EventHandler(this.makPlacaVeiculo_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(665, 257);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 15);
            this.label14.TabIndex = 61;
            this.label14.Text = "Placa do Veículo";
            // 
            // cbBoxFuncionario
            // 
            this.cbBoxFuncionario.FormattingEnabled = true;
            this.cbBoxFuncionario.Location = new System.Drawing.Point(79, 296);
            this.cbBoxFuncionario.Name = "cbBoxFuncionario";
            this.cbBoxFuncionario.Size = new System.Drawing.Size(235, 23);
            this.cbBoxFuncionario.TabIndex = 14;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.Location = new System.Drawing.Point(398, 250);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(225, 22);
            this.txtEmpresa.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(79, 250);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(235, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Empresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(234, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 15);
            this.label13.TabIndex = 54;
            this.label13.Text = "Celular";
            // 
            // cbUF
            // 
            this.cbUF.FormattingEnabled = true;
            this.cbUF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cbUF.Location = new System.Drawing.Point(974, 169);
            this.cbUF.Name = "cbUF";
            this.cbUF.Size = new System.Drawing.Size(74, 23);
            this.cbUF.TabIndex = 47;
            // 
            // maskCelular
            // 
            this.maskCelular.Enabled = false;
            this.maskCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskCelular.Location = new System.Drawing.Point(286, 209);
            this.maskCelular.Mask = "(00)00000-0000";
            this.maskCelular.Name = "maskCelular";
            this.maskCelular.Size = new System.Drawing.Size(132, 22);
            this.maskCelular.TabIndex = 9;
            this.maskCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(945, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 53;
            this.label12.Text = "UF";
            // 
            // btnPesquisarCep
            // 
            this.btnPesquisarCep.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPesquisarCep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarCep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarCep.Location = new System.Drawing.Point(793, 160);
            this.btnPesquisarCep.Name = "btnPesquisarCep";
            this.btnPesquisarCep.Size = new System.Drawing.Size(131, 31);
            this.btnPesquisarCep.TabIndex = 7;
            this.btnPesquisarCep.Text = "Pesquisar  CEP";
            this.btnPesquisarCep.UseVisualStyleBackColor = false;
            this.btnPesquisarCep.Click += new System.EventHandler(this.btnPesquisarCep_Click);
            // 
            // maskCEP
            // 
            this.maskCEP.Location = new System.Drawing.Point(685, 169);
            this.maskCEP.Mask = "00000-000";
            this.maskCEP.Name = "maskCEP";
            this.maskCEP.Size = new System.Drawing.Size(85, 21);
            this.maskCEP.TabIndex = 6;
            this.maskCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(650, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 15);
            this.label11.TabIndex = 51;
            this.label11.Text = "Cep";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(312, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 50;
            this.label10.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(364, 169);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(279, 22);
            this.txtCidade.TabIndex = 5;
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(79, 169);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(208, 22);
            this.txtBairro.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 49;
            this.label9.Text = "Bairro";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.btSelecionarHospedeServico);
            this.tabPage2.Controls.Add(this.btnSelecionarHospedeEdicao);
            this.tabPage2.Controls.Add(this.btnSelecionar);
            this.tabPage2.Controls.Add(this.gridHospedes);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1133, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CONSULTAR HÓSPEDES";
            // 
            // btnSelecionarHospedeEdicao
            // 
            this.btnSelecionarHospedeEdicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarHospedeEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarHospedeEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarHospedeEdicao.Location = new System.Drawing.Point(823, 92);
            this.btnSelecionarHospedeEdicao.Name = "btnSelecionarHospedeEdicao";
            this.btnSelecionarHospedeEdicao.Size = new System.Drawing.Size(199, 35);
            this.btnSelecionarHospedeEdicao.TabIndex = 30;
            this.btnSelecionarHospedeEdicao.Text = "Selecionar Hóspede";
            this.btnSelecionarHospedeEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarHospedeEdicao.Click += new System.EventHandler(this.btnSelecionarHospedeEdicao_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionar.Location = new System.Drawing.Point(823, 92);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(199, 35);
            this.btnSelecionar.TabIndex = 29;
            this.btnSelecionar.Text = "Selecionar Hóspede";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // toolTipSelecionar
            // 
            this.toolTipSelecionar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipSelecionar.ToolTipTitle = "Selecione um registro na tabela!";
            // 
            // btSelecionarHospedeServico
            // 
            this.btSelecionarHospedeServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSelecionarHospedeServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelecionarHospedeServico.ForeColor = System.Drawing.Color.Red;
            this.btSelecionarHospedeServico.Location = new System.Drawing.Point(823, 92);
            this.btSelecionarHospedeServico.Name = "btSelecionarHospedeServico";
            this.btSelecionarHospedeServico.Size = new System.Drawing.Size(199, 35);
            this.btSelecionarHospedeServico.TabIndex = 31;
            this.btSelecionarHospedeServico.Text = "Selecionar Hóspede";
            this.btSelecionarHospedeServico.UseVisualStyleBackColor = true;
            this.btSelecionarHospedeServico.Click += new System.EventHandler(this.btSelecionarHospedeServico_Click);
            // 
            // FrmHospedes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1186, 539);
            this.Controls.Add(this.tabControlHospedes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmHospedes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóspedes";
            this.Load += new System.EventHandler(this.FrmHospedes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHospedes)).EndInit();
            this.tabControlHospedes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.MaskedTextBox maskTelefone;
        private System.Windows.Forms.MaskedTextBox maskCpf;
        private System.Windows.Forms.MaskedTextBox maskBuscarCPF;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.RadioButton rBBuscarCPF;
        private System.Windows.Forms.RadioButton rBNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.DataGridView gridHospedes;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlHospedes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbUF;
        private System.Windows.Forms.MaskedTextBox maskCelular;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnPesquisarCep;
        private System.Windows.Forms.MaskedTextBox maskCEP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox makPlacaVeiculo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbBoxFuncionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacaVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnSelecionarHospedeEdicao;
        private System.Windows.Forms.ToolTip toolTipSelecionar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btSelecionarHospedeServico;
    }
}