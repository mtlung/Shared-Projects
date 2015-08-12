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
	InfixExpressionToPostfix(string infixExpression);
	InfixExpressionToPostfix(char* infixExpression);
	InfixExpressionToPostfix(vector<string> infixExpression);
	~InfixExpressionToPostfix();

public:
	void Process();
	void DisplayInfixExpression();
	void DisplayPostfixExpression();
	void setInfixExpression(string infixExpression);
	void setInfixExpression(char *infixExpression);
	void setInfixExpression(vector<string> infixExpression);
	string getInfixExpression() const;
	string getPostfixPexression() const;

private:
	vector <string> infixExpression;
	vector<Token> postfixExpression;
	stack <Token> operatorStack;

private:
	
	inline vector<string> stov(string s)
	{
		string buffer("");
		int i = 0;
		buffer.clear();
		vector<string> temp;
		for (auto token : s)
		{
			while(true)
			{
				if (token == ' ' || token == '/0')
					break;
				else;
				buffer.append(token, 1);
				
				break;
			}
		}
		cout<<buffer<<endl;
		return temp;
	}
	
};

#endif