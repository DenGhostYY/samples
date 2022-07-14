#ifndef QUEUE_H
#define QUEUE_H

class BadEmpty {};

template <typename T>
struct Node // узел списка
{
	T data;			// данные
	Node<T>* next;	// указатель на следующий элемент
};

template <typename T> // подобие std::queue<>
class Queue
{
	Node<T>* head;	// указатель на голову списка
	Node<T>* last;	// указатель на последний
					// элемент списка
public:
	Queue();

	// запрет на копирование
	Queue(const Queue<T>&) = delete;

	// запрет на присваивание
	Queue<T>& operator=(const Queue<T>&) = delete;

	void push(T);
	bool is_empty() const { return head == last; };
	T front() const;
	void pop();
	~Queue();
};

template <typename T>
Queue<T>::Queue()
{
	head = new Node<T>;
	head->next = nullptr;
	last = new Node<T>;
	last = head;
}

template <typename T>
void Queue<T>::push(T data)
{
	Node<T>* x = new Node<T>;
	x->data = data;
	x->next = nullptr;
	last->next = x;
	last = x;
}

template <typename T>
T Queue<T>::front() const
{
	if (is_empty()) {
		throw BadEmpty();
	}

	return head->next->data;
}

template <typename T>
void Queue<T>::pop()
{
	if (is_empty()) {
		throw BadEmpty();
	}
	Node<T>* p = head->next;
	if (p == last) {
		last = head;
	}
	head->next = p->next;
	delete p;
}

template <typename T>
Queue<T>::~Queue()
{
	Node<T>* p = head, * x;
	while (p != nullptr) {
		x = p;
		p = p->next;
		delete x;
	}
}
#endif // QUEUE_H