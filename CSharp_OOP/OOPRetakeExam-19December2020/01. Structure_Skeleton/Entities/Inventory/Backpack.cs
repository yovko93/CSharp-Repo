namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int DefaultCapacityValue = 100;

        public Backpack() 
            : base(DefaultCapacityValue)
        {
        }
    }
}
