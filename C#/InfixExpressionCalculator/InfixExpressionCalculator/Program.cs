using System;
using System.Collections.Generic;
using System.Threading;

namespace InfixCalculator
{
	class InfixPostfixCalculator
	{
		public static void Main (string[] args)
		{
			var infixToPostfixProcessor = new InfixPostfixProcessor ();
			string infixExpression = null;
			do {
				Console.Write ("Please enter infix expression (press Enter to terminate): ");

				infixExpression = Console.ReadLine ();
				Console.WriteLine("---------------------------------------");
				if (infixExpression.Length > 0) {
				infixToPostfixProcessor.InfixExpression = infixExpression;
				infixToPostfixProcessor.PreProcessInfixExpresion();
				infixToPostfixProcessor.ProcessInfixToPostfix ();
				infixToPostfixProcessor.ProcessPostfixCaculation ();

				double result = infixToPostfixProcessor.CalculationResult;
				Console.WriteLine(infixToPostfixProcessor.ToString ());
						
				Console.WriteLine("---------------------------------------");
				}
			} while (!String.IsNullOrEmpty (infixExpression));
		}
	}
}