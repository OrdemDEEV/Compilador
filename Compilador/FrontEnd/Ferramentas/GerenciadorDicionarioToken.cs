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
    public partial class GerenciadorDicionarioToken : Form
    {
        public GerenciadorDicionarioToken()
        {
            InitializeComponent();
        }

        private void GerenciadorDicionarioToken_Load(object sender, EventArgs e)
        {
            CarregarGridTokens();
        }

        private void CarregarGridTokens()
        {
            try
            {
                GcTokens.DataSource =  TokenController.ListaTokens;
                GcTokens.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
