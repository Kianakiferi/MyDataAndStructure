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
		=>item.Data;

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

		public void SetNodeData(int x, string str)
		{
			vertexList[x].Data = str;
		}
		public string GetNodeData(int x)
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

		public void DFS(Stack stack)
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


		public void BFS(Queue queue)
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
