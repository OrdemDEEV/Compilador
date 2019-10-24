using Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos;
using Compilador.BackEnd.AnalisadorSintatico.Codigos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar
{
	public class NaoTerminais
	{
		public int Codigo { get; set; }
		public string Simbolo { get; set; }

		string CaminhoXml = "C:\\Users\\User\\Desktop\\Projetos\\Compilador\\gramatica.xml";

		public void MontarTabelaNaoTerminais()
		{
			/*XElement xml = XElement.Load("C:\\Users\\User\\Desktop\\Projetos\\Compilador\\gramatica.xml");
			foreach (XElement x in xml.Elements())
			{
				NaoTerminais naoterminal = new NaoTerminais();
				//naoterminal.Codigo = Convert.ToInt32(x.Attribute("codigo"));
				//naoterminal.Simbolo = x.Attribute("simbolo").ToString();
				Simbolo = (string)x.Attribute("simbolo");
				AnalizadorSintatico.NaoTerminaisList.Add(naoterminal);
			}*/

			LerXml();
		}

		// Falhou
		private gramatica LerXml()
		{
			try
			{
				FileStream stream = new FileStream(CaminhoXml, FileMode.Open);
				XmlSerializer deserealizador = new XmlSerializer(typeof(gramatica));
				gramatica gramatica = (gramatica)deserealizador.Deserialize(stream);
				return gramatica;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

	}
}
