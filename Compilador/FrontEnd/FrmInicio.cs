using Compilador.BackEnd.AnalizadorLexico.Auxiliar;
using Compilador.BackEnd.AnalizadorLexico.DicionarioTokens;
using Compilador.FrontEnd.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador.FrontEnd
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            TokenController tokenController = new TokenController();
			//tokenController.IniciarDicionarioTokens();
			tokenController.IniciarDicionarioTokensComExcel();
		}

		#region --- CONTROLE GRID VIEW TOKENS ---

		private void dgvDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if ((DgvPilhaPrincipal.Rows[e.RowIndex].DataBoundItem != null) && (DgvPilhaPrincipal.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
			{
				e.Value = BindProperty(DgvPilhaPrincipal.Rows[e.RowIndex].DataBoundItem, DgvPilhaPrincipal.Columns[e.ColumnIndex].DataPropertyName);
			}
		}

		private string BindProperty(object property, string propertyName)
		{
			string retValue = "";
			if (propertyName.Contains("."))
			{
				PropertyInfo[] arrayProperties;
				string leftPropertyName;
				leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
				arrayProperties = property.GetType().GetProperties();
				foreach (PropertyInfo propertyInfo in arrayProperties)
				{
					if (propertyInfo.Name == leftPropertyName)
					{
						retValue = BindProperty(
						  propertyInfo.GetValue(property, null),
						  propertyName.Substring(propertyName.IndexOf(".") + 1));
						break;
					}
				}
			}
			else
			{
				Type propertyType;
				PropertyInfo propertyInfo;
				propertyType = property.GetType();
				propertyInfo = propertyType.GetProperty(propertyName);
				retValue = propertyInfo.GetValue(property, null).ToString();
			}
			return retValue;
		}

		private void CarregarGridViewTokensAtivos()
		{
			DgvPilhaPrincipal.DataSource = TokenController.PilhaTokenPrincipal;
			DgvPilhaPrincipal.Refresh();
		}

		#endregion

		private void gerenciarDicionarioDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGerenciadorDicionarioTokens1 gerToken = new FrmGerenciadorDicionarioTokens1();
            gerToken.Show();
        }

		private void BtnAbrir_Click(object sender, EventArgs e)
		{
			string arquivo = "";
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "Procurar";
				openFileDialog.InitialDirectory = @"c:\Program Files"; //Se ja quiser em abrir 

				openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
					arquivo = openFileDialog.FileName;
			}

			if (!string.IsNullOrEmpty(arquivo))
			{
				// Armazena no campo para leitura psterior.
				TxtCaminhoArquivo.Text = arquivo;

				ClnArquivo clArquivo = new ClnArquivo();
				List<string> retorno = clArquivo.LerArquivo(arquivo);

				for (int i = 0; i < retorno.Count; i++)
				{
					TxtEditorTexto.Text += retorno[i] + "\n";
				}
			}
			else
			{
				MessageBox.Show("Arquivop Invalido", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnRodarAnalizadorLexico_Click(object sender, EventArgs e)
		{
			ClnArquivo clArquivo = new ClnArquivo();
			List<string> LinhaLidas = clArquivo.LerArquivo(TxtCaminhoArquivo.Text);

			TokenController tokenController = new TokenController();
			tokenController.MontagemPilha(LinhaLidas);

			CarregarGridViewTokensAtivos();
		}

		private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog teste = new FolderBrowserDialog();
			teste.ShowDialog();
			string Caminho = teste.SelectedPath;

			Escrevertexto(TxtEditorTexto.Text, Caminho);
		}

		public void Escrevertexto(string texto, string caminho)
		{
			string[] linhas = { "teste" };
			linhas[0] = texto;

			using (System.IO.StreamWriter arquivo = new System.IO.StreamWriter(@caminho + "\\Arquivo.txt"))
			{
				foreach (string linha in linhas)
				{
					arquivo.WriteLine(linha);
				}
			}
		}

	}
}
