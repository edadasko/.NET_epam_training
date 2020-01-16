//-----------------------------------------------------------------------
// <copyright file="Queue.cs" company="EpamTraining">
//     All rights reserved.
// </copyright>
// <author>Eduard Adasko</author>
//-----------------------------------------------------------------------

namespace QueueTask
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Generic class for operations with queue.
    /// </summary>
    /// <typeparam name="T">Type for elements of a queue.</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Head of a queue.
        /// </summary>
        private Node<T> head;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.head = null;
        }

        /// <summary>
        /// Adds element to a queue.
        /// </summary>
        /// <param name="element">Element to add.</param>
        public void Push(T element)
        {
            if (this.head == null)
            {
                this.head = new Node<T>(element);
                return;
            }

            Node<T> pointer = this.head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }

            pointer.Next = new Node<T>(element);
        }

        /// <summary>
        /// Takes out element from a head of a queue.
        /// </summary>
        /// <returns>Element from head.</returns>
        public T Pop()
        {
            if (this.head == null)
            {
                throw new NullReferenceException();
            }

            T element = this.head.Element;
            this.head = this.head.Next;
            return element;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => new QueueEnumerator(this);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        /// Enumerator for iterating over a queue.
        /// </summary>
        public class QueueEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Queue for iterating.
            /// </summary>
            private readonly Queue<T> queue;

            /// <summary>
            /// Pointer for iterating.
            /// </summary>
            private Node<T> pointer;

            /// <summary>
            /// Initializes a new instance of the <see cref="QueueEnumerator"/> class.
            /// </summary>
            /// <param name="queue">Queue for iterating.</param>
            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue ?? throw new ArgumentNullException();
                this.pointer = new Node<T>(default);
                this.pointer.Next = queue.head;
            }

            /// <inheritdoc/>
            public T Current => this.pointer.Element;

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (this.pointer.Next != null)
                {
                    this.pointer = this.pointer.Next;
                    return true;
                }

                return false;
            }

            /// <inheritdoc/>
            public void Reset()
            {
                this.pointer = new Node<T>(default);
                this.pointer.Next = this.queue.head;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
            }
        }
    }
}
