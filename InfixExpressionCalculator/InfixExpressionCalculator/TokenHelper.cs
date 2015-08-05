using System;
namespace InfixExpressionCalculator
{
    class TokenHelper
    {
        public TokenHelper() {
        }

        public bool IsTokenNumeric(char c) {
            return (Char.IsNumber(c)) ? true : false;
        }

        public bool IsTokenWhiteSpace(char c)
        {
            return (c == ' ' || c == '\t') ? true: false;
        }

        public bool IsTokenOperator(char c) {
            return (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^') ? true : false;
        }

        public bool IsTokenParenthesis(char c) {
            return (c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']') ? true : false;
        }
        public UNARY GetUnaryType (char c)
        {
            if (c == '+')
                return UNARY.POSITIVE;
            else if (c == '-')
                return UNARY.NEGATIVE;
            else
                return UNARY.NONE;
        }
        public OPERATOR GetOperatorType (char c)
        {
            if (c == '+')
                return OPERATOR.ADD;
            else if (c == '-')
                return OPERATOR.SUB;
            else if (c == '*')
                return OPERATOR.MUL;
            else if (c == '/')
                return OPERATOR.DIV;
            else if (c == '%')
                return OPERATOR.MOD;
            else if (c == '^')
                return OPERATOR.PWR;
            else
                return OPERATOR.NONE;
        }
        public PARENTHESIS GetParenthesisType (char c)
        {
            if (c == '(')
                return PARENTHESIS.OPEN;
            else if (c == ')')
                return PARENTHESIS.CLOSE;
            else
                return PARENTHESIS.NONE;
        }
    }
}
