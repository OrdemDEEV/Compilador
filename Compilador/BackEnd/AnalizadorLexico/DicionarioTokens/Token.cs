using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorLexico.DicionarioTokens
{
    class Token
    {
        public Token(int codigo, string simbolo)
        {
            Codigo = codigo;
            Simbolo = simbolo;
        }

        public int Codigo { get; private set; }
        public string Simbolo { get; private set; }
    }
}
