using System;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			int[,] a = new int[,] { { 0, 1, 1, 0, 0, 0, 0, 0 },
									{ 1, 0, 0, 1, 1, 0, 0, 0 },
									{ 1, 0, 0, 0, 0, 1, 1, 0 },
									{ 0, 1, 0, 0, 0, 0, 0, 1 },
									{ 0, 1, 0, 0, 0, 0, 0, 1 },
									{ 0, 0, 1, 0, 0, 0, 0, 1 },
									{ 0, 0, 1, 0, 0, 0, 0, 1 },
									{ 0, 0, 0, 1, 1, 1, 1, 0 } };

			MyGraph myGraph = new MyGraph(a);
			myGraph.DFSTraverse();
			myGraph.BFSTraverse();

			Console.WriteLine("完事");
		}
	}
}
