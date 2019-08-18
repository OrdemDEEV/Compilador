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
    }
}
