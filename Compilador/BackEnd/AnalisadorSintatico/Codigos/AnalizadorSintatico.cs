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
		AnalizadorSemantico.Codigos.AnalizadorSemantico analizadorSemantico = new AnalizadorSemantico.Codigos.AnalizadorSemantico();

		public static List<NaoTerminal> ListNaoTerminais { get; set; }
		public static List<Terminal> ListTerminais { get; set; }
		public static List<Item> ListParsing { get; set; }

		// Ir armazenando aqui as derivacoes usadas.
		public static List<string> ArvoreDerivacao = new List<string>();

		private Boolean Nivel1;


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

		private string TestarTipo(string elemento)
		{
			if (double.TryParse(elemento, out double verificacao))
			{
				return "INTEGER";
			}
			return "STRING";
		}

		private Boolean MontarTabelaSimbolos(List<TokenAtivo> TokenControle)
		{
			int Nivel = 0;
			if (Nivel1.Equals(true))
			{
				Nivel = 1;
			}

			// PROGRAM.
			if (TokenControle[0].token.Codigo.Equals(1))
			{
				analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[1].Buffer_ident, "ROTULO", "STRING", Nivel));
			}
			//CONSTANTE.
			else if (TokenControle[0].token.Codigo.Equals(3))
			{
				// Se for diferente de var. ainda estamos declarando constantes.
				int i = 0;
				while (!TokenControle[i].token.Codigo.Equals(4))
				{
					if (TokenControle[i].token.Codigo.Equals(25))
					{

						if (!analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[i].Buffer_ident, "CONSTANTE", TokenControle[i+2].token.Simbolo, Nivel)))
						{
							// Sinalizar erro.
							_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Variável ambigua encontrada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
							return false;
						}
					}
					i++;
				}
			}
			// VAR.
			else if (TokenControle[0].token.Codigo.Equals(4))
			{
				int i = 1;
				List<string> identificadores = new List<string>();
				while (TokenControle[i].token.Simbolo != ":")
				{
					if (TokenControle[i].token.Codigo.Equals(25))
					{
						// Salvar o identificador, em uma lista para verificar o tipo posteriormente.
						identificadores.Add(TokenControle[i].Buffer_ident);
						//analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[i].Buffer_ident, "IDENTIFICADOR", "STRING", 1));

					}
					i++;
				}

				// proximo do i e o tipo de dados das declaracoes.
				for (int x = 0; x < identificadores.Count; x++)
				{

					if (!analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(identificadores[x], "VARIAVEL", TokenControle[i + 1].token.Simbolo, Nivel)))
					{ 
						// Sinalizar erro.
						_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Variável ambigua encontrada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
						return false;
					}
				}
			}
			// PROCEDURE.
			else if (TokenControle[0].token.Codigo.Equals(5))
			{
				Nivel1 = true;
				// Salvar nome da procedure.
				analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[1].Buffer_ident, "PROCEDURE", "STRING", 0));

				// Verificar existenica de parametros.
				int i = 3;
				List<string> identificadores = new List<string>();
				while (TokenControle[i].token.Simbolo!=":")
				{
					if (TokenControle[i].token.Codigo.Equals(25))
					{
						// Salvar o identificador, em uma lista para verificar o tipo posteriormente.
						identificadores.Add(TokenControle[i].Buffer_ident);
						//analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[i].Buffer_ident, "IDENTIFICADOR", "STRING", 1));

					}
					i++;
				}

				// proximo do i e o tipo de dados das declaracoes.
				for (int x=0;x<identificadores.Count;x++)
				{
					if(!analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(identificadores[x], "PARAMETRO", TokenControle[i+1].token.Simbolo, 1)))
					{
						// Sinalizar erro.
						_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Variável ambigua encontrada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
						return false;
					}
				}

			}
			// Controle limpeza de niveis 1.
			else if (TokenControle[0].token.Codigo.Equals(7))
			{
				analizadorSemantico.Deletar();
				Nivel1 = false;
			}
			// Atribuicao de variaveis. -- aqui que verifica o tipo da variavel na atribuição
			else if (TokenControle[0].token.Codigo.Equals(25) && TokenControle[0].token.Codigo.Equals(38))
			{
				if (analizadorSemantico.Busca(TokenControle[0].Buffer_ident, Nivel))
				{
					// Verificar o tipo doque esta sendo atribuido para verificar legalidade da operacao.
					if(analizadorSemantico.VerificarTipo(TokenControle[0].Buffer_ident, TokenControle[0].Buffer_ident))
					{
						_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Atribuição de tipo incorreta.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
						return false;
					}
				}
				else
				{
					// Sinalizar erro.
					_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Atribuição de variável não declarada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
					return false;
				}
			}


			#region --- COMEMNTADO ---
			// Para nomes de funcoes.
			/*if (TokenControle[1].token.Simbolo.Equals(";"))
			{
				// Provavel nome de function, ou rotulo.
				analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[0].Buffer_ident, "ROTULO", "FUNCTION", 0));
			}*/

			// Tratamento das declaracoes de contantes.
			/*if (TokenControle[0].token.Simbolo.Equals("CONST"))
			{
				// Parei de implementar aqui.
			}

			// Identifica as declaracoes de variaveis inclusive aninhadas.
			if (TokenControle[0].token.Simbolo.Equals("VAR"))
			{
				int i = 0;
				while (!TokenControle[i].token.Simbolo.Equals("INTEGER"))
				{

                    //tava tentando achar algum lugar pra definir o nivel, obviamente não é aqui
                    if (TokenControle[i].token.Simbolo.Equals("PROCEDURE"))
                    {
                        Nivel = 1;
                    }


                    if (TokenControle[i].token.Simbolo.Equals("END") && TokenControle[i+1].token.Simbolo.Equals(";"))
                    {
                        Nivel = 0;
                    }

                    if (TokenControle[i].token.Simbolo.Equals("IDENTIFICADOR"))
					{
						if (!analizadorSemantico.Inserir(new AnalizadorSemantico.Auxiliar.TabelaSimbolos(TokenControle[i].Buffer_ident, "VARIAVEL", "INTEIRO", Nivel)))
						{
							_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Variável declarada duplicada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
							return false;
						}
					}
					i++;
				}
			}

			// Tratar quando e uma atribuicao.
			if (TokenControle[1].token.Simbolo.Equals(":="))
			{
				// Verificar primeiro se o identificador foi declarado.
				// Verificar se o tipo de dados que se esta atribuindo e valido com o tipo declarado.
				if (analizadorSemantico.Busca(TokenControle[0].Buffer_ident))
				{
					// Simbolo presente na tabela.
					// Verificar tipagem.
					if (double.TryParse(TokenControle[2].Buffer_ident, out double verificacao))
					{
						// Inteiro.
						if(!analizadorSemantico.VerificarTipo(TokenControle[0].Buffer_ident, "INTEIRO"))
						{
							_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Atribuição de valor ilegal para variavel inteira.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
							return false;

						}
					}
					else
					{

					}
				}
				else
				{
					_frmInicio.EscreverSaida("ERROS ENCONTRADOS >> Atribuição de variavel não declarada.  | linha: " + TokenController.PilhaTokenPrincipal[0].Linha);
					return false;
				}
			}*/
			#endregion
			// Sucesso apos todas as leituras.
			return true;
			// Verificar Atribuicoes de valores as variaveis.

		}

        public void RunAnalizadorSintatico()
        {


            MontagemTabelaNaoTerminais();
            MontagemTabelaTerminais();
            MontagemTabelaParsing();

            NaoTerminal _retorno = RetornarCodigoNaoTerminal("PROGRAMA");
            Item item = VerificarPilhaParsingPorCodigo(_retorno.Codigo + "," + "1");
            CarregarArvoreDerivacao(item);
			string arvoreDerivacaoUnida;


			while (ArvoreDerivacao.Count > 0 && TokenController.PilhaTokenPrincipal.Count > 0)
            {
                if (VerificaTerminal(ArvoreDerivacao[0]))
                {
                    if (ArvoreDerivacao[0].Equals(TokenController.PilhaTokenPrincipal[0].token.Simbolo))
                    {
                        arvoreDerivacaoUnida = string.Join("|", ArvoreDerivacao);
                        _frmInicio.EscreverGrid(Convert.ToString(TokenController.PilhaTokenPrincipal[0].Linha), ArvoreDerivacao[0], arvoreDerivacaoUnida);

						// Rodar analizador semantico.
						// Sempre que for um Identificador, Constante, Procedure
						if (TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(4) || TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(5) || TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(1) || TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(3) || TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(25) && TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(38) || TokenController.PilhaTokenPrincipal[0].token.Codigo.Equals(7))
						{
							if (!MontarTabelaSimbolos(TokenController.PilhaTokenPrincipal))
							{
								break;
							}
						}

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
          
                    //string teste = RetornaTerminal(item.Codigo);

                    if (VerificarPilhaParsingPorCodigoBool(Convert.ToString(_retorno.Codigo + "," + TokenController.PilhaTokenPrincipal[0].token.Codigo)))
                    {
                         arvoreDerivacaoUnida = string.Join("|", ArvoreDerivacao);
                        _frmInicio.EscreverGrid(Convert.ToString(TokenController.PilhaTokenPrincipal[0].Linha), ArvoreDerivacao[0], arvoreDerivacaoUnida);
                        ArvoreDerivacao.RemoveAt(0);
                        CarregarArvoreDerivacao(VerificarPilhaParsingPorCodigo(Convert.ToString(_retorno.Codigo + "," + TokenController.PilhaTokenPrincipal[0].token.Codigo)));
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
                    if (itens[i] != "NULL")
                    {
                        ArvoreDerivacao.Insert(i,itens[i]);
                    }
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
				//parsing = ListParsing[i].Codigo.Split(',');
				if (ListParsing[i].Codigo == codigo)
				{
                    return ListParsing[i];
				}
			}
			return null;
		}

        private bool VerificarPilhaParsingPorCodigoBool(string codigo)
        {
            for (int i = 0; i < ListParsing.Count; i++)
            {
                //parsing = ListParsing[i].Codigo.Split(',');
                if (ListParsing[i].Codigo == codigo)
                {
                    return true;
                }
            }
            return false;
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
