#ifndef VECTOR_H
#define VECTOR_H

class BadIndex {};

template <typename T> // ������� std::vector<>
class Vector
{
	// ��������� ���������� ��������� �� ���������
	static const int N_MIN = 4;

	// ������� ���������� ���������
	int n;

	// ������� ���������� ������ ����������������� ������
	int nmax;

	// ��������� �� ������� ������
	// ����������������� ������ ��� �������
	T* a;
public:
	// ���������� ��������� � �������� ��� �������������
	Vector(int, T);

	Vector(int);	// ���������� ���������
	Vector();		// ����������� �� ���������

	// ����������� �����
	Vector(const Vector<T>&);

	// ������ ������������
	Vector<T>& operator=(const Vector<T>&) = delete;

	T& operator[](int);
	T operator[](int) const;
	void push_back(T); // ������� � �����
	void reserve(int); // �������������� ������
	int size() const { return n; };
	~Vector() { delete[] a; }
};

template <typename T>
Vector<T>::Vector(int n, T value)
{
	this->n = n;
	nmax = n;
	a = new T[nmax];
	for (int i = 0; i < n; i++) {
		a[i] = value;
	}
}

template <typename T>
Vector<T>::Vector(int n)
{
	this->n = n;
	nmax = n;
	a = new T[nmax];
}

template <typename T>
Vector<T>::Vector()
{
	n = 0;
	nmax = N_MIN;
	a = new T[nmax];
}

template <typename T>
Vector<T>::Vector(const Vector<T>& v)
{
	n = v.n;
	nmax = v.nmax;
	a = new T[nmax];
	for (int i = 0; i < n; i++) {
		a[i] = v.a[i];
	}
}

template <typename T>
T& Vector<T>::operator[](int i)
{
	if (i < 0 || i >= n) {
		throw BadIndex();
	}
	return a[i];
}

template <typename T>
T Vector<T>::operator[](int i) const
{
	if (i < 0 || i >= n) {
		throw BadIndex();
	}
	return a[i];
}

template <typename T>
void Vector<T>::push_back(T value)
{
	if (n == nmax) {
		nmax *= 2;
		T* b = new T[nmax];
		for (int i = 0; i < n; i++) {
			b[i] = a[i];
		}
		delete[] a;
		a = b;
	}
	a[n++] = value;
}

template <typename T>
void Vector<T>::reserve(int _nmax)
{
	if (_nmax <= nmax) {
		return;
	}
	nmax = _nmax;
	T* b = new T[nmax];
	for (int i = 0; i < n; i++) {
		b[i] = a[i];
	}
	delete[] a;
	a = b;
}
#endif // VECTOR_H