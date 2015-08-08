using System;
using System.Collections.Generic;
using System.Threading;

namespace Infix
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var infixNormalizer = new InfixNormalizer ();
			string infixExpression = null;
			do {
				Console.WriteLine ("Please enter infix expression: ");

				infixExpression = Console.ReadLine ();
				infixNormalizer.Infix = infixExpression;
				infixNormalizer.Normalize ();

				Console.WriteLine ("Infix entered: {0}", infixNormalizer.Infix);
				Console.WriteLine ("Normalized: {0}", infixNormalizer.Normalized); 


			} while (!String.IsNullOrEmpty (infixExpression));
		}
	}
}