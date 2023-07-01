using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms.HelperClasses
{
    public class SplayTree
    {
        public Node NewNode(int key)
        {
            Node node = new Node(key);
            node.Left = node.Right = null;
            return node;
        }

        public Node? RightRotate(Node? x)
        {
            if (x is null)
            {
                return x;
            }
            Node? y = x.Left;
            if (y is not null)
            {
                x.Left = y.Right;
                y.Right = x;
            }
            return y;
        }

        public Node? LeftRotate(Node? x)
        {
            if (x is null)
            {
                return x;
            }
            Node? y = x.Right;
            if (y is not null)
            {
                x.Right = y.Left;
                y.Left = x;
            }
            return y;
        }

        public Node? Splay(Node? root, int key)
        {
            if (root is null || root.Value == key)
            {
                return root;
            }

            if (root.Value > key)
            {
                if (root.Left is null)
                {
                    return root;
                }
                if (root.Left.Value > key)
                {
                    root.Left.Left = Splay(root.Left.Left, key);
                    root = RightRotate(root);
                }
                else if (root.Left.Value < key)
                {
                    root.Left.Right = Splay(root.Left.Right, key);
                    if (root.Left.Right is not null)
                    {
                        root.Left = LeftRotate(root.Left);
                    }
                }
                return (root is null || root.Left is null) ? root : RightRotate(root);
            }
            else
            {
                if (root.Right is null)
                {
                    return root;
                }
                if (root.Right.Value > key)
                {
                    root.Right.Left = Splay(root.Right.Left, key);
                    if (root.Right.Left is not null)
                    {
                        root.Right = RightRotate(root.Right);
                    }
                }
                else if (root.Right.Value < key)
                {
                    root.Right.Right = Splay(root.Right.Right, key);
                    root = LeftRotate(root);
                }
                return (root is null || root.Right is null) ? root : LeftRotate(root);
            }
        }

        public Node? Insert(Node? root, int key)
        {
            if (root is null)
            {
                return NewNode(key);
            }

            root = Splay(root, key);

            if (root is not null && root.Value == key)
            {
                return root;
            }

            Node node = NewNode(key);
            if (root is not null && root.Value > key)
            {
                node.Right = root;
                node.Left = root.Left;
                root.Left = null;
            }
            else
            {
                node.Left = root;
                if (root is not null)
                {
                    node.Right = root.Right;
                    root.Right = null;
                }
            }
            return node;
        }

        public void InOrderTraversal(Node? node, Action<int> action)
        {
            if (node is not null)
            {
                if (node.Left is not null)
                {
                    InOrderTraversal(node.Left, action);
                }
                action(node.Value);
                if (node.Right is not null)
                {
                    InOrderTraversal(node.Right, action);
                }
            }
        }
    }
}
