using System;
using System.Threading;

namespace Graph
{
	class MyFunc
	{
		const int allFuncNum = 10;
		private int _menuNum;
		public int menuNum
		{
			get { return _menuNum; }
			set
			{
				if (value >= 1 && value <= allFuncNum)
				{
					_menuNum = value;
				}
				else
				{
					_menuNum = Math.Abs(allFuncNum - value);//距离为allFuncNum: 1,2,3,4,5,6,7,8,9,10
				}
			}
		}
		string[] menu =
			{
			"请使用:上下方向键切换, 回车确定, Esc返回",
			"--------<图的基本操作及应用>--------",
			"1. 创建无向图",
			"2. 创建无向网",
			"3. 创建有向图",
			"4. 创建有向网",
			"5. 遍历",
			"6. 拓扑排序 ",
			"7. 最小生成树（应用）",
			"8. 最短路径（应用）",
			"9. 关键路径（应用） ",
			"10. 退出",
			"---------------------------------"
			};
		int times = 0;

		public int ReadKey()
		{
			ConsoleKeyInfo _cki;
			menuNum = 1;
			ShowMenu(1);
			do
			{
				while (Console.KeyAvailable == false)
				{
					Thread.Sleep(100);
				}
				_cki = Console.ReadKey(true);
				if (_cki.Key == ConsoleKey.UpArrow)
				{
					menuNum--;
					ShowMenu(menuNum);
				}
				if (_cki.Key == ConsoleKey.DownArrow)
				{
					menuNum++;
					ShowMenu(menuNum);
				}
				if (_cki.Key == ConsoleKey.Enter)
				{
					Console.Clear();
					return menuNum;
				}

			} while (_cki.Key != ConsoleKey.Escape);
			Console.Clear();

			return 0;
		}

		public void ShowMenu()
		{
			foreach (var item in menu)
			{
				Console.WriteLine(item);
			}
		}
		public void ShowMenu(int num)
		{
			num++;
			Console.SetCursorPosition(0, 0);
			ShowMenu();

			//高亮选项，设为白底黑字
			Console.SetCursorPosition(0, num);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine(menu[num]);
			Console.ResetColor();
		}

		public void DoFunc(int num, ref MyGraph myGraph)
		{
			ConsoleKeyInfo _cki;
			do
			{
				switch (num)
				{
					case 0:
						{
							times++;
							if (times > 10)
							{
								Console.WriteLine("李在赣神魔??");
								Thread.Sleep(2000);
								times = 0;
							}
							return;
						}
					case 1:
						{
							int[,] a = new int[,] { { 0, 1, 1, 0, 0, 0, 0, 0 },
													{ 1, 0, 0, 1, 1, 0, 0, 0 },
													{ 1, 0, 0, 0, 0, 1, 1, 0 },
													{ 0, 1, 0, 0, 0, 0, 0, 1 },
													{ 0, 1, 0, 0, 0, 0, 0, 1 },
													{ 0, 0, 1, 0, 0, 0, 0, 1 },
													{ 0, 0, 1, 0, 0, 0, 0, 1 },
													{ 0, 0, 0, 1, 1, 1, 1, 0 } };
							myGraph = a;
							if (myGraph.IsUndirectedGraph)
							{
								Console.WriteLine("创建了无向图");
							}
							else
							{
								Console.WriteLine("创建的不是无向图");
							}
							break;
						}
					case 2:
						{
							int[,] a = new int[,] { { 0, 1, 2, 0, 0, 0, 0, 0 },
													{ 1, 0, 0, 1, 3, 0, 0, 0 },
													{ 2, 0, 0, 0, 0, 1, 4, 0 },
													{ 0, 1, 0, 0, 0, 0, 0, 1 },
													{ 0, 3, 0, 0, 0, 0, 0, 5 },
													{ 0, 0, 1, 0, 0, 0, 0, 1 },
													{ 0, 0, 4, 0, 0, 0, 0, 6 },
													{ 0, 0, 0, 1, 5, 1, 6, 0 } };
							myGraph = a;
							if (myGraph.IsUndirectedGraph)
							{
								Console.WriteLine("创建了无向网");
							}
							else
							{
								Console.WriteLine("创建的不是无向网");
							}
							break;
						}
					case 3:
						{
							int[,] b = new int[,] { { 0, 1, 1, 1, 0, 0 },
													{ 0, 0, 0, 0, 0, 0 },
													{ 0, 0, 0, 0, 0, 1 },
													{ 0, 1, 0, 0, 0, 1 },
													{ 0, 0, 1, 0, 0, 1 },
													{ 0, 0, 0, 0, 0, 0 }};
							myGraph = b;
							Console.WriteLine("创建了有向图");
							break;
						}
					case 4:
						{
							int[,] b = new int[,] { { 0, 1, 1, 4, 0, 0 },
													{ 0, 0, 0, 0, 0, 0 },
													{ 0, 0, 0, 0, 0, 1 },
													{ 0, 2, 0, 0, 0, 1 },
													{ 0, 0, 3, 0, 0, 1 },
													{ 0, 0, 0, 0, 0, 0 }};
							myGraph = b;
							Console.WriteLine("创建了有向网");
							break;
						}
					case 5:
						{
							Console.WriteLine("DFS遍历: ");
							myGraph.DFSTraverse();
							Console.WriteLine("BFS遍历: ");
							myGraph.BFSTraverse();
							break;
						}
					case 6:
						{
							Console.WriteLine("Topo排序: ");
							myGraph.TopoSort();
							break;
						}
					case 7:
						{
							throw new NotImplementedException();
						}
					case 8:
						{ 
							throw new NotImplementedException();
						}
					case 9:
						{
							throw new NotImplementedException();
						}
					case 10:
						{
							Console.WriteLine("拜拜");
							Environment.Exit(0);
							break;
						}
					case -1:
						{
							throw new NotImplementedException();
						}
					default:
					break;
			}
				while (Console.KeyAvailable == false)
				{
					Thread.Sleep(100);
				}
				_cki = Console.ReadKey(true);

			} while (_cki.Key != ConsoleKey.Escape);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			MyFunc myFunc = new MyFunc();
			MyGraph myGraph = new MyGraph();

			while (true)
			{
				myFunc.DoFunc(myFunc.ReadKey(), ref myGraph);
			}
		}
	}
}
