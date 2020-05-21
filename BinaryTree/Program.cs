using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace BinaryTree
{
	class Program
	{
        class MyMenu
        {
            const int allFuncNum = 6;
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
                    if (value >= 1 && value <= allFuncNum)
                    {
                        _menuNum = value;
                    }
                    else
                    {
                        _menuNum = Math.Abs(allFuncNum - value);
                    }
                }
            }

            string[] menu =
                {
            "请使用:上下方向键切换, 回车确定, Esc返回",
            "--------------<栈>--------------",
            "1. 创建二叉树",
            "2. 先序遍历二叉树",
            "3. 中序序遍历二叉树",
            "4. 后序遍历二叉树",
            "5. 计算树的深度 ",
            "6. 退出",
            "--------------------------------"
            };

            public MyMenu()
            {

                MyTree<string> myTree = new MyTree<string>();

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

                                myTree.PreTraversal();
                                Console.WriteLine("长出了 {0} 个结点", myTree.Count);
                                break;
                            case 2:
                                myTree.PreTraversal();

                                break;
                            case 3:
                                myTree.InoTraversal();
                                break;
                            case 4:
                                myTree.PosTraversal();
                                break;
                            case 5:
                                Console.WriteLine(myTree.GetTreeDepth().ToString());
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
        static void Main(string[] args)
		{
            MyMenu tree = new MyMenu();
		}
	}
}
