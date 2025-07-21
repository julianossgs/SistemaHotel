namespace SistemaHotel.Relatorios
{
    partial class FrmRelProdutos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.produtosFornecedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new SistemaHotel.HotelDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tblProdutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblProdutosTableAdapter = new SistemaHotel.HotelDataSetTableAdapters.TblProdutosTableAdapter();
            this.produtosFornecedoresTableAdapter = new SistemaHotel.HotelDataSetTableAdapters.ProdutosFornecedoresTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.produtosFornecedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProdutosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // produtosFornecedoresBindingSource
            // 
            this.produtosFornecedoresBindingSource.DataMember = "ProdutosFornecedores";
            this.produtosFornecedoresBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "HotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetProdutos";
            reportDataSource1.Value = this.produtosFornecedoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaHotel.Relatorios.RelProdutos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(734, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblProdutosBindingSource
            // 
            this.tblProdutosBindingSource.DataMember = "TblProdutos";
            this.tblProdutosBindingSource.DataSource = this.hotelDataSet;
            // 
            // tblProdutosTableAdapter
            // 
            this.tblProdutosTableAdapter.ClearBeforeFill = true;
            // 
            // produtosFornecedoresTableAdapter
            // 
            this.produtosFornecedoresTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 661);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRelProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATÓRIO DE PRODUTOS";
            this.Load += new System.EventHandler(this.FrmRelProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produtosFornecedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProdutosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource tblProdutosBindingSource;
        private HotelDataSetTableAdapters.TblProdutosTableAdapter tblProdutosTableAdapter;
        private System.Windows.Forms.BindingSource produtosFornecedoresBindingSource;
        private HotelDataSetTableAdapters.ProdutosFornecedoresTableAdapter produtosFornecedoresTableAdapter;
    }
}