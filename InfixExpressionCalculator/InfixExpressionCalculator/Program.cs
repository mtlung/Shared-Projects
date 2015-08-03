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
            Tokenizer tokenizer = new Tokenizer("-11 + -22");
            tokenizer.NormalizeInputString();
        }
    }
    
    class Token
    {
        public string Data { get; set; }
        public TOKEN TokenType { get; set; }
        public UNARY UnaryType { get; set; }
        public OPERATOR OperatorType { get; set; }
        public PARENTHESIS ParenthesisType { get; set; }
    }

    class TokenHelper
    {
        public TokenHelper()
        {

        }
        public bool IsTokenNumeric(char c)
        {
            if (Char.IsNumber(c)) return true;
            else return false;
        }
        public bool IsTokenOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^') return true;
            else return false;
        }
        public bool IsTokenParenthesis(char c)
        {
            if (c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']') return true;
            else return false;
        }

    }

    class Tokenizer
    {
        private TokenHelper helper;
        private  List<Token> tokens;

        public string inputString
        {
            get; set;
        }

        public Tokenizer(string inputString)
        {
            this.inputString = inputString;
        }
        public Tokenizer()
        {

        }
        public string NormalizeInputString()
        {
            string normalizedString = string.Empty;
            int length = inputString.Length;
            helper = new TokenHelper();

            if (inputString != null || length > 0)
            {
                char currentToken;
                int index = 0;

                for (index = 0; index < length; index++)
                {
                    currentToken = inputString[index];

                    if (helper.IsTokenNumeric(inputString[index]))
                    {
                        while (helper.IsTokenNumeric(inputString[index]))
                        {
                            normalizedString += inputString[index];
                            index = index + 1;
                        }

                        normalizedString += ' ';
                    }
                    else if (helper.IsTokenOperator(inputString[index]))
                    {
                        if (inputString[index] == '+' || inputString[index] == '-')
                        {
                            if (index == 0)
                            {
                                normalizedString += inputString[index];
                            }
                            else
                            {
                                if (index + 1 < length)
                                {
                                    if (helper.IsTokenNumeric(inputString[index + 1]))
                                    {
                                        normalizedString += inputString[index];
                                    }
                                    else
                                    {
                                        normalizedString += inputString[index];
                                        normalizedString += ' ';
                                    }
                                }
                            }
                        }
                        else
                        {
                            normalizedString += inputString[index];
                            normalizedString += ' ';
                        }
                    }
                    else if (helper.IsTokenParenthesis(inputString[index]))
                    {
                        normalizedString += inputString[index];
                        normalizedString += ' ';
                    }

                    Console.WriteLine(inputString[index].ToString());
                  
                }
                normalizedString += inputString[index-1];
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

    enum TOKEN { NUMBER, OPERATOR, PARENTHESIS, NONE };
    enum UNARY { POSITIVE, NEGATIVE, NONE };
    enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE };
    enum PARENTHESIS { OPEN, CLOSE, NONE };
}
