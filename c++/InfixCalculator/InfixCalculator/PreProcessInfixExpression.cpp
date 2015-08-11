#pragma once

#include "stdafx.h"

//  Created by Patrick Shim on 10/8/15.
//  Copyright (c) 2015 Microsoft Corporation. All rights reserved.

#include "PreProcessInfixExpression.h"

PreProcessInfixExpression::PreProcessInfixExpression() {
}

PreProcessInfixExpression::PreProcessInfixExpression(const string infixExpression) {
	this->trimmedInfixExpression = infixExpression;
}

PreProcessInfixExpression::PreProcessInfixExpression(const char * infixExpression) {
	string s = string(infixExpression);
	this->rawInfixExpression = s;
}

PreProcessInfixExpression::~PreProcessInfixExpression() {
}

void PreProcessInfixExpression::Process() {

	unsigned int index = 0;
	string concatenated;
	preProcessedInfixExpression.clear();
	trimmedInfixExpression = removespaces(rawInfixExpression);

	while (index < trimmedInfixExpression.length()) {

		// if current token is a digit
		if (TokenHelper::isTokenDigit(trimmedInfixExpression[index])) {

			do {
				// IF current token is a digit, then keep on adding to output string
				if (TokenHelper::isTokenDigit(trimmedInfixExpression[index])) {
					concatenated += cs(trimmedInfixExpression[index]);
					index = index + 1;
				}
				// ELSE IF current index reached end of infix string, then break after adding to output
				else if (index >= trimmedInfixExpression.length()) {
					concatenated += cs(trimmedInfixExpression[index]);
					index = index + 1;
					break;
				}
				// ELSE (if token is a opererator, parenthesis, etc, then BREK after adding to output
				else {
					break;
				};

			} while (true);
			preProcessedInfixExpression.push_back(concatenated);
			concatenated.clear();
		}
		// if current token is an operator ( +, -, *, /, ^, %)
		else if (TokenHelper::isTokenOperator(trimmedInfixExpression[index])) {
			// if current token is a unary operator
			if (TokenHelper::isTokenUnary(trimmedInfixExpression, index)) {
				// if the unary operator is -, then add - symbol to the output without space
				if (trimmedInfixExpression[index] == '-') {
				//	preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
					concatenated = trim(cs(trimmedInfixExpression[index]));
					index = index + 1;
				}
				// if the unary operator is +, then skip to the next position without adding to output)
				else if (trimmedInfixExpression[index] == '+') {
					index = index + 1;
				}
				// if neither, then add token and whitespace to output
				else {
					preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
					index = index + 1;
				}
			}
			else {
				preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
				index = index + 1;
			}
		}
		// if current token is a parenthesis
		else if (TokenHelper::isTokenParenthesis(trimmedInfixExpression[index])) {

			if (index == 0) {
				preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
				index = index + 1;
			}
			else {
				// if open parenthesis, then decide wether it has leading unary operator
				if ((trimmedInfixExpression[index] == '(') || (trimmedInfixExpression[index] == '{') || (trimmedInfixExpression[index]) == '[') {
					// if unary operator, then add "1 * " to output then add current token (i.g. if "-(" then "-1 * (")
					if (TokenHelper::isTokenOperator(trimmedInfixExpression[index - 1])) {

						if (trimmedInfixExpression[index - 1] == '-' || trimmedInfixExpression[index - 1] == '+') {
							concatenated += "1";
							preProcessedInfixExpression.push_back(concatenated );
							preProcessedInfixExpression.push_back("*");
							preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
							concatenated.clear();
							index = index + 1;
						}
						// if not unary ('*', '/', '^', '%') then proceed as normal
						else {
							preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
							index = index + 1;
						}
					}
					// if leading number before open parenthesis then add "* " in-between the parenthesis and the number
					else if (TokenHelper::isTokenDigit(trimmedInfixExpression[index - 1])) {
						preProcessedInfixExpression.push_back("*");
						preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
						index = index + 1;

					}
					// if leading open parenthesis before open parenthesis then add "1 * " in-between the parenthesis ("((" -> "(1 * (")
					else if (TokenHelper::isTokenParenthesis(trimmedInfixExpression[index - 1])) {
						if ((trimmedInfixExpression[index] == ')') || (trimmedInfixExpression[index] == '}') || (trimmedInfixExpression[index]) == ']') {
							preProcessedInfixExpression.push_back("1");
							preProcessedInfixExpression.push_back("*");
							preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
							index = index + 1;
						}
						else {
							preProcessedInfixExpression.push_back("*");
							preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
							index = index + 1;
						}
					}
				}
				// if closing parenthesis then proceed as normal
				else {
					preProcessedInfixExpression.push_back(trim(cs(trimmedInfixExpression[index])));
					index = index + 1;
				}
			}
		}
		// if undefined symbol has been detected in the main while loop
		else {
			cerr.clear();
			cerr << "Invalid symbol [" << trimmedInfixExpression[index] <<"] detected. Preceeding to next token..." << endl;
			index = index + 1;
		}
	}
}

void PreProcessInfixExpression::DisplayPreProcessedInfixExpression() {
	string processed;
	for (auto token: preProcessedInfixExpression) {
		processed += token + " ";
	}
	cout << "Processed: " << rtrim(processed) << endl;
}

string PreProcessInfixExpression::GetPreProcessedInfixExpression() const {
	string processed;
	for (auto token : preProcessedInfixExpression) {
		processed += token + " ";
	}
	return processed;
}

string PreProcessInfixExpression::GetRawInfixExpression() const {
	return rawInfixExpression;
}

void PreProcessInfixExpression::SetRawInfixExpression(string rawInfixExpression) {
	this->rawInfixExpression = rawInfixExpression;
}

void PreProcessInfixExpression::SetRawInfixExpression(char rawInfixExpression[]) {
	string s = string(rawInfixExpression);
	this->rawInfixExpression = s;
}
