using Fans.DataAndStructure;
using System;

namespace Fans
{
	class Program
	{
		static void Main(string[] args)
		{
			MyFunc myFunc = new MyFunc();

			while (true)
			{
				myFunc.ReadKey();
				myFunc.DoFunc();
			}
		}
	}
}
