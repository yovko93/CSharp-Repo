using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        public Box(List<T> list)
        {
            this.List = list;
        }
        public List<T> List { get; set; } = new List<T>();

        public int GetCountOfGreaterValues(T value)
        {
            int counter = 0;

            foreach (T currentValue in List)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
