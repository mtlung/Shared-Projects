using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.IO;

namespace Infix
{
	public class Normalize
	{
		public Normalize ()
		{
			this.output = string.Empty;
			this.input = string.Empty;
		}
		public Normalize(string s)
		{
			this.output = string.Empty;
			this.input = string.Empty;
			this.input = s;
		}
		public void ProcessWhiteSpace()
		{
			
		}
		private char GetLookAheadToken(int index)
		{
			
			char lookahead = (index < input.Length - 1) ? input [index + 1] : '\0';
			Console.WriteLine ("lookahead called: {0}", lookahead);
			return lookahead;
		}

		public void ProcessNormalization()
		{
			helper = new TokenHelper ();
			for (int index = 0; index < input.Length; index++)
			{
				if (helper.IsTokenNumber (input [index]))
				{
					while (true) {
						if (helper.IsTokenNumber (input [index]) && index < input.Length - 1) {
							output += input [index];
							index = index + 1;
						}
						else break;
					}
					output += ' ';
				}
				else if (helper.IsTokenOperator (input [index]))
				{
					if (input [index] == '-') {
						if (helper.IsTokenNumber (GetLookAheadToken (index))) {
							output += input [index++];
							output += input [index++];
						} else {
							output += input [index++];
						}
						output += input [index];

					} else if (input [index] == '+') {
						if (helper.IsTokenNumber (GetLookAheadToken (index))) {
							index = index + 1;
							output += input [index++];
						} else {
							output += input [index++];
						//	output += ' ';
						}

						output += input [index];
					} else {
						output += input [index];
						output += ' ';
					}
					//output += ' ';
				}
				else if (helper.IsTokenParenthesis (input [index])) 
				{
					output += input [index];
				} 
				else 
				{
					if (helper.IsTokenWhiteSpace (input [index])) {
						while (helper.IsTokenWhiteSpace (GetLookAheadToken (index))) {
							index = index + 1;
						}
					//	output += input [index];

					} 
					else {
					
					}
				}
					
				Console.WriteLine (input[index]);
			}
		}

		private TokenHelper helper = null;
		public string input { get ; set; }
		public string output { get; set; }

	}
}

