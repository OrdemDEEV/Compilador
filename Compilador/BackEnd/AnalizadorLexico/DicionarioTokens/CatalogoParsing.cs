using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.BackEnd.AnalizadorLexico.DicionarioTokens
{
    class CatalogoParsing
    {
        public CatalogoParsing(int codigoParsing1, int codigoParsing2 , string simboloparsing)
        {
            CodigoParsing1 = codigoParsing1;
            CodigoParsing2 = codigoParsing2;
            SimboloParsing = simboloparsing;
        }

        public int CodigoParsing1 { get; private set; }

        public int CodigoParsing2 { get; private set; }
        public string SimboloParsing { get; private set; }
    }
}
