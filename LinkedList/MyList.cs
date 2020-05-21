//Copyright:FANS Corporation
//Author: Kiana
//Date: 22-05-2019 02:07AM
//Description: 线性表类
//Version: Alpha 0.1

using System;
using System.Collections.Generic;

//TODO:
//V	int Count;
//V	bool IsEmpty; 
//V	void Push();
//V	T Pop();
//V	T Peek();
//V	void Clear();
//V Find(T Data)
//V bool Delete(int i);
//}

namespace LinkedList
{
	class MyNode<T>
	{
		public T MyData { set; get; }
		public MyNode<T> Next { set; get; }

		public MyNode()
		{
			MyData = default(T);
			Next = null;
		}

		public MyNode(T data, MyNode<T> p)
		{
			MyData = data;
			Next = p;
		}

		public MyNode(T item)
		{
			MyData = item;
			Next = null;
		}

	}

	public class MyList<T>
	{
		private int _count;

		private MyNode<T> Head;

		public MyList()
		{
			Head = null;
			_count = 0;
		}

		//遍历插入
		public void Push(T item)
		{

			MyNode<T> Item = new MyNode<T>(item);
			if (IsEmpty)
			{
				Head = Item;
				_count++;
				return;
			}

			MyNode<T> Seeker = new MyNode<T>();
			Seeker = Head;
			while (Seeker.Next != null)
			{
				Seeker = Seeker.Next;
				
			}
			_count++;
			Seeker.Next = Item;

		}
		
		public T Peek()
		{
			
			if (IsEmpty)
			{
				Console.WriteLine("空");
				return default(T);
			}
			MyNode<T> Seeker = new MyNode<T>();
			Seeker = Head;
			while(Seeker.Next != null)
			{
				Seeker = Seeker.Next;
			}
			return Seeker.MyData;
			
		}

		public T Peek(int num)
		{

			if (IsEmpty || num < 1)
			{
				Console.WriteLine("空");
				return default(T);
			}
			MyNode<T> Seeker = new MyNode<T>();
			Seeker = Head;
			for (int i = 1; i < num; i++)
			{
				Seeker = Seeker.Next;
			}
			return Seeker.MyData;

		}

		public void ShowAll()
		{
			if(IsEmpty)
			{
				return;
			}
			MyNode<T> Seeker = new MyNode<T>();
			Seeker = Head;
			int num = 1;
			Console.WriteLine(num + ". " + Seeker.MyData.ToString());
			while (Seeker.Next != null)
			{
				Seeker = Seeker.Next;
				num++;
				Console.WriteLine(num + ". " + Seeker.MyData.ToString());
			}
			Console.WriteLine("Totle {0} Node", _count);
		}


		public bool Delete(int num)
		{
			if (IsEmpty || num < 1)
			{
				Console.WriteLine("????????");
				return false;
			}

			MyNode<T> Seeker = new MyNode<T>();
			if (num == 1)
			{
				Seeker = Head;
				Head = Head.Next;
				return true;
			}
			MyNode<T> Cleaner = new MyNode<T>();

			Seeker = Head;
			for (int i = 1; i < (num - 1); i++)
			{
				Seeker = Seeker.Next;
			}
			Cleaner = Seeker.Next;
			Seeker.Next = Cleaner.Next;
			Cleaner.MyData = default(T);
			_count--;
			return true;
		}

		public void Delete()
		{
			Head = null;
		}

		public int Find(T data)
		{
			if(IsEmpty)
			{
				return -1;
			}

			MyNode<T> Seeker = new MyNode<T>();
			Seeker = Head;
			for (int i = 1; i < (_count - 1); i++)
			{
				if(Seeker.MyData.Equals(data))
				{
					return i;
				}
				Seeker = Seeker.Next;
			}
			return -1;
		}

		public int Count { get { return _count; } }

		public bool IsEmpty { get {return Head == null;} }

	}
}
