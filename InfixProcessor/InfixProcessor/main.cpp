//
//  main.cpp
//  InfixProcessor
//
//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#include <iostream>

#include "InfixCalculator.h"

int main(int argc, const char * argv[]) {
 
    InfixCalculator infixCalc("123+45+6789");
    infixCalc.preprocessInfixExpression();
    return 0;
}
