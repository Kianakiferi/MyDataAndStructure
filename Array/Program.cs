using System;
using System.Collections;
using System.Threading;
using System.Xml;

namespace MyArray
{
	class Tab
	{
		private int _MaxRow;
		private int _MaxCol;
		private int[,] _array;
		private int _NowLine;

		string[] tab =
			{
				"┌", "───", "┬", "───┐",

				"├", "───", "┼", "───┤",

				"└", "───", "┴", "───┘",
				"│"
			};

		public Tab(int[,] array)
		{
			_array = array;
			_MaxRow = array.GetLength(0);
			_MaxCol = array.GetLength(1);
			_NowLine = 0;

			WriteTop();
			for (; _NowLine < _MaxRow - 1; _NowLine++)
			{
				WriteNum();
				WriteMiddle();
			}

			WriteNum();
			WriteBottom();
		}

		public void WriteTop()
		{
			Console.Write(tab[0]);
			for (int i = 0; i < _MaxCol - 1; i++)
			{
				Console.Write(tab[1] + tab[2]);
			}
			Console.Write(tab[3] + "\n");
		}

		public void WriteNum()
		{
			Console.Write(tab[12]);
			for (int i = 0; i < _MaxCol; i++)
			{
				if (_array[_NowLine, i].ToString().Length == 1)
				{
					Console.Write("  " + _array[_NowLine, i] + tab[12]);
				}
				if (_array[_NowLine, i].ToString().Length == 2)
				{
					Console.Write(" " + _array[_NowLine, i] + tab[12]);
				}
				if (_array[_NowLine, i].ToString().Length == 3)
				{
					Console.Write(_array[_NowLine, i] + tab[12]);
				}


			}
			Console.Write("\n");
		}

		public void WriteMiddle()
		{
			Console.Write(tab[4]);
			for (int i = 0; i < _MaxCol - 1; i++)
			{
				Console.Write(tab[5] + tab[6]);
			}
			Console.Write(tab[7] + "\n");
		}

		public void WriteBottom()
		{
			Console.Write(tab[8]);
			for (int i = 0; i < _MaxCol - 1; i++)
			{
				Console.Write(tab[9] + tab[10]);
			}
			Console.Write(tab[11] + "\n");
		}
	}

	class MyFunc
	{
		static readonly string[] menu =
			{
			"请使用:上下方向键切换, 回车确定, Esc返回",
			"-----<稀疏矩阵的压缩存储及应用>-----",
			"1. 创建",
			"2. 显示",
			"3. 矩阵乘法(应用)",
			"4. 退出",
			"--------------------------------"
			};

		private int _allFuncNum = menu.GetLength(0) - 3;
		public int AllFuncNum { get => _allFuncNum; set => _allFuncNum = value; }
		private int _menuNum;
		public int menuNum
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
			menuNum = 1;
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
					return;
				}

			} while (_cki.Key != ConsoleKey.Escape);
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

		public void DoFunc(ref MyArray myArray)
		{
			Console.Clear();
			switch (menuNum)
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
						myArray = new MyArray(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } });
						Console.WriteLine("创建了 {0} 个元素的数组", myArray.arraylist.Length);
						Tab tab0 = new Tab(myArray.arraylist);
						break;
					}
				case 2:
					{
						Tab tab0 = new Tab(myArray.arraylist);
						break;
					}
				case 3:
					myArray = new MyArray(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } });
					Console.WriteLine("数组A:");
					Tab tab1 = new Tab(myArray.arraylist);

					MyArray myBrray = new MyArray(new int[,] { { 5, 6 }, { 3, 2 }, { 1, 4 } });
					Console.WriteLine("数组B:");
					Tab tab2 = new Tab(myBrray.arraylist);

					MyArray item = myArray * myBrray;
					Console.WriteLine("矩阵相乘:");
					Tab tab3 = new Tab(item.arraylist);
					break;
				case 4:
					Environment.Exit(0);
					break;
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

	class Program
	{

		static void Main(string[] args)
		{
			MyFunc myFunc = new MyFunc();
			MyArray myArray = new MyArray();
			while (true)
			{
				myFunc.ReadKey();
				myFunc.DoFunc(ref myArray);
			}

			//int[,] Array = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
			//int[,] Brray = new int[,] { { 5, 6 }, { 3, 2 }, { 1, 4 } };
			//MyArray arrayList = new MyArray(Array);
			//MyArray item = arrayList * Brray;
		}
	}
}
