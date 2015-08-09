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
			operatorStack = new Stack<Token> ();
			postfix = new List<Token> ();
		}
			
		public void ProcessInfixToPostfix()
		{	
			operatorStack.Clear ();
			postfix.Clear ();

			foreach (string currentToken in infix) {
				Token token = new Token ();
				token.Value = currentToken;
				token.Type = TokenHelper.GetTokenType (currentToken);
				token.Precedence = TokenHelper.GetPrecedence (currentToken);

				switch (token.Type) {
				case TOKENTYPE.NUMBER: {
						postfix.Add (token);
					} break;

				case TOKENTYPE.OPERATOR: {
						if (operatorStack.Count < 1) {
							operatorStack.Push (token);
						} else {
							Token peek = operatorStack.Peek ();
							while (operatorStack.Count > 0 && (token.Precedence <= peek.Precedence)) {
								postfix.Add (operatorStack.Pop ());
							} 
							operatorStack.Push (token);	
						}
					} break;

				case TOKENTYPE.PARENTHESIS: {
						if (currentToken == "(") {
							operatorStack.Push (token);

						} else if (currentToken == ")") {
							while (operatorStack.Peek ().Value != "(") {
								postfix.Add (operatorStack.Pop ());
							}
							operatorStack.Pop ();
						}
					} break;
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
		private string[] infix = null;
		private List<Token> postfix = null;
		private Stack<Token> operatorStack = null;

		public string Infix {
			get { return String.Join (" ", infix); }

			set { infix = value.Split (' '); } 
		}
	}
}

