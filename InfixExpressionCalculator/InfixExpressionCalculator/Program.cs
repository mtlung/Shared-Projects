using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixExpressionCalculator
{
    class Program
    {
        static string inputString = "-11 + -22";
        static void Main(string[] args)
        {
            // NormaizeString();
            Tokenizer tokenizer = new Tokenizer("-11 + -22");
            tokenizer.NormalizeInputString();

        }
        static bool IsEndOfString(int index)
        {
            return (index == inputString.Length - 1) ? true : false;
        }
        static void NormaizeString()
        {
            int index = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                Console.WriteLine(inputString[i]);
            }
        }
       
    }
}
