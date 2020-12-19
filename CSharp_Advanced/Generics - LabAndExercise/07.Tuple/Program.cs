using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split()
                .ToArray();

            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            Tuple<string, string> tuple = new Tuple<string, string>(fullName, address);


            string[] nameAndAmount = Console.ReadLine()
                .Split()
                .ToArray();

            string name = nameAndAmount[0];
            int amount = int.Parse(nameAndAmount[1]);

            Tuple<string, int> tuple2 = new Tuple<string, int>(name, amount);

            string[] intAndDouble = Console.ReadLine()
                .Split()
                .ToArray();

            int intNum = int.Parse(intAndDouble[0]);
            double doubleNum = double.Parse(intAndDouble[1]);

            Tuple<int, double> tuple3 = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);

        }
    }
}
