using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indexes = new Dictionary<T, int>();
        }

        public void Enqueue(T element)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void DecreaseKey(T key)
        {
            HeapifyUp(this.indexes[key]);
        }

        public void DecreaseKey(T key, T newKey)
        {
            var oldIndex = this.indexes[key];
            this.elements[oldIndex] = newKey;
            this.indexes.Remove(key);
            this.indexes.Add(newKey, oldIndex);

            this.HeapifyUp(oldIndex);
        }
    }
}
