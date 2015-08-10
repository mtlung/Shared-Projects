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

#include "TokenType.h"
#include "Token.h"
#include "TokenHelper.h"

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

class InfixCalculator {
public:
    InfixCalculator();
    InfixCalculator(string infix);

public:
    void preprocessInfixExpression();
    void processInfixToPostfix();
    void processPostfixEvaluation();
    
private:

    double result;
    string postfixExpression;
    string infixExpression;
    vector<token> vector;
    stack<string> operatorStack;
    stack<double> operandStack;

private:
    inline  string cs(char c){
        stringstream ss;
        string s;
        ss << c;
        ss >> s;
        return s;
    }
};

#endif
