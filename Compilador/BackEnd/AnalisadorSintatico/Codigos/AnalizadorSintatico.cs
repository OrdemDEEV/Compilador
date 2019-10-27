using Compilador.BackEnd.AnalisadorSintatico.Auxiliar;
using Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos;
using Compilador.BackEnd.AnalizadorLexico.DicionarioTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalisadorSintatico.Codigos
{
	class AnalizadorSintatico
	{
		XmlHelper xmlHelper = new XmlHelper();

		public static List<NaoTerminal> ListNaoTerminais { get; set; }
		public static List<Terminal> ListTerminais { get; set; }
		public static List<Item> ListParsing { get; set; }

		#region --- MONTAGEM DE TABELAS E LISTAS ---

		public void MontagemTabelaNaoTerminais()
		{
			ListNaoTerminais = xmlHelper.RetornaNaoTerminais();
		}

		// Nao sei se isso ainda e necessario.
		public void MontagemTabelaTerminais()
		{
			ListTerminais = xmlHelper.RetornaTerminais();
		}    

		public void MontagemTabelaParsing()
		{
			ListParsing = xmlHelper.RetornarListParsing();
		}

		#endregion


		#region --- EXECUCAO DO AUTOMATO DE ANALISE SINTATICA ---

		public TokenAtivo Proximo { get; set; }
		public int i { get; set; }

		public void RodarAnalizadoSintatico()
		{
			// CRIAR O ANALIZADO LEXICO AQUI SOMENTE NESTA CLASSE POR FAVOR.
			MontagemTabelaNaoTerminais();
			//MontagemTabelaTerminais();
			MontagemTabelaParsing();

			// Colocar no Proximo o proximo da pilha.

			#region --- EXECUCAO DO AUTOMATO ---

			// Colocar em proximo o simbolo $ e o incial da gramatica PROGRAM
			while (!TokenController.PilhaTokenPrincipal.Equals("$"))
			{
				// Encontrar proximo elemento analizado.
				Proximo = TokenController.PilhaTokenPrincipal[i + 1];

				// Verificar se o elemento e um terminal ou o simbolo final.
				if (VerificaTerminal(TokenController.PilhaTokenPrincipal[i]))
				{
					if (TokenController.PilhaTokenPrincipal[i].Equals(Proximo))
					{
						TokenController.PilhaTokenPrincipal.RemoveAt(i);
						Proximo = null;
					}
					else
					{
						// Carecteriza erro.
						// Colocar na saida.
					}
				}
				else
				{

				}

				i++;
			}

			#endregion

		}

		private bool VerficaNaoTerminal(NaoTerminal naoTerminal)
		{
			if (ListNaoTerminais.Contains(naoTerminal))
			{
				return true;
			}
			return false;
		}

		private bool VerificaTerminal(Terminal terminal)
		{
			if (ListTerminais.Contains(terminal))
			{
				return true;
			}
			return false;
		}

		#endregion

	}
}
