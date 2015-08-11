#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "PreProcessInfixExpression.h"
#include "InfixExpressionToPostfix.h"

int main(int argc, const char * argv[]) {

	string userInput;
	PreProcessInfixExpression infixCalc;
	InfixExpressionToPostfix infixToPostfix;
	string preProcessedInfixExpression;

	do {
		cout << "Enter expression to evaluate: " << endl;
		getline(cin, userInput);
		if (!userInput.empty()) {
			infixCalc.SetRawInfixExpression(userInput);
			infixCalc.Process();
			infixCalc.DisplayPreProcessedInfixExpression();
			preProcessedInfixExpression = infixCalc.GetPreProcessedInfixExpression();
			infixToPostfix.Process();
	//		infixCalc.processInfixToPostfix();
		}
	} while (userInput.length() > 0);
	cout << "Execution terminated..." << endl;
	return 0;
}