using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorLexico.DicionarioTokens
{
	class TokenAtivo
	{
		public int Codigo { get; private set; }
		public string Car { get; private set; }
		public int valor { get; private set; }
		public bool buffer	{ get; private set; }
	}
}
