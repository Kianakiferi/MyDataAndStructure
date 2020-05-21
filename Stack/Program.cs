
using MyStack;
using System;
using System.Threading;

namespace CollectionsApplication
{
    class MyMenu
    {
        private ConsoleKeyInfo _cki;
        private int _menuNum;
        public int menuNum
        {
            get
            {
                return _menuNum;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _menuNum = value;
                }
                else
                {
                    _menuNum = Math.Abs(5 - value);
                }
            }
        }

        string[] menu =
            {
            "请使用:上下方向键切换, 回车确定, Esc返回",
            "--------------<栈>--------------",
            "1. 创建栈",
            "2. 数据元素入栈",
            "3. 数据元素出栈",
            "4. 取栈顶元素",
            "5. 退出",
            "--------------------------------"
            };

        public MyMenu()
        {

            MyStack<string> myStack = new MyStack<string>();

            ShowMenu();
            menuNum = 1;
            ShowMenu(1);
            do
            {

                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(100);
                }

                _cki = Console.ReadKey(true);

                if (_cki.Key == ConsoleKey.UpArrow)
                {
                    menuNum--;
                    ShowMenu(menuNum);
                }
                if (_cki.Key == ConsoleKey.DownArrow)
                {
                    menuNum++;
                    ShowMenu(menuNum);
                }
                if (_cki.Key == ConsoleKey.Enter)
                {
                    ConsoleKeyInfo _tempcki;
                    Console.Clear();

                    switch (menuNum)
                    {
                        case 1:
                            myStack.Push("A");
                            myStack.Push("B");
                            myStack.Push("C");
                            myStack.Push("D");
                            myStack.Push("E");
                            myStack.Push("F");
                            myStack.Push("G");
                            myStack.Push("H");
                            myStack.Push("I");
                            myStack.Push("J");
                            myStack.Push("K");
                            myStack.Push("L");
                            myStack.Push("M");
                            myStack.Push("N");
                            Console.WriteLine("{0} 个元素入栈", myStack.Count);
                            break;
                        case 2:
                            int prevCount = myStack.Count;
                            Console.WriteLine("请输入:");
                            myStack.Push(Console.ReadLine());
                            if (prevCount == myStack.Count - 1)
                            {
                                Console.WriteLine("添加完成");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("?????????");
                            }

                            break;
                        case 3:
                            Console.WriteLine(myStack.Pop().ToString());

                            //Console.WriteLine("请输入:");
                            //int finded = myStack.Find(Console.ReadLine());
                            //if (finded != -1)
                            //{
                            //    string data = myStack.Peek(finded).ToString();
                            //    Console.WriteLine("位于结点 {0}", finded);
                            //    Console.WriteLine("数据: {0}", data);
                            //}
                            //else
                            //{
                            //    Console.WriteLine("?????????");
                            //}
                            break;
                        case 4:
                            Console.WriteLine(myStack.Peek().ToString());

                            //myStack.ShowAll();
                            //Console.WriteLine("请输入要删除的编号:");
                            //string numMaybe = Console.ReadLine();
                            //int i = 0;
                            //bool result = int.TryParse(numMaybe, out i);
                            //if (result)
                            //{
                            //    myStack.Delete(i);
                            //    Console.WriteLine("删除完成");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("请输入数字");
                            //    break;
                            //}

                            break;
                        //case 5:
                        //    myStack.ShowAll();
                        //    break;
                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                    do
                    {
                        while (Console.KeyAvailable == false)
                        {
                            Thread.Sleep(100);
                        }
                        _tempcki = Console.ReadKey(true);
                        if (_tempcki.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            ShowMenu();
                            menuNum = 1;
                            ShowMenu(1);
                        }
                    } while (_tempcki.Key != ConsoleKey.Escape);

                }
            } while (_cki.Key != ConsoleKey.X);
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
            Console.SetCursorPosition(0, num);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(menu[num]);
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyMenu list = new MyMenu();
        }
    }
}