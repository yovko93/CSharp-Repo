using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("gosho");
            list.Add("gosho1");
            list.Add("gosho2");

            Console.WriteLine(list.RandomString());
            Console.WriteLine( list.Count);
        }
    }
}
