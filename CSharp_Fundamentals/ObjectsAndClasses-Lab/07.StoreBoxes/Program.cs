using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] data = command.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                decimal itemPrice = decimal.Parse(data[3]);

                decimal totalPrice = itemQuantity * itemPrice;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.ItemPrice = itemPrice;
                box.PriceBox = totalPrice;

                boxes.Add(box);
                command = Console.ReadLine();
            }

            List<Box> sortedBox = boxes.OrderBy(itemBoxes => itemBoxes.PriceBox).ToList();
            sortedBox.Reverse();

            foreach (Box box in sortedBox)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.ItemPrice:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }

        //class Item
        //{
        //    public string Name { get; set; }

        //    public decimal Price { get; set; }
        //}

        class Box
        {
            public string SerialNumber { get; set; }

            public string ItemName { get; set; }

            public int ItemQuantity { get; set; }

            public decimal ItemPrice { get; set; }

            public decimal PriceBox { get; set; }

            //public Box()
            //{
            //    ItemName = new Item();
            //    this.ItemName = ItemName;
            //    this.ItemPrice = ItemPrice;
            //}
        }
    }
}
