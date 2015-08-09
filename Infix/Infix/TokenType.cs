using System;
using System.Runtime.CompilerServices;

namespace InfixCalculator
{
	public enum TOKENTYPE { NUMBER, OPERATOR, PARENTHESIS, WHITESPACE, NONE = 10 }
	public enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE = 10 }
	public enum PARENTHESIS { OPEN, CLOSE, NONE = 10 }
	public enum UNARY { POSITIVE, NEGATIVE, NONE = 10 }
	public enum PRECEDENCE { PAREN = -1, ADD = 1, SUB = 1, MUL = 2, DIV = 2, MOD = 3, PWR = 4, NONE = 10 }
}

