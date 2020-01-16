//-----------------------------------------------------------------------
// <copyright file="Node.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace BST_Task
{
    /// <summary>
    /// Represents a node in binary tree.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">Value in a node.</param>
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
            this.Parent = null;
        }

        /// <summary>
        /// Gets or sets a value of a node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets left child of a node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets right child of a node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Gets or sets parent of a node.
        /// </summary>
        public Node<T> Parent { get; set; }
    }
}
