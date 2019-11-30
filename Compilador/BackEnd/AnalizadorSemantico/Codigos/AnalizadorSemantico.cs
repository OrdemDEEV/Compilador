using Compilador.BackEnd.AnalizadorSemantico.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador.BackEnd.AnalizadorSemantico.Codigos
{
	class AnalizadorSemantico
	{

		public static List<TabelaSimbolos> ListTabekaSimbolos = new List<TabelaSimbolos>();

		public Boolean Busca(TabelaSimbolos tabelaSimb)
		{
			for (int i=0;i< ListTabekaSimbolos.Count;i++)
			{
				if (ListTabekaSimbolos[i].Nome.Equals(tabelaSimb.Nome))
				{
					return true;
				}
			}
			return false;
			//return ListTabekaSimbolos.Contains(tabelaSimb);
		}

		public Boolean Inserir(TabelaSimbolos tabelaSimb)
		{
			// Falta fazer a parte das verificacoes.
			if (Busca(tabelaSimb).Equals(false))
			{
				ListTabekaSimbolos.Add(tabelaSimb);
				return true;
			}
			else
			{
				//MessageBox.Show("Identificador Já declarado.");
				return false;
			}
		}

		public void Deletar()
		{

		}

	}
}
