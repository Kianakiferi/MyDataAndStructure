using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace BinaryTree
{
    class MyFunc
        {
            private int _allFuncNum = menu.GetLength(0) - 3;
            public int AllFuncNum { get => _allFuncNum; set => _allFuncNum = value; }
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

            static readonly string[] menu =
                {
            "请使用:上下方向键切换, 回车确定, Esc返回",
            "------------<二叉树>------------",
            "1. 创建二叉树",
            "2. 先序遍历二叉树",
            "3. 中序序遍历二叉树",
            "4. 后序遍历二叉树",
            "5. 计算树的深度 ",
            "6. 退出",
            "--------------------------------"
            };

            public void DoFunc (ref MyTree<string> myTree)
            {
                Console.Clear();
                switch (MenuNum)
                {
                    case 0:
                        {
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
                            myTree.Insert("K");
                            myTree.Insert("G");
                            myTree.Insert("M");
                            myTree.Insert("F");
                            myTree.Insert("H");
                            myTree.Insert("I");
                            myTree.Insert("L");
                            myTree.Insert("J");
                            myTree.Insert("N");
                            //          K
                            //    G           M
                            //  F   H       L   N
                            //        I
                            //         J
                            // 深度 5
                            myTree.PreTraversal();
                            Console.WriteLine("长出了 {0} 个结点", myTree.Count);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("先序遍历:");
                            myTree.PreTraversal();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("中序序遍:");
                            myTree.InoTraversal();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("后序遍历:");
                            myTree.PosTraversal();
                            break;
                        }
                    case 5:
                        { 
                        Console.WriteLine("树的最大深度为: " + myTree.GetTreeDepth().ToString());
                        break;
                        }
                    case 6:
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

	class Program
	{
        //菜单 + 功能选项类
        
        
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
