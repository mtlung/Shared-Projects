// InfixCalculator.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "PreProcessInfixExpression.h"

int main(int argc, const char * argv[]) {

	string userInput;
	PreProcessInfixExpression infixCalc;

	do {
		cout << "Enter expression to evaluate: " << endl;
		getline(cin, userInput);
		if (!userInput.empty()) {
			infixCalc.rawInfixExpression = userInput;
			infixCalc.Process();
			infixCalc.DisplayPreProcessedInfixExpression();
	//		infixCalc.processInfixToPostfix();
		}
	} while (userInput.length() > 0);
	cout << "Execution terminated..." << endl;
	return 0;
}