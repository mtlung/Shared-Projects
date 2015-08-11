#pragma once

#include "stdafx.h"
#include "TokenType.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#ifndef INFIXCALCULATOR_TOKENHELPER_H
#define INFIXCALCULATOR_TOKENHELPER_H

namespace TokenHelper {
	inline bool isTokenDigit(char c) {
		return isdigit(c);
	}
	bool isTokenOperator(char c);
	bool isTokenUnary(string s, int index);
	bool isTokenParenthesis(char c);
	string getStringFromCharacter(char c);
	PARENTHESIS_OPENING getParenthesisOpening(char c);
}
#endif
