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
			return ((c == '+') || (c == '-') || (c == '*') || (c == '/') || (c == '%') || (c == '^')? true: false);
		}

		public  static bool IsTokenParenthesis (char c) {
			return ((c == '(' || c == ')' || c == '{' || c == '}' || c == '[' || c == ']') ? true : false);
		}

		public  static UNARY GetUnaryType(char c)
		{
			switch (c) {
			case '+':
				return UNARY.POSITIVE;
				break;
			case '-':
				return UNARY.NEGATIVE;
				break;
			default: 
				return UNARY.NONE;
				break;
			}
		}

		public  static PARENTHESIS GetParenthesisType (char c)
		{
			switch (c) {
			case '(':
				return PARENTHESIS.OPEN;
				break;
			case '{':
				return PARENTHESIS.OPEN;
				break;
			case '[':
				return PARENTHESIS.OPEN;
				break;
			case ')':
				return PARENTHESIS.CLOSE;
				break;
			case ']':
				return PARENTHESIS.CLOSE;
				break;
			case '}':
				return PARENTHESIS.CLOSE;
				break;
			default: 
				return PARENTHESIS.NONE;
				break;
			}
		}

		public  static OPERATOR GetOperatorType(char c)
		{
			switch (c) {
			case '+':
				return OPERATOR.ADD;
				break;
			case '-':
				return OPERATOR.SUB;
				break;
			case '*':
				return OPERATOR.MUL;
				break;
			case '/':
				return OPERATOR.DIV;
				break;
			case '^':
				return OPERATOR.PWR;
				break;
			case '%':
				return OPERATOR.MOD;
				break;
			default:
				return OPERATOR.NONE;
				break;
			}
		}
	}
}
