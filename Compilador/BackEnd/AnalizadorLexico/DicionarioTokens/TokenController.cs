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

		#region --- Excel ---

		private OleDbConnection _olecon;
		private OleDbCommand _oleCmd;
		private static String _Arquivo = @"C:\Users\Eduardo\Desktop\Projetos\Compilador-master\Compilador\BackEnd\AnalizadorLexico\DicionarioTokens\TabelaTokens.xlsx";
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

		#endregion

		#region --- MONTAGEM DICIONARIO DE DADOS ---

		//public static List<Token> ListaTokens = new List<Token>();

		public List<Token> IniciarDicionarioTokens()
        {

            ListaTokens.Add(new Token(1, "Program"));
            ListaTokens.Add(new Token(2, "Label"));
            ListaTokens.Add(new Token(3, "Const"));
            ListaTokens.Add(new Token(4, "Var"));
            ListaTokens.Add(new Token(5, "Procedure"));
            ListaTokens.Add(new Token(6, "Begin"));
            ListaTokens.Add(new Token(7, "End"));
            ListaTokens.Add(new Token(8, "Integer"));
            ListaTokens.Add(new Token(9, "Array"));
            ListaTokens.Add(new Token(10, "Of"));
            ListaTokens.Add(new Token(11, "Call"));
            ListaTokens.Add(new Token(12, "Goto"));
            ListaTokens.Add(new Token(13, "If"));
            ListaTokens.Add(new Token(14, "Then"));
            ListaTokens.Add(new Token(15, "Else"));
            ListaTokens.Add(new Token(16, "While"));
            ListaTokens.Add(new Token(17, "Do"));
            ListaTokens.Add(new Token(18, "Repeat"));
            ListaTokens.Add(new Token(19, "Until"));
            ListaTokens.Add(new Token(20, "Readln"));
            ListaTokens.Add(new Token(21, "Writeln"));
            ListaTokens.Add(new Token(22, "Or"));
            ListaTokens.Add(new Token(23, "And"));
            ListaTokens.Add(new Token(24, "Not"));
            ListaTokens.Add(new Token(25, "Identificador"));
            ListaTokens.Add(new Token(26, "Inteiro"));
            ListaTokens.Add(new Token(27, "For"));
            ListaTokens.Add(new Token(28, "To"));
            ListaTokens.Add(new Token(29, "Case"));
            ListaTokens.Add(new Token(30, "+ "));
            ListaTokens.Add(new Token(31, "- "));
            ListaTokens.Add(new Token(32, "* "));
            ListaTokens.Add(new Token(33, "/ "));
            ListaTokens.Add(new Token(34, "["));
            ListaTokens.Add(new Token(35, "]"));
            ListaTokens.Add(new Token(36, "("));
            ListaTokens.Add(new Token(37, ")"));
            ListaTokens.Add(new Token(38, ":= "));
            ListaTokens.Add(new Token(39, ":"));
            ListaTokens.Add(new Token(40, "= "));
            ListaTokens.Add(new Token(41, "> "));
            ListaTokens.Add(new Token(42, ">= "));
            ListaTokens.Add(new Token(43, "< "));
            ListaTokens.Add(new Token(44, "<= "));
            ListaTokens.Add(new Token(45, "<> "));
            ListaTokens.Add(new Token(46, ","));
            ListaTokens.Add(new Token(47, "; "));
            ListaTokens.Add(new Token(48, "literal"));
            ListaTokens.Add(new Token(49, "."));
            ListaTokens.Add(new Token(50, ".."));
            ListaTokens.Add(new Token(51, "$"));

            // Retorna Lista.
            return ListaTokens;
        }

		#endregion

		#region --- METODOS ANALIZADOR LEXICO ---

		private Token BuscarTokenNoDicionario(string variavel, string proximo, string anterior)
		{
			Token tokenEncontradoAtual = ListaTokens.Find(c => c.Simbolo.Equals(variavel));
			
			if (tokenEncontradoAtual == null)
			{
				//	Token tokenEncontradoProx = ListaTokens.Find(c => c.Simbolo.Equals(proximo));


				/*if (proximo == ";" || proximo == "," || proximo == " " || proximo == ":")
                {
					// Retorna o codigo do token do identificador.
					return ListaTokens.Find(c => c.Simbolo.Equals("Identificador"));
				}*/

				// se o anterior for um identificador e o proximo aspas tem que pegar o do meio das aspas pra ser literal.

				// Se o anterior for um identificador o proximo e um literal inteiro ou bool

				// Se o proximo for encontrado o atual e um dentificador.
				if (proximo == " " || proximo == null || ListaTokens.Exists(c=>c.Simbolo.Equals(proximo)))
				{
					return ListaTokens.Find(c => c.Simbolo.Equals("IDENTIFICADOR"));
				}

			}

			return tokenEncontradoAtual;
		}
		
		public void MontagemPilha(List<string> Codigos)
		{
			// Recebe as linhas brutas.
			char[] Leitura;

			// Percorre as linhas brutas recebidas.
			for (int i=0;i<Codigos.Count;i++)
			{
				// Quebra linha recebida em char para realizar tratamento.
				Leitura = Codigos[i].ToCharArray();

				Token Retorno = null;
				int j = 0;
				string concatenado = "";
				while (j < Leitura.Length-1)
				{

					concatenado = concatenado + Leitura[j].ToString();
					if (Leitura[j+1].Equals(';') || Leitura[j+1].Equals(',') || Leitura[j+1].Equals(' ') || Leitura[j+1].Equals('(') || Leitura[j+1].Equals(')') || Leitura[j+1].Equals('[') || Leitura[j+1].Equals(']'))
					{
						Retorno = BuscarTokenNoDicionario(concatenado.ToUpper(), j == Leitura.Length - 1 ? null : Leitura[j + 1].ToString().ToUpper(), j == 0 ? null : Leitura[j - 1].ToString());
					}


					if (Retorno != null)
                    {
						//mandar para onde tem que mandar
						PilhaTokenPrincipal.Add(new TokenAtivo(Retorno, i, "", 0, "", ""));
                        //e limpar a variavel
                        concatenado = null;
                        Retorno = null;
                    }
					j++;
				}

				// Percore characteres.
				//for (int j=0;j <= Leitura.Length;j++)
				//{
				//	Token retorno = BuscarTokenNoDicionario(Leitura[j].ToString());

				//	if (retorno == null)
				//	{
				//		BuscarTokenNoDicionario(Leitura[j].ToString() + Leitura[j + 1].ToString());
				//	}
				//	else
				//	{
				//		SalvarPilhaPrincipal(retorno);
				//	}
					
				//}

			}
		}


		#endregion

	}
}
