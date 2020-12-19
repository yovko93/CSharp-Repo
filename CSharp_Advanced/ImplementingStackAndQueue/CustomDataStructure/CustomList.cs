using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructure
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentException();
                }

                return this.items[index];
            }
            set
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentException();
                }

                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentException();
            }

            var removed = this.items[index];
            this.items[index] = default;
            this.ShiftToLeft(index);
            this.Count--;

            if (this.Count <= this.items.Length/4)
            {
                this.Shrink();
            }

            return removed;

        }

        public void Insert(int index, int item)
        {
            if (!this.IsValidIndex(index))
            {
                throw new ArgumentException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;

        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element == this.items[i])
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }

        public void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            items = copy;
        }

        private bool IsValidIndex(int index)
        {
            return index < this.Count;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count -1)
                {
                    sb.Append($"{this.items[i]}");
                }
                else
                {
                    sb.Append($"{this.items[i]}, ");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
