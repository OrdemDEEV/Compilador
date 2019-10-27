namespace Compilador.FrontEnd.Ferramentas
{
	partial class FrmlGerenciadorTabelaParsing
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
			this.DgvTabelaParsing = new System.Windows.Forms.DataGridView();
			this.catalogoParsingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.derivacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.DgvTabelaParsing)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.catalogoParsingBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// DgvTabelaParsing
			// 
			this.DgvTabelaParsing.AutoGenerateColumns = false;
			this.DgvTabelaParsing.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.DgvTabelaParsing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvTabelaParsing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoDataGridViewTextBoxColumn,
            this.derivacaoDataGridViewTextBoxColumn});
			this.DgvTabelaParsing.DataSource = this.itemBindingSource;
			this.DgvTabelaParsing.Location = new System.Drawing.Point(12, 12);
			this.DgvTabelaParsing.Name = "DgvTabelaParsing";
			this.DgvTabelaParsing.Size = new System.Drawing.Size(777, 426);
			this.DgvTabelaParsing.TabIndex = 1;
			// 
			// catalogoParsingBindingSource
			// 

			// 
			// itemBindingSource
			// 
			this.itemBindingSource.DataSource = typeof(Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos.Item);
			// 
			// codigoDataGridViewTextBoxColumn
			// 
			this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
			this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
			this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
			// 
			// derivacaoDataGridViewTextBoxColumn
			// 
			this.derivacaoDataGridViewTextBoxColumn.DataPropertyName = "Derivacao";
			this.derivacaoDataGridViewTextBoxColumn.HeaderText = "Derivacao";
			this.derivacaoDataGridViewTextBoxColumn.Name = "derivacaoDataGridViewTextBoxColumn";
			this.derivacaoDataGridViewTextBoxColumn.Width = 600;
			// 
			// FrmlGerenciadorTabelaParsing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.DgvTabelaParsing);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmlGerenciadorTabelaParsing";
			this.Text = "FrmlGerenciadorTabelaParsing";
			this.Load += new System.EventHandler(this.FrmlGerenciadorTabelaParsing_Load);
			((System.ComponentModel.ISupportInitialize)(this.DgvTabelaParsing)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.catalogoParsingBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DgvTabelaParsing;
		private System.Windows.Forms.BindingSource catalogoParsingBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn derivacaoDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource itemBindingSource;
	}
}