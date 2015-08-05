namespace InfixExpressionCalculator
{
    enum TOKEN { NUMBER, OPERATOR, PARENTHESIS, NONE = 10 };
    enum UNARY { POSITIVE, NEGATIVE, NONE = 10 };
    enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE = 10 };
    enum PARENTHESIS { OPEN, CLOSE, NONE = 10 };
    enum PRECEDENCE { ADD = 1, SUB = 1, MUL = 2, DIV = 2, MOD = 2, PWR = 3, NONE = 10 }
    enum ASSOCIATIVITY { L2R, R2L, NONE = 10 }

    class Token
    {
        public string Data { get; set; }
        public UNARY UnaryType { get; set; }
        public OPERATOR OperatorType { get; set; }
        public TOKEN TokenType { get; set; }
        public PARENTHESIS ParenthesisType { get; set; }
    }
}
