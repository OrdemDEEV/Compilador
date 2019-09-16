namespace Compilador.FrontEnd
{
    partial class FrmInicio
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarDicionarioDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnRodarAnalizadorLexico = new System.Windows.Forms.ToolStripMenuItem();
            this.rodarAnalizarSintáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rodarAnalizadorSemanticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvPilhaPrincipal = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtEditorTexto = new System.Windows.Forms.RichTextBox();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.tokenAtivoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tokenAtivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tokenAtivoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buffer_ident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buffer_literal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPilhaPrincipal)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.ferramentasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1256, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAbrir,
            this.salvarToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // BtnAbrir
            // 
            this.BtnAbrir.Name = "BtnAbrir";
            this.BtnAbrir.Size = new System.Drawing.Size(109, 22);
            this.BtnAbrir.Text = "Abrir";
            this.BtnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarDicionarioDeDadosToolStripMenuItem,
            this.toolStripSeparator1,
            this.BtnRodarAnalizadorLexico,
            this.rodarAnalizarSintáticoToolStripMenuItem,
            this.rodarAnalizadorSemanticoToolStripMenuItem,
            this.toolStripSeparator2,
            this.compilarToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // gerenciarDicionarioDeDadosToolStripMenuItem
            // 
            this.gerenciarDicionarioDeDadosToolStripMenuItem.Name = "gerenciarDicionarioDeDadosToolStripMenuItem";
            this.gerenciarDicionarioDeDadosToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.gerenciarDicionarioDeDadosToolStripMenuItem.Text = "Gerenciar Dicionario de tokens";
            this.gerenciarDicionarioDeDadosToolStripMenuItem.Click += new System.EventHandler(this.gerenciarDicionarioDeDadosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // BtnRodarAnalizadorLexico
            // 
            this.BtnRodarAnalizadorLexico.Name = "BtnRodarAnalizadorLexico";
            this.BtnRodarAnalizadorLexico.Size = new System.Drawing.Size(235, 22);
            this.BtnRodarAnalizadorLexico.Text = "Rodar Analizador Léxico";
            this.BtnRodarAnalizadorLexico.Click += new System.EventHandler(this.BtnRodarAnalizadorLexico_Click);
            // 
            // rodarAnalizarSintáticoToolStripMenuItem
            // 
            this.rodarAnalizarSintáticoToolStripMenuItem.Name = "rodarAnalizarSintáticoToolStripMenuItem";
            this.rodarAnalizarSintáticoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.rodarAnalizarSintáticoToolStripMenuItem.Text = "Rodar Analizar Sintático";
            // 
            // rodarAnalizadorSemanticoToolStripMenuItem
            // 
            this.rodarAnalizadorSemanticoToolStripMenuItem.Name = "rodarAnalizadorSemanticoToolStripMenuItem";
            this.rodarAnalizadorSemanticoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.rodarAnalizadorSemanticoToolStripMenuItem.Text = "Rodar Analizador Semantico";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.compilarToolStripMenuItem.Text = "Compilar";
            // 
            // DgvPilhaPrincipal
            // 
            this.DgvPilhaPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvPilhaPrincipal.AutoGenerateColumns = false;
            this.DgvPilhaPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPilhaPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.linhaDataGridViewTextBoxColumn,
            this.Column2,
            this.Column1,
            this.Valor,
            this.Buffer_ident,
            this.Buffer_literal});
            this.DgvPilhaPrincipal.DataSource = this.tokenAtivoBindingSource2;
            this.DgvPilhaPrincipal.Location = new System.Drawing.Point(725, 31);
            this.DgvPilhaPrincipal.Name = "DgvPilhaPrincipal";
            this.DgvPilhaPrincipal.Size = new System.Drawing.Size(519, 700);
            this.DgvPilhaPrincipal.TabIndex = 5;
            this.DgvPilhaPrincipal.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDados_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TxtEditorTexto);
            this.groupBox1.Controls.Add(this.LineNumberTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 715);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // TxtEditorTexto
            // 
            this.TxtEditorTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEditorTexto.Location = new System.Drawing.Point(46, 9);
            this.TxtEditorTexto.Name = "TxtEditorTexto";
            this.TxtEditorTexto.Size = new System.Drawing.Size(651, 700);
            this.TxtEditorTexto.TabIndex = 1;
            this.TxtEditorTexto.Text = "";
            this.TxtEditorTexto.VScroll += new System.EventHandler(this.TxtEditorTexto_VScroll);
            this.TxtEditorTexto.FontChanged += new System.EventHandler(this.TxtEditorTexto_FontChanged);
            this.TxtEditorTexto.TextChanged += new System.EventHandler(this.TxtEditorTexto_TextChanged);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LineNumberTextBox.Location = new System.Drawing.Point(6, 10);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ReadOnly = true;
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberTextBox.Size = new System.Drawing.Size(40, 700);
            this.LineNumberTextBox.TabIndex = 0;
            this.LineNumberTextBox.Text = "";
            this.LineNumberTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LineNumberTextBox_MouseDown);
            // 
            // tokenAtivoBindingSource2
            // 
            this.tokenAtivoBindingSource2.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.TokenAtivo);
            // 
            // tokenAtivoBindingSource
            // 
            this.tokenAtivoBindingSource.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.TokenAtivo);
            // 
            // tokenAtivoBindingSource1
            // 
            this.tokenAtivoBindingSource1.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.TokenAtivo);
            // 
            // linhaDataGridViewTextBoxColumn
            // 
            this.linhaDataGridViewTextBoxColumn.DataPropertyName = "Linha";
            this.linhaDataGridViewTextBoxColumn.HeaderText = "Linha";
            this.linhaDataGridViewTextBoxColumn.Name = "linhaDataGridViewTextBoxColumn";
            this.linhaDataGridViewTextBoxColumn.ReadOnly = true;
            this.linhaDataGridViewTextBoxColumn.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "token.Codigo";
            this.Column2.HeaderText = "Codigo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "token.Simbolo";
            this.Column1.HeaderText = "Simbolo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 115;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 70;
            // 
            // Buffer_ident
            // 
            this.Buffer_ident.DataPropertyName = "Buffer_ident";
            this.Buffer_ident.HeaderText = "Identificador";
            this.Buffer_ident.Name = "Buffer_ident";
            this.Buffer_ident.ReadOnly = true;
            this.Buffer_ident.Width = 70;
            // 
            // Buffer_literal
            // 
            this.Buffer_literal.DataPropertyName = "Buffer_literal";
            this.Buffer_literal.HeaderText = "Literal";
            this.Buffer_literal.Name = "Buffer_literal";
            this.Buffer_literal.ReadOnly = true;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1256, 749);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvPilhaPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmInicio";
            this.Text = "Inicio - Compilador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.Resize += new System.EventHandler(this.FrmInicio_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPilhaPrincipal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenAtivoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnAbrir;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarDicionarioDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtnRodarAnalizadorLexico;
        private System.Windows.Forms.ToolStripMenuItem rodarAnalizarSintáticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rodarAnalizadorSemanticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
		private System.Windows.Forms.BindingSource tokenAtivoBindingSource;
		private System.Windows.Forms.BindingSource tokenAtivoBindingSource1;
		private System.Windows.Forms.DataGridView DgvPilhaPrincipal;
		private System.Windows.Forms.BindingSource tokenAtivoBindingSource2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox TxtEditorTexto;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn linhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buffer_ident;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buffer_literal;
    }
}