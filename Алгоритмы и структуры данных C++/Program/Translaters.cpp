#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <fstream>
#include <windows.h>

#include "Vector.h"
#include "String.h"
#include "Queue.h"

using namespace std;

int BFS(int a, int b, const Vector<Vector<int> >& g,
		Vector<int>& chain)
{
	// a, b - номера первого и
	// последнего человека соответственно
	// между которыми нужно построить цепочку переводчиков

	// g - сам граф

	// chain - массив, в котором будут храниться
	// номера вершин, образующих цепочку переводчиков

	// BFS возвращает количество элементов массива chain,
	// если цепочка между a и b существует,
	// иначе возвращает 0
	int n = g.size(); // количество вершин в графе
	Vector<bool> used(n, false);
	Vector<int> p(n, -1);
	used[a] = true;
	Queue<int> q;
	q.push(a);
	int v = a;
	while (!q.is_empty()) {
		v = q.front();
		q.pop();
		if (v == b) {
			break;
		}
		for (int i = 0; i < g[v].size(); i++) {
			int u = g[v][i];
			if (!used[u]) {
				used[u] = true;
				p[u] = v;
				q.push(u);
			}
		}
	}
	if (v == b) {
		int i = 0;
		Vector<int> chain_1(n);
		for (int u = b; u != -1; u = p[u]) {
			chain_1[i++] = u;
		}
		for (int j = i - 1; j >= 0; j--) {
			chain[i - 1 - j] = chain_1[j];
		}
		return i;
	}
	return 0;
}

int main()
{
	SetConsoleOutputCP(1251);

	ifstream fin("input.txt");
	if (!fin.is_open()) {
		cout << "Ошибка открытия входного файла\n";
		cin.get();
		return 0;
	}

	int n, m; // количество людей, языков соответственно
	fin >> n;
	Vector<String> names(n);
	cout << "Имена:\n";
	for (int i = 0; i < n; i++) {
		fin >> names[i];
		cout << i + 1 << ". " << names[i] << "\n";
	}

	fin >> m;
	Vector<String> languages(m);
	cout << "\nЯзыки:\n";
	for (int i = 0; i < m; i++) {
		fin >> languages[i];
		cout << i + 1 << ". " << languages[i] << "\n";
	}
	cout << "\n";

	int n_vertex = n + m;
	// общая нумерация в графе,
	// представимого в виде списка смежности:
	// 0...(n_people - 1) - люди
	// n_people...(n_vertex - 1) - языки
	Vector<Vector<int> > graph(n_vertex);
	// для уменьшения количества
	// перераспределения памяти
	for (int i = 0; i < n_vertex; i++) {
		graph[i].reserve(100);
	}
	for (int i = 0; i < n; i++) {
		int a;
		fin >> a;
		while (a) {
			graph[i].push_back(a - 1 + n);
			graph[a - 1 + n].push_back(i);
			fin >> a;
		}
	}
	fin.close();

	Vector<int> chain(n_vertex);
	// массив, в котором будут храниться номера вершин,
	// образующих цепочку переводчиков
	cout << "Введите номер пункта меню\n";
	while (true) {
		cout << "1. Запрос\n2. Завершить\n";
		char c;
		cin >> c;
		if (c == '2') {
			// условие окончания работы
			break;
		}
		if (c != '1') {
			continue;
		}
		cout << "\nВведите номера двух людей через пробел\n";
		int a, b;	// номера людей, между которыми нужно
					// построить цепочку переводчиков
		cin >> a >> b;
		if (a == b || a > n || b > n ||
			a <= 0 || b <= 0) {
			cout << "Некорректный запрос\n\n";
			continue;
		}
		int n_chain = BFS(a - 1, b - 1, graph, chain);
		for (int i = 0; i < n_chain; i++) {
			if (chain[i] < n) {
				// если номер вершины означает человека
				cout << names[chain[i]];
			}
			else {
				// иначе номер вершины означает язык
				cout << languages[chain[i] - n];
			}
			if (i < n_chain - 1) {
				cout << "->";
			}
		}
		if (n_chain == 0) {
			cout << "Цепочки переводчиков нет";
		}
		cout << "\n\nДля продолжения нажмите клавишу Enter\n";
		cin.get();
		cin.get();
	}
	return 0;
}