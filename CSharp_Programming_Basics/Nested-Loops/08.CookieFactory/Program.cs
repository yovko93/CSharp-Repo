using System;

namespace _08.CookieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int batch = int.Parse(Console.ReadLine());

            int countBatch = 0;
            bool flour = false;
            bool eggs = false;
            bool sugar = false;
            string ingredient = string.Empty;

            for (int i = 1; i <= batch; i++)
            {
                while (!flour && !eggs && !sugar)
                {
                    ingredient = Console.ReadLine();
                    if (ingredient == "flour")
                    {
                        flour = true;
                    }
                    else if (ingredient == "eggs")
                    {
                        eggs = true;
                    }
                    else if (ingredient == "sugar")
                    {
                        sugar = true;
                    }
                    if (ingredient == "Bake!")
                    {
                        if (flour && eggs && sugar)
                        {
                            Console.WriteLine($"Baking batch number {++countBatch}...");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                            ingredient = Console.ReadLine();
                        }
                    }
                }

            }



            //for (int i = 1; i <= batch; i++)
            //{
            //    string command = Console.ReadLine();
            //    if (command == "Bake!")
            //    {
            //        Console.WriteLine("The batter should contain flour, eggs and sugar!");
            //        command = Console.ReadLine();
            //    }
            //    while (command != "Bake!")
            //    {
            //        if (command == "flour")
            //        {
            //            flour = true;
            //        }
            //        if (command == "eggs")
            //        {
            //            eggs = true;
            //        }
            //        if (command == "sugar")
            //        {
            //            sugar = true;
            //        }
            //        command = Console.ReadLine();
            //        if (command == "Bake!")
            //        {
            //            if (flour && eggs && sugar)
            //            {
            //                Console.WriteLine($"Baking batch number {++countBatch}...");
            //                flour = false;
            //                eggs = false;
            //                sugar = false;
            //                continue;
            //            }
            //            else
            //            {
            //                Console.WriteLine("The batter should contain flour, eggs and sugar!");
            //                command = Console.ReadLine();
            //            }

            //        }
            //    }

            //}
        }
    }
}
