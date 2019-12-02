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

		public Boolean Busca(string simbolo, int Nivel)
		{
			for (int i=0;i< ListTabekaSimbolos.Count;i++)
			{
				if (ListTabekaSimbolos[i].Nome.Equals(simbolo) && ListTabekaSimbolos[i].Nivel.Equals(Nivel))
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
			if (Busca(tabelaSimb.Nome, tabelaSimb.Nivel).Equals(false))
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
			// Remover todos os elementos de nivel 1.
			for (int i = 0; i < ListTabekaSimbolos.Count; i++)
			{
				if (ListTabekaSimbolos[i].Nivel.Equals(1))
				{
					ListTabekaSimbolos.RemoveAt(i);
					i--;
				}
			}
		}

		public Boolean VerificarTipo(string simbolo, string tipo)
		{
			for (int i = 0; i < ListTabekaSimbolos.Count; i++)
			{
				if (ListTabekaSimbolos[i].Nome.Equals(simbolo) && ListTabekaSimbolos[i].Tipo.Equals(tipo))
				{
					// Encontrou elemento.
					return true;
				}
			}
			return false;
		}

	}
}
