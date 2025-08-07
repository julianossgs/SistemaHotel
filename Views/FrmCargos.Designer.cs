namespace SistemaHotel.Views
{
    partial class FrmCargos
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
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btNovo = new System.Windows.Forms.Button();
            this.gridCargos = new System.Windows.Forms.DataGridView();
            this.IdCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipCargo = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarCargoEdicao = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCargo
            // 
            this.txtCargo.Enabled = false;
            this.txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.Location = new System.Drawing.Point(96, 61);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(269, 22);
            this.txtCargo.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(50, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cargo";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(96, 12);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(66, 22);
            this.txtCod.TabIndex = 18;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Código";
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::SistemaHotel.Properties.Resources.botaoDeletar;
            this.btExcluir.Location = new System.Drawing.Point(534, 199);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(65, 65);
            this.btExcluir.TabIndex = 23;
            this.toolTipCargo.SetToolTip(this.btExcluir, "EXCLUIR REGISTRO");
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::SistemaHotel.Properties.Resources.botaoEditar;
            this.btEditar.Location = new System.Drawing.Point(534, 295);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(65, 65);
            this.btEditar.TabIndex = 22;
            this.toolTipCargo.SetToolTip(this.btEditar, "ALTERAR REGISTRO");
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Visible = false;
            this.btEditar.Click += new System.EventHandler(this.BtEditar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::SistemaHotel.Properties.Resources.botaoSalvar;
            this.btSalvar.Location = new System.Drawing.Point(352, 478);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(65, 65);
            this.btSalvar.TabIndex = 21;
            this.toolTipCargo.SetToolTip(this.btSalvar, "INSERIR REGISTRO");
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.Image = global::SistemaHotel.Properties.Resources.botaoNovo;
            this.btNovo.Location = new System.Drawing.Point(234, 478);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(65, 65);
            this.btNovo.TabIndex = 20;
            this.toolTipCargo.SetToolTip(this.btNovo, "NOVO REGISTRO");
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // gridCargos
            // 
            this.gridCargos.AllowUserToAddRows = false;
            this.gridCargos.AllowUserToDeleteRows = false;
            this.gridCargos.AllowUserToOrderColumns = true;
            this.gridCargos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCargos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCargo,
            this.Cargo});
            this.gridCargos.Location = new System.Drawing.Point(34, 107);
            this.gridCargos.Name = "gridCargos";
            this.gridCargos.ReadOnly = true;
            this.gridCargos.Size = new System.Drawing.Size(418, 341);
            this.gridCargos.TabIndex = 24;
            this.gridCargos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCargos_CellClick);
            // 
            // IdCargo
            // 
            this.IdCargo.DataPropertyName = "IdCargo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "#,##0";
            this.IdCargo.DefaultCellStyle = dataGridViewCellStyle1;
            this.IdCargo.HeaderText = "Código";
            this.IdCargo.Name = "IdCargo";
            this.IdCargo.ReadOnly = true;
            this.IdCargo.Width = 70;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 290;
            // 
            // toolTipCargo
            // 
            this.toolTipCargo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnSelecionarCargoEdicao
            // 
            this.btnSelecionarCargoEdicao.AllowDrop = true;
            this.btnSelecionarCargoEdicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionarCargoEdicao.FlatAppearance.BorderSize = 2;
            this.btnSelecionarCargoEdicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarCargoEdicao.ForeColor = System.Drawing.Color.Red;
            this.btnSelecionarCargoEdicao.Location = new System.Drawing.Point(458, 107);
            this.btnSelecionarCargoEdicao.Name = "btnSelecionarCargoEdicao";
            this.btnSelecionarCargoEdicao.Size = new System.Drawing.Size(183, 38);
            this.btnSelecionarCargoEdicao.TabIndex = 50;
            this.btnSelecionarCargoEdicao.Text = "Selecionar Cargo";
            this.toolTipCargo.SetToolTip(this.btnSelecionarCargoEdicao, "Selecione para alteração/exclusão");
            this.btnSelecionarCargoEdicao.UseVisualStyleBackColor = true;
            this.btnSelecionarCargoEdicao.Click += new System.EventHandler(this.btnSelecionarCargoEdicao_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "NOVO REGISTRO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "INSERIR REGISTRO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "ALTERAR REGISTRO";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(511, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "EXCLUIR REGISTRO";
            this.label6.Visible = false;
            // 
            // FrmCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(674, 574);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelecionarCargoEdicao);
            this.Controls.Add(this.gridCargos);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCargos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCargos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.DataGridView gridCargos;
        private System.Windows.Forms.ToolTip toolTipCargo;
        private System.Windows.Forms.Button btnSelecionarCargoEdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}