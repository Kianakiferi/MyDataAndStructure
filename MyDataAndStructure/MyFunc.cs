using System;
using System.Threading;

namespace Fans
{
	namespace DataAndStructure
	{
		public class MyFunc
		{
			//通用，不用看
			private int _mainAllFuncNum = mainMenu.GetLength(0) - 3;
			public int MainAllFuncNum { get => _mainAllFuncNum; }
			private int _mainMenuNum;
			public int MainMenuNum
			{
				get { return _mainMenuNum; }
				set
				{
					if (value >= 1 && value <= MainAllFuncNum)
					{
						_mainMenuNum = value;
					}
					else
					{
						_mainMenuNum = Math.Abs(MainAllFuncNum - value);
					}
				}
			}
			private int times = 0;
			public void ReadKey()
			{
				Console.Clear();
				MainMenuNum = 1;
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
						MainMenuNum--;
						ShowMenu(MainMenuNum);
					}
					if (_cki.Key == ConsoleKey.DownArrow)
					{
						MainMenuNum++;
						ShowMenu(MainMenuNum);
					}
					if (_cki.Key == ConsoleKey.Enter)
					{
						Console.Clear();
						return;
					}

				} while (_cki.Key != ConsoleKey.Escape);
				_mainMenuNum = 0;
			}
			public void ShowMenu()
			{
				foreach (var item in mainMenu)
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
				Console.WriteLine(mainMenu[num]);
				Console.ResetColor();
			}
			public bool IsGoBack { get; set; }
			//通用，不用看

			static readonly string[] mainMenu =
			{
				"请使用:上下方向键切换, 回车确定, Esc返回",
				"----------<算法与数据结构>----------",
				"1. 单链表 的基本操作及应用",
				"2. 栈 的基本操作及应用",
				"3. 数组 的基本操作及应用",
				"4. 树 的基本操作及应用",
				"5. 图 的基本操作及应用",
				"6. 退出 ",
				"---------------------------------"
			};

			public void DoFunc()
			{
				Console.Clear();

				switch (MainMenuNum)
					{
						case 0:
						{
							IsGoBack = true;
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
							LinkedList.MyFunc myFunc = new LinkedList.MyFunc();
							LinkedList.MyList<string> myList = new LinkedList.MyList<string>();
							do
							{
								myFunc.ReadKey();
								myFunc.DoFunc(ref myList);
							} while (myFunc.IsGoBack == false);
							break;
						}
						case 2:
						{
							Stack.MyFunc myFunc = new Stack.MyFunc();
							Stack.MyStack<string> myStack = new Stack.MyStack<string>();
							do
							{
								myFunc.ReadKey();
								myFunc.DoFunc(ref myStack);
							} while (myFunc.IsGoBack == false) ;
							break;
						}
						case 3:
						{
							Array.MyFunc myFunc = new Array.MyFunc();
							Array.MyArray myArray = new Array.MyArray();
							do
							{
								myFunc.ReadKey();
								myFunc.DoFunc(ref myArray);
							} while (myFunc.IsGoBack == false) ;
							break;
						}
						case 4:
						{

							BinaryTree.MyFunc myFunc = new BinaryTree.MyFunc();
							BinaryTree.MyTree<string> myTree = new BinaryTree.MyTree<string>();
							do
							{
								myFunc.ReadKey();
								myFunc.DoFunc(ref myTree);
							} while (myFunc.IsGoBack == false);
							break;
						}
						case 5:
						{
							Graph.MyGraph myGraph = new Graph.MyGraph();
							Graph.MyFunc myFunc = new Graph.MyFunc();
							do 
							{ 
								myFunc.ReadKey();
								myFunc.DoFunc(ref myGraph);
							} while (myFunc.IsGoBack == false) ;
							break;
						}
						case 6:
						{
							Console.WriteLine("拜拜");
							Environment.Exit(0);
							break;
						}
						default:
							break;
					}

				//Console.WriteLine("\n Wwwwwww");
				////按下 “Esc” 以返回
				//ConsoleKeyInfo _tempcki;
				//do
				//{
				//	while (Console.KeyAvailable == false)
				//	{
				//		Thread.Sleep(100);
				//	}
				//	_tempcki = Console.ReadKey(true);

				//} while (_tempcki.Key != ConsoleKey.Escape);
			}
		}
	}
}
