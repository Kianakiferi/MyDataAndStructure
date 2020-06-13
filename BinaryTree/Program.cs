using System.Text.RegularExpressions;

namespace BinaryTree
{

	class Program
	{
        static void Main(string[] args)
		{
            MyFunc myFunc = new MyFunc();
            MyTree<string> myTree = new MyTree<string>();

            while (true)
			{
                myFunc.ReadKey();
                myFunc.DoFunc(ref myTree);
			}
        }
	}
}
