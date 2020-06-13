using System;
using System.Collections.Generic;
using System.Threading;
using TanyaMalisRPN;

namespace Fans
{
    namespace Stack
    {
	    public class MyFunc
        {
            //通用，不用看
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
            //通用，不用看

            static readonly string[] menu =
            {
                "请使用:上下方向键切换, 回车确定, Esc返回",
                "--------------<栈>--------------",
                "1. 创建栈",
                "2. 数据元素入栈",
                "3. 数据元素出栈",
			    "4. 取栈顶元素",
                "5. 计算表达式(应用)",
                "6. 退出",
                "--------------------------------"
            };

            public void DoFunc(ref MyStack<string> myStack)
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
                        {
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
                        }
                    case 2:
                        {
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
                        }
                    case 3:
                        Console.WriteLine(myStack.Pop().ToString());
                        break;
                    case 4:
                        Console.WriteLine(myStack.Peek().ToString());
                        break;
                    case 5:
                    { 
                        Console.Write("请输入: ");
                        string input = Console.ReadLine();

                        Stroka str = new Stroka(input);
                        List<string> strok = str.OutString();
                        double result = str.Calculate();

                        Console.Write("逆波兰式为:");
                        foreach (var item in strok)
                        {
                            Console.Write(item + " ");
                        }
                        Console.Write("\n");

                        Console.WriteLine("计算结果为: {0}", result);
                        break;
                    }
                    case 6:
                        Console.WriteLine("拜拜");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\n 按下 “Esc” 以返回");

                ConsoleKeyInfo _tempcki;
                do
                {
                    while (Console.KeyAvailable == false)
                    {
                        Thread.Sleep(100);
                    }
                    _tempcki = Console.ReadKey(true);

                } while (_tempcki.Key != ConsoleKey.Escape);
            }
        }
    }
}

