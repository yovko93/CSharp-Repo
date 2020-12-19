using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public List<T> List { get; set; } = new List<T>();

        public Box(List<T> list)
        {
            this.List = list;
        }
        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var value in List)
            {
                sb.Append(value.GetType() + ": ");
                sb.AppendLine(value.ToString());
            
            }

            return sb.ToString().Trim();
        }

    }
}
