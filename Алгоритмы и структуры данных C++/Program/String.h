#ifndef STRING_H
#define STRING_H

#include <iostream>

using namespace std;

class String // подобие std::string
{
	int len;	// длина строки
	char* str;	// указатель на область памяти
public:
	String(const char* = "");
	String(const String&);
	String(char);
	~String() { delete[] str; };

	int length() const { return len; }
	const char* c_str() const { return str; }

	String& operator = (const String&);
	char operator [] (int) const;
	char& operator [] (int);

	// ввод до конца строки
	friend istream& operator >> (istream&, String&);
	friend ostream& operator << (ostream&, const String&);

	String& operator += (const String&);
};

#endif //STRING_H