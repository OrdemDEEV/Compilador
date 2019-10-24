using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos
{
	public class gramatica
	{
		public List<terminal> terminais { get; set; }
		public List<naoTerminal> naoTerminais { get; set; }
	}
}
