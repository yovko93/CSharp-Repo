namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int DefaultCapacityValue = 20;

        public Satchel() 
            : base(DefaultCapacityValue)
        {
        }
    }
}
