using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDoubles
{
    public class Box<T>
        where T : IComparable
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }

        public List<T> Values { get; set; } = new List<T>();

        public int GetCountOfGreaterValues(T value)
        {
            int counter = 0;

            foreach (T num in Values)
            {
                if (num.CompareTo(value) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}
