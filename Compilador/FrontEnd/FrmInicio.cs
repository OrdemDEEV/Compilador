using Compilador.BackEnd.AnalizadorLexico.DicionarioTokens;
using Compilador.FrontEnd.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            tokenController.IniciarDicionarioTokens();
        }

        private void gerenciarDicionarioDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciadorDicionarioToken gerToken = new GerenciadorDicionarioToken();
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

			/*if (!string.IsNullOrEmpty(arquivo))
			{
				ClnArquivo clArquivo = new ClnArquivo();
				List<Leitura> retorno = clArquivo.LerTexto(arquivo);

				for (int i = 0; i < retorno.Count; i++)
				{
					TxtTextoLido.Text += retorno[i].Tipo + " " + retorno[i].Texto + " | ";
				}
			}
			else
			{
				MessageBox.Show("Arquivop Invalido", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}*/
		}
	}
}
