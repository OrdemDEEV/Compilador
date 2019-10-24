using Compilador.BackEnd.AnalizadorLexico.DicionarioTokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador.FrontEnd.Ferramentas
{
	public partial class FrmGerenciadorDicionarioTokens1 : Form
	{
		public FrmGerenciadorDicionarioTokens1()
		{
			InitializeComponent();
		}

		private void FrmGerenciadorDicionarioTokens1_Load(object sender, EventArgs e)
		{
			DgvTeste.DataSource = TokenController.ListaTokens;
			DgvTeste.Refresh();

            dgvParsing.DataSource = TokenController.CatalogoParsing;
            dgvParsing.Refresh();
		}


    }
}
