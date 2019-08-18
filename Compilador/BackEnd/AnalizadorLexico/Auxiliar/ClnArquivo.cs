using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorLexico.Auxiliar
{
    class ClnArquivo
    {
        string[] linhas = { "teste" };
        public void Escrevertexto(string texto, string caminho)
        {
            linhas[0] = texto;

            using (System.IO.StreamWriter arquivo = new System.IO.StreamWriter(@caminho + "\\Arquivo.txt"))
            {
                foreach (string linha in linhas)
                {
                    arquivo.WriteLine(linha);
                }
            }
        }

        public List<Leitura> LerTexto(string arquivo)
        {
            string TextoLido = "";
            List<string> linhaMensagem = new List<string>();
            List<Leitura> listaLeitura = new List<Leitura>();
            using (StreamReader reader = new StreamReader(arquivo))
            {
                while ((TextoLido = reader.ReadLine()) != null)
                {
                    linhaMensagem.Add(TextoLido);
                    listaLeitura.Add(new Leitura(verificaSeeDigito(TextoLido), TextoLido));
                }
            }

            return listaLeitura;
        }

        public List<string> LerSeparadamente(string arquivo)
        {
            string TextoLido = "";
            List<string> linhaMensagem = new List<string>();
            List<Leitura> Pilha = new List<Leitura>();
            using (StreamReader reader = new StreamReader(arquivo))
            {
                while ((TextoLido = reader.ReadLine()) != null)
                {
                    linhaMensagem.Add(TextoLido);
                }
            }

            return linhaMensagem;
        }

        private bool verificaSeeDigito(string s)
        {
            char[] c = s.ToCharArray();
            Boolean d = true;

            for (int i = 0; i < c.Length; i++)
                // verifica se o char não é um dígito
                if (!Char.IsDigit(c[i]))
                {
                    d = false;
                    break;
                }
            return d;
        }
    }

    

}
