using _2._04.BorderControl.Contracts;
using _2._04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;

            List<IId> ids = new List<IId>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split().ToArray();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    IId citizen = new Citizen(name, age, id);

                    ids.Add(citizen);
                }
                else if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];

                    IId robot = new Robot(model, id);

                    ids.Add(robot);
                }

            }

            int lastDigitsId = int.Parse(Console.ReadLine());

            var fakeIds = ids.FindAll(x => x.Id.EndsWith(lastDigitsId.ToString()));

            foreach (var id in fakeIds)
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
