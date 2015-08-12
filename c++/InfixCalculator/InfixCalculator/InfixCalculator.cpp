#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "PreProcessInfixExpression.h"
#include "InfixExpressionToPostfix.h"
#include "PostfixExpressionToCalculation.h"
int main(int argc, const char * argv[]) {

	string userInput;
	PreProcessInfixExpression infixProcessor;
	InfixExpressionToPostfix infixToPostfix;
	PostfixExpressionToCalculation postfixCalculator;

	
	do {
		cout << "Enter expression to evaluate: " << endl;
		getline(cin, userInput);
		if (!userInput.empty()) {

			infixProcessor.SetRawInfixExpression(userInput);
			infixProcessor.Process();
			infixProcessor.DisplayPreProcessedInfixExpression();
			
			string preProcessedInfixExpression = infixProcessor.GetPreProcessedInfixExpression();

			infixToPostfix.setInfixExpression(preProcessedInfixExpression);
			infixToPostfix.DisplayInfixExpression();
			infixToPostfix.Process();			
			infixToPostfix.DisplayPostfixExpression();

			string postfixExpression = infixToPostfix.getPostfixExpression();

			postfixCalculator.setPostfixExpression(postfixExpression);
			postfixCalculator.DisplayPostfixExpression();
			postfixCalculator.Process();
			postfixCalculator.DisplayPostfixCaculationResult();
		
		}
	} while (userInput.length() > 0);
	cout << "Execution terminated..." << endl;
	return 0;
}