using System;
using System.Threading;

namespace Fans
{
    namespace LinkedList
    {
	    public class MyFunc
	    {
            private int _allFuncNum = menu.GetLength(0) - 3;
            public int AllFuncNum { get => _allFuncNum;}
            private int _menuNum;
            public int MenuNum
            {
                get { return _menuNum; }
                set
                {
                    if (value >= 1 && value <= AllFuncNum)
                    {
                        _menuNum = value;
                    }
                    else
                    {
                        _menuNum = Math.Abs(AllFuncNum - value);
                    }
                }
            }
            private int times = 0;
            public void ReadKey()
            {
                Console.Clear();
                MenuNum = 1;
                ShowMenu(1);

                ConsoleKeyInfo _cki;
                do
                {
                    while (Console.KeyAvailable == false)
                    {
                        Thread.Sleep(100);
                    }
                    _cki = Console.ReadKey(true);
                    if (_cki.Key == ConsoleKey.UpArrow)
                    {
                        MenuNum--;
                        ShowMenu(MenuNum);
                    }
                    if (_cki.Key == ConsoleKey.DownArrow)
                    {
                        MenuNum++;
                        ShowMenu(MenuNum);
                    }
                    if (_cki.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        return;
                    }
                } while (_cki.Key != ConsoleKey.Escape);
                _menuNum = 0;
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
            public bool IsGoBack { get; set; }

            static readonly string[] menu =
                {
                "请使用:上下方向键切换, 回车确定, Esc返回",
                "-------------<链表>-------------",
                "1. 创建线性表",
                "2. 插入元素",
                "3. 查找元素",
                "4. 删除元素",
                "5. 浏览",
                "6. 没做 通讯录设计(应用)",
                "7. 退出",
                "--------------------------------"
                };
            public void DoFunc(ref MyList<string> myList)
		    {
                Console.Clear();
                switch (MenuNum)
                {
                    case 0:
                        {
                            IsGoBack = true;
                            times++;
                            if (times > 10)
                            {
                                Console.WriteLine("李在赣神魔??");
                                Thread.Sleep(2000);
                                times = 0;
                            }
                            return;
                        }
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
                        if (result)
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
                        throw new NotImplementedException();
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("按下 “Esc” 以返回");

                ConsoleKeyInfo _tempcki;
                do
                {
                    while (Console.KeyAvailable == false)
                    {
                        Thread.Sleep(100);
                    }
                    _tempcki = Console.ReadKey(true);
                } while (_tempcki.Key != ConsoleKey.Escape);
                IsGoBack = true;
            }
        }
    }
}