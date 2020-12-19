using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            if (personInfo.Length == 5)
            {
                town += " " + personInfo[4];
            }

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>(fullName, address, town);

            string[] nameBeerAndDrunk = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = nameBeerAndDrunk[0];
            int beer = int.Parse(nameBeerAndDrunk[1]);
            string isDrunk = string.Empty;

            if (nameBeerAndDrunk[2] == "not")
            {
                isDrunk = "False";
            }
            else if (nameBeerAndDrunk[2] == "drunk")
            {
                isDrunk = "True";
            }

            Tuple<string, int, string> secondTuple = new Tuple<string, int, string>(name, beer, isDrunk);

            string[] personBankInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string personName = personBankInfo[0];
            double bankBalance = double.Parse(personBankInfo[1]);
            string bankName = personBankInfo[2];

            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(personName, bankBalance, bankName);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2} -> {firstTuple.Item3}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2} -> {secondTuple.Item3}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2} -> {thirdTuple.Item3}");

        }
    }
}
