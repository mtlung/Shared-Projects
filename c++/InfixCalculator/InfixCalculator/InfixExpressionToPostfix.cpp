#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "InfixExpressionToPostfix.h"

InfixExpressionToPostfix::InfixExpressionToPostfix()
{
}


InfixExpressionToPostfix::~InfixExpressionToPostfix()
{
}

void InfixExpressionToPostfix::Process()
{
	for (auto item : infixExpression)
	{
		Token token(item, TokenHelper::getTokenType(item));
	}
}