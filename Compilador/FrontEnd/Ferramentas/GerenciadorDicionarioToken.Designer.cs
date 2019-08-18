namespace Compilador.FrontEnd.Ferramentas
{
    partial class GerenciadorDicionarioToken
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
            this.GcTokens = new DevExpress.XtraGrid.GridControl();
            this.DgvTokens = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSimbolo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tokenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GcTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GcTokens
            // 
            this.GcTokens.Location = new System.Drawing.Point(12, 12);
            this.GcTokens.LookAndFeel.SkinName = "Office 2013";
            this.GcTokens.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GcTokens.MainView = this.DgvTokens;
            this.GcTokens.Name = "GcTokens";
            this.GcTokens.Size = new System.Drawing.Size(776, 426);
            this.GcTokens.TabIndex = 0;
            this.GcTokens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvTokens});
            // 
            // DgvTokens
            // 
            this.DgvTokens.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colSimbolo});
            this.DgvTokens.GridControl = this.GcTokens;
            this.DgvTokens.Name = "DgvTokens";
            this.DgvTokens.OptionsBehavior.Editable = false;
            this.DgvTokens.OptionsView.ShowGroupPanel = false;
            // 
            // colCodigo
            // 
            this.colCodigo.AppearanceCell.Options.UseTextOptions = true;
            this.colCodigo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodigo.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.ReadOnly = true;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 66;
            // 
            // colSimbolo
            // 
            this.colSimbolo.FieldName = "Simbolo";
            this.colSimbolo.Name = "colSimbolo";
            this.colSimbolo.OptionsColumn.ReadOnly = true;
            this.colSimbolo.Visible = true;
            this.colSimbolo.VisibleIndex = 1;
            this.colSimbolo.Width = 747;
            // 
            // tokenBindingSource
            // 
            this.tokenBindingSource.DataSource = typeof(Compilador.BackEnd.AnalizadorLexico.DicionarioTokens.Token);
            // 
            // GerenciadorDicionarioToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GcTokens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GerenciadorDicionarioToken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dicionário de Tokens";
            this.Load += new System.EventHandler(this.GerenciadorDicionarioToken_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GcTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GcTokens;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvTokens;
        private System.Windows.Forms.BindingSource tokenBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colSimbolo;
    }
}