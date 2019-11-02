using Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Compilador.BackEnd.AnalisadorSintatico.Auxiliar
{
	class XmlHelper
	{

		// Caminho xml gramatica.
		string CaminhoXml = "BackEnd\\AnalisadorSintatico\\Auxiliar\\tabelaGramatica.xml";

		// Caminho xml tabela parsing.
		string CaminhoXmlParsing = "BackEnd\\AnalisadorSintatico\\Auxiliar\\tabelaParsing.xml";

		#region --- XML GRAMATICA ---

		// Leitura xml gramatica nao teminais.
		public List<NaoTerminal> RetornaNaoTerminais()
		{
			Gramatica gramatica = LerXml();
			return gramatica.NaoTerminais.NaoTerminal;
		}

		// Leitura xml terminais.
		public List<Terminal> RetornaTerminais()
		{
			Gramatica gramatica = LerXml();
			return gramatica.Terminais.Terminal;
		}

		// Leitura xml gramatica.
		private Gramatica LerXml()
		{
			try
			{
				FileStream stream = new FileStream(CaminhoXml, FileMode.Open);
				XmlSerializer deserealizador = new XmlSerializer(typeof(Gramatica));
				Gramatica gramatica = (Gramatica)deserealizador.Deserialize(stream);
				stream.Close();
				return gramatica;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		#endregion

		#region --- XML TABELA PARSING ---

		public List<Item> RetornarListParsing()
		{
			TabelaParsing tabelaParsing = LerXmlGramatica();
			return tabelaParsing.Item;
		}

		// Leitura xml tabela parsing.
		private TabelaParsing LerXmlGramatica()
		{
			try
			{
				FileStream stream = new FileStream(CaminhoXmlParsing, FileMode.Open);
				XmlSerializer deserealizador = new XmlSerializer(typeof(TabelaParsing));
				TabelaParsing tabelaParsing = (TabelaParsing)deserealizador.Deserialize(stream);
				return tabelaParsing;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		#endregion

	}
}
