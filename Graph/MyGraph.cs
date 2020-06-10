using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
	class VertexNode
	{
		private string _data;
		public string Data
		{
			get { return _data; }
			set { _data = value; }
		}

		public bool IsVisited { get; set; }

		public VertexNode()
		{
			_data = new string("Vdef");
		}

		public VertexNode(string item)
		{
			_data = item;
		}

		public static implicit operator string(VertexNode item)
		=> item.Data;

	}

	//无用
	class VertexList : IList
	{
		private VertexNode[] _vertexList = new VertexNode[10];
		private int _count;

		public VertexList()
		{
			_count = 0;
		}

		public object this[int index]
		{
			get { return _vertexList[index]; }
			set { _vertexList[index].Data = (string)value; }
		}

		public bool IsFixedSize { get { return true; } }
		public bool IsReadOnly { get { return false; } }
		public int Count { get{ return _count; } }
		public bool IsSynchronized { get { return false; } }
		public object SyncRoot { get { return this; } }

		public int Add(object value)
		{
			if (_count < _vertexList.Length)
			{
				_vertexList[_count].Data = (string)value;
				_count++;

				return (_count - 1);
			}

			return -1;
		}

		public void Clear()
		{
			_count = 0;
			_vertexList.Initialize();
		}

		public bool Contains(object value)
		{
			for (int i = 0; i < Count; i++)
			{
				if(_vertexList[i].Data == (string)value)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(Array array, int index)
		{
			for (int i = 0; i < Count; i++)
			{
				array.SetValue(_vertexList[i].Data, index++);
			}
		}

		public IEnumerator GetEnumerator()
		{
			foreach (var item in _vertexList)
			{
				yield return item;
			}
		}

		public int IndexOf(object value)
		{
			for (int i = 0; i < Count; i++)
			{
				if (_vertexList[i].Data == (string)value)
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, object value)
		{
			if ((_count +1 <= _vertexList.Length) && (index < Count) && (index >= 0))
			{
				_count++;

				for (int i = Count -1 ; i > index; i--)
				{
					_vertexList[i] = _vertexList[i - 1];
				}
				_vertexList[index].Data = (string)value;
			}
		}

		public void Remove(object value)
		{
			RemoveAt(IndexOf(value));
		}

		public void RemoveAt(int index)
		{
			if ((index >= 0) && (index < Count))
			{
				for (int i = index; i < Count - 1; i++)
				{
					_vertexList[i] = _vertexList[i + 1];
				}
				_count--;
			}
		}
	}

	class MyGraph
	{
		private VertexNode[] vertexList;
		private int[,] adjacencyMatrix;

		private int _count;
		public int Count { get { return _count; } }

		public bool IsUndirectedGraph 
		{ 
			get 
			{
				int size = adjacencyMatrix.GetLength(0);

				for (int i = 0; i < size; i++)
				{
					for (int j = i + 1; j < size; j++)
					{
						if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i])
						{
							return false;
						}
					}
				}
				return true;
			} 
		}

		public MyGraph()
		{
			vertexList = new VertexNode[1];
			adjacencyMatrix = new int[1, 1] { { 0 } };
		}
		public MyGraph(int[,] adjM)
		{
			if (adjM.GetLength(0) == adjM.GetLength(1))
			{
				_count = adjM.GetLength(0);
				adjacencyMatrix = adjM;
				vertexList = new VertexNode[_count];
				for (int i = 0; i < _count; i++)
				{
					vertexList[i] = new VertexNode("V" + (i+1)); 
				}
			}
			else
			{
				Console.WriteLine("????????");
			}
			
		}
		public static implicit operator MyGraph(int[,] arrary)
		{
			return new MyGraph(arrary);
		}

		private void SetNodeData(int x, string str)
		{
			vertexList[x].Data = str;
		}
		private string GetNodeData(int x)
		{
			return vertexList[x].Data;
		}

		public void AddDrctEdge(int vexNode1, int vexNode2)
		{
			adjacencyMatrix[vexNode1, vexNode2] = 1;
		}
		public void AddDrctEdge(int vexNode1, int vexNode2, int weight)
		{
			adjacencyMatrix[vexNode1, vexNode2] = weight;
		}
		public void AddCoEdge(int vexNode1, int vexNode2)
		{
			adjacencyMatrix[vexNode1, vexNode2] = 1;
			adjacencyMatrix[vexNode2, vexNode1] = 1;
		}
		public void AddCoEdge(int vexNode1, int vexNode2, int weight)
		{
			adjacencyMatrix[vexNode1, vexNode2] = 1;
			adjacencyMatrix[vexNode2, vexNode1] = 1;
		}

		public void TopoSort()
		{
			Queue result = new Queue();
			int[] indegrees = GetIndegrees();

			while(result.Count < Count)
			{
				int vexnum;
				int newNum = result.Count;
				for (vexnum = 0; vexnum < Count; vexnum++)
				{
					if (( indegrees[vexnum] == 0) && (vertexList[vexnum].IsVisited == false ))
					{
						result.Enqueue(vertexList[vexnum].Data);
						DeleteVex(vexnum);
						indegrees = GetIndegrees();
						vexnum = 0;
					}
				}
				if (vexnum == Count && newNum == result.Count)
				{
					Console.Write("这个有些问题，排不了\n");
					return;
				}
			}

			foreach (var item in result)
			{
				Console.Write(item + " ");
			}
			Console.Write("\n");
		}
		public int[] GetIndegrees()
		{
			int[] indegree = new int[adjacencyMatrix.GetLength(0)];
			for (int i = 0; i < Count; i++)
			{
				for (int j = 0; j < Count; j++)
				{
					if (adjacencyMatrix[j, i] == 1)
					{
						indegree[i]++;
					}
				}
			}

			//foreach (var item in indegree)
			//{
			//	Console.Write(item + " ");
			//}
			//Console.Write("\n");

			return indegree;
		}
		private void DeleteVex(int item)
		{
			vertexList[item].IsVisited = true;

			for (int i = 0; i < Count; i++)
			{
				adjacencyMatrix[item, i] = 0;
			}

		}

		public void DFSTraverse()
		{
			InitVisited();
			Stack ts = new Stack();
			int defVex = 0;

			vertexList[defVex].IsVisited = true;
			Console.Write(vertexList[defVex] + " ");
			ts.Push(defVex);
			DFS(ts);
			Console.Write("\n");
		}
		public void DFSTraverse(int vexNum)
		{
			InitVisited();
			Stack ts = new Stack();

			vertexList[vexNum].IsVisited = true;
			Console.Write(vertexList[vexNum] + " ");
			ts.Push(vexNum);
			DFS(ts);
			Console.Write("\n");
		}
		private void DFS(Stack stack)
		{
			int vexNum = GetUnviewedVex((int)stack.Peek());
			if (vexNum == -1)
			{
				stack.Pop();
			}
			else
			{
				vertexList[vexNum].IsVisited = true;
				Console.Write(vertexList[vexNum] + " ");
				stack.Push(vexNum);
			}

			if (stack.Count == 0)
			{
				return;
			}

			DFS(stack);
		}

		public void BFSTraverse()
		{
			InitVisited();
			Queue tq = new Queue();
			int defVex = 0;

			vertexList[defVex].IsVisited = true;
			Console.Write(vertexList[defVex] + " ");
			tq.Enqueue(defVex);
			BFS(tq);

			Console.Write("\n");
		}
		public void BFSTraverse(int vexNum)
		{
			InitVisited();
			Queue tq = new Queue();

			vertexList[vexNum].IsVisited = true;
			Console.Write(vertexList[vexNum] + " ");
			tq.Enqueue(vexNum);
			BFS(tq);

			Console.Write("\n");
		}
		private void BFS(Queue queue)
		{
			int Vex1 = (int)queue.Dequeue();
			int Vex2 = GetUnviewedVex(Vex1);

			while (Vex2 != -1)
			{
				vertexList[Vex2].IsVisited = true;
				Console.Write(vertexList[Vex2] + " ");
				queue.Enqueue(Vex2);
				Vex2 = GetUnviewedVex(Vex1);
			}

			if (queue.Count == 0)
			{
				return;
			}

			BFS(queue);
		}

		private int GetUnviewedVex(int vnum)
		{
			for (int i = 0; i < Count; i++)
			{
				if (adjacencyMatrix[vnum, i] == 1 && vertexList[i].IsVisited == false)
				{
					return i;
				}
			}
			return -1;
		}

		public void InitVisited()
		{
			foreach (var item in vertexList)
			{
				item.IsVisited = false;
			}
		}

	}
}
