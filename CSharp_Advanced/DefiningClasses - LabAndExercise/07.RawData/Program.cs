using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.RawData
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                //double tire1Pressure = double.Parse(info[5]);
                //int tire1Age = int.Parse(info[6]);
                //double tire2Pressure = double.Parse(info[7]);
                //int tire2Age = int.Parse(info[8]);
                //double tire3Pressure = double.Parse(info[9]);
                //int tire3Age = int.Parse(info[10]);
                //double tire4Pressure = double.Parse(info[11]);
                //int tire4Age = int.Parse(info[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                int counter = 0;
                for (int j = 5; j < info.Length; j+=2)
                {
                    double tire1Pressure = double.Parse(info[j]);
                    int tire1Age = int.Parse(info[j + 1]);

                    Tire tire = new Tire(tire1Pressure, tire1Age);
                    tires[counter++] = tire;
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                var fragileCars = cars.Where(x => x.Cargo.Type == "fragile" 
                && x.Tires.Any(p => p.TirePressure < 1)).ToList();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "flamable")
            {
                var flamableCars = cars.Where(x => x.Cargo.Type == "flamable"
                && x.Engine.Power > 250).ToList();

                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }


        }
    }
}
