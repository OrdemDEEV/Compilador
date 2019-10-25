using System.Collections.Generic;
using System.Xml.Serialization;

namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos
{

		[XmlRoot(ElementName = "item")]
		public class Item
		{
			[XmlAttribute(AttributeName = "codigo")]
			public string Codigo { get; set; }
			[XmlAttribute(AttributeName = "derivacao")]
			public string Derivacao { get; set; }
		}

		[XmlRoot(ElementName = "tabelaParsing")]
		public class TabelaParsing
		{
			[XmlElement(ElementName = "item")]
			public List<Item> Item { get; set; }
		}
	
}
