#pragma once
//
//  InfixCalculator.h
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef InfixProcessor_InfixCalculator_h
#define InfixProcessor_InfixCalculator_h

#include <sstream>
using std::stringstream;

#include <iostream>
using std::cout;
using std::cin;
using std::endl;
#include <string>
using std::string;


#include <stack>
#include <vector>
using std::vector;
using std::stack;

#include "TokenType.h"
#include "Token.h"
#include "TokenHelper.h"

class InfixCalculator {
public:
    InfixCalculator();
    InfixCalculator(string infix);
    InfixCalculator(string infix[]);
public:
    void preprocessInfixExpression();
    void processInfixToPostfix();
    void processPostfixEvaluation();
    
public:
    string infixExpression;
    double result;
    
private:
    string postfixExpression;
    vector<token> vector;
    stack<string> operatorStack;
    stack<double> operandStack;

private:
    static inline  std::string cs(char c) {
        std::stringstream ss;
        std::string s;
        ss << c;
        ss >> s;
        return s;
    }
    static inline std::string &removespaces(std::string &s) {
        s.erase(remove_if(s.begin(), s.end(), isspace), s.end());
        return s;
    }
    static inline std::string &ltrim(std::string &s) {
        s.erase(s.begin(), std::find_if(s.begin(), s.end(), std::not1(std::ptr_fun<int, int>(std::isspace))));
        return s;
    }
    
    // trim from end
    static inline std::string &rtrim(std::string &s) {
        s.erase(std::find_if(s.rbegin(), s.rend(), std::not1(std::ptr_fun<int, int>(std::isspace))).base(), s.end());
        return s;
    }
    
    // trim from both ends
    static inline std::string &trim(std::string &s) {
        return ltrim(rtrim(s));
    }
};

#endif
