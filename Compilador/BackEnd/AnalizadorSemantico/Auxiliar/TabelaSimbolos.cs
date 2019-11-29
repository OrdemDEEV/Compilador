using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorSemantico.Auxiliar
{
	class TabelaSimbolos
	{
		public TabelaSimbolos(string nome, string categoria, string tipo, int nivel)
		{
			Nome = nome;
			Categoria = categoria;
			Tipo = tipo;
			Nivel = nivel;
		}

		public string Nome { get; set; }
		public string Categoria { get; set; }
		public string Tipo { get; set; }
		public int Nivel { get; set; }
	}
}
