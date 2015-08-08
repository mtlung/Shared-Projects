using System;

namespace Infix
{
	public class InfixNormalizer
	{
		public InfixNormalizer () { 
		}

		public InfixNormalizer (char[] infix) {
			
			this.Infix = new string (infix);
		}

		public InfixNormalizer(string infix) {
			
			this.Infix = infix;
		}

		public void Normalize()
		{
			PreProcessInfix ();
			int index = 0;
			normalized = null;

			while (!(index >= Infix.Length)) {
				
				if (TokenHelper.IsTokenDigit (Infix [index])) {
					
					do {
						
						if (!TokenHelper.IsTokenDigit (Infix [index])) {
							
							normalized += " ";
							break;

						} else if (IsEndOfString (index)) {
							
							normalized += Infix [index++];
							break;

						} else {
							
							normalized += Infix [index++];
						}

					} while(true);

				} else if (TokenHelper.IsTokenOperator (Infix [index])) {
					
					if (IsTokenUnary (Infix, index)) {
						
						if (Infix [index] == '-') {
							
							normalized += Infix [index++];

						} else if (Infix [index] == '+') {
							
							index = index + 1;	

						} else {
							
							normalized += Infix [index++] + " ";

						}

					} else {
						
						normalized += Infix [index++] + " ";

					}

				} else if (TokenHelper.IsTokenParenthesis (Infix [index])) {
					
					if (index == 0) {
						
						normalized += Infix [index++] + " ";

					} else {
						
						if (Infix [index] == '(') {
							
							if (TokenHelper.IsTokenOperator (Infix [index - 1])) {
								
								if (Infix [index - 1] == '-' || Infix [index - 1] == '+') {
									
									normalized += "1 * " + Infix [index++] + " ";

								} else {
									
									normalized += Infix [index++] + " ";
								}

							} else if (TokenHelper.IsTokenDigit (Infix[index - 1])){
								
								normalized += "* " + Infix [index++] + " ";
							}
						} else {
							
							normalized += Infix [index++] + " ";
						}
					}

				} else {
					
					normalized += Infix [index++] + " ";
				}
			}					// end of main while (index < Infix.Length)
		}

		private bool IsEndOfString(int index) {
			
			return (index >= Infix.Length - 1) ? true : false;

		}

		private bool IsTokenUnary(string s, int index) {
			
			if (index == 0) {
				
				return true;

			} else if (TokenHelper.IsTokenOperator (s [index - 1])) {
				
				return true;

			} else if (TokenHelper.IsTokenParenthesis (s [index - 1])) {
				
				if (s [index - 1] == '(') { return true; } 
				else { return false; }

			} else {
				
				return false;

			}
		}

		private void PreProcessInfix() {
			Infix = Infix.Replace ( " ", "");
			Infix = Infix.Replace ("\t", "");
			Infix = Infix.Trim ();
		}

		private string postfix = null;
		private string normalized = null;
		public string Normalized { get { return normalized; } }
		public string Infix {get; set; }
		public string Postfix {get; set; }
	}
}