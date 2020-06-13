using System;
using System.Threading;

namespace Graph
{
	class MyFunc
	{
		//通用，不用看
		private int _allFuncNum = menu.GetLength(0) - 3;
		public int AllFuncNum { get => _allFuncNum;}
		private int _menuNum;
		public int MenuNum
		{
			get { return _menuNum; }
			set
			{
				if (value >= 1 && value <= AllFuncNum)
				{
					_menuNum = value;
				}
				else
				{
					_menuNum = Math.Abs(AllFuncNum - value);
				}
			}
		}
		private int times = 0;
		public void ReadKey()
		{
			Console.Clear();
			MenuNum = 1;
			ShowMenu(1);

			ConsoleKeyInfo _cki;
			do
			{
				while (Console.KeyAvailable == false)
				{
					Thread.Sleep(100);
				}
				_cki = Console.ReadKey(true);
				if (_cki.Key == ConsoleKey.UpArrow)
				{
					MenuNum--;
					ShowMenu(MenuNum);
				}
				if (_cki.Key == ConsoleKey.DownArrow)
				{
					MenuNum++;
					ShowMenu(MenuNum);
				}
				if (_cki.Key == ConsoleKey.Enter)
				{
					Console.Clear();
					return;
				}

			} while (_cki.Key != ConsoleKey.Escape);
			_menuNum = 0;
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
		//通用，不用看

		//定义你的功能
		static readonly string[] menu =
		{
			"请使用:上下方向键切换, 回车确定, Esc返回",
			"--------<图的基本操作及应用>--------",
			"1. 创建无向图",
			"2. 创建无向网",
			"3. 创建有向图",
			"4. 创建有向网",
			"5. 遍历",
			"6. 拓扑排序 ",
			"7. 最小生成树(应用)",
			"8. 没做 最短路径(应用)",
			"9. 没做 关键路径(应用)",
			"10. 退出",
			"---------------------------------"
		};
		public void DoFunc(ref MyGraph myGraph)
		{
			Console.Clear();
			switch (MenuNum)
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
					myGraph.DFSTraverse();
					
					myGraph.BFSTraverse();
					break;
				}
				case 6:
				{
					myGraph.TopoSort();
					break;
				}
				case 7:
				{
					int[,] b1 = new int[,] {{ 0, 3, 1, 2, 99, 99 },
											{ 3, 0, 99, 4, 99, 99 },
											{ 1, 99, 0, 99, 4, 3 },
											{ 2, 4, 99, 0, 99, 1 },
											{ 99, 99, 4, 99, 0, 2 },
											{ 99, 99, 3, 1, 2, 0 }};
					myGraph = b1;
					Console.WriteLine("创建了连通带权图");
					myGraph.MiniSpannTree();
					break;
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
				default:
					break;
			}
			Console.WriteLine("\n 按下 “Esc” 以返回");

			ConsoleKeyInfo _tempcki;
			do
			{ 
				while (Console.KeyAvailable == false)
				{
					Thread.Sleep(100);
				}
				_tempcki = Console.ReadKey(true);
				
			} while (_tempcki.Key != ConsoleKey.Escape);
		}

	}
}
