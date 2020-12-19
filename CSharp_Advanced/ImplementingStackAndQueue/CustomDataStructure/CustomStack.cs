using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructure
{
    public class CustomStack
    {
        private const int Initaial_Capacity = 4;
        private const string EMPTY_STACK_EXC_MSG = "Stack is Empty!";

        private int[] items;

        public CustomStack()
        {
            this.items = new int[Initaial_Capacity];
        }

        public int Count { get; private set; }


        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException
                    (EMPTY_STACK_EXC_MSG);
            }

            int poppedItem = this.items[this.Count - 1];
            this.items[this.Count - 1] = default;
            this.Count--;
            
            return poppedItem;

        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            int lastElement = this.items[this.Count - 1];

            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }

        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
