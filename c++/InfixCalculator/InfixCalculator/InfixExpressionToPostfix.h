#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenHelper.h"
#include "Token.h"

#ifndef INFIXCALCULATOR_INFIXEXPRESSIONTOPOSTFIX_H
#define INFIXCALCULATOR_INFIXEXPRESSIONTOPOSTFIX_H

class InfixExpressionToPostfix
{
public:
	InfixExpressionToPostfix();
	~InfixExpressionToPostfix();
public:
	void Process();

public:
	vector <string> infixExpression;
private:
	vector<Token> postfixExpression; 
	vector<Token> operatorStack;
};

#endif