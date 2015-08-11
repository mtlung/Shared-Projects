using System;
using System.Runtime.CompilerServices;

namespace InfixCalculator
{
	public enum TOKENTYPE { NUMBER, OPERATOR, PARENTHESIS, WHITESPACE, NONE = 10 }
	public enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE = 10 }
	public enum PARENTHESIS { OPEN, CLOSE, NONE = 10 }
	public enum UNARY { POSITIVE, NEGATIVE, NONE = 10 }
	public enum PRECEDENCE { PAREN = 1, ADD = 2, SUB = 2, MUL = 3, DIV = 3, MOD = 3, PWR = 4, NONE = 10 }
}

