namespace SistemaHotel.Relatorios
{
    partial class FrmRelComprovante
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vendasPorIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new SistemaHotel.HotelDataSet();
            this.detalhesvendaidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vendasPorIdTableAdapter = new SistemaHotel.HotelDataSetTableAdapters.vendasPorIdTableAdapter();
            this.detalhes_venda_idTableAdapter = new SistemaHotel.HotelDataSetTableAdapters.detalhes_venda_idTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorIdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesvendaidBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vendasPorIdBindingSource
            // 
            this.vendasPorIdBindingSource.DataMember = "vendasPorId";
            this.vendasPorIdBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "HotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // detalhesvendaidBindingSource
            // 
            this.detalhesvendaidBindingSource.DataMember = "detalhes_venda_id";
            this.detalhesvendaidBindingSource.DataSource = this.hotelDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSVendas";
            reportDataSource1.Value = this.vendasPorIdBindingSource;
            reportDataSource2.Name = "DSDetalhesVenda";
            reportDataSource2.Value = this.detalhesvendaidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaHotel.Relatorios.RelComprovante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(734, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // vendasPorIdTableAdapter
            // 
            this.vendasPorIdTableAdapter.ClearBeforeFill = true;
            // 
            // detalhes_venda_idTableAdapter
            // 
            this.detalhes_venda_idTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelComprovante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelComprovante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprovante de Venda";
            this.Load += new System.EventHandler(this.FrmRelComprovante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorIdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesvendaidBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vendasPorIdBindingSource;
        private HotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource detalhesvendaidBindingSource;
        private HotelDataSetTableAdapters.vendasPorIdTableAdapter vendasPorIdTableAdapter;
        private HotelDataSetTableAdapters.detalhes_venda_idTableAdapter detalhes_venda_idTableAdapter;
    }
}