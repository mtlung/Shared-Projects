using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace InfixCalculator
{	
	public class InfixPostfixProcessor
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Infix.InfixPostfixProcessor"/> class.
		/// </summary>
		public InfixPostfixProcessor () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Infix.InfixPostfixProcessor"/> class.
		/// </summary>
		/// <param name="infixExpression">string</param>
		public InfixPostfixProcessor(string infixExpression) {
			
			this.InfixExpression = infixExpression;
		}
		/// <summary>
		/// Calculates postfix expression.  Produces a (double) numerical result
		/// </summary>
		public void ProcessPostfixCaculation() {
			
			double operand1 = 0.0f;
			double operand2 = 0.0f;
			operandStack = new Stack<double> ();

			foreach (Token token in postfixExpression) {
				
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

								if (operand2 == 0) {
									throw new DivideByZeroException ("Zero-division while postfix process at OPERATOR.DIV");
								} else {
									operandStack.Push ((double)operand1 / operand2);
								}
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
								calculationResult = 0.0f;
							}
							break;

						default: 
							{
								calculationResult = 0.0f;
							}
							break;
						}
					}
					break;
				}
			}

			calculationResult = operandStack.Pop ();
		}
		/// <summary>
		/// Processes pre-processed infix expression to postfix.
		/// </summary>
		public void ProcessInfixToPostfix() {
			
			postfixExpression = new List<Token> ();
			operatorStack = new Stack<Token> ();

			foreach (string currentToken in normalizedInfixExression) {
				
				Token token = new Token ();
				token.Value = currentToken;
				token.Type = TokenHelper.GetTokenType (currentToken);
				token.Precedence = TokenHelper.GetPrecedence (currentToken);

				switch (token.Type) {

				case TOKENTYPE.NUMBER:
					{
						postfixExpression.Add (token);
					}
					break;

				case TOKENTYPE.OPERATOR:
					{
						if (operatorStack.Count < 1) {
							
							operatorStack.Push (token);

						} else {

							while ((operatorStack.Count > 0) && 
								(TokenHelper.IsTokenOperator (operatorStack.Peek ().Value)) && 
								(token.Precedence <= operatorStack.Peek ().Precedence)) {
								postfixExpression.Add (operatorStack.Pop ());
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
								postfixExpression.Add (operatorStack.Pop ());
							}
							operatorStack.Pop ();
						}
					}
					break;
				} 
			}			
		
			while (operatorStack.Count > 0) {	
				postfixExpression.Add (operatorStack.Pop ());
			}

			int index = 0;
			Console.WriteLine ("In Postfix List:");
			foreach (Token l in postfixExpression) {
				Console.WriteLine ("L[{0}]: {1}", index++, l.Value);
			}
		}
        /// <summary>
        /// Pre-process infix expression.  The method removes and re-formats leading, tailing and other exccessive
        /// whitespaces in infix expression.  
        /// </summary>
        public void PreProcessInfixExpresion()
        {

            TrimInfixExpression();

            int index = 0;
            string preProccessedInfixExpression = null; ;

            while (!(index >= InfixExpression.Length))
            {
                if (TokenHelper.IsTokenDigit(InfixExpression[index]))
                {
                    do
                    {
                        if (!TokenHelper.IsTokenDigit(InfixExpression[index]))
                        {
                            preProccessedInfixExpression += " ";
                            break;
                        }
                        else if (index >= InfixExpression.Length - 1)
                        {
                            preProccessedInfixExpression += InfixExpression[index++];
                            break;
                        }
                        else
                        {
                            preProccessedInfixExpression += InfixExpression[index++];
                        }
                    } while (true);
                }
                else if (TokenHelper.IsTokenOperator(InfixExpression[index]))
                {
                    if (TokenHelper.IsTokenUnary(InfixExpression, index))
                    {
                        if (InfixExpression[index] == '-')
                        {
                            preProccessedInfixExpression += InfixExpression[index++];
                        }
                        else if (InfixExpression[index] == '+')
                        {
                            index = index + 1;
                        }
                        else
                        {
                            preProccessedInfixExpression += InfixExpression[index++] + " ";
                        }
                    }
                    else
                    {
                        preProccessedInfixExpression += InfixExpression[index++] + " ";
                    }
                }
                else if (TokenHelper.IsTokenParenthesis(InfixExpression[index]))
                {
                    if (index == 0)
                    {
                        preProccessedInfixExpression += InfixExpression[index++] + " ";
                    }
                    else
                    {
                        if ((InfixExpression[index] == '(') || (InfixExpression[index] == '{') || (InfixExpression[index] == '['))
                        {
                            if (TokenHelper.IsTokenOperator(InfixExpression[index - 1]))
                            {
                                if (InfixExpression[index - 1] == '-' || InfixExpression[index - 1] == '+')
                                {
                                    preProccessedInfixExpression += "1 * " + InfixExpression[index++] + " ";
                                }
                                else
                                {
                                    preProccessedInfixExpression += InfixExpression[index++] + " ";
                                }
                            }
                            else if (TokenHelper.IsTokenDigit(InfixExpression[index - 1]))
                            {
                                preProccessedInfixExpression += "* " + InfixExpression[index++] + " ";
                            }
                            else if (TokenHelper.IsTokenParenthesis(InfixExpression[index - 1]))
                                if ((InfixExpression[index - 1] == ')') || (InfixExpression[index - 1] == '}') || (InfixExpression[index - 1] == ']'))
                                {
                                    preProccessedInfixExpression += " * " + InfixExpression[index++] + " ";
                                }
                                else
                                {
                                    preProccessedInfixExpression += "1 * " + InfixExpression[index++] + " ";
                                }
                        }
                        else
                        {
                            preProccessedInfixExpression += InfixExpression[index++] + " ";
                        }
                    }
                }
                else
                {
                    preProccessedInfixExpression += InfixExpression[index++] + " ";
                }
            }

            Console.WriteLine("Normalized: {0}", preProccessedInfixExpression);

            normalizedInfixExression = preProccessedInfixExpression.Split(' ');
        }

		public override string ToString ()
		{
			return string.Format ("[InfixPostfixProcessor]\nInfixExpression:\t{0}\nNormalizedInfixExpression:\t{1}\nCalculationResult:\t{2}\n", InfixExpression, NormalizedInfixExpression, CalculationResult);
		}

		private void TrimInfixExpression() {
			InfixExpression = InfixExpression.Replace ( " ", "");
			InfixExpression = InfixExpression.Replace ("\t", "");
			InfixExpression = InfixExpression.Trim ();
		}

        #region member variables   
        private string[] normalizedInfixExression = null;
		private string[] infixExpiression = null;
		private double calculationResult = 0.0f;
		private List<Token> postfixExpression = null;
		private Stack<Token> operatorStack = null;
		private Stack<double> operandStack = null;
        #endregion

        #region properties
        public double CalculationResult { get { return calculationResult; } }
		public string InfixExpression  { get { return String.Join (" ", infixExpiression); } set { infixExpiression = value.Split (' '); } }
		public string NormalizedInfixExpression { get { return String.Join (" ", normalizedInfixExression); } }
        #endregion
    }
}



