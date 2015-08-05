using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixExpressionCalculator
{
    class Tokenizer
    {
        public Tokenizer() {
        }
        public Tokenizer(string inputString) {
            this.inputString = inputString;
        }
        private char GetLookAhead(string input, int index)
        {
            int length = input.Length;
            char lookAhead = ((index + 1) < length) ? input[index + 1] : ' ';
            return lookAhead; 
        }
        private bool IsTokenUnary(char c)
        {
            return true;
        }
        public string NormalizeInputString()
        {
            int index = 0;
            int stringLength = inputString.Length;
            helper = new TokenHelper();

            for (index = 0; index < stringLength; index++)
            {
                if (helper.IsTokenNumeric(inputString[index]))
                {
                    normalizedString += inputString[index];
                }
                else if (helper.IsTokenOperator(inputString[index]))
                {
                }
                else
                {
                    if (inputString[index] == ' ' || inputString[index] == '\t')
                    {
                        normalizedString += "";
                    }
                    else
                    {
                        normalizedString += inputString[index];
                    }
                }
            }
            Console.WriteLine(normalizedString);
            return normalizedString;
        }
                
        public List<Token> Process()
        {
            helper = new TokenHelper();
            tokens = new List<Token>();
            return tokens;
        }
        private string inputString = null;
        private string normalizedString = null;
        private TokenHelper helper = null;
        private List<Token> tokens = null;
        public string InputString { get; set; }
        public string NormalizedString { get; set; }
    }


}
