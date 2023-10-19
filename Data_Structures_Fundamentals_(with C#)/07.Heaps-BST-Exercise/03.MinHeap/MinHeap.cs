using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected Dictionary<T, int> indexes;
        protected List<T> elements;

        public MinHeap()
        {
            this.indexes = new Dictionary<T, int>();
            this.elements = new List<T>();
        }

        public int Count => throw new NotImplementedException();

        public void Add(T element)
        {
            throw new NotImplementedException();
        }

        public T ExtractMin()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
