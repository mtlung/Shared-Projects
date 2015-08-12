#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenType.h"

#ifndef INFIXCALCULATOR_TOKENHELPER_H
#define INFIXCALCULATOR_TOKENHELPER_H

namespace TokenHelper {
	bool isTokenDigit(char c);
	bool isTokenOperator(char c);
	bool isTokenUnary(string s, int index);
	bool isTokenParenthesis(char c);
	bool isTokenParenthesis(string s);
	bool isTokenNumber(string s);
	bool isTokenOperator(string s);
	bool convertStringToDouble(string s, double &d);
	TOKEN_TYPE getTokenType(string s);
	OPERATOR_TYPE getOperatorType(string s);
	PRECEDENCE getTokenPrecedence(string s);
	PARENTHESIS_OPENING getParenthesisOpening(string s);
	PARENTHESIS_OPENING getParenthesisOpening(char c);
	string convertCharToString(char c);
	vector<string> convertStringToVector(string s);
}
#endif
