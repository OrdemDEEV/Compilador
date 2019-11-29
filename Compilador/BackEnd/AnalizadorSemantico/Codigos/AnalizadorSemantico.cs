using Compilador.BackEnd.AnalizadorSemantico.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorSemantico.Codigos
{
	class AnalizadorSemantico
	{

		public static List<TabelaSimbolos> ListTabekaSimbolos = new List<TabelaSimbolos>();

		public void Busca()
		{

		}

		public void Inserir(TabelaSimbolos tabelaSimb)
		{
			// Falta fazer a parte das verificacoes.
			ListTabekaSimbolos.Add(tabelaSimb);
		}

		public void Deletar()
		{

		}

	}
}
