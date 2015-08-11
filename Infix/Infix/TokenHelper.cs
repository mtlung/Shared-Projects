using System;

namespace InfixCalculator
{
	static class TokenHelper {
		public static bool IsTokenDigit(char c){
			return	Char.IsDigit (c);
		}

		public static bool IsStringEmpty (string s) {
			return (s.Length < 1) ? true : false;
		}
		public static  bool IsTokenWhiteSpace (char c) {
			return ((c == ' ') || (c == '\t')) ? true : false;
		}

		public static bool IsTokenNumer(string s) {
			double d = 0.00f;
			return double.TryParse (s, out d);
		}
		public static bool IsTokenOperator(string s) {
			return ((s == "+") || (s == "-") || (s == "*") || (s == "/") || (s == "%") || (s == "^") ? true: false);
		}

		public static bool IsTokenOperator(char c) {
			return ((c == '+') || (c == '-') || (c == '*') || (c == '/') || (c == '%') || (c == '^') ? true: false);
		}

		public static bool IsTokenParenthesis (string s) {
			return ((s == "(" || s == ")" || s == "{" || s == "}" || s == "[" || s == "]") ? true : false);	
		}

		public static bool IsTokenParenthesis (char c) {
			return ((c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']') ? true : false);
		}

		/// <summary>
		/// Determines whether specificed token (s at index) is a unary operator.
		/// </summary>
		/// <returns><c>true</c> if token at index is unary; otherwise, <c>false</c>.</returns>
		/// <param name="s">string</param>
		/// <param name="index">inteter</param>
		public static bool IsTokenUnary(string s, int index) 
		{
			if (index == 0)
			{
				return true;
			} 
			else if (TokenHelper.IsTokenOperator (s [index - 1])) 
			{
				return true;
			} 
			else if (TokenHelper.IsTokenParenthesis (s [index - 1])) 
			{
				return (s [index - 1] == '(') ? true : false;
			} 
			else 
			{
				return false;
			}
		}
		/// <summary>
		/// Gets the precedence of an operator S
		/// </summary>
		/// <returns>enum PRECEDENCE</returns>
		/// <param name="s">string</param>
		public static PRECEDENCE GetPrecedence(string s) {
			switch(s) {
			case "+":
				return PRECEDENCE.ADD;
			case "-":
				return PRECEDENCE.SUB;
			case "*":
				return PRECEDENCE.MUL;
			case "/":
				return PRECEDENCE.DIV;
			case "^":
				return PRECEDENCE.PWR;
			case "%":
				return PRECEDENCE.MOD;
			case "(":
				return PRECEDENCE.PAREN;
			case ")":
				return PRECEDENCE.PAREN;
			default:
				return PRECEDENCE.NONE;
			}
		}

		public static PRECEDENCE GetPrecedence(char c) {
			switch(c) {
			case '+':
				return PRECEDENCE.ADD;
			case '-':
				return PRECEDENCE.SUB;
			case '*':
				return PRECEDENCE.MUL;
			case '/':
				return PRECEDENCE.DIV;
			case '^':
				return PRECEDENCE.PWR;
			case '%':
				return PRECEDENCE.MOD;
			case '(':
				return PRECEDENCE.PAREN;
			case ')':
				return PRECEDENCE.PAREN;

			default:
				return PRECEDENCE.NONE;
			}
		}

		public  static UNARY GetUnaryType(char c) {
			switch (c) {
			case '+':
				return UNARY.POSITIVE;
			case '-':
				return UNARY.NEGATIVE;
			default: 
				return UNARY.NONE;
			}
		}

		public  static UNARY GetUnaryType(string s)
		{
			switch (s) {
			case "+":
				return UNARY.POSITIVE;
			case "-":
				return UNARY.NEGATIVE;
			default: 
				return UNARY.NONE;
			}
		}

		public  static PARENTHESIS GetParenthesisType (char c) {
			switch (c) {
			case '(':
				return PARENTHESIS.OPEN;
			case '{':
				return PARENTHESIS.OPEN;
			case '[':
				return PARENTHESIS.OPEN;
			case ')':
				return PARENTHESIS.CLOSE;
			case ']':
				return PARENTHESIS.CLOSE;
			case '}':
				return PARENTHESIS.CLOSE;
			default: 
				return PARENTHESIS.NONE;
			}
		}

		public  static PARENTHESIS GetParenthesisType (string s) {
			switch (s) {
			case "(":
				return PARENTHESIS.OPEN;
			case "{":
				return PARENTHESIS.OPEN;
			case "[":
				return PARENTHESIS.OPEN;
			case ")":
				return PARENTHESIS.CLOSE;
			case "]":
				return PARENTHESIS.CLOSE;
			case "}":
				return PARENTHESIS.CLOSE;
			default: 
				return PARENTHESIS.NONE;
			}
		}

		public  static OPERATOR GetOperatorType(char c)
		{
			switch (c) {
			case '+':
				return OPERATOR.ADD;
			case '-':
				return OPERATOR.SUB;
			case '*':
				return OPERATOR.MUL;
			case '/':
				return OPERATOR.DIV;
			case '^':
				return OPERATOR.PWR;
			case '%':
				return OPERATOR.MOD;
			default:
				return OPERATOR.NONE;
			}
		}

		public  static OPERATOR GetOperatorType(string s)
		{
			switch (s) {
			case "+":
				return OPERATOR.ADD;
			case "-":
				return OPERATOR.SUB;
			case "*":
				return OPERATOR.MUL;
			case "/":
				return OPERATOR.DIV;
			case "^":
				return OPERATOR.PWR;
			case "%":
				return OPERATOR.MOD;
			default:
				return OPERATOR.NONE;
			}
		}

		public static TOKENTYPE GetTokenType(string s)
		{
			if (IsTokenNumer (s)) {
				return TOKENTYPE.NUMBER;
			} else if (IsTokenOperator (s)) {
				return TOKENTYPE.OPERATOR;
			} else if (IsTokenParenthesis (s)) {
				return TOKENTYPE.PARENTHESIS;
			} else {
				return TOKENTYPE.NONE;
			}
		}
	}
}
