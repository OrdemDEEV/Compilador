using Compilador.BackEnd.AnalisadorSintatico.Auxiliar;
using Compilador.BackEnd.AnalisadorSintatico.Auxiliar.Objetos;
using Compilador.BackEnd.AnalizadorLexico.DicionarioTokens;
using Compilador.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalisadorSintatico.Codigos
{
	class AnalizadorSintatico
	{
		FrmInicio _frmInicio;
		XmlHelper xmlHelper = new XmlHelper();

		public static List<NaoTerminal> ListNaoTerminais { get; set; }
		public static List<Terminal> ListTerminais { get; set; }
		public static List<Item> ListParsing { get; set; }

		// Ir armazenando aqui as derivacoes usadas.
		public static List<string> ArvoreDerivacao = new List<string>();


		#region --- CONSTRUTORES ---

		public AnalizadorSintatico()
		{

		}

		public AnalizadorSintatico(FrmInicio _form)
		{
			_frmInicio = _form;
		}

		#endregion

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


        public void RunAnalizadorSintatico()
        {
            MontagemTabelaNaoTerminais();
            MontagemTabelaTerminais();
            MontagemTabelaParsing();

            NaoTerminal _retorno = RetornarCodigoNaoTerminal("PROGRAMA");
            Item item = VerificarPilhaParsingPorCodigo(_retorno.Codigo);
            CarregarArvoreDerivacao(item);

            while (ArvoreDerivacao.Count > 0)
            {
                if (VerificaTerminal(ArvoreDerivacao[0]))
                {
                    if (ArvoreDerivacao[0].Equals(TokenController.PilhaTokenPrincipal[0].token.Simbolo))
                    {
                        TokenController.PilhaTokenPrincipal.RemoveAt(0);
                        ArvoreDerivacao.RemoveAt(0);
                    }
                    else
                    {
                        _frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Simbolo incial incorreto  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
                        break;
                    }
                }
                else
                {
                    _retorno = RetornarCodigoNaoTerminal(ArvoreDerivacao[0]);
                    item = VerificarPilhaParsingPorCodigo(_retorno.Codigo);

                    string teste = RetornaTerminal(item.Codigo);

                    if (teste == ArvoreDerivacao[0])
                    {
                        ArvoreDerivacao.RemoveAt(0);
                        CarregarArvoreDerivacao(item);
                    }
                    else
                    {
                        _frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Simbolo incial incorreto  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
                        break;
                    }
                }
            }
        }


        public TokenAtivo Proximo { get; set; }

		public void RodarAnalizadoSintatico()
		{
			int i = 0;
			// CRIAR O ANALIZADO LEXICO AQUI SOMENTE NESTA CLASSE POR FAVOR.
			MontagemTabelaNaoTerminais();
			MontagemTabelaTerminais();
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


				// ir percorrendo lista, verificando se esta na tabela de parsing.
				// se estiver mandar pear o retorno e procurar na tabela de nao terminais.
				// pegar o codigo do nao terminal encontrado e mandar par tabela de parsing.
				// assim encontramos a proxima linha de derivacao.

				// verificamos se o item esta na tabela de parsing.
				Item _item = null;
				if (i.Equals(0))
				{
					if (TokenController.PilhaTokenPrincipal[i].token.Simbolo.Equals("PROGRAM"))
					{
						_item = VerificarPilhaParsing(TokenController.PilhaTokenPrincipal[i].token.Simbolo);
						CarregarArvoreDerivacao(_item);

						TokenController.PilhaTokenPrincipal.RemoveAt(i);
						ArvoreDerivacao.RemoveAt(i);
                        _frmInicio.EscreverGrid(Convert.ToString(TokenController.PilhaTokenPrincipal[i].Linha) , Convert.ToString(_item.Codigo) , Convert.ToString(_item.Derivacao));
                    }
					else
					{
						_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Simbolo incial incorreto  | linha: " + TokenController.PilhaTokenPrincipal[i].Linha);
						break;
					}
				}
				else
				{


					// Primeiro precisa ver se eum terminal.
					if (VerificaTerminal(TokenController.PilhaTokenPrincipal[0].token.Simbolo))
					{
						if (TokenController.PilhaTokenPrincipal[0].token.Simbolo.Equals(ArvoreDerivacao[0]))
						{
							// terminal
							TokenController.PilhaTokenPrincipal.RemoveAt(0);
							ArvoreDerivacao.RemoveAt(0);
						}
						else if(RetornarCodigoNaoTerminal(ArvoreDerivacao[0]) != null)
						{
							// Proximo da arvore e nao terminal.
							// Buscar por esse nao terminal, no parsing.
							// Enquanto o termo mais a esquerda for um nao terminal vai derivando.
							while (RetornarCodigoNaoTerminal(ArvoreDerivacao[0]) != null)
							{
								NaoTerminal _chaveNaoTerminal = RetornarCodigoNaoTerminal(ArvoreDerivacao[0]);
								Item _itemRetornado = VerificarPilhaParsingPorCodigo(_chaveNaoTerminal.Codigo);

								// pegar recursao mais a esquerda.
								string _recursaoEsquerda = _itemRetornado.Derivacao.Split('|')[0] ;

								if (TokenController.PilhaTokenPrincipal[0].token.Simbolo.Equals(_recursaoEsquerda))
								{
									ArvoreDerivacao.RemoveAt(0);
									CarregarArvoreDerivacao(_itemRetornado);
                                    _frmInicio.EscreverGrid(Convert.ToString(TokenController.PilhaTokenPrincipal[i].Linha), Convert.ToString(_itemRetornado.Codigo), Convert.ToString(_itemRetornado.Derivacao));
                                }
                                else
								{
									ArvoreDerivacao.RemoveAt(0);
									ArvoreDerivacao.Insert(0, _recursaoEsquerda);
                                    _frmInicio.EscreverGrid(Convert.ToString(TokenController.PilhaTokenPrincipal[i].Linha), "0", Convert.ToString(_recursaoEsquerda));

                                }
                            }
						}
						else
						{
							_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Simbolo invalido conforme gramatica  | linha: " + TokenController.PilhaTokenPrincipal[i].Linha);
							break;
						}
					}
					else
					{
						// nao terminal.
						// pode ser um nao terminal.
						// Encontrar o nao terminal em questao.
						NaoTerminal _chaveNaoTerminal = RetornarCodigoNaoTerminal(ArvoreDerivacao[i]);

						if (_chaveNaoTerminal != null)
						{
							Item _itemRetornado = VerificarPilhaParsingPorCodigo(_chaveNaoTerminal.Codigo);
							CarregarArvoreDerivacao(_itemRetornado);
						}
						else
						{
							_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Simbolo invalido conforme gramatica  | linha: " + TokenController.PilhaTokenPrincipal[i].Linha);
							break;
						}
						
					}
				}

				i++;
			}

			#endregion

		}

		// Carrega Item na arvore de derivacao.
		private bool CarregarArvoreDerivacao(Item _item)
		{
			try
			{
				string[] itens = _item.Derivacao.Split('|');

				for (int i=0;i<itens.Length;i++)
				{
					ArvoreDerivacao.Insert(i,itens[i]);
				}
				return true;
			}
			catch (Exception ex)
			{
				// caso de algum erro interno, parar a analise.
				return false;
			}
			
		}

        // Retorna Descricao do terminal pelo codigo.
        private string RetornaTerminal(string Codigos)
        {
            string CodTerminal = Codigos.Split(',')[1];

            for (int i=0;i<ListTerminais.Count;i++)
            {
                if (ListTerminais[i].Codigo == CodTerminal)
                {
                    return ListTerminais[i].Simbolo;
                }
            }
            return null;
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
				if (ListParsing[i].Derivacao != "NULL" && parsing.Contains(codigo))
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

		private bool VerificaTerminal(string simbolo)
		{
			for (int i=0;i< ListTerminais.Count;i++)
			{
				if (ListTerminais[i].Simbolo.Equals(simbolo))
				{
					return true;
				}
			}
			return false;
		}

		#endregion

	}
}
