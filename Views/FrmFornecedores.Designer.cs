namespace SistemaHotel.Views
{
    partial class FrmFornecedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.maskTel = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gridFornecedores = new System.Windows.Forms.DataGridView();
            this.IdFornec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.maskCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maskCEP = new System.Windows.Forms.MaskedTextBox();
            this.btnPesquisarCep = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.maskCelular = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.cbUF = new System.Windows.Forms.ComboBox();
            this.toolTipFornec = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarFornecEdicao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFornecedores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(436, 45);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(278, 22);
            this.txtEndereco.TabIndex = 3;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(72, 46);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(279, 22);
            this.txtNome.TabIndex = 2;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(433, 12);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(79, 21);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCod.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Endereço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nome";
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(1122, 414);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 25;
            this.toolTipFornec.SetToolTip(this.btExcluir, "EXCLUIR REGISTRO");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(1122, 320);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 24;
            this.toolTipFornec.SetToolTip(this.btEditar, "ALTERAR REGISTRO");
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Visible = false;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(675, 507);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 23;
            this.toolTipFornec.SetToolTip(this.btSalvar, "INSERIR REGISTRO");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(548, 507);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 22;
            this.toolTipFornec.SetToolTip(this.btNovo, "NOVO REGISTRO");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Contato";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(480, 179);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(235, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // txtContato
            // 
            this.txtContato.Enabled = false;
            this.txtContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContato.Location = new System.Drawing.Point(790, 178);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(225, 22);
            this.txtContato.TabIndex = 11;
            // 
            // maskTel
            // 
            this.maskTel.Enabled = false;
            this.maskTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskTel.Location = new System.Drawing.Point(72, 180);
            this.maskTel.Mask = "(00)0000-0000";
            this.maskTel.Name = "maskTel";
            this.maskTel.Size = new System.Drawing.Size(132, 22);
            this.maskTel.TabIndex = 8;
            this.maskTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtBuscarNome);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(798, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 69);
            this.panel1.TabIndex = 32;
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNome.Location = new System.Drawing.Point(88, 21);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(203, 22);
            this.txtBuscarNome.TabIndex = 9;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.txtBuscarNome_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "BUSCAR ";
            // 
            // gridFornecedores
            // 
            this.gridFornecedores.AllowUserToAddRows = false;
            this.gridFornecedores.AllowUserToDeleteRows = false;
            this.gridFornecedores.AllowUserToOrderColumns = true;
            this.gridFornecedores.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gridFornecedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFornecedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFornec,
            this.Cnpj,
            this.Nome,
            this.Endereco,
            this.Bairro,
            this.Cidade,
            this.Estado,
            this.Cep,
            this.Telefone,
            this.Celular,
            this.Email,
            this.Contato,
            this.Data,
            this.Observacoes});
            this.gridFornecedores.Location = new System.Drawing.Point(19, 276);
            this.gridFornecedores.Name = "gridFornecedores";
            this.gridFornecedores.ReadOnly = true;
            this.gridFornecedores.Size = new System.Drawing.Size(1037, 214);
            this.gridFornecedores.TabIndex = 33;
            // 
            // IdFornec
            // 
            this.IdFornec.DataPropertyName = "IdFornec";
            dataGridViewCellStyle3.Format = "#,##0";
            this.IdFornec.DefaultCellStyle = dataGridViewCellStyle3;
            this.IdFornec.HeaderText = "Cod ";
            this.IdFornec.Name = "IdFornec";
            this.IdFornec.ReadOnly = true;
            this.IdFornec.Visible = false;
            // 
            // Cnpj
            // 
            this.Cnpj.DataPropertyName = "Cnpj";
            this.Cnpj.HeaderText = "CNPJ";
            this.Cnpj.Name = "Cnpj";
            this.Cnpj.ReadOnly = true;
            this.Cnpj.Width = 150;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 220;
            // 
            // Endereco
            // 
            this.Endereco.DataPropertyName = "Endereco";
            this.Endereco.HeaderText = "Endereco";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Visible = false;
            this.Endereco.Width = 200;
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
            this.Estado.HeaderText = "UF";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Visible = false;
            this.Estado.Width = 20;
            // 
            // Cep
            // 
            this.Cep.DataPropertyName = "Cep";
            this.Cep.HeaderText = "Cep";
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Visible = false;
            this.Cep.Width = 50;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Width = 110;
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "Celular";
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            this.Celular.Width = 110;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Email.Width = 200;
            // 
            // Contato
            // 
            this.Contato.DataPropertyName = "Contato";
            this.Contato.HeaderText = "Contato";
            this.Contato.Name = "Contato";
            this.Contato.ReadOnly = true;
            this.Contato.Width = 200;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataCadastro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle4;
            this.Data.HeaderText = "Data/Cadastro";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.Visible = false;
            // 
            // Observacoes
            // 
            this.Observacoes.DataPropertyName = "Observacoes";
            this.Observacoes.HeaderText = "Obs";
            this.Observacoes.Name = "Observacoes";
            this.Observacoes.ReadOnly = true;
            this.Observacoes.Visible = false;
            this.Observacoes.Width = 150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "CNPJ";
            // 
            // maskCNPJ
            // 
            this.maskCNPJ.Location = new System.Drawing.Point(72, 15);
            this.maskCNPJ.Mask = "00.000.000/0000-00";
            this.maskCNPJ.Name = "maskCNPJ";
            this.maskCNPJ.Size = new System.Drawing.Size(141, 21);
            this.maskCNPJ.TabIndex = 1;
            this.maskCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(72, 85);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(279, 22);
            this.txtBairro.TabIndex = 4;
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(436, 85);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(279, 22);
            this.txtCidade.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 39;
            this.label10.Text = "Cidade";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "Cep";
            // 
            // maskCEP
            // 
            this.maskCEP.Location = new System.Drawing.Point(72, 134);
            this.maskCEP.Mask = "00000-000";
            this.maskCEP.Name = "maskCEP";
            this.maskCEP.Size = new System.Drawing.Size(85, 21);
            this.maskCEP.TabIndex = 6;
            this.maskCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPesquisarCep
            // 
            this.btnPesquisarCep.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPesquisarCep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarCep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarCep.Location = new System.Drawing.Point(175, 124);
            this.btnPesquisarCep.Name = "btnPesquisarCep";
            this.btnPesquisarCep.Size = new System.Drawing.Size(131, 31);
            this.btnPesquisarCep.TabIndex = 42;
            this.btnPesquisarCep.Text = "Pesquisar  CEP";
            this.btnPesquisarCep.UseVisualStyleBackColor = false;
            this.btnPesquisarCep.Click += new System.EventHandler(this.btnPesquisarCep_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(409, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = "UF";
            // 
            // txtUF
            // 
            this.txtUF.Enabled = false;
            this.txtUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(720, 128);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(74, 22);
            this.txtUF.TabIndex = 7;
            this.txtUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUF.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 15);
            this.label13.TabIndex = 45;
            this.label13.Text = "Celular";
            // 
            // maskCelular
            // 
            this.maskCelular.Enabled = false;
            this.maskCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskCelular.Location = new System.Drawing.Point(283, 179);
            this.maskCelular.Mask = "(00)00000-0000";
            this.maskCelular.Name = "maskCelular";
            this.maskCelular.Size = new System.Drawing.Size(132, 22);
            this.maskCelular.TabIndex = 9;
            this.maskCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 226);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 15);
            this.label14.TabIndex = 47;
            this.label14.Text = "Observações";
            // 
            // txtObs
            // 
            this.txtObs.Enabled = false;
            this.txtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(99, 219);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(384, 51);
            this.txtObs.TabIndex = 12;
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
            this.cbUF.Location = new System.Drawing.Point(438, 128);
            this.cbUF.Name = "cbUF";
            this.cbUF.Size = new System.Drawing.Size(74, 23);
            this.cbUF.TabIndex = 7;
            // 
            // toolTipFornec
            // 
            this.toolTipFornec.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnSelecionarFornecEdicao
            // 
            this.btnSelecionarFornecEdicao.AllowDrop = true;
            this.btnSelecionarFornecEdicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionarFornecEdicao.FlatAppearance.BorderSize = 2;
            this.btnSelecionarFornecEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarFornecEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarFornecEdicao.Location = new System.Drawing.Point(1062, 276);
            this.btnSelecionarFornecEdicao.Name = "btnSelecionarFornecEdicao";
            this.btnSelecionarFornecEdicao.Size = new System.Drawing.Size(183, 38);
            this.btnSelecionarFornecEdicao.TabIndex = 48;
            this.btnSelecionarFornecEdicao.Text = "Selecionar Forneçedor";
            this.toolTipFornec.SetToolTip(this.btnSelecionarFornecEdicao, "Selecione para alteração/exclusão");
            this.btnSelecionarFornecEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarFornecEdicao.Click += new System.EventHandler(this.btnSelecionarFornecEdicao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1101, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "EXCLUIR REGISTRO";
            this.label1.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(1102, 388);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 60;
            this.label15.Text = "ALTERAR REGISTRO";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(653, 575);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "INSERIR REGISTRO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(528, 575);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "NOVO REGISTRO";
            // 
            // FrmFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1249, 598);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelecionarFornecEdicao);
            this.Controls.Add(this.cbUF);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.maskCelular);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnPesquisarCep);
            this.Controls.Add(this.maskCEP);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskCNPJ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gridFornecedores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.maskTel);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFornecedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TELA DE FORNECEDORES";
            this.Load += new System.EventHandler(this.FrmFornecedores_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFornecedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.MaskedTextBox maskTel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gridFornecedores;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskCNPJ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskCEP;
        private System.Windows.Forms.Button btnPesquisarCep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox maskCelular;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.ComboBox cbUF;
        private System.Windows.Forms.ToolTip toolTipFornec;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFornec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacoes;
        private System.Windows.Forms.Button btnSelecionarFornecEdicao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}