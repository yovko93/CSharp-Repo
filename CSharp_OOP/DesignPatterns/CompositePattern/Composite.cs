using System.Collections.Generic;

namespace CompositePattern
{
    public class Composite : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> giftBases;

        public Composite(string name, int price) 
            : base(name, price)
        {
            this.giftBases = new List<GiftBase>();


        }


        public void Add(GiftBase giftBase)
        {
            this.giftBases.Add(giftBase);
        }

        public bool Remove(GiftBase giftBase)
        {
           return this.giftBases.Remove(giftBase);
        }
       
        public override int CalculateTotalPrice()
        {
            var totalPrice = 0;

            foreach (var item in this.giftBases)
            {
                totalPrice += item.CalculateTotalPrice();
            }

            return totalPrice;
        }

    }
}
