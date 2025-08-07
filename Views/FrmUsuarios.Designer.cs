namespace SistemaHotel.Views
{
    partial class FrmUsuarios
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
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cBCargos = new System.Windows.Forms.ComboBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridUsuarios = new System.Windows.Forms.DataGridView();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenhaSalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.toolTipUsuario = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarUsuarioEdicao = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(909, 237);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 0;
            this.toolTipUsuario.SetToolTip(this.btExcluir, "EXCLUIR REGISTRO");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(909, 333);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 0;
            this.toolTipUsuario.SetToolTip(this.btEditar, "ALTERAR REGISTRO");
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Visible = false;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(581, 446);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 5;
            this.toolTipUsuario.SetToolTip(this.btSalvar, "INSERIR REGISTRO");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(440, 446);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 0;
            this.toolTipUsuario.SetToolTip(this.btNovo, "NOVO REGISTRO");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(83, 100);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(278, 22);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(82, 57);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(279, 22);
            this.txtNome.TabIndex = 1;
            // 
            // cBCargos
            // 
            this.cBCargos.Enabled = false;
            this.cBCargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCargos.FormattingEnabled = true;
            this.cBCargos.Location = new System.Drawing.Point(402, 141);
            this.cBCargos.Name = "cBCargos";
            this.cBCargos.Size = new System.Drawing.Size(186, 24);
            this.cBCargos.TabIndex = 4;
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNome.Location = new System.Drawing.Point(91, 20);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(172, 24);
            this.txtBuscarNome.TabIndex = 9;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.TxtBuscarNome_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "BUSCAR ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtBuscarNome);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(561, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 62);
            this.panel1.TabIndex = 30;
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.AllowUserToAddRows = false;
            this.gridUsuarios.AllowUserToDeleteRows = false;
            this.gridUsuarios.AllowUserToOrderColumns = true;
            this.gridUsuarios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gridUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario,
            this.Nome,
            this.Cargo,
            this.Usuario,
            this.Senha,
            this.SenhaSalt,
            this.Data});
            this.gridUsuarios.Location = new System.Drawing.Point(20, 184);
            this.gridUsuarios.MultiSelect = false;
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.ReadOnly = true;
            this.gridUsuarios.RowTemplate.Height = 26;
            this.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsuarios.Size = new System.Drawing.Size(824, 226);
            this.gridUsuarios.TabIndex = 29;
            this.gridUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridUsuarios_CellClick);
            // 
            // IdUsuario
            // 
            this.IdUsuario.DataPropertyName = "IdUsuario";
            dataGridViewCellStyle1.Format = "#,##0";
            this.IdUsuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdUsuario.HeaderText = "Cod";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.ReadOnly = true;
            this.IdUsuario.Visible = false;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nome.Width = 160;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cargo.Width = 110;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Senha
            // 
            this.Senha.DataPropertyName = "SenhaHash";
            this.Senha.HeaderText = "Senha Hash";
            this.Senha.Name = "Senha";
            this.Senha.ReadOnly = true;
            this.Senha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Senha.Width = 150;
            // 
            // SenhaSalt
            // 
            this.SenhaSalt.DataPropertyName = "SenhaSalt";
            this.SenhaSalt.HeaderText = "Senha Salt";
            this.SenhaSalt.Name = "SenhaSalt";
            this.SenhaSalt.ReadOnly = true;
            this.SenhaSalt.Width = 110;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "DataCadastro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.HeaderText = "Data de Cadastro";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.Width = 110;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(82, 16);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(79, 21);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Usuário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Senha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cargo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Código";
            // 
            // txtSenha
            // 
            this.txtSenha.Enabled = false;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(82, 143);
            this.txtSenha.MaxLength = 6;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(166, 22);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipUsuario.SetToolTip(this.txtSenha, "Somente números máximo de 6 digitos!");
            // 
            // toolTipUsuario
            // 
            this.toolTipUsuario.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnSelecionarUsuarioEdicao
            // 
            this.btnSelecionarUsuarioEdicao.AllowDrop = true;
            this.btnSelecionarUsuarioEdicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionarUsuarioEdicao.FlatAppearance.BorderSize = 2;
            this.btnSelecionarUsuarioEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarUsuarioEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarUsuarioEdicao.Location = new System.Drawing.Point(850, 184);
            this.btnSelecionarUsuarioEdicao.Name = "btnSelecionarUsuarioEdicao";
            this.btnSelecionarUsuarioEdicao.Size = new System.Drawing.Size(183, 38);
            this.btnSelecionarUsuarioEdicao.TabIndex = 31;
            this.btnSelecionarUsuarioEdicao.Text = "Selecionar Usuário";
            this.btnSelecionarUsuarioEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarUsuarioEdicao.Click += new System.EventHandler(this.btnSelecionarUsuarioEdicao_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(421, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "NOVO REGISTRO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(884, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "ALERAR REGISTRO";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(557, 514);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "INSERIR REGISTRO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(887, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "EXCLUIR REGISTRO";
            this.label10.Visible = false;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1056, 543);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelecionarUsuarioEdicao);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cBCargos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridUsuarios);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TELA DE USUÁRIOS";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cBCargos;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridUsuarios;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ToolTip toolTipUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senha;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenhaSalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.Button btnSelecionarUsuarioEdicao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}