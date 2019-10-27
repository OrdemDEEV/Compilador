using Compilador.BackEnd.AnalisadorSintatico.Codigos;
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
	public partial class FrmlGerenciadorTabelaParsing : Form
	{
		public FrmlGerenciadorTabelaParsing()
		{
			InitializeComponent();
		}

		private void FrmlGerenciadorTabelaParsing_Load(object sender, EventArgs e)
		{
			CarregarGridView();
		}

		private void CarregarGridView()
		{
			DgvTabelaParsing.DataSource = AnalizadorSintatico.ListParsing;
			DgvTabelaParsing.Refresh();
		}

	}
}
