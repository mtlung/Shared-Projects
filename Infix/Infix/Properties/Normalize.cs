using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.IO;
using System.Collections.Specialized;

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

		private char GetLookAheadToken(int index) {
			return (index < input.Length - 1) ? input [index + 1] : '\0';
		}

		public void Normalization() {
			helper = new TokenHelper ();
			string normalized = string.Empty;

			for (int index = 0; index < input.Length; index++) {
				if (helper.IsTokenNumber (input [index])) {
					normalized += input [index];
				}
				else if (helper.IsTokenOperator (input [index])) {
					if (input [index] == '-') {
						if (helper.IsTokenNumber (GetLookAheadToken (index))) {
							normalized += input [index++];
							normalized += input [index++];
						} 
						else if (helper.IsTokenParenthesis (GetLookAheadToken (index))) {
							normalized += "-1*";
							index++;
						}
						else {
							normalized += input [index++];
						}
						normalized += input [index];
					} else if (input [index] == '+') {
						if (helper.IsTokenNumber (GetLookAheadToken (index))) {
							index = index + 1;
							normalized += input [index++];
						} else {
							normalized += input [index++];
						}
						normalized += input [index];
					} else {
						normalized += input [index];
					}
				}
				else if (helper.IsTokenParenthesis (input [index])) {
					normalized += input [index];
				} 
				else {
					if (helper.IsTokenWhiteSpace (input [index])) {
						while (helper.IsTokenWhiteSpace (GetLookAheadToken (index))) {
							index++;
						}
						normalized += input [index];
					} 
				}
			}

			for (int index = 0; index < normalized.Length; index++) {
				if (helper.IsTokenNumber (normalized [index])) {
					for (;helper.IsTokenNumber (normalized[index]);) {
						index++;
						output += normalized [index];					
					}
					output += ' ';
				} else if (helper.IsTokenOperator (normalized [index])) {
					Console.WriteLine ("operator detected");
					output += normalized [index++];

				} else if (helper.IsTokenParenthesis (normalized [index])) {
					output += normalized [index++];
				
				} else if (helper.IsTokenWhiteSpace (normalized [index])) {
					output += normalized [index++];
						
				} else {
					index++;
				}
			}
			Console.WriteLine ("normalized: {0}", normalized);
			Console.WriteLine ("final output: {0}", output);
		}

		private TokenHelper helper = null;
		public string input { get ; set; }
		public string output { get; set; }

	}
}

