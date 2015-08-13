#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "InfixExpressionToPostfix.h"

InfixExpressionToPostfix::InfixExpressionToPostfix() 
{

}

InfixExpressionToPostfix::InfixExpressionToPostfix(string infixExpression) 
{
	this->setInfixExpression(infixExpression);
}

InfixExpressionToPostfix::InfixExpressionToPostfix(char * infixExpression) 
{
	this->setInfixExpression(infixExpression);
}

InfixExpressionToPostfix::InfixExpressionToPostfix(vector<string> infixExpression) 
{
	this->setInfixExpression(infixExpression);
}

InfixExpressionToPostfix::~InfixExpressionToPostfix() {
}

void InfixExpressionToPostfix::Process()
{
	Token token;
	postfixExpression.clear();

	for (unsigned index = 0; index < infixExpression.size(); index++) {
		
		token.value = infixExpression.at(index);
		token.type = TokenHelper::getTokenType(infixExpression.at(index));
		token.precedence = TokenHelper::getTokenPrecedence(infixExpression.at(index));
			
		if (token.type == TOKEN_TYPE::NUM)
		{
			postfixExpression.push_back(token);
		}
		else if (token.type == TOKEN_TYPE::OPR) {

			if (operatorStack.empty())
			{
				operatorStack.push(token);
			}
			else 
			{
				while (!operatorStack.empty() && TokenHelper::isTokenOperator(operatorStack.top().value) && (token.precedence <= operatorStack.top().precedence)) 
				{
					postfixExpression.push_back(operatorStack.top());
					operatorStack.pop();
				}
				operatorStack.push(token);
			}
		}
		else if (token.type == TOKEN_TYPE::PAR) {

			if (TokenHelper::getParenthesisOpening(token.value) == PARENTHESIS_OPENING::OPN)
			{
				operatorStack.push(token);
			}
			else if (TokenHelper::getParenthesisOpening(token.value) == PARENTHESIS_OPENING::CLS)
			{
				while (TokenHelper::getParenthesisOpening(operatorStack.top().value) != PARENTHESIS_OPENING::OPN)
				{
					postfixExpression.push_back(operatorStack.top());
					operatorStack.pop();
				}
				operatorStack.pop();
			}
		}
	}

	while (!operatorStack.empty()) {
		postfixExpression.push_back(operatorStack.top());
		operatorStack.pop();
	}
}

void InfixExpressionToPostfix::DisplayInfixExpression()
{
	int index = 0;
	cout << "----- INPUT PREFIX----- " << endl;
	for (auto token : infixExpression)
	{
		cout << "\'" << token << "\' ";
		index = index + 1;
	}
	cout << endl;
}

void InfixExpressionToPostfix::DisplayPostfixExpression()
{
	unsigned int index = 0;
	cout << "----- POSTFIX ----- " << endl;
	for (auto token : postfixExpression)
	{
		cout << "token at[" << index << "]:" << token.value << endl;
		index = index + 1;
	}
}

void InfixExpressionToPostfix::setInfixExpression(string infixExpression) {

	this->infixExpression = TokenHelper::convertStringToVector(infixExpression);
}

void InfixExpressionToPostfix::setInfixExpression(char * infixExpression)
{
	this->infixExpression = TokenHelper::convertStringToVector(infixExpression);
}

void InfixExpressionToPostfix::setInfixExpression(vector<string> infixExpression)
{
	this->infixExpression = infixExpression;
}

string InfixExpressionToPostfix::getInfixExpression() const
{
	string buffer;
	for (auto token : infixExpression)
	{
		buffer.append(token);
		buffer.append(" ");
	}

	return buffer;
}

string InfixExpressionToPostfix::getPostfixExpression() const
{
	string buffer;
	for (auto token : postfixExpression)
	{
		buffer.append(token.value);
		buffer.append(" ");
	}

	return buffer;
}
