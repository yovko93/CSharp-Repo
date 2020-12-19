using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace Christmas
{
    class Bag
    {
        private List<Present> presents;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            this.presents = new List<Present>();
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count
            => this.presents.Count;


        public void Add(Present present)
        {
            if (Count < Capacity)
            {
                presents.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var present = presents.FirstOrDefault(x => x.Name == name);

            return presents.Remove(present);
        }

        public Present GetHeaviestPresent()
        {
            Present present = presents.OrderByDescending(x => x.Weight).First();

            return present;
        }

        public Present GetPresent(string name)
        {
            var present = presents.FirstOrDefault(x => x.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} bag contains:");

            foreach (var present in presents)
            {
                sb.AppendLine(present.ToString());
            }

            return sb
                .ToString()
                .Trim();
        }

    }
}
