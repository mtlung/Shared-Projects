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
        

        public Tokenizer(string inputString)
        {
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
                Console.WriteLine(normalizedString);
                if (helper.IsTokenNumeric(inputString[index]))
                {
                    while ( (helper.IsTokenNumeric(inputString[index])) && (index != stringLength))

                    {
                        Console.WriteLine(index);
                        normalizedString += inputString[index];
                        index = index + 1;
                    }
                    normalizedString += " ";

                }
                else if (helper.IsTokenOperator(inputString[index]))
                {
                    if (inputString[index] == '+' || inputString[index] == '-')
                    {
                        if (inputString[index] == '-')
                        {
                            if ( helper.IsTokenNumeric(GetLookAhead(inputString, index)))
                            {
                                normalizedString += inputString[index];
                            }
                            else
                            {
                                normalizedString += inputString[index];
                                normalizedString += " ";
                            }
                        }
                        else
                        {
                            if (helper.IsTokenNumeric(GetLookAhead(inputString, index)))
                            {
                                normalizedString += "";
                            }
                            else
                            {
                                normalizedString += inputString[index];
                                normalizedString += " ";
                            }
                        }
                    }
                }
                else
                {
                    normalizedString += inputString[index];
                    //normalizedString += " ";
                }
            }
            return this.normalizedString;
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
