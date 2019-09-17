using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador.BackEnd.AnalizadorLexico.DicionarioTokens
{


    class TokenController
    {

       

        public static List<TokenAtivo> PilhaTokenPrincipal = new List<TokenAtivo>();
		public static List<Token> ListaTokens = new List<Token>();
        public int valor = 0;
        public string buffer_ident = "";

        #region --- Excel ---

        /*
        private OleDbConnection _olecon;
		private OleDbCommand _oleCmd;
		private static String _Arquivo = @"C:\Users\User\Desktop\Projetos\Compilador\Compilador\BackEnd\AnalizadorLexico\DicionarioTokens\TabelaTokens.xlsx";
		private String _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
		private String _Consulta;
     
		public List<Token> IniciarDicionarioTokensComExcel()
		{
			// Conectar com excel.
			ConectarExcel();
			// Busca excel com dados da tabela.

			try
			{
				_oleCmd.CommandText = "SELECT COD, SIMBOLO FROM [fonte$] ";
				OleDbDataReader reader = _oleCmd.ExecuteReader();

				while (reader.Read())
				{
					// Monta os objetos do dicionario tokens.
					ListaTokens.Add(new Token(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString()));
				}

				reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro Fatal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// Retorna Lista.
			return ListaTokens;
		}
       
		#region --- CONTROLE CONEXAO ---

		private void ConectarExcel()
		{
			try
			{
				_olecon = new OleDbConnection(_StringConexao);
				_olecon.Open();

				_oleCmd = new OleDbCommand();
				_oleCmd.Connection = _olecon;
				_oleCmd.CommandType = CommandType.Text;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro Fatal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
         
        #endregion
    */
        #endregion

        #region --- MONTAGEM DICIONARIO DE DADOS ---

        public List<Token> IniciarDicionarioTokens()
        {

            ListaTokens.Add(new Token(1, "PROGRAM"));
            ListaTokens.Add(new Token(2, "LABEL"));
            ListaTokens.Add(new Token(3, "CONST"));
            ListaTokens.Add(new Token(4, "VAR"));
            ListaTokens.Add(new Token(5, "PROCEDURE"));
            ListaTokens.Add(new Token(6, "BEGIN"));
            ListaTokens.Add(new Token(7, "END"));
            ListaTokens.Add(new Token(8, "INTEGER"));
            ListaTokens.Add(new Token(9, "ARRAY"));
            ListaTokens.Add(new Token(10, "OF"));
            ListaTokens.Add(new Token(11, "CALL"));
            ListaTokens.Add(new Token(12, "GOTO"));
            ListaTokens.Add(new Token(13, "IF"));
            ListaTokens.Add(new Token(14, "THEN"));
            ListaTokens.Add(new Token(15, "ELSE"));
            ListaTokens.Add(new Token(16, "WHILE"));
            ListaTokens.Add(new Token(17, "DO"));
            ListaTokens.Add(new Token(18, "REPEAT"));
            ListaTokens.Add(new Token(19, "UNTIL"));
            ListaTokens.Add(new Token(20, "READLN"));
            ListaTokens.Add(new Token(21, "WRITELN"));
            ListaTokens.Add(new Token(22, "OR"));
            ListaTokens.Add(new Token(23, "AND"));
            ListaTokens.Add(new Token(24, "NOT"));
            ListaTokens.Add(new Token(25, "IDENTIFICADOR"));
            ListaTokens.Add(new Token(26, "INTEIRO"));
            ListaTokens.Add(new Token(27, "FOR"));
            ListaTokens.Add(new Token(28, "TO"));
            ListaTokens.Add(new Token(29, "CASE"));
            ListaTokens.Add(new Token(30, "+"));
            ListaTokens.Add(new Token(31, "-"));
            ListaTokens.Add(new Token(32, "*"));
            ListaTokens.Add(new Token(33, "/"));
            ListaTokens.Add(new Token(34, "["));
            ListaTokens.Add(new Token(35, "]"));
            ListaTokens.Add(new Token(36, "("));
            ListaTokens.Add(new Token(37, ")"));
            ListaTokens.Add(new Token(38, ":="));
            ListaTokens.Add(new Token(39, ":"));
            ListaTokens.Add(new Token(40, "="));
            ListaTokens.Add(new Token(41, ">"));
            ListaTokens.Add(new Token(42, ">="));
            ListaTokens.Add(new Token(43, "<"));
            ListaTokens.Add(new Token(44, "<="));
            ListaTokens.Add(new Token(45, "<>"));
            ListaTokens.Add(new Token(46, ","));
            ListaTokens.Add(new Token(47, ";"));
            ListaTokens.Add(new Token(48, "LITERAL"));
            ListaTokens.Add(new Token(49, "."));
            ListaTokens.Add(new Token(50, ".."));
            ListaTokens.Add(new Token(51, "$"));

            // Retorna Lista.
            return ListaTokens;
        }

        

        #endregion

        #region --- METODOS ANALIZADOR LEXICO ---


        private Token BuscarTokenNoDicionario(string variavel, int linha)
		{
          
            if (int.TryParse(variavel, out int verificacao))
            {
                valor = Convert.ToInt32(variavel);
				return new Token(26, "INTEIRO");
            }


            Token token = ListaTokens.Find(c => c.Simbolo.Equals(variavel));

            if (token != null)
			{
                return token;
            }


            if (variavel != "")
            {
                buffer_ident = variavel;
                return new Token(25, "IDENTIFICADOR");
            }

            return null;
        }

		
		public void MontagemPilha(List<string> Linhas)
		{
            PilhaTokenPrincipal.Clear();
            try
			{
				// Recebe as linhas brutas.
				char[] Caracteres;
				int j = 0;
				string concatenado = null;
				Token TokenEncontrado=  null;
                string buffer_literal = "";


				// Percorre as linhas brutas recebidas.
				for (int i = 0; i < Linhas.Count; i++)
				{
					// Quebra linha recebida em char para realizar tratamento.
					Caracteres = Linhas[i].ToCharArray();

					while (j < Caracteres.Length)
					{
						// Concatena
						concatenado += Caracteres[j];

                        #region --- IGNORAR ESPAÇOS ---
                        if (concatenado == " ")
                        {
                            j++;
                            concatenado = "";
                            continue;
                        }

                        if (concatenado == "\t")
                        {
                            j++;
                            concatenado = "";
                            continue;
                        }

                        #endregion

                        #region --- CONROLE COMENTARIOS ---
                        // Tratamento de comentarios.
                        if (Caracteres[j].Equals('(') && Caracteres[j + 1].Equals('*'))
						{
							while (TratarComentarios(Caracteres[j], Caracteres.Length == 1 ? 'a' : Caracteres[j+1]) != true)
							{
								j++;
								if (j.Equals(Caracteres.Length) | j.Equals(Caracteres.Length-1))
								{
									do
									{
										i++;
										Caracteres = Linhas[i].ToCharArray();
									}
									while (Caracteres.Length == 0);
									
									j = 0;
								}
							}
							concatenado = "";
							j++;
						}

                        #endregion

                        #region --- LITERAL ---

                        if (Caracteres[j].Equals('\''))
                        {
                            concatenado = "";
							j++;
                            while (!Caracteres[j].Equals('\''))
                            {
								if (concatenado.Length < 255)
								{
									concatenado += Caracteres[j];
									j++;
								}
								else
								{
									MessageBox.Show("Tamanho inválido de literal na linha: " + Convert.ToInt32(i + 1).ToString(), "Erro de compilação!", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}

							}

                            TokenEncontrado = BuscarTokenNoDicionario("LITERAL", i);
                            buffer_literal = concatenado;

							concatenado = "";

							goto SalvamentoDireto;
							
                        }

                        #endregion

                        // Switch pega os tokens dos caracteres especiais.
                        switch (concatenado)
						{
							case ",":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "+":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "-":
                                // Verificar aqui se o proximo e numero se for manda buscar la e retorna o inteiro e ignora o sinal.
                                Boolean TESTE = char.IsNumber(Caracteres[j + 1]);
                                Boolean OUTROTESTE = char.IsNumber(Caracteres[j - 1]);
                                if (Caracteres[j].Equals('-') && char.IsNumber(Caracteres[j+1]) && i == Caracteres.Length ? false : !char.IsNumber(Caracteres[j - 1]))
                                {
                                    while (char.IsNumber(Caracteres[j + 1]))
                                    {
                                        j++;
                                        concatenado += Caracteres[j];
                                    }
									if (!concatenado.Equals("-"))
									{
										valor = Convert.ToInt32(concatenado);
									}
									TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
                                }
                                else
                                {
                                    TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
                                }
								concatenado = null;
								break;
							case "*":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "/":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "[":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "]":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case "(":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case ")":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case ":":
									//TokenEncontrado = Caracteres[j+1].Equals('=')? BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j+1]) :BuscarTokenNoDicionario(concatenado.ToUpper());
									if (Caracteres[j + 1].Equals('='))
									{
										TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j + 1], i);
										j++;
									}
									else
									{
										TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
									}
								concatenado = null;
								break;
							case "=":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case ">":
									//TokenEncontrado = Caracteres[j+1].Equals('=')? BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j+1]) :BuscarTokenNoDicionario(concatenado.ToUpper());
									if (Caracteres[j + 1].Equals('='))
									{
										TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j + 1], i);
										j++;
									}
									else
									{
										TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
									}
								concatenado = null;
								break;
							case "<":
									//TokenEncontrado = Caracteres[j+1].Equals('=')? BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j+1]) :BuscarTokenNoDicionario(concatenado.ToUpper());
									if (Caracteres[j + 1].Equals('='))
									{
										TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j + 1], i);
										j++;
									}
									else
									{
										BuscarTokenNoDicionario(concatenado.ToUpper(), i);
									}
								concatenado = null;
								break;
							case "<>":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							case ";":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
                            case ".":
								if (Caracteres[j+1] == '.')
								{
									TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper() + Caracteres[j + 1], i);
									j++;
								}
								else
								{
									TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								}
                                concatenado = null;
                                break;
                            case "$":
								TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
								concatenado = null;
								break;
							default:
								// Default para concatenacao e manda para busca no dicionario.
								if (j.Equals(Caracteres.Length - 1)
									|| Caracteres[j + 1].Equals(',')
									|| Caracteres[j + 1].Equals(' ')
									|| Caracteres[j + 1].Equals(';')
									|| Caracteres[j + 1].Equals('+')
									|| Caracteres[j + 1].Equals('-')
									|| Caracteres[j + 1].Equals('*')
									|| Caracteres[j + 1].Equals('/')
									|| Caracteres[j + 1].Equals('[')
									|| Caracteres[j + 1].Equals(']')
									|| Caracteres[j + 1].Equals('(')
									|| Caracteres[j + 1].Equals(')')
									|| Caracteres[j + 1].ToString().Equals(":=")
									|| Caracteres[j + 1].Equals(':')
									|| Caracteres[j + 1].Equals('=')
									|| Caracteres[j + 1].Equals('>')
									|| Caracteres[j + 1].ToString().Equals(">=")
									|| Caracteres[j + 1].Equals('<')
									|| Caracteres[j + 1].ToString().Equals("<=")
									|| Caracteres[j + 1].ToString().Equals("<>")
                                    || Caracteres[j + 1].ToString().Equals("..")
                                    || Caracteres[j + 1].Equals('.')
									|| Caracteres[j + 1].Equals('$')
									)
								{
                                    TokenEncontrado = BuscarTokenNoDicionario(concatenado.ToUpper(), i);
									concatenado = null;
								}
								break;
						}

					
						SalvamentoDireto:
						// Adicionar a pilha principal.
						if (TokenEncontrado != null)
						{
							SalvarPilhaPrincipal(new TokenAtivo(TokenEncontrado, i + 1, "", valor, buffer_ident, buffer_literal));
						}

                        // Limpar Token encontrado.
                        // Para encontrar proximo.
                        valor = 0;
                        buffer_literal = "";
                        buffer_ident = "";
                        TokenEncontrado = null;
                        j++;

                    }
                    j = 0;
					
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SalvarPilhaPrincipal(TokenAtivo tokenAtivo)
		{
			PilhaTokenPrincipal.Add(tokenAtivo);
		}


		private Boolean TratarComentarios(char primeiro, char segundo)
		{
			if (primeiro != '*'|| segundo != ')')
			{
				return false;
			}
			return true;
		}

		#endregion

	}
}
