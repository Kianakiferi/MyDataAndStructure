using System;
using System.Threading;

namespace MyArray
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

		public void DoFunc(ref MyArray myArray)
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
}
