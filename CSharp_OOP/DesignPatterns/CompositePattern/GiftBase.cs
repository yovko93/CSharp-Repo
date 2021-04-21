namespace CompositePattern
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }


        public abstract int CalculateTotalPrice();
    }
}
