using System;
using System.Collections.Generic;
using System.Threading;

namespace Infix
{
	class Program
	{
		public static void Main (string[] args)
		{
			var infixNormalizer = new InfixNormalizer ();
			var infixToPostfixProcessor = new InfixPostfixProcessor ();

			string infixExpression = null;
			do {
				Console.WriteLine ("Please enter infix expression: ");

				infixExpression = Console.ReadLine ();
				infixNormalizer.Infix = infixExpression;
				infixNormalizer.Normalize ();
				infixToPostfixProcessor.Infix = infixNormalizer.Normalized;
				infixToPostfixProcessor.ProcessInfixToPostfix ();
				string s = infixToPostfixProcessor.Infix;
				Console.WriteLine("Processed infix: {0}", s);
				Console.WriteLine ("Infix entered: {0}", infixNormalizer.Infix);
				Console.WriteLine ("Normalized: {0}", infixNormalizer.Normalized); 
				infixToPostfixProcessor.ProcessPostfix();
				double result = infixToPostfixProcessor.Result;
				Console.WriteLine ("final calculation result is: {0}", result);
			

			} while (!String.IsNullOrEmpty (infixExpression));
		}
	}
}