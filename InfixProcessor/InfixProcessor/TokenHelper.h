#pragma once
//
//  TokenHelper.h
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//
#include <string>
using std::string;
#include <sstream>
using std::stringstream;

#ifndef InfixProcessor_TokenHelper_h
#define InfixProcessor_TokenHelper_h
namespace TokenHelper {
    bool isTokenDigit(char c);
    bool isTokenOperator(char c);
    bool isTokenUnary(string s, int index);
    bool isTokenParenthesis(char c);
    string getStringFromCharacter(char c);
    PARENTHESIS_OPENING getParenthesisOpening(char c);
}
#endif
