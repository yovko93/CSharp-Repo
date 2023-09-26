namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;

        public CircularQueue(int capacity = 4)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var deletedItem = this.elements[this.startIndex];

            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return deletedItem;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.elements[this.startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyElements(new T[this.Count]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < this.Count; currentIndex++)
            {
                var index = (startIndex + currentIndex) % this.elements.Length;
                yield return this.elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        #region Helpers
        private void Grow()
        {
            this.elements = this.CopyElements(new T[this.elements.Length * 2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
            }

            return resultArr;
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
        #endregion
    }

}
