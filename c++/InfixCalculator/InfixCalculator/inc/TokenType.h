#pragma once

#include "../stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.



#ifndef INFIXCALCULATOR_TOKENTYPE_H
#define INFIXCALCULATOR_TOKENTYPE_H

enum class TOKEN_TYPE {
	NUM = 1,
	OPR = 2,
	PAR = 3,
	SPC = 4,
	TAB = 5,
	NON = 10
};

enum class ASSOCIATIVITY {
	LTR = 1,
	RTR = 2,
};

enum class PARENTHESIS_TYPE {
	SML = 1,
	MID = 2,
	BIG = 3,
	NON = 10
};

enum class PARENTHESIS_OPENING {
	OPN = 1,
	CLS = 2,
	NON = 10
};

enum class NUMBER_TYPE {
	POS = 1,
	NEG = 2
};

enum class PRIORITY {
	PRN = 1,
	ADD = 2,
	SUB = 2,
	MUL = 3,
	DIV = 3,
	MOD = 3,
	PWR = 4,
	NON = 10
};

#endif
