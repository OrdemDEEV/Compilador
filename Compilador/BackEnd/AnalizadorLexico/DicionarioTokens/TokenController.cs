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

		#region --- MONTAGEM DICIONARIO DE DADOS ---

		/* CODIGO PROIBIDO NAO MECHA */

		private OleDbConnection _olecon;
        private OleDbCommand _oleCmd;
        private static String _Arquivo = @"C:\Users\Eduardo\Desktop\Projetos\Compilador\Compilador\BackEnd\AnalizadorLexico\DicionarioTokens\TabelaTokens.xlsx";
        private String _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _Arquivo);
        private String _Consulta;

        public static List<Token> ListaTokens = new List<Token>();

        public List<Token> IniciarDicionarioTokens()
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

		#region --- METODOS ANALIZADOR LEXICO ---

		private Token BuscarTokenNoDicionario(string variavel, string proximo)
		{
			Token tokenEncontradoAtual = ListaTokens.Find(c => c.Simbolo.Equals(variavel));
			
			if (tokenEncontradoAtual == null)
			{
				Token tokenEncontradoProx = ListaTokens.Find(c => c.Simbolo.Equals(proximo));
				if (tokenEncontradoProx != null)
				{
					// Retorna o codigo do token do identificador.
					return ListaTokens.Find(c => c.Simbolo.Equals("Identificador"));
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
				while (Retorno == null)
				{
					concatenado = concatenado + Leitura[j].ToString();
					Retorno = BuscarTokenNoDicionario(concatenado,  j==Leitura.Length-1 ?null: Leitura[j + 1].ToString());
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

		private void SalvarPilhaPrincipal(Token Token)
		{

		}

		#endregion

	}
}
