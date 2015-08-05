using System;
namespace InfixExpressionCalculator
{
    class TokenHelper
    {
        public TokenHelper() {
        }

        public bool IsTokenNumeric(char c) {
            if (Char.IsNumber(c))
                return true;
            else
                return false;
        }

        public bool IsTokenOperator(char c) {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^')
                return true;
            else
                return false;
        }

        public bool IsTokenParenthesis(char c) {
            if (c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']')
                return true;
            else
                return false;
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
