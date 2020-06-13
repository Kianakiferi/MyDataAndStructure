using MyStack;

namespace CollectionsApplication
{
	class Program
    {
        static void Main(string[] args)
        {
			MyFunc myFunc = new MyFunc();
			MyStack<string> myStack = new MyStack<string>();

			while (true)
			{
				myFunc.ReadKey();
				myFunc.DoFunc(ref myStack);
			}
		}
    }
}
