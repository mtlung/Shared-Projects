using System;

namespace Infix
{
	public enum TOKENTYPE { NUMBER, OPERATOR, PARENTHESIS, NONE = 10 }
	public enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE = 10 }
	public enum PARENTHESIS { OPEN, CLOSE, NONE = 10 }
	public enum UNARY { POSITIVE, NEGATIVE, NONE = 10 }
	public enum PRECEDENCE { ADD = 0, SUB = 0, MUL = 1, DIV = 1, MOD = 2, PWR = 3, NONE = 10 }
}

