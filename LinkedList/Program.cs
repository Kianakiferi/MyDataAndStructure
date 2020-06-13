using LinkedList;

namespace CollectionsApplication
{

	class Program
    {
        static void Main(string[] args)
        {
            MyFunc myFunc =new MyFunc();
            MyList<string> myList = new MyList<string>();

			while (true)
			{
                myFunc.ReadKey();
                myFunc.DoFunc(ref myList);
			}
        }
    }
}