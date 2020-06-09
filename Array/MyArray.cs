using System;
using System.Collections.Generic;
using System.Text;



namespace MyArray
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

		public int row
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

		public int column
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

	class MyArray
	{

		private int[,] array;
		private ArrayIndex index;

		public int[,] arraylist { get { return array; } }

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
		=> myArray.arraylist;

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
							c[i, j] += a.arraylist[i, l] * b[l, k];
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
								c[i, j] += a.arraylist[i, l] * b.arraylist[l, k];
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
}
