//
//  InfixCalculator.cpp
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//


#include "InfixCalculator.h"

InfixCalculator::InfixCalculator() {
    
}

InfixCalculator::InfixCalculator(string infix) {
    this->infixExpression = infix;
}

void InfixCalculator::preprocessInfixExpression() {
    
    int index = 0;
    string preProcessedInfixExpression;

    while (infixExpression[index]) {
        // if current token is a digit
        if (TokenHelper::isTokenDigit(infixExpression[index])) {
            
            do {
                // IF current token is a digit, then keep on adding to output string
                if (TokenHelper::isTokenDigit(infixExpression[index])) {
                    preProcessedInfixExpression += cs(infixExpression[index]);
                    index = index + 1;
                }
                // ELSE IF current index reached end of infix string, then break after adding to output
                else if (index >= infixExpression.length()) {
                    preProcessedInfixExpression += cs(infixExpression[index]);
                    index = index + 1;
                    break;
                }
                // ELSE (if token is a opererator, parenthesis, etc, then BREK after adding to output
                else {
                    preProcessedInfixExpression += " ";
                    break;
                }
            } while (true);
        }
        // if current token is an operator ( +, -, *, /, ^, %)
        else if (TokenHelper::isTokenOperator(infixExpression[index])) {
            // if current token is a unary operator
            if (TokenHelper::isTokenUnary(infixExpression, index)) {
                // if the unary operator is -, then add - symbol to the output without space
                if (infixExpression [index] == '-') {
                    preProcessedInfixExpression += cs(infixExpression [index++]);
                }
                // if the unary operator is +, then skip to the next position without adding to output)
                else if (infixExpression [index] == '+') {
                    index = index + 1;
                    
                }
                // if neither, then add token and whitespace to output
                else {
                    preProcessedInfixExpression += cs(infixExpression[index++]) + " ";
                }
            }
            else {
                preProcessedInfixExpression += cs(infixExpression [index++]) + " ";
            }
        } // End if token is an operator
        else if (TokenHelper::isTokenParenthesis(infixExpression[index])) {
            
            if (index == 0) {
                preProcessedInfixExpression += cs(infixExpression [index++]) + " ";
            }
            else {
                
                if ((infixExpression [index] == '(') || (infixExpression[index] == '{') || (infixExpression[index]) == '[') {
                    
                    if (TokenHelper::isTokenOperator(infixExpression [index - 1])) {
                        
                        if (infixExpression [index - 1 ] == '-' || infixExpression [index - 1] == '+') {
                            preProcessedInfixExpression += "1 * " + cs(infixExpression [index++]) + " ";
                        }
                        else {
                            preProcessedInfixExpression += cs(infixExpression [index++]) + " ";
                        }
                    }
                    else if (TokenHelper::isTokenDigit (infixExpression [index - 1])) {
                        preProcessedInfixExpression += "* " + cs(infixExpression [index++]) + " ";
                    
                    }
                    else if (TokenHelper::isTokenParenthesis (infixExpression [index - 1])) {
                        preProcessedInfixExpression += "1 * " + cs(infixExpression [index++]) + " ";
                    }
                }
                else {
                    preProcessedInfixExpression += cs(infixExpression [index++]) + " ";
                }	
            }
        }
        else {
            preProcessedInfixExpression += cs(infixExpression [index++]) + " ";
        }
    }
    cout<<"Preprocessed: "<<preProcessedInfixExpression<<endl;
}

void InfixCalculator::processInfixToPostfix() {
    
}

void InfixCalculator::processPostfixEvaluation() {
    
}