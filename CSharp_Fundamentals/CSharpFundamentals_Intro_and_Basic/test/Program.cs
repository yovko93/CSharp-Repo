using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int j = 1; j <= 10; j++)
            //    {
            //        Console.WriteLine("{0} * {1} = {2} ,", i, j, i * j);
            //    }
            //    Console.WriteLine();
            //}

            int n = int.Parse(Console.ReadLine());
            int times = 0;
            while (n%10 !=0)
            {
                times++;
                n = n / 10;
            }

            Console.WriteLine(times);

           
        }
    }
}
