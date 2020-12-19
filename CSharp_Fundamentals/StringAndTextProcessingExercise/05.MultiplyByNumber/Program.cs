using System;
using System.Text;

namespace _05.MultiplyByNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string reallyBigNumber = Console.ReadLine().Trim('0');
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int reminder = 0;

            for (int i = reallyBigNumber.Length - 1; i >= 0; i--)
            {
                int result = (int.Parse(reallyBigNumber[i].ToString()) * number + reminder);

                reminder = 0;

                if (result > 9)
                {
                    reminder = result / 10;
                    result = result % 10;
                }
                
                sb.Append(result);
            }

            if (reminder > 0)
            {
                sb.Append(reminder);
            }
            StringBuilder finalResult = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                finalResult.Append(sb[i]);
            }

            Console.WriteLine(finalResult);
        }
    }
}
