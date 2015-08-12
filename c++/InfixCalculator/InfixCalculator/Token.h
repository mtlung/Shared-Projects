#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenType.h"

#ifndef INFIX_CALCULATOR_TOKEN_H
#define INFIX_CALCULATOR_TOKEN_H

class Token
{
public:

	Token() {

	}
	Token(std::string value, TOKEN_TYPE type, PRECEDENCE precedence) {
		this->value = value;
		this->type = type;
		this->precedence = precedence;
	}
	~Token() {}
	
	string value;
	TOKEN_TYPE type;
	PRECEDENCE precedence;
};

#endif
