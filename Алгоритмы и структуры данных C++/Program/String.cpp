#define _CRT_SECURE_NO_WARNINGS

#include <cstring>

#include "String.h"

String::String(const char* s)
{
	len = strlen(s);
	str = new char[len + 1];
	strcpy(str, s);
}

String::String(const String& s)
{
	len = strlen(s.str);
	str = new char[len + 1];
	strcpy(str, s.str);
}

String::String(char c)
{
	len = 1;
	str = new char[2];
	str[0] = c;
	str[1] = '\0';
}

String& String::operator = (const String& s)
{
	String t(s);
	swap(len, t.len);
	swap(str, t.str);

	return *this;
}

char String::operator [] (int i) const
{
	if (i < 0 || i >= len)
	{
		cout << "Bad index\n";
		exit(1);
	}

	return str[i];
}

char& String::operator [] (int i)
{
	if (i < 0 || i >= len)
	{
		cout << "Bad index\n";
		exit(1);
	}

	return str[i];
}

istream& operator >> (istream& input, String& s)
{
	s = "";
	char c;
	do {
		input >> c;
		s += c;
	} while (input.peek() != '\n');

	return input;
}

ostream& operator << (ostream& output, const String& s)
{
	for (int i = 0; i < s.len; i++)
	{
		output << s[i];
	}

	return output;
}

String& String::operator += (const String& s)
{
	len += s.len;
	char* p = new char[len + 1];
	strcpy(p, str);
	strcat(p, s.str);

	delete str;
	str = p;
	return *this;
}