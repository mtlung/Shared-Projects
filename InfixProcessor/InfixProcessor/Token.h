#pragma once
//
//  Token.h
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//
#include "TokenType.h"
#include <string>
using std::string;

#ifndef InfixProcessor_Token_h
#define InfixProcessor_Token_h
class token {
public:
    string value;
    TOKEN_TYPE type;
};

#endif
