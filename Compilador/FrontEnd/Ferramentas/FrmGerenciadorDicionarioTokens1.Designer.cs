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
			this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.simboloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.DgvTeste)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
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
			this.DgvTeste.Location = new System.Drawing.Point(12, 57);
			this.DgvTeste.Name = "DgvTeste";
			this.DgvTeste.Size = new System.Drawing.Size(776, 381);
			this.DgvTeste.TabIndex = 0;
			// 
			// tokenBindingSource
			// 
			this.tokenBindingSource.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.Token);
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
			// FrmGerenciadorDicionarioTokens1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DgvTeste);
			this.Name = "FrmGerenciadorDicionarioTokens1";
			this.Text = "FrmGerenciadorDicionarioTokens1";
			this.Load += new System.EventHandler(this.FrmGerenciadorDicionarioTokens1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DgvTeste)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DgvTeste;
		private System.Windows.Forms.BindingSource tokenBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn simboloDataGridViewTextBoxColumn;
	}
}