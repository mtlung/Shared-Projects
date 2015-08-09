using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection.Emit;
using System.Net.NetworkInformation;

namespace Infix
{
	public class InfixPostfixProcessor
	{
		public InfixPostfixProcessor ()
		{
			operandStack = new Stack<double> ();
			operatorStack = new Stack<Token> ();
			postfix = new List<Token> ();
		}

		private void ProcessPostfix()
		{
			operandStack.Clear ();

			double operand1 = 0.0f;
			double operand2 = 0.0f;

			foreach (Token token in postfix) {
				switch (token.Type) {
				case TOKENTYPE.NUMBER: 
					{
						operandStack.Push (double.Parse (token.Value));
					}
					break;
				case TOKENTYPE.OPERATOR: 
					{
						switch (TokenHelper.GetOperatorType (token.Value)) { 
						case OPERATOR.ADD: 
							{
								operand2 = operandStack.Pop ();
								operand1 = operandStack.Pop ();
								operandStack.Push (operand1 + operand2);
							}
							break;
						case OPERATOR.SUB: 
							{
								operand2 = operandStack.Pop ();
								operand1 = operandStack.Pop ();
								operandStack.Push (operand1 - operand2);
							}
							break;
						case OPERATOR.MUL:
							{
								operand2 = operandStack.Pop ();
								operand1 = operandStack.Pop ();
								operandStack.Push (operand1 * operand2);
							}
							break;
						case OPERATOR.DIV: 
							{
								operand2 = operandStack.Pop ();
								operand1 = operandStack.Pop ();
								operandStack.Push ((operand2 == 0) ? 0 : (operand1 / operand2));
							}
							break;
						case OPERATOR.MOD: 
							{
								operand2 = operandStack.Pop ();
								operand1 = operandStack.Pop ();
								operandStack.Push ((int)operand1 % (int)operand2);
							}
							break;
						case OPERATOR.PWR: 
							{
								calculatedResult = 0.0f;
							}
							break;
						default: 
							{
								calculatedResult = 0.0f;
							}
							break;
						}
					}
					break;
				}
			}
			calculatedResult = operandStack.Pop ();
		}

		private void ProcessInfixToPostfix()
		{	
			operatorStack.Clear ();
			postfix.Clear ();

			foreach (string currentToken in infix) {
				
				Token token = new Token ();
				token.Value = currentToken;
				token.Type = TokenHelper.GetTokenType (currentToken);
				token.Precedence = TokenHelper.GetPrecedence (currentToken);

				switch (token.Type) {
				case TOKENTYPE.NUMBER:
					{
						postfix.Add (token);
					}
					break;

				case TOKENTYPE.OPERATOR:
					{
						if (operatorStack.Count < 1) {
							operatorStack.Push (token);
						} else {
							Token peek = operatorStack.Peek ();
							while (operatorStack.Count > 0 && (token.Precedence <= peek.Precedence)) {
								postfix.Add (operatorStack.Pop ());
							} 
							operatorStack.Push (token);	
						}
					}
					break;

				case TOKENTYPE.PARENTHESIS:
					{
						if (currentToken == "(") {
							operatorStack.Push (token);

						} else if (currentToken == ")") {

							while (operatorStack.Peek ().Value != "(") {
								postfix.Add (operatorStack.Pop ());
							}
							operatorStack.Pop ();
						}
					}
					break;
				} 
			}			
		
			while (operatorStack.Count > 0) {
				postfix.Add (operatorStack.Pop ());
			}

			int index = 0;
			Console.WriteLine ("In Postfix List:");
			foreach (Token l in postfix) {
				Console.WriteLine ("L[{0}]: {1}", index++, l.Value);
			}
		}

		private double calculatedResult = 0.0f;
		private string[] infix = null;
		private List<Token> postfix = null;
		private Stack<Token> operatorStack = null;
		private Stack<double> operandStack = null;
		public double Result { get { return calculatedResult; } set { calculatedResult = value; } }
		public string Infix  { get { return String.Join (" ", infix); } set { infix = value.Split (' '); } }
	}
}


