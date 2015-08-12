#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#ifndef INFIXCALCULATOR_TOKENTYPE_H
#define INFIXCALCULATOR_TOKENTYPE_H

enum class TOKEN_TYPE {
	NUM = 0,
	OPR = 1,
	PAR = 2,
	SPC = 3,
	TAB = 4,
	NON = 10
};

enum class ASSOCIATIVITY {
	LTR = 0,
	RTR = 1,
};

enum class PARENTHESIS_TYPE {
	SML = 0,
	MID = 1,
	BIG = 2,
	NON = 10
};

enum class PARENTHESIS_OPENING {
	OPN = 0,
	CLS = 1,
	NON = 2
};

enum class NUMBER_TYPE {
	POS = 0,
	NEG = 1
};

enum class PRECEDENCE {
	NUM = 0,
	PAR = 1,
	ADD = 2,
	SUB = 2,
	MUL = 3,
	DIV = 3,
	MOD = 3,
	PWR = 4,
	NON = 10
};

#endif
