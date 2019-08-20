using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorLexico.DicionarioTokens
{
	class TokenAtivo
	{
		public TokenAtivo(Token token, int linha, string car, int valor, string buffer_ident, string buffer_literal)
		{
			this.token = token;
			Linha = linha;
			Car = car;
			Valor = valor;
			Buffer_ident = buffer_ident;
			Buffer_literal = buffer_literal;
		}

		public Token token { get; private set; }
		public int Linha { get; private set; }
		public string Car { get; private set; }
		public int Valor { get; private set; }
		public string Buffer_ident	{ get; private set; }
		public string Buffer_literal { get; private set; }
	}
}
