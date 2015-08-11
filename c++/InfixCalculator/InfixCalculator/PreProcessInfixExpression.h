#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "TokenHelper.h"

#ifndef INFIXCALCULATOR_PREPROCESSINFIXEXPRESSION_H
#define INFIXCALCULATOR_PREPROCESSINFIXEXPRESSION_H

class PreProcessInfixExpression
{
public:
	PreProcessInfixExpression();
	PreProcessInfixExpression(const string infixExpression);
	PreProcessInfixExpression(const char *infixExpression);
	~PreProcessInfixExpression();

public:
	void Process();
	void DisplayPreProcessedInfixExpression();
	string GetPreProcessedInfixExpression() const;
	string GetRawInfixExpression() const;
	void SetRawInfixExpression(string rawInfixExpression);
	void SetRawInfixExpression(char rawInfixExpression[]);
	

private:
	vector<string> preProcessedInfixExpression;
	string trimmedInfixExpression;
	string rawInfixExpression;
private:
	inline string cs(char c) {
		stringstream ss;
		string s;
		ss << c;
		ss >> s;
		return s;
	}

	inline string &removespaces(string &s) {
		s.erase(remove(s.begin(), s.end(), ' '), s.end());
		return s;
	}

	inline string &ltrim(string &s) {
		s.erase(s.begin(), find_if(s.begin(), s.end(), not1(std::ptr_fun<int, int>(std::isspace))));
		return s;
	}

	inline std::string &rtrim(std::string &s) {
		s.erase(std::find_if(s.rbegin(), s.rend(), std::not1(std::ptr_fun<int, int>(std::isspace))).base(), s.end());
		return s;
	}

	inline std::string trim(std::string s) {
		return ltrim(rtrim(s));
	}

	inline std::string &trim(std::string &s) {
		return ltrim(rtrim(s));
	}
};

#endif
