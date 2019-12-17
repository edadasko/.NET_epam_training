using System;
using System.Collections;
using System.Collections.Generic;

namespace BST_Task
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> root;

        private readonly IComparer<T> comparer;

        public BinarySearchTree()
        {
            this.root = null;
            this.comparer = Comparer<T>.Default;
        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            this.root = null;
            this.comparer = comparer;
        }

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new Node<T>(value);
                return;
            }

            this.Insert(value, root);
        }

        public void Remove(T value) => Remove(value, root);

        public bool Find(T value) => Find(value, root);

        public IEnumerable<T> InOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.InOrder(this.root);
        }

        public IEnumerable<T> PostOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.PostOrder(this.root);
        }

        public IEnumerable<T> PreOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.PreOrder(this.root);
        }

        private void Insert(T value, Node<T> node)
        {
            if (comparer.Compare(value, node.Value) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value)
                    {
                        Parent = node
                    };
                    return;
                }

                Insert(value, node.Right);
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value)
                    {
                        Parent = node
                    };
                    return;
                }

                Insert(value, node.Left);
            }
        }

        private void Remove(T value, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (this.comparer.Compare(value, node.Value) < 0)
            {
                this.Remove(value, node.Left);
                return;
            }

            if (this.comparer.Compare(value, node.Value) > 0)
            {
                this.Remove(value, node.Right);
                return;
            }

            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = null;
                    return;
                }
                else
                {
                    node.Parent.Right = null;
                    return;
                }
            }

            if (node.Left == null)
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }

            if (node.Right == null)
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            T leftMost = FindLeft(node.Right);
            node.Value = leftMost;
            Remove(leftMost, node.Right);

            static T FindLeft(Node<T> node)
            {
                if (node.Left != null)
                {
                    return FindLeft(node.Left);
                }

                return node.Value;
            }
        }

        private bool Find(T value, Node<T> currentNode)
        {
            if (currentNode == null)
                return false;

            if (comparer.Compare(value, currentNode.Value) == 0)
            {
                return true;
            }

            if (comparer.Compare(value, currentNode.Value) > 0)
            {
                return Find(value, currentNode.Right);
            }

            return Find(value, currentNode.Left);
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var elem in this.InOrder(node.Left))
                {
                    yield return elem;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var elem in this.InOrder(node.Right))
                {
                    yield return elem;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var elem in this.PostOrder(node.Left))
                {
                    yield return elem;
                }
            }

            if (node.Right != null)
            {
                foreach (var elem in this.PostOrder(node.Right))
                {
                    yield return elem;
                }
            }

            yield return node.Value;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var elem in this.PreOrder(node.Left))
                {
                    yield return elem;
                }
            }

            if (node.Right != null)
            {
                foreach (var elem in this.PreOrder(node.Right))
                {
                    yield return elem;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }
    }
}
