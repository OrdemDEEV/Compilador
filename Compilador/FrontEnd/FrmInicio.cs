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
using System.IO;
using Compilador.BackEnd.AnalisadorSintatico.Auxiliar;

namespace Compilador.FrontEnd
{

    public partial class FrmInicio : Form
    {
        public string LocalArquivo = "";    
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            TokenController tokenController = new TokenController();
			//tokenController.IniciarDicionarioTokens();
			tokenController.IniciarDicionarioTokens();


                LineNumberTextBox.Font = TxtEditorTexto.Font;
                TxtEditorTexto.Select();
                AddLineNumbers();

            TxtSaida.Text = "Saída >>";
        }

        private void FrmInicio_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

		#region ---- CONTROLE SAIDA ---

		public void EscreverSaida(string mensagem)
		{
			TxtSaida.Text += "\n"+ DateTime.Now.TimeOfDay + " >>  " + mensagem;
		}

		#endregion

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
            DgvPilhaPrincipal.DataSource = null;
            DgvPilhaPrincipal.DataSource = TokenController.PilhaTokenPrincipal;
			DgvPilhaPrincipal.Refresh();
		}

		#endregion

		private void gerenciarDicionarioDeDadosToolStripMenuItem_Click
			(object sender, EventArgs e)
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

				openFileDialog.Filter = "All files (*.*)|*.*|LMS File (*.lms*)|*.lms*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
					arquivo = openFileDialog.FileName;
			}

			if (!string.IsNullOrEmpty(arquivo))
			{
				// Armazena no campo para leitura psterior.
				LocalArquivo = arquivo;

				ClnArquivo clArquivo = new ClnArquivo();
				List<string> retorno = clArquivo.LerArquivo(arquivo);

                TxtEditorTexto.Text = "";

                for (int i = 0; i < retorno.Count; i++)
				{
					TxtEditorTexto.Text += retorno[i] + "\n";
				}
			}
			else
			{
				//MessageBox.Show("Arquivop Invalido", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnRodarAnalizadorLexico_Click(object sender, EventArgs e)
		{
			// Escreve na saida.
			EscreverSaida("Iniciada Execução do analizador lexico! ");

            if (LocalArquivo == "")
            {
             salvarToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(LocalArquivo,TxtEditorTexto.Text);
            }
			ClnArquivo clArquivo = new ClnArquivo();
			List<string> LinhaLidas = clArquivo.LerArquivo(LocalArquivo);

			TokenController tokenController = new TokenController(this); 
			tokenController.MontagemPilha(LinhaLidas);

			CarregarGridViewTokensAtivos();

			EscreverSaida("Finalizada Execução do analizador lexico! ");
		}

		private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
		{
   

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "LMS File (*.lms*)|*.lms*|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "lms";
            saveFileDialog1.AddExtension = true;


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                if (File.Exists(saveFileDialog1.FileName))
                {
                    File.Delete(saveFileDialog1.FileName);
                }
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    LocalArquivo = saveFileDialog1.FileName;
                    sw.Write(TxtEditorTexto.Text);
                }
            }
           
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


        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = TxtEditorTexto.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)TxtEditorTexto.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)TxtEditorTexto.Font.Size;
            }
            else
            {
                w = 50 + (int)TxtEditorTexto.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = TxtEditorTexto.GetCharIndexFromPosition(pt);
            int First_Line = TxtEditorTexto.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = TxtEditorTexto.GetCharIndexFromPosition(pt);
            int Last_Line = TxtEditorTexto.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberTextBox.Text = "";
            LineNumberTextBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void TxtEditorTexto_VScroll(object sender, EventArgs e)
        {
            LineNumberTextBox.Text = "";
            AddLineNumbers();
            LineNumberTextBox.Invalidate();
        }

        private void TxtEditorTexto_TextChanged(object sender, EventArgs e)
        {
            if (TxtEditorTexto.Text != "")
            {
                AddLineNumbers();
            }
        }

        private void TxtEditorTexto_FontChanged(object sender, EventArgs e)
        {
            LineNumberTextBox.Font = TxtEditorTexto.Font;
            TxtEditorTexto.Select();
            AddLineNumbers();
        }

        private void LineNumberTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            TxtEditorTexto.Select();
            LineNumberTextBox.DeselectAll();
        }

		private void rodarAnalizarSintáticoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NaoTerminais naoTerminais = new NaoTerminais();
			naoTerminais.MontarTabelaNaoTerminais();
			
		}
	}
}
