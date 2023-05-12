namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            var node = this.head;
            return node.Element;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;

            return oldHead.Element;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var node = this.head;

            if (this.Count == 1)
            {
                this.head = null;
                this.Count--;
                return node.Element;
            }

            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            var deletedElement = node.Next;
            node.Next = null;
            this.Count--;
            return deletedElement.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        #region Helpers
        private void EnsureNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
        #endregion
    }
}