namespace SistemaHotel.Views
{
    partial class FrmPagamentos
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
            this.txtDinheiro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCartao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btFinalizarVendas = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtVendas = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDinheiro
            // 
            this.txtDinheiro.Enabled = false;
            this.txtDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDinheiro.Location = new System.Drawing.Point(238, 139);
            this.txtDinheiro.Name = "txtDinheiro";
            this.txtDinheiro.Size = new System.Drawing.Size(173, 35);
            this.txtDinheiro.TabIndex = 1;
            this.txtDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinheiro_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(82, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 29);
            this.label9.TabIndex = 63;
            this.label9.Text = "Dinheiro R$";
            // 
            // txtCartao
            // 
            this.txtCartao.Enabled = false;
            this.txtCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartao.Location = new System.Drawing.Point(238, 200);
            this.txtCartao.Name = "txtCartao";
            this.txtCartao.Size = new System.Drawing.Size(173, 35);
            this.txtCartao.TabIndex = 2;
            this.txtCartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCartao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCartao_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 65;
            this.label1.Text = "Cartão";
            // 
            // txtPix
            // 
            this.txtPix.Enabled = false;
            this.txtPix.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPix.Location = new System.Drawing.Point(238, 261);
            this.txtPix.Name = "txtPix";
            this.txtPix.Size = new System.Drawing.Size(173, 35);
            this.txtPix.TabIndex = 3;
            this.txtPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPix_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 29);
            this.label2.TabIndex = 67;
            this.label2.Text = "Pix";
            // 
            // btFinalizarVendas
            // 
            this.btFinalizarVendas.BackColor = System.Drawing.Color.Blue;
            this.btFinalizarVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFinalizarVendas.Enabled = false;
            this.btFinalizarVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFinalizarVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFinalizarVendas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btFinalizarVendas.Location = new System.Drawing.Point(140, 460);
            this.btFinalizarVendas.Name = "btFinalizarVendas";
            this.btFinalizarVendas.Size = new System.Drawing.Size(332, 40);
            this.btFinalizarVendas.TabIndex = 5;
            this.btFinalizarVendas.Text = "Finalizar Venda";
            this.btFinalizarVendas.UseVisualStyleBackColor = false;
            this.btFinalizarVendas.Click += new System.EventHandler(this.btFinalizarVendas_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(238, 400);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(173, 35);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 29);
            this.label3.TabIndex = 78;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(188, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 37);
            this.label4.TabIndex = 79;
            this.label4.Text = "PAGAMENTO";
            // 
            // txtTroco
            // 
            this.txtTroco.Enabled = false;
            this.txtTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Location = new System.Drawing.Point(238, 321);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(173, 35);
            this.txtTroco.TabIndex = 0;
            this.txtTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 29);
            this.label5.TabIndex = 81;
            this.label5.Text = "Troco";
            // 
            // dtVendas
            // 
            this.dtVendas.Enabled = false;
            this.dtVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtVendas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVendas.Location = new System.Drawing.Point(238, 84);
            this.dtVendas.Name = "dtVendas";
            this.dtVendas.Size = new System.Drawing.Size(173, 35);
            this.dtVendas.TabIndex = 88;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 29);
            this.label8.TabIndex = 87;
            this.label8.Text = "Data do pagto";
            // 
            // FrmPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 514);
            this.Controls.Add(this.dtVendas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTroco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btFinalizarVendas);
            this.Controls.Add(this.txtPix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCartao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDinheiro);
            this.Controls.Add(this.label9);
            this.Name = "FrmPagamentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TELA DE PAGAMENTOS";
            this.Load += new System.EventHandler(this.FrmPagamentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDinheiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCartao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btFinalizarVendas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DateTimePicker dtVendas;
        private System.Windows.Forms.Label label8;
    }
}