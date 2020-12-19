using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count
            => this.pets.Count;


        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name);

            return pets.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(p =>
            p.Name == name
            && p.Owner == owner);

            if (pet != null)
            {
                return pet;
            }

            return null;
        }

        public Pet GetOldestPet()
        {

            Pet pet = pets.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb
                .ToString()
                .Trim();
        }
    }
}
