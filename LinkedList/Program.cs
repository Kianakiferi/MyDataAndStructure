
using LinkedList;
using System;
using System.Threading;

namespace CollectionsApplication
{
    //菜单 + 功能选项类
    class MyMenu
    {
        const int allFuncNum = 6;
        private ConsoleKeyInfo _cki;
        private int _menuNum;
        public int menuNum { 
            get 
            {
                return _menuNum;
            } 
            set 
            {
                if (value >= 1 && value <= allFuncNum)
                { 
                    _menuNum = value;
                }
                else
                {
                    _menuNum = Math.Abs(allFuncNum - value);//距离为allFuncNum: 1,2,3,4,5,6
                }
            } 
        }

        string[] menu =
            {
            "请使用:上下方向键切换, 回车确定, Esc返回",
            "-------------<链表>-------------",
            "1. 创建线性表",
            "2. 插入元素",
            "3. 查找元素",
            "4. 删除元素",
            "5. 浏览",
            "6. 退出",
            "--------------------------------"
            };

        public MyMenu()
        {
           
            MyList<string> myList = new MyList<string>();

            ShowMenu();
            menuNum = 1;
            ShowMenu(1);
            do
            {
                //避免程序阻塞
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
                            myList.Push("A");
                            myList.Push("B");
                            myList.Push("C");
                            myList.Push("D");
                            myList.Push("E");
                            myList.Push("F");
                            myList.Push("G");
                            myList.Push("H");
                            myList.Push("I");
                            myList.Push("J");
                            myList.Push("K");
                            myList.Push("L");
                            myList.Push("M");
                            myList.Push("N");
                            myList.ShowAll();
                            break;
                        case 2:
                            int prevCount = myList.Count;
                            Console.WriteLine("请输入:");
                            myList.Push(Console.ReadLine());
                            if (prevCount == myList.Count - 1)
                            {
                                Console.WriteLine("添加完成");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("?????????");
                                break;
                            }
                        case 3:
                            Console.WriteLine("请输入要查找的数据:");
                            int finded = myList.Find(Console.ReadLine());
                            if (finded != -1)
                            {
                                string data = myList.Peek(finded).ToString();
                                Console.WriteLine("位于结点 {0}", finded);
                                Console.WriteLine("数据: {0}", data);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("?????????");
                                break;
                            }
                        case 4:
                            myList.ShowAll();
                            Console.WriteLine("请输入要删除的编号:");
                            string numMaybe = Console.ReadLine();
                            int i = 0;
                            bool result = int.TryParse(numMaybe, out i);
                            if(result)
                            {
                                myList.Delete(i);
                                Console.WriteLine("删除完成");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("请输入数字");
                                    break;
                            }
                        case 5:
                            myList.ShowAll();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                    do
                    {
                        while (Console.KeyAvailable == false)
                        {
                            Thread.Sleep(50);
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
            //高亮选项，设为白底黑字
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
            MyMenu list =new MyMenu();
        }
    }
}