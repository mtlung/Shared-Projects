using System;
using System.Collections.Generic;
using System.Threading;

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
		{	var token = new Token ();
			foreach (string currentToken in infix) {
				
				if (TokenHelper.IsTokenNumer (currentToken)) {
					token.Value = currentToken;
					token.TokenType = TokenHelper.GetTokenType (currentToken);
					postfix.Add (token);
				} 
				else {
					
				
				}

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

