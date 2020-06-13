using System;
using System.Collections.Generic;
using System.Text;

namespace Fans
{
	namespace Array
	{
		class ArrayIndex
		{
			public int MaxRow;
			public int MaxColumn;
			private int _row;
			private int _column;

			public ArrayIndex()
			{
				_row = 0;
				_column = 0;
			}

			public ArrayIndex(int maxrow, int maxcolumn)
			{
				MaxRow = maxrow;
				MaxColumn = maxcolumn;
			}

			public int Row
			{
				get { return _row; }

				set
				{
					if ((0 <= value) && (value <= MaxRow))
					{
						_row = value;
					}
					else
					{
						_column++;
						_row = Math.Abs(MaxRow - value);
					}

				}

			}

			public int Column
			{
				get { return _column; }
				set
				{
					if ((0 <= value) && (value <= MaxColumn))
					{
						_column = value;
					}
					else
					{
						_column = MaxColumn;
					}

				}
			}
		}

		public class MyArray
		{

			private int[,] array;
			private ArrayIndex index;

			public int[,] ArrayList { get { return array; } }

			public MyArray()
			{
				array = new int[1, 1];
				index = new ArrayIndex(0, 0);
			}

			public MyArray(int row, int column)
			{
				array = new int[row, column];
				index = new ArrayIndex(row, column);
			}

			public MyArray(int[,] item)
			{
				array = item;
				index = new ArrayIndex(item.GetLength(0), item.GetLength(1));
			}

			public static implicit operator int[,](MyArray myArray)
			=> myArray.ArrayList;

		public static MyArray operator *(MyArray a, int[,] b)
		{
			int aR = a.index.MaxRow;
			int aC = a.index.MaxColumn;
			int bR = b.GetLength(0);
			int bC = b.GetLength(1);
			int[,] c = new int[aR, bC];

			if (aC == bR)
			{

				for (int i = 0; i < aR;)
				{
					for (int j = 0; j < bC;)
					{
						for (int k = 0; k < bC; k++)
						{
							for (int l = 0; l < aC; l++)
							{
								c[i, j] += a.ArrayList[i, l] * b[l, k];
							}
							j++;
						}
						if (j >= bC)
						{
							j = 0;
							i++;
						}
						if (i >= aR)
						{
							break;
						}
					}
				}
			}
			MyArray d = new MyArray(c);
			return d;
		}

		public static MyArray operator *(MyArray a, MyArray b)
			{
				int aR = a.index.MaxRow;
				int aC = a.index.MaxColumn;
				int bR = b.index.MaxRow;
				int bC = b.index.MaxColumn;
				int[,] c = new int[aR, bC];

				if (aC == bR)
				{
					for (int i = 0; i < aR;)
					{
						for (int j = 0; j < bC;)
						{
							for (int k = 0; k < bC; k++)
							{
								for (int l = 0; l < aC; l++)
								{
									c[i, j] += a.ArrayList[i, l] * b.ArrayList[l, k];
								}
								j++;
							}
							if (j >= bC)
							{
								j = 0;
								i++;
							}
							if (i >= aR)
							{
								break;
							}
						}
					}
				}
				MyArray d = new MyArray(c);
				return d;
			}

		}

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
	}
}

