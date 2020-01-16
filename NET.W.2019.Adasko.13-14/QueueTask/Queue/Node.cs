//-----------------------------------------------------------------------
// <copyright file="Node.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace QueueTask
{
    /// <summary>
    /// Generic class for Node of a Queue.
    /// </summary>
    /// <typeparam name="T">
    /// Type of queue's values.
    /// </typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="element">Element of node.</param>
        public Node(T element)
        {
            this.Element = element;
            this.Next = null;
        }

        /// <summary>
        /// Gets element in this node.
        /// </summary>
        public T Element { get; }

        /// <summary>
        /// Gets or sets a pointer to the next node.
        /// </summary>
        public Node<T> Next { get; set; }
    }
}
