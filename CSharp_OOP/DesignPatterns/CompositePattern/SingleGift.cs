﻿using System;

namespace CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            return this.Price;
        }
    }
}
