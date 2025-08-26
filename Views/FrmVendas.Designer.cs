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
            this.GridViewVendas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.dtVendas = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuant
            // 
            this.txtQuant.Enabled = false;
            this.txtQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuant.Location = new System.Drawing.Point(318, 340);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(101, 22);
            this.txtQuant.TabIndex = 59;
            this.txtQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuant_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 63;
            this.label1.Text = "Quant";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Enabled = false;
            this.txtEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoque.Location = new System.Drawing.Point(145, 340);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(100, 22);
            this.txtEstoque.TabIndex = 57;
            this.txtEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Estoque Atual";
            // 
            // txtVrVenda
            // 
            this.txtVrVenda.Enabled = false;
            this.txtVrVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVrVenda.Location = new System.Drawing.Point(145, 381);
            this.txtVrVenda.Name = "txtVrVenda";
            this.txtVrVenda.Size = new System.Drawing.Size(102, 24);
            this.txtVrVenda.TabIndex = 58;
            this.txtVrVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 390);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 61;
            this.label9.Text = "Valor R$";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtProduto
            // 
            this.txtProduto.Enabled = false;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(145, 301);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(330, 22);
            this.txtProduto.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Produto";
            // 
            // txtHospedes
            // 
            this.txtHospedes.Enabled = false;
            this.txtHospedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHospedes.Location = new System.Drawing.Point(145, 251);
            this.txtHospedes.Name = "txtHospedes";
            this.txtHospedes.Size = new System.Drawing.Size(332, 22);
            this.txtHospedes.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "Hóspedes/Clientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 67;
            this.label4.Text = "Buscar Vendas";
            // 
            // dtBuscarVendas
            // 
            this.dtBuscarVendas.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBuscarVendas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarVendas.Location = new System.Drawing.Point(502, 71);
            this.dtBuscarVendas.Name = "dtBuscarVendas";
            this.dtBuscarVendas.Size = new System.Drawing.Size(137, 21);
            this.dtBuscarVendas.TabIndex = 68;
            this.dtBuscarVendas.ValueChanged += new System.EventHandler(this.DtBuscarVendas_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 77;
            this.label6.Text = "Nº Venda";
            // 
            // txtIdVenda
            // 
            this.txtIdVenda.Enabled = false;
            this.txtIdVenda.Location = new System.Drawing.Point(145, 210);
            this.txtIdVenda.Name = "txtIdVenda";
            this.txtIdVenda.Size = new System.Drawing.Size(100, 21);
            this.txtIdVenda.TabIndex = 78;
            this.txtIdVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.Color.Red;
            this.btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcluir.Enabled = false;
            this.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btExcluir.Location = new System.Drawing.Point(803, 513);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(143, 40);
            this.btExcluir.TabIndex = 72;
            this.btExcluir.Text = "Cancelar a Venda";
            this.toolTip1.SetToolTip(this.btExcluir, "Cancelar Venda");
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.Color.Blue;
            this.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSalvar.Enabled = false;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btSalvar.Location = new System.Drawing.Point(654, 513);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(127, 40);
            this.btSalvar.TabIndex = 75;
            this.btSalvar.Text = "Pagamento";
            this.toolTip1.SetToolTip(this.btSalvar, "Finalizar a Venda");
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // btNovo
            // 
            this.btNovo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNovo.Location = new System.Drawing.Point(141, 57);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(158, 47);
            this.btNovo.TabIndex = 74;
            this.btNovo.Text = "Nova Venda";
            this.toolTip1.SetToolTip(this.btNovo, "Nova Venda");
            this.btNovo.UseVisualStyleBackColor = false;
            this.btNovo.Click += new System.EventHandler(this.BtNovo_Click);
            // 
            // btRel
            // 
            this.btRel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRel.Enabled = false;
            this.btRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRel.Location = new System.Drawing.Point(968, 513);
            this.btRel.Name = "btRel";
            this.btRel.Size = new System.Drawing.Size(137, 40);
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
            this.btFecharGrid.Location = new System.Drawing.Point(566, 525);
            this.btFecharGrid.Name = "btFecharGrid";
            this.btFecharGrid.Size = new System.Drawing.Size(47, 28);
            this.btFecharGrid.TabIndex = 81;
            this.toolTip1.SetToolTip(this.btFecharGrid, "Fechar o Formulário");
            this.btFecharGrid.UseVisualStyleBackColor = false;
            this.btFecharGrid.Visible = false;
            this.btFecharGrid.Click += new System.EventHandler(this.BtFecharGrid_Click);
            // 
            // btRemoverItens
            // 
            this.btRemoverItens.BackColor = System.Drawing.Color.Red;
            this.btRemoverItens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemoverItens.Enabled = false;
            this.btRemoverItens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemoverItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoverItens.ForeColor = System.Drawing.Color.White;
            this.btRemoverItens.Location = new System.Drawing.Point(314, 469);
            this.btRemoverItens.Name = "btRemoverItens";
            this.btRemoverItens.Size = new System.Drawing.Size(105, 39);
            this.btRemoverItens.TabIndex = 71;
            this.btRemoverItens.Text = "Remover Item";
            this.toolTip1.SetToolTip(this.btRemoverItens, "Remova itens da Venda");
            this.btRemoverItens.UseVisualStyleBackColor = false;
            this.btRemoverItens.Click += new System.EventHandler(this.BtRemoverItens_Click);
            // 
            // btAddItens
            // 
            this.btAddItens.BackColor = System.Drawing.Color.Green;
            this.btAddItens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddItens.Enabled = false;
            this.btAddItens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddItens.ForeColor = System.Drawing.Color.Transparent;
            this.btAddItens.Location = new System.Drawing.Point(169, 469);
            this.btAddItens.Name = "btAddItens";
            this.btAddItens.Size = new System.Drawing.Size(116, 39);
            this.btAddItens.TabIndex = 70;
            this.btAddItens.Text = "Adicionar item";
            this.toolTip1.SetToolTip(this.btAddItens, "Adicione itens a Venda");
            this.btAddItens.UseVisualStyleBackColor = false;
            this.btAddItens.Click += new System.EventHandler(this.BtAddItens_Click);
            // 
            // btAddHospedes
            // 
            this.btAddHospedes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddHospedes.Enabled = false;
            this.btAddHospedes.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddHospedes.Location = new System.Drawing.Point(483, 232);
            this.btAddHospedes.Name = "btAddHospedes";
            this.btAddHospedes.Size = new System.Drawing.Size(47, 40);
            this.btAddHospedes.TabIndex = 65;
            this.toolTip1.SetToolTip(this.btAddHospedes, "Selecione um Hóspede");
            this.btAddHospedes.UseVisualStyleBackColor = true;
            this.btAddHospedes.Click += new System.EventHandler(this.BtAddHospedes_Click);
            // 
            // btAddProdutos
            // 
            this.btAddProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAddProdutos.Enabled = false;
            this.btAddProdutos.Image = global::SistemaHotel.Properties.Resources._1481313373_sign_add;
            this.btAddProdutos.Location = new System.Drawing.Point(483, 282);
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
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(880, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 18);
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
            // GridViewVendas
            // 
            this.GridViewVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewVendas.Location = new System.Drawing.Point(566, 180);
            this.GridViewVendas.Name = "GridViewVendas";
            this.GridViewVendas.Size = new System.Drawing.Size(637, 236);
            this.GridViewVendas.TabIndex = 83;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 84;
            this.label8.Text = "Data da Venda";
            // 
            // dtVendas
            // 
            this.dtVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtVendas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVendas.Location = new System.Drawing.Point(145, 171);
            this.dtVendas.Name = "dtVendas";
            this.dtVendas.Size = new System.Drawing.Size(100, 22);
            this.dtVendas.TabIndex = 86;
            // 
            // FrmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1215, 567);
            this.Controls.Add(this.dtVendas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GridViewVendas);
            this.Controls.Add(this.btRel);
            this.Controls.Add(this.btFecharGrid);
            this.Controls.Add(this.lblTotalVendas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.btRemoverItens);
            this.Controls.Add(this.btAddItens);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVendas_FormClosing);
            this.Load += new System.EventHandler(this.FrmVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button btAddItens;
        private System.Windows.Forms.Button btRemoverItens;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdVenda;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalVendas;
        private System.Windows.Forms.Button btFecharGrid;
        private System.Windows.Forms.Button btRel;
        private System.Windows.Forms.DataGridView GridViewVendas;
        public System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtVendas;
    }
}