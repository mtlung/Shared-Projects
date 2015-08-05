using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixExpressionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // NormaizeString();
            Tokenizer tokenizer = new Tokenizer("-11  (  + -22-      33");
            tokenizer.NormalizeInputString();

        }
    }
}
