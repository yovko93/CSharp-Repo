using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box(List<T> list)
        {
            this.List = list;
        }

        public List<T> List { get; set; } = new List<T>();


        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = this.List[firstIndex];
            this.List[firstIndex] = this.List[secondIndex];
            this.List[secondIndex] = temp;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T value in List)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }

            return sb
                .ToString()
                .Trim();
        }

    }
}
