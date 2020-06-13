using HuffmanCoder;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Fans
{
    namespace BinaryTree
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
            "------------<二叉树>------------",
            "1. 创建二叉树",
            "2. 遍历二叉树(先序、中序、后序遍历)",
            "3. 计算叶子结点个数及树的深度",
            "4. 查找指定结点的双亲",
            "5. 查找指定结点的兄弟",
            "6. Huffman 编码(应用)",
            "7. 退出",
            "--------------------------------"
            };

            public void DoFunc (ref MyTree<string> myTree)
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
                        myTree = default;
                        myTree = new MyTree<string>();
                        myTree.Insert("F");
                        myTree.Insert("B");
                        myTree.Insert("H");
                        myTree.Insert("A");
                        myTree.Insert("C");
                        myTree.Insert("D");
                        myTree.Insert("G");
                        myTree.Insert("E");
                        myTree.Insert("I");
                        //          F
                        //    B           H
                        //  A   C       G   I
                        //        D
                        //         E
                        // 深度 5
                        myTree.PreTraversal();
                        Console.WriteLine("长出了 {0} 个结点", myTree.Count);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("先序遍历:");
                        myTree.PreTraversal();
                        Console.WriteLine("中序序遍:");
                        myTree.InoTraversal();
                        Console.WriteLine("后序遍历:");
                        myTree.PosTraversal();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("叶子结点个数为: " + myTree.GetWeedNum().ToString());
                        Console.WriteLine("树的最大深度为: " + myTree.GetTreeDepth().ToString());
                        break;
                    }
                    case 4:
                    {
                        myTree.PreTraversal();
                        Console.Write("挑一个吧，请输入: ");
                        myTree.GetParentNode(Console.ReadLine());
                        break;
                    }
                    case 5:
                    {
                        myTree.PreTraversal();
                        Console.Write("挑一个吧，请输入: ");
                        myTree.GetChildrenNode(Console.ReadLine());
                        break;
                    }
                    case 6:
                    {
                        List<HuffmanNode> NodeList = new List<HuffmanNode>();
                        Dictionary<char, string> CodingDictonary = new Dictionary<char, string>();

                        Console.Write("Please type your text and press Enter: ");
                        string text = Console.ReadLine();
                        if (text == string.Empty)
						{
                            return;
						}

                        //添加并排序
                        NodeList.Add(new HuffmanNode(text[0]));
                        for (int i = 1; i <= text.Length - 1; i++)
                        {
                            HuffmanNode existingNode = NodeList.Find(n => n.chr == text[i]);
                            if (existingNode == null)
                            {
                                NodeList.Add(new HuffmanNode(text[i]));
                            }
                            else
                            {
                                existingNode.frequency++;
                            }
                        }
                        NodeList.Sort();
                        while (NodeList.Count > 1)
                        {
                            NodeList.Add(new HuffmanNode(NodeList[0], NodeList[1]));
                            NodeList.RemoveRange(0, 2);
                            NodeList.Sort();
                        }
                        //编码
                        NodeList[0].CollectCodes(string.Empty, CodingDictonary);


                        Console.WriteLine("\n变长码: ");
                        foreach (KeyValuePair<char, string> keyValuePair in CodingDictonary)
                        {
                            Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
                        }

                        string resultCodedText = "";
                        for (int i = 0; i <= text.Length - 1; i++)
                        {
                            resultCodedText += CodingDictonary[text[i]];
                        }
                        Console.WriteLine("\nHuffman coded text: \n" + resultCodedText);
                        break;
                    }
                    case 7:
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
