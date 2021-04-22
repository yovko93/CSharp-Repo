using System;
using System.Collections.Generic;

using _2._03.ShoppingSpree.Common;

namespace _2._03.ShoppingSpree.Models
{
    public class Person
    {
        private const string NOT_ENOUGH_MONEY_EXC_MSG = "{0} can't afford {1}";
        private const string SUCC_BOUGHT_PRODUCT_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXC_MSG);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_MONEY_EXC_MSG);
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag.AsReadOnly();
            }
        }


        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return String.Format(NOT_ENOUGH_MONEY_EXC_MSG, this.Name, product.Name);
            }

            this.Money -= product.Cost;
            this.bag.Add(product);

            return String.Format(SUCC_BOUGHT_PRODUCT_MSG, this.Name, product.Name);
        }

        public override string ToString()
        {
            string productOutput = this.Bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {productOutput}";
        }

    }
}
