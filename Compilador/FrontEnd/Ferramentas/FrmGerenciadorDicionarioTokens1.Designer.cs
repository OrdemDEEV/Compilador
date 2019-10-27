namespace Compilador.FrontEnd.Ferramentas
{
	partial class FrmGerenciadorDicionarioTokens1
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
            this.DgvTeste = new System.Windows.Forms.DataGridView();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simboloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvParsing = new System.Windows.Forms.DataGridView();
            this.catalogoParsingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoParsing1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoParsing2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simboloParsingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTeste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParsing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogoParsingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvTeste
            // 
            this.DgvTeste.AutoGenerateColumns = false;
            this.DgvTeste.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvTeste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTeste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.simboloDataGridViewTextBoxColumn});
            this.DgvTeste.DataSource = this.tokenBindingSource;
            this.DgvTeste.Location = new System.Drawing.Point(6, 0);
            this.DgvTeste.Name = "DgvTeste";
            this.DgvTeste.Size = new System.Drawing.Size(777, 372);
            this.DgvTeste.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // simboloDataGridViewTextBoxColumn
            // 
            this.simboloDataGridViewTextBoxColumn.DataPropertyName = "Simbolo";
            this.simboloDataGridViewTextBoxColumn.HeaderText = "Simbolo";
            this.simboloDataGridViewTextBoxColumn.Name = "simboloDataGridViewTextBoxColumn";
            this.simboloDataGridViewTextBoxColumn.ReadOnly = true;
            this.simboloDataGridViewTextBoxColumn.Width = 600;
            // 
            // tokenBindingSource
            // 
            this.tokenBindingSource.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.Token);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 404);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgvTeste);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tokens";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvParsing);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parsing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvParsing
            // 
            this.dgvParsing.AutoGenerateColumns = false;
            this.dgvParsing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParsing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoParsing1DataGridViewTextBoxColumn,
            this.codigoParsing2DataGridViewTextBoxColumn,
            this.simboloParsingDataGridViewTextBoxColumn});
            this.dgvParsing.DataSource = this.catalogoParsingBindingSource;
            this.dgvParsing.Location = new System.Drawing.Point(6, 3);
            this.dgvParsing.Name = "dgvParsing";
            this.dgvParsing.Size = new System.Drawing.Size(776, 369);
            this.dgvParsing.TabIndex = 0;
            // 
            // catalogoParsingBindingSource
            // 
            // 
            // codigoParsing1DataGridViewTextBoxColumn
            // 
            this.codigoParsing1DataGridViewTextBoxColumn.DataPropertyName = "CodigoParsing1";
            this.codigoParsing1DataGridViewTextBoxColumn.HeaderText = "Codigo 1";
            this.codigoParsing1DataGridViewTextBoxColumn.Name = "codigoParsing1DataGridViewTextBoxColumn";
            this.codigoParsing1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoParsing2DataGridViewTextBoxColumn
            // 
            this.codigoParsing2DataGridViewTextBoxColumn.DataPropertyName = "CodigoParsing2";
            this.codigoParsing2DataGridViewTextBoxColumn.HeaderText = "Codigo 2";
            this.codigoParsing2DataGridViewTextBoxColumn.Name = "codigoParsing2DataGridViewTextBoxColumn";
            this.codigoParsing2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // simboloParsingDataGridViewTextBoxColumn
            // 
            this.simboloParsingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.simboloParsingDataGridViewTextBoxColumn.DataPropertyName = "SimboloParsing";
            this.simboloParsingDataGridViewTextBoxColumn.HeaderText = "Simbolo Parsing";
            this.simboloParsingDataGridViewTextBoxColumn.Name = "simboloParsingDataGridViewTextBoxColumn";
            this.simboloParsingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmGerenciadorDicionarioTokens1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmGerenciadorDicionarioTokens1";
            this.Text = "Visualização";
            this.Load += new System.EventHandler(this.FrmGerenciadorDicionarioTokens1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTeste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParsing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogoParsingBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DgvTeste;
		private System.Windows.Forms.BindingSource tokenBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn simboloDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvParsing;
        private System.Windows.Forms.BindingSource catalogoParsingBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoParsing1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoParsing2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simboloParsingDataGridViewTextBoxColumn;
    }
}