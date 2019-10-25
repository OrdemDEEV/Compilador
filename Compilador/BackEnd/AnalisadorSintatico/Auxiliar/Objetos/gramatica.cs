using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos
{
		[XmlRoot(ElementName = "terminal")]
		public class Terminal
		{
			[XmlAttribute(AttributeName = "codigo")]
			public string Codigo { get; set; }
			[XmlAttribute(AttributeName = "simbolo")]
			public string Simbolo { get; set; }
		}

		[XmlRoot(ElementName = "terminais")]
		public class Terminais
		{
			[XmlElement(ElementName = "terminal")]
			public List<Terminal> Terminal { get; set; }
		}

		[XmlRoot(ElementName = "naoTerminal")]
		public class NaoTerminal
		{
			[XmlAttribute(AttributeName = "codigo")]
			public string Codigo { get; set; }
			[XmlAttribute(AttributeName = "simbolo")]
			public string Simbolo { get; set; }
		}

		[XmlRoot(ElementName = "naoTerminais")]
		public class NaoTerminais
		{
			[XmlElement(ElementName = "naoTerminal")]
			public List<NaoTerminal> NaoTerminal { get; set; }
		}

		[XmlRoot(ElementName = "gramatica")]
		public class Gramatica
		{
			[XmlElement(ElementName = "terminais")]
			public Terminais Terminais { get; set; }
			[XmlElement(ElementName = "naoTerminais")]
			public NaoTerminais NaoTerminais { get; set; }
		}
}
