using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace BinaryTree
{
    public class MyNode<T>
	{
        public MyNode<T> LChild;
        private T _Data;
        public MyNode<T> RChild;

        public MyNode()
		{
			LChild = null;
			_Data = default(T);
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
			_Data = default(T);
			RChild = rp;
		}
		public MyNode(T item)
		{
			LChild = null;
			_Data = item;
			RChild = null;
		}

        //public MyNode<T> LChild { get { return _LChild; }  set { _LChild = value; } }
        public T Data { get { return _Data; } set { _Data = value; } }
        //public MyNode<T> RChild { get { return RChild; } set { RChild = value; } }
    }

	public class MyTree<T>
    {
        private MyNode<T> root;
        private int _count;

        public MyTree()
        {
            root = null;
        }

        public MyTree(MyNode<T> lNode, T value, MyNode<T> rNode )
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
                else if (i== 1)
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

        //public void Insert(T data)
        //{
        //    MyNode<T> newNode = new MyNode<T>(data);
        //    MyNode<T> current = root;

        //    if (root == null)
        //    {
        //        root = newNode;
        //        return;
        //    }
        //    else
        //    {
        //        while (true)
        //        {
        //            MyNode<T> parent = current;
        //            if (string.Compare(current.Data.ToString(), data.ToString())>0)
        //            {
        //                current = current.LChild;
        //                if (current == null)
        //                {
        //                    parent.LChild = newNode;
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                current = current.RChild;
        //                if (current == null)
        //                {
        //                    parent.RChild = newNode;
        //                    break;
        //                }

        //            }
        //        }
        //    }
        //}

        public void PreTraversal<T>(MyNode<T> root)
        {
            if(root ==  null)
            {
                return;
            }

            Console.Write(root.Data + " ");
            PreTraversal<T>(root.LChild);
            PreTraversal<T>(root.RChild);
        }
        public void PreTraversal()
        {
            PreTraversal<T>(root);
            Console.Write("\n");
        }

        public void InoTraversal<T>(MyNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            PreTraversal<T>(root.LChild);
            Console.Write(root.Data + " ");   
            PreTraversal<T>(root.RChild);
        }
        public void InoTraversal()
        {
            InoTraversal<T>(root);
            Console.Write("\n");
        }

        public void PosTraversal<T>(MyNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            PreTraversal<T>(root.LChild);
            PreTraversal<T>(root.RChild);
            Console.Write(root.Data + " ");
        }
        public void PosTraversal()
        {
            PosTraversal<T>(root);
            Console.Write("\n");
        }

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

        public void Clear()
        {
            root = null;
        }

        public int Count { get { return _count; } }

        public bool IsEmpty { get { return root == null; } }

    }
}