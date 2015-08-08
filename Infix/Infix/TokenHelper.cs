using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Net;

namespace Infix
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

		public static bool IsTokenOperator(char c) {
			return ((c == '+') || (c == '-') || (c == '*') || (c == '/') || (c == '%') || (c == '^') ? true: false);
		}

		public  static bool IsTokenParenthesis (char c) {
			return ((c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']') ? true : false);
		}

		public  static UNARY GetUnaryType(char c)
		{
			switch (c) {
			case '+':
				return UNARY.POSITIVE;
			case '-':
				return UNARY.NEGATIVE;
			default: 
				return UNARY.NONE;
			}
		}

		public  static PARENTHESIS GetParenthesisType (char c)
		{
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
	}
}
