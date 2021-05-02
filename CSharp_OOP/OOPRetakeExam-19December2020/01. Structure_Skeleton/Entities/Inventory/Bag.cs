using System;
using System.Linq;
using WarCroft.Entities.Items;
using System.Collections.Generic;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        //private int capacity = 100;

        private readonly ICollection<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load =>
            this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => 
            this.items.ToList();

        public void AddItem(Item item)
        {
            int newWeight = this.Load + item.Weight;

            if (newWeight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (item == null)
            {
                var excMessage = String.Format(ExceptionMessages.ItemNotFoundInBag, name);

                throw new ArgumentException(excMessage);
            }

            this.items.Remove(item);

            return item;
        }
    }
}
