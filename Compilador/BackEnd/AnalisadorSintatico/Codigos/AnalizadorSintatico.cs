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

		// Ir armazenando aqui as derivacoes usadas.
		public static List<string> ArvoreDerivacao { get; set; }

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

		public void RodarAnalizadoSintatico()
		{
			int i = 0;
			// CRIAR O ANALIZADO LEXICO AQUI SOMENTE NESTA CLASSE POR FAVOR.
			//MontagemTabelaNaoTerminais();
			//MontagemTabelaTerminais();
			MontagemTabelaParsing();

			// Colocar no Proximo o proximo da pilha.

			#region --- EXECUCAO DO AUTOMATO ---

			// Colocar em proximo o simbolo $ e o incial da gramatica PROGRAM
			while (TokenController.PilhaTokenPrincipal.Count > 0)
			{
				// Encontrar proximo elemento analizado.
				//Proximo = TokenController.PilhaTokenPrincipal[i + 1];

				// Verificar se o elemento e um terminal ou o simbolo final.
				/*if (VerificaTerminal(TokenController.PilhaTokenPrincipal[i]))
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

				}*/

				// Algoritimo proprio.

				VerificarPilhaParsing(TokenController.PilhaTokenPrincipal[i].token.Simbolo);

				i++;
			}

			#endregion

		}

		// Encontra Codigo nao terminal.
		private NaoTerminal RetornarCodigoNaoTerminal(string simbolo)
		{
			for (int i=0;i<ListNaoTerminais.Count;i++)
			{
				if (ListNaoTerminais[i].Simbolo.Equals(simbolo))
				{
					return ListNaoTerminais[i];
				}
			}
			return null;
		}

		//ENCONTRA PARSING POR CODIGO.
		private Item VerificarPilhaParsingPorCodigo(string codigo)
		{
			string[] parsing;
			for (int i = 0; i < ListParsing.Count; i++)
			{
				parsing = ListParsing[i].Codigo.Split(',');
				if (parsing.Contains(codigo))
				{
					return ListParsing[i];
				}
			}
			return null;
		}

		// ENCONTRA PARSING POR DESCRICAO.
		private Item VerificarPilhaParsing(string derivacao)
		{
			string[] parsing;
			for (int i=0;i<ListParsing.Count;i++)
			{
				parsing = ListParsing[i].Derivacao.Split('|');
				if (parsing.Contains(derivacao)) 
				{
					return ListParsing[i];
				}
			}
			return null;
		}

		private bool VerficaNaoTerminal(NaoTerminal naoTerminal)
		{
			if (ListNaoTerminais.Contains(naoTerminal))
			{
				return true;
			}
			return false;
		}

		private bool VerificaTerminal(TokenAtivo terminal)
		{
			for (int i=0;i< ListTerminais.Count;i++)
			{
				if (ListTerminais[i].Simbolo.Equals(terminal.Valor))
				{
					return true;
				}
			}
			return false;
		}

		#endregion

	}
}
