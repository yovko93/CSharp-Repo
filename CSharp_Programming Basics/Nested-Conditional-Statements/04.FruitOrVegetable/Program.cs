using System;

namespace _04.FruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }

            //CTRL + K + C
            //CTRL + K + U
            //if(product == "banana" || product == "apple" || product == "kiwi" || product== "cherry" || product == "lemon" || product == "grapes")
            //{
            //    Console.WriteLine("fruit");
            //}
            //else if(product == "tomato" || product == "cucumber" || product == "pepper" || product == "carrot")
            //{
            //    Console.WriteLine("vegetable");
            //}
            //else
            //{
            //    Console.WriteLine("unknown");
            //}
        }
    }
}
