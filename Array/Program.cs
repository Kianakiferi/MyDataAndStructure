using Fans.Array;
using System;
using System.Collections;
using System.Xml;

namespace Fans
{
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
