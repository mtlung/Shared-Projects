#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenHelper.h"
#include "TokenType.h"

namespace TokenHelper {

	bool isTokenOperator(char c) {
		switch (c)
		{
		case '+': return true; break;
		case '-': return true; break;
		case '*': return true; break;
		case '/': return true; break;
		case '%': return true; break;
		case '^': return true; break;
		default: return false; break;
		}
	}

	bool isTokenOperator(string s)
	{
		if ((s == "+") || (s == "-") || (s == "*") || (s == "/") || (s == "%") || (s == "^"))
			return true;
		else 
			return false;
	}

	bool isTokenParenthesis(string s)
	{
		if ((s == "(") || (s == "[") || (s == "{") || (s == "}") || (s == "]") || (s == ")"))
			return true;
		else 
			return false;
	}

	bool isTokenParenthesis(char c) {
		switch (c) {
		case '(': return true; break;
		case '{': return true; break;
		case '[': return true; break;
		case ')': return true; break;
		case '}': return true; break;
		case ']': return true; break;
		default: return false; break;
		}
	}

	PARENTHESIS_OPENING getParenthesisOpening(string c)
	{
		if (c == "(" || c == "{" || c == "[")
			return PARENTHESIS_OPENING::OPN;
		else if (c == ")" || c == "}" || c == "]")
			return PARENTHESIS_OPENING::CLS;
		else
			return PARENTHESIS_OPENING::NON;
	}

	PARENTHESIS_OPENING getParenthesisOpening(char c)
	{
		if (c == '(' || c == '{' || c == '[')
			return PARENTHESIS_OPENING::OPN;
		else if (c == ')' || c == '}' || c == ']')
			return PARENTHESIS_OPENING::CLS;
		else
			return PARENTHESIS_OPENING::NON;
	}

	bool isTokenDigit(char c) {
		return (isdigit(c) > 0) ? true : false;
	}

	bool isTokenNumber(string s) {

		bool isNumber = true;
		for (string::const_iterator it = s.begin(); it != s.end(); ++it)
		{
			isNumber = isNumber && isdigit(*it);
		}
		return isNumber;
	}

	TOKEN_TYPE getTokenType(string s)
	{
		if (isTokenNumber(s)) {
			return TOKEN_TYPE::NUM;
		}
		else if (isTokenOperator(s)) {
			return TOKEN_TYPE::OPR;
		}
		else if (isTokenParenthesis(s)) {
			return TOKEN_TYPE::PAR;
		}
		else {
			return TOKEN_TYPE::NON;
		}
	}

	PRECEDENCE getTokenPrecedence(string s)
	{
		if (s == "+")
			return PRECEDENCE::ADD;
		else if (s == "-")
			return PRECEDENCE::SUB;
		else if (s == "*")
			return PRECEDENCE::MUL;
		else if (s == "/")
			return PRECEDENCE::DIV;
		else if (s == "^")
			return PRECEDENCE::PWR;
		else if (s == "%")
			return PRECEDENCE::MOD;
		else if (TokenHelper::isTokenParenthesis(s))
			return PRECEDENCE::PAR;
		else if (TokenHelper::isTokenNumber(s))
			return PRECEDENCE::NON;
		else
			return PRECEDENCE::NON;
	}

	bool isTokenUnary(string s, int index) {

		if ((index == 0) && ((s[index] == '+') || (s[index] == '-'))) {
			return true;
		}
		else if (isTokenOperator(s[index - 1])) {
			return true;
		}
		else if (isTokenParenthesis(s[index - 1])) {
			return (getParenthesisOpening(s[index - 1]) == PARENTHESIS_OPENING::OPN) ? true : false;
		}
		else {
			return false;
		}
	}
};