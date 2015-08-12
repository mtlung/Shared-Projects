#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenHelper.h"
#include "Token.h"

#ifndef POSTFIX_EXPRESSION_TO_CALCULATION_H
#define	POSTFIX_EXPRESSION_TO_CALCULATION_H

class PostfixExpressionToCalculation 
{
public:
	PostfixExpressionToCalculation();
	PostfixExpressionToCalculation(string postfixExression);
	PostfixExpressionToCalculation(char *postfixExpression);
	PostfixExpressionToCalculation(vector<string> postfixExpression);
	
	~PostfixExpressionToCalculation();
	void Process();
	void DisplayPostfixExpression();
	void DisplayPostfixCaculationResult();
	void setPostfixExpression(string postfixExpression);
	void setPostfixExpression(char *postfixExpression);
	void setPostfixExpression(vector<string> postfixExpression);
	string getPostfixExpression() const;
	double getCalculationResult() const;
	
private:
	vector<string> postfixExpression;
	stack <double> operandStack;
	double calculationResult;
};

#endif