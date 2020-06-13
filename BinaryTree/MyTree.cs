//Copyright:FANS Corporation
//Author: Kiana
//Date: 22-05-2019 02:06AM
//Description: 二叉树类
//Version: Alpha 0.1

using System;

namespace Fans
{
    namespace BinaryTree
    {
        public class MyNode<T>
        {
            //由于引用的问题，只能Public了
            public MyNode<T> LChild;
            private T _Data;
            public T Data { get { return _Data; } set { _Data = value; } }

            public MyNode<T> RChild;

            public MyNode()
            {
                LChild = null;
                _Data = default;
                RChild = null;
            }
            public MyNode(MyNode<T> lp, T data, MyNode<T> rp)
            {
                LChild = lp;
                _Data = data;
                RChild = rp;
            }
            public MyNode(MyNode<T> lp, MyNode<T> rp)
            {
                LChild = lp;
                _Data = default;
                RChild = rp;
            }
            public MyNode(T item)
            {
                LChild = null;
                _Data = item;
                RChild = null;
            }
        }

        public class MyTree<T>
        {
            private MyNode<T> root;
            private int _count;

            public MyTree()
            {
                root = null;
            }
            public MyTree(MyNode<T> lNode, T value, MyNode<T> rNode)
            {
                root.LChild = lNode;
                root.Data = value;
                root.RChild = rNode;
            }
            public MyTree(T value)
            {
                root.Data = value;
            }
            public MyTree(MyNode<T> lNode, MyNode<T> rNode)
            {
                root.LChild = lNode;
                root.RChild = rNode;
            }

            //地龟创建树
            public void Insert(ref MyNode<T> current, T data)
            {
                if (current == null)
                {
                    current = new MyNode<T>(data);
                    return;
                }
                else
                {
                    int i = data.ToString().CompareTo(current.Data.ToString());

                    if (i == -1)
                    {
                        Insert(ref current.LChild, data);
                    }
                    else if (i == 1)
                    {
                        Insert(ref current.RChild, data);
                    }
                }
            }
            public void Insert(T data)
            {
                Insert(ref root, data);
                _count++;
            }

            //地龟 先序遍历
            public void PreTraversal(MyNode<T> root)
            {
                if (root == null)
                {
                    return;
                }

                Console.Write(root.Data + " ");
                PreTraversal(root.LChild);
                PreTraversal(root.RChild);
            }
            public void PreTraversal()
            {
                PreTraversal(root);
                Console.Write("\n");
            }

            //地龟 中序遍历
            public void InoTraversal(MyNode<T> root)
            {
                if (root == null)
                {
                    return;
                }
                PreTraversal(root.LChild);
                Console.Write(root.Data + " ");
                PreTraversal(root.RChild);
            }
            public void InoTraversal()
            {
                InoTraversal(root);
                Console.Write("\n");
            }

            //地龟 后序遍历
            public void PosTraversal(MyNode<T> root)
            {
                if (root == null)
                {
                    return;
                }
                PreTraversal(root.LChild);
                PreTraversal(root.RChild);
                Console.Write(root.Data + " ");
            }
            public void PosTraversal()
            {
                PosTraversal(root);
                Console.Write("\n");
            }

            //地龟 获取叶子
            public void GetWeedNode(MyNode<T> root, ref int result)
            {
                if (root == null)
                {
                    return;
                }
                if (root.LChild == null && root.RChild == null)
                {
                    result++;
                    return;
                }
                else
                {
                    GetWeedNode(root.LChild, ref result);
                    GetWeedNode(root.RChild, ref result);
                }
            }
            public int GetWeedNum()
            {
                int result = 0;
                GetWeedNode(root, ref result);
                return result;
            }

            //地龟 获取树深度
            public int GetTreeDepth(MyNode<T> root)
            {
                if (root == null)
                {
                    return 0;
                }

                int left = GetTreeDepth(root.LChild);
                int right = GetTreeDepth(root.RChild);

                return left >= right ? left + 1 : right + 1;
            }
            public int GetTreeDepth()
            {
                return GetTreeDepth(root);
            }

            //地龟 获取父结点
            public MyNode<T> GetParentNode(MyNode<T> root, string item)
            {
                if (root == null)
                {
                    return default;
                }
                if (root.LChild.Data.ToString().Equals(item) || root.RChild.Data.ToString().Equals(item))
                {
                    return root;
                }
                if (GetParentNode(root.LChild, item) != default)
                {
                    return root.LChild;
                }
                if (GetParentNode(root.RChild, item) != default)
                {
                    return root.RChild;
                }
                return default;

            }
            public void GetParentNode(string item)
            {
                MyNode<T> result = GetParentNode(root, item);

                if (result == default)
                {
                    Console.WriteLine("没找到这个结点");
                }
                else
                {
                    Console.WriteLine("父结点为: " + result.Data.ToString());
                }
            }

            //地龟 获取子结点
            public MyNode<T> GetChildrenNode(MyNode<T> root, string item)
            {
                MyNode<T> result = new MyNode<T>();
                if (root == null)
                {
                    return default;
                }
                if (root.Data.ToString().Equals(item))
                {
                    return root;
                }
                else
                {
                    result = GetChildrenNode(root.LChild, item);
                    if (result == null)
                    {
                        result = GetChildrenNode(root.RChild, item);
                        if (result == null)
                        {
                            return default;
                        }
                    }
                    return result;
                }
            }
            public void GetChildrenNode(string item)
            {
                MyNode<T> result = GetChildrenNode(root, item);

                string[] resultLR = new string[2];

                if (result.LChild == null && result.RChild != null)
                {
                    resultLR[0] = "null";
                    resultLR[1] = result.RChild.Data.ToString();
                    Console.WriteLine("子结点为: ");
                    foreach (var node in resultLR)
                    {
                        Console.Write(node + " ");
                    }
                    return;
                }
                if (result.LChild != null && result.RChild == null)
                {
                    resultLR[0] = result.LChild.Data.ToString();
                    resultLR[1] = "null";
                    Console.WriteLine("子结点为: ");
                    foreach (var node in resultLR)
                    {
                        Console.Write(node + " ");
                    }
                    return;
                }
                if (result.LChild != null && result.RChild != null)
                {
                    resultLR[0] = result.LChild.Data.ToString();
                    resultLR[1] = result.RChild.Data.ToString();
                    Console.WriteLine("子结点为: ");
                    foreach (var node in resultLR)
                    {
                        Console.Write(node + " ");
                    }
                    return;
                }
                Console.WriteLine("{0} 为叶子结点", item);
                return;
            }

            public void Clear()
            {
                root = null;
            }

            public int Count { get { return _count; } }

            public bool IsEmpty { get { return root == null; } }

        }
    }
}