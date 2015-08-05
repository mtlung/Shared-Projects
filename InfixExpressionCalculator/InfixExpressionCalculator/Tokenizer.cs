using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixExpressionCalculator
{
    class Tokenizer
    {
        private TokenHelper helper = null;
        private List<Token> tokens = null;

        public string inputString { get; set; }

        public Tokenizer(string inputString)
        {
            this.inputString = inputString;
        }
        public Tokenizer()
        {

        }
        static char GetLookAhead(string input, int index)
        {
            char lookAhead;
            int length = input.Length;

            if ((index + 1) < length)
                lookAhead = input[index + 1];
            else
                lookAhead = ' ';
            return lookAhead;
        }

        private bool IsIndexValid(string input, int index)
        {
            int length = inputString.Length;
            if ((index > 0) && (index < length - 1))
                return true;
            else
                return false;
        }
        private bool IsIndexAtEndOfString(string input, int index)
        {
            int length = inputString.Length;
            if (index == length - 1)
                return true;
            else return false;
        }
        public string NormalizeInputString()
        {
            int index = 0;
            string normalizedString = string.Empty;
            int length = inputString.Length;
            helper = new TokenHelper();

            if (length > 0)
            {
                char lookAheadToken;
                char currentToken;

                for (index = 0; index < length; index++)
                {
                    lookAheadToken = GetLookAhead(inputString, index);

                    if (helper.IsTokenNumeric(inputString[index]))
                    {
                        while(helper.IsTokenNumeric(inputString[index]))
                        {
                            normalizedString += inputString[index];
                            index = index + 1;
                        }
                        normalizedString += ' ';
                    }
                    else if (helper.IsTokenOperator(inputString[index]))
                    {

                    }
                    else if (helper.IsTokenParenthesis(inputString[index]))
                    {
                        normalizedString += inputString[index];
                        normalizedString += ' ';
                    }
                    else
                    {

                    }
                }
            }
            Console.WriteLine("normalized string is: {0}", normalizedString);
            return null;
        }
        public List<Token> Process()
        {
            helper = new TokenHelper();
            tokens = new List<Token>();
            return tokens;
        }
    }


}
