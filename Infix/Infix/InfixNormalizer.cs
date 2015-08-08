using System;

namespace Infix
{
	public class InfixNormalizer
	{
		public InfixNormalizer ()
		{
		}

		public InfixNormalizer(string infix)
		{
			this.Infix = infix;
		}

		public void Normalize()
		{
			PreProcessInfix ();
			int index = 0;
			Normalized = String.Empty;
			while (!(index >= Infix.Length)) {
				if (TokenHelper.IsTokenDigit (Infix [index])) {
					do {
						if (!TokenHelper.IsTokenDigit (Infix [index])) {
							Normalized += " ";
							break;

						} else if (IsEndOfString (index)) {
							Normalized += Infix [index];
							index = index + 1;
							break;

						} else {
							Normalized += Infix [index];
							index = index + 1;
						}
					} while(true);

				} else if (TokenHelper.IsTokenOperator (Infix [index])) {
					if (IsTokenUnary (Infix, index)) {
						if (Infix [index] == '-') {
							Normalized += Infix [index];
							index = index + 1;

						} else if (Infix [index] == '+') {
							index = index + 1; 

						} else {
							Normalized += Infix [index];
							Normalized += " ";
							index = index + 1;
						}
					} else {
						Normalized += Infix [index];
						Normalized += " ";
						index = index + 1;
					}
				} else if (TokenHelper.IsTokenParenthesis (Infix [index])) {
					if (index == 0) {
						Normalized += Infix [index];
						Normalized += " ";
						index = index + 1;

					} else {
						if (Infix [index] == '(') {
							if (TokenHelper.IsTokenOperator (Infix [index - 1])) {
								if (Infix [index - 1] == '-' || Infix [index - 1] == '+') {
									Normalized += "1 * ";
									Normalized += Infix [index];
									Normalized += " ";
									index = index + 1;

								} else {
									Normalized += Infix [index];
									Normalized += " ";
									index = index + 1;
								}
							} else if (TokenHelper.IsTokenDigit (Infix[index - 1])){
								Normalized += "* ";
								Normalized += Infix [index];
								Normalized += " ";
								index = index + 1;
							}
						} else {
							Normalized += Infix [index];
							Normalized += " ";
							index = index + 1;
						}
					}
				} else {
					Normalized += Infix [index];
					Normalized += " ";
					index = index + 1;
				}
			}					// end of main while (index < Infix.Length)
			Console.WriteLine (Normalized);
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
				if (s [index - 1] == '(') {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}

		}
		private void PreProcessInfix() {
			Infix = Infix.Replace ( " ", "");
			Infix = Infix.Replace ("\t", "");
			Infix = Infix.Trim ();
		}

		public string Normalized { get; set; }
		public string Infix {get; set; }
		public string Postfix {get; set; }
	}
}