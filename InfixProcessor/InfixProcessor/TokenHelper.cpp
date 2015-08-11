//
//  TokenHelper.cpp
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//
#include "TokenType.h"
#include "TokenHelper.h"
namespace TokenHelper {
    
    bool isTokenDigit(char c) {
        return isdigit(c);
    }
    
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
    
    string getStringFromCharacter(char c)
    {
        stringstream ss;
        string s;
        ss << c;
        ss >> s;
        return s;
    }
    
    bool isTokenUnary(string s, int index) {
        
        if ((index == 0) && ((s[index] == '+') || (s[index] == '-'))) {
            return true;
        }
        else if (isTokenOperator(s[index - 1])) {
            return true;
        
        }
        else if (isTokenParenthesis(s[index-1])) {
            return (getParenthesisOpening(s[index - 1]) == PARENTHESIS_OPENING::OPN) ? true: false;
        }
        else {
            return false;
        }
    }
};