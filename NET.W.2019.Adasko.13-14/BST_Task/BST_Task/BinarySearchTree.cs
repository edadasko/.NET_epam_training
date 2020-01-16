//-----------------------------------------------------------------------
// <copyright file="BinarySearchTree.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BST_Task
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents generic binary search tree and provides operations for working with it.
    /// </summary>
    /// <typeparam name="T">Type of nodes values.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Comparer for nodes collocation.
        /// </summary>
        private readonly IComparer<T> comparer;

        /// <summary>
        /// Root of a tree.
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Comparer for tree nodes.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.root = null;
            this.comparer = comparer;
        }

        /// <summary>
        /// Inserts a new node to a tree.
        /// </summary>
        /// <param name="value">Value to insert.</param>
        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(value);
                return;
            }

            this.Insert(value, this.root);
        }

        /// <summary>
        /// Removes a value from a tree.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        public void Remove(T value) => this.Remove(value, this.root);

        /// <summary>
        /// Finds value in a tree.
        /// </summary>
        /// <param name="value">Value for searching.</param>
        /// <returns>Is there element in a tree.</returns>
        public bool Find(T value) => this.Find(value, this.root);

        /// <summary>
        /// In order traversal.
        /// </summary>
        /// <returns>IEnumerable for in order iterating.</returns>
        public IEnumerable<T> InOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.InOrder(this.root);
        }

        /// <summary>
        /// Post order traversal.
        /// </summary>
        /// <returns>IEnumerable for post order iterating.</returns>
        public IEnumerable<T> PostOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.PostOrder(this.root);
        }

        /// <summary>
        /// Pre order traversal.
        /// </summary>
        /// <returns>IEnumerable for pre order iterating.</returns>
        public IEnumerable<T> PreOrder()
        {
            if (this.root == null)
            {
                throw new NullReferenceException();
            }

            return this.PreOrder(this.root);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }

        private void Insert(T value, Node<T> node)
        {
            if (this.comparer.Compare(value, node.Value) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value)
                    {
                        Parent = node
                    };
                    return;
                }

                this.Insert(value, node.Right);
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

                this.Insert(value, node.Left);
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
            {
                return false;
            }

            if (this.comparer.Compare(value, currentNode.Value) == 0)
            {
                return true;
            }

            if (this.comparer.Compare(value, currentNode.Value) > 0)
            {
                return this.Find(value, currentNode.Right);
            }

            return this.Find(value, currentNode.Left);
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
    }
}
