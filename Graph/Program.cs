namespace Graph
{

	class Program
	{
		static void Main(string[] args)
		{
			MyFunc myFunc = new MyFunc();
			MyGraph myGraph = new MyGraph();

			while (true)
			{
				myFunc.ReadKey();
				myFunc.DoFunc(ref myGraph);
			}
		}
	}
}
