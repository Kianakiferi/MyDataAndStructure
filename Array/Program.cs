using System;
using System.Collections;
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
