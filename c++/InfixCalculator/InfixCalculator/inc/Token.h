#pragma once

#include "inc/stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenType.h"

#ifndef INFIX_CALCULATOR_TOKEN_H
#define INFIX_CALCULATOR_TOKEN_H

class Token
{
public:

	Token(std::string value, TOKEN_TYPE type) {
		this->value = value;
		this->type = TOKEN_TYPE::NON;
	}
	~Token() {}
	
	std::string value;
	TOKEN_TYPE type;
};

#endif
