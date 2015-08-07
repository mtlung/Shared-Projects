using System;

namespace Infix
{
	public enum TOKEN { NUMBER, OPERATOR, PARENTHESIS, NONE = 10 }
	public enum OPERATOR { ADD, SUB, MUL, DIV, MOD, PWR, NONE = 10 }
	public enum PARENTHESIS { OPEN, CLOSE, NONE = 10 }
	public enum UNARY { POSITIVE, NEGATIVE, NONE = 10 }
}

