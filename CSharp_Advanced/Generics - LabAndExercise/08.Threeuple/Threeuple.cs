using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }

        public TFirst FirstItem { get; set; }

        public TSecond SecondItem { get; set; }

        public TThird ThirdItem { get; set; }


        //public override string ToString()
        //{
        //    return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        //}

    }
}
