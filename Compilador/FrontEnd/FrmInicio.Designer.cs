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
			this.TxtEditorTexto = new System.Windows.Forms.RichTextBox();
			this.TxtCaminhoArquivo = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(939, 24);
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
			this.BtnAbrir.Size = new System.Drawing.Size(180, 22);
			this.BtnAbrir.Text = "Abrir";
			this.BtnAbrir.Click += new System.EventHandler(this.BtnAbrir_Click);
			// 
			// salvarToolStripMenuItem
			// 
			this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
			this.salvarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.salvarToolStripMenuItem.Text = "Salvar";
			// 
			// fecharToolStripMenuItem
			// 
			this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
			this.fecharToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
			// TxtEditorTexto
			// 
			this.TxtEditorTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtEditorTexto.Location = new System.Drawing.Point(12, 78);
			this.TxtEditorTexto.Name = "TxtEditorTexto";
			this.TxtEditorTexto.Size = new System.Drawing.Size(915, 308);
			this.TxtEditorTexto.TabIndex = 3;
			this.TxtEditorTexto.Text = "";
			// 
			// TxtCaminhoArquivo
			// 
			this.TxtCaminhoArquivo.Location = new System.Drawing.Point(12, 27);
			this.TxtCaminhoArquivo.Name = "TxtCaminhoArquivo";
			this.TxtCaminhoArquivo.Size = new System.Drawing.Size(345, 20);
			this.TxtCaminhoArquivo.TabIndex = 4;
			// 
			// FrmInicio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(939, 507);
			this.Controls.Add(this.TxtCaminhoArquivo);
			this.Controls.Add(this.TxtEditorTexto);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmInicio";
			this.Text = "Inicio - Compilador";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmInicio_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.RichTextBox TxtEditorTexto;
		private System.Windows.Forms.TextBox TxtCaminhoArquivo;
	}
}