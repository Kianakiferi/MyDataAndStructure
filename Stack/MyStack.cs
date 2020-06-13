//Copyright:FANS Corporation
//Author: Kiana
//Date: 22-05-2019 02:08AM
//Description: 栈类
//Version: Alpha 0.0.2

using System;
using System.Collections;
using System.Collections.Generic;

namespace Fans
{
	namespace Stack
	{
		public class MyNode<T>
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

		public class MyStack<T> : ICollection<T>
		{
			public MyNode<T> Head;

			private int _count;
			public int Count { get { return _count; } }

			public MyStack()
			{
				Head = null;
				_count = 0;
			}

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

			public T Pop()
			{
				_count--;
				if (IsEmpty)
				{
					Console.WriteLine("空");
					return default(T);
				}
				MyNode<T> Seeker = new MyNode<T>();
				Seeker = Head;
				for (int i = 0; i < Count; i++)
				{
					Seeker = Seeker.Next;
				}
				return Seeker.MyData;
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
				while (Seeker.Next != null)
				{
					Seeker = Seeker.Next;
				}
				return Seeker.MyData;

			}

			public void Clear()
			{
				_count = 0;
				Head = null;
			}

			public void Add(T item)
			{
				Push(item);
			}

			public bool Contains(T item)
			{
				if (IsEmpty)
				{
					return false;
				}

				MyNode<T> Seeker = new MyNode<T>();
				Seeker = Head;
				for (int i = 1; i < (_count - 1); i++)
				{
					if (Seeker.MyData.Equals(item))
					{
						return true;
					}
					Seeker = Seeker.Next;
				}
				return false;
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public bool Remove(T item)
			{
				bool result = false;

				MyNode<T> Seeker = new MyNode<T>();
				Seeker = Head;
				for (int i = 0; i < Count; i++)
				{
					if (Seeker.MyData.Equals(item))
					{
						RemoveAt(i);
						result = true;
						break;
					}
					Seeker = Seeker.Next;
				}

				return result;
			}

			public bool RemoveAt(int num)
			{
				if (IsEmpty || num < 1)
				{
					Console.WriteLine("????????");
					return false;
				}

				MyNode<T> Seeker = new MyNode<T>();
				if (num == 1)
				{
					Head = Head.Next;
					return true;
				}

				MyNode<T> Cleaner = new MyNode<T>();

				Seeker = Head;
				for (int i = 0; i < Count; i++)
				{
					Seeker = Seeker.Next;
				}
				Cleaner = Seeker.Next;
				Seeker.Next = Cleaner.Next;
				Cleaner.MyData = default(T);
				_count--;
				return true;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return new StackEnumerator<T>(this);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new StackEnumerator<T>(this);
			}

			public bool IsEmpty { get { return Head == null; } }

			public bool IsReadOnly
			{
				get { return false; }
			}
		}

		public class StackEnumerator<T>: IEnumerator<T>
		{
			private MyStack<T> _myStacks;
			private int curIndex;
			private MyNode<T> curNode;

			public StackEnumerator(MyStack<T> myStacks)
			{
				_myStacks = myStacks;
				curIndex = -1;
				curNode = default;
			}

			public T Current
			{
				get { return curNode.MyData; }
			}

			object IEnumerator.Current
			{
				get { return Current; }
			}

			public void Dispose()
			{

			}

			public bool MoveNext()
			{
				if (++curIndex >= _myStacks.Count)
				{
					return false;
				}
				else
				{
					curNode = _myStacks.Head;
					for (int i = 0; i < curIndex; i++)
					{
						curNode = curNode.Next;
					}
				}
				return true;
			}

			public void Reset()
			{
				curIndex = -1;
			}
		}
	}
}