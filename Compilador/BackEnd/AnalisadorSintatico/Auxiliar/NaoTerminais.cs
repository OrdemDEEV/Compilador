using Compilador.BackEnd.AnalisadorSintatico.Codigos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar
{
	class NaoTerminais
	{
		public int Codigo { get; set; }
		public string Simbolo { get; set; }


		public void MontarTabelaNaoTerminais()
		{
			XElement xml = XElement.Load("C:\\Users\\User\\Desktop\\Projetos\\Compilador\\gramatica.xml");
			foreach (XElement x in xml.Elements())
			{
				NaoTerminais naoterminal = new NaoTerminais();
				//naoterminal.Codigo = Convert.ToInt32(x.Attribute("codigo"));
				//naoterminal.Simbolo = x.Attribute("simbolo").ToString();
				Simbolo = (string)x.Attribute("simbolo");
				AnalizadorSintatico.NaoTerminaisList.Add(naoterminal);
			}
		}

	}
}
