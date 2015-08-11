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
		{
			return true;
		}
		else { return false; }
	}
	bool isTokenParenthesis(string s)
	{
		if ((s == "(") || (s == "[") || (s == "{") || (s == "}") || (s == "]") || (s == ")"))
		{
			return true;
		}
		else { return false; }
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

	PARENTHESIS_OPENING getParenthesisOpening(char c)
	{
		switch (c) {
		case '(': return PARENTHESIS_OPENING::OPN; break;
		case '{': return PARENTHESIS_OPENING::OPN; break;
		case '[': return PARENTHESIS_OPENING::OPN; break;
		case ')': return PARENTHESIS_OPENING::CLS; break;
		case '}': return PARENTHESIS_OPENING::CLS; break;
		case ']': return PARENTHESIS_OPENING::CLS; break;
		default: return PARENTHESIS_OPENING::NON; break;
		}
	}

	bool isTokenDigit(char c) {
		return (isdigit(c) > 0) ? true : false;
	}

	bool isTokenNumber(string s) {
		stringstream ss;
		ss << s;
		double number = 0.0f;
		ss >> number;
		if (ss.good()) {
			return false;
		}
		else if (number == 0 && s[0] != '0') {
			return false;
		}
		else {
			return true;
		}
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