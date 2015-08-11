#pragma once

#include "../stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "../inc/TokenType.h"

#ifndef INFIXCALCULATOR_TOKENHELPER_H
#define INFIXCALCULATOR_TOKENHELPER_H

namespace TokenHelper {
	inline bool isTokenDigit(char c) {
		return (isdigit(c) > 0) ? true : false;
	}
	bool isTokenOperator(char c);
	bool isTokenUnary(string s, int index);
	bool isTokenParenthesis(char c);
	PARENTHESIS_OPENING getParenthesisOpening(char c);
}
#endif
