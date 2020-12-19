using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<TFirst, TSecond>
    {
        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public TFirst FirstItem { get; set; }

        public TSecond SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}".ToString();
        }

    }
}
