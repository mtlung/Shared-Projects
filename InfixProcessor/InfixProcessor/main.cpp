//
//  main.cpp
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#include <iostream>
using std::cout;
using std::cin;
using std::endl;

#include <string>
using std::string;

#include "InfixCalculator.h"

int main(int argc, const char * argv[]) {
 
    string userInput;
    InfixCalculator infixCalc;
    
    do {
        cout<<"Enter expression to evaluate: "<<endl;
        getline(cin, userInput);
        if (!userInput.empty()) {
            infixCalc.infixExpression = userInput;
            infixCalc.preprocessInfixExpression();
        }
    } while (userInput.length() > 0);
    cout<<"Execution terminated..."<<endl;
    
    return 0;
}
