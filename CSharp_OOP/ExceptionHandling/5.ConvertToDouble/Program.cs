using System;

namespace _5.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            ////  не е решена !!!!!!!!!!!!
            ///=-============================
            ///


            string input = Console.ReadLine();

            double result;

            try
            {
                result = Convert.ToDouble(input);

            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception");
            }
            catch (OverflowException)
            {

                Console.WriteLine("Overflow Exception");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }

            //Console.WriteLine(result);
        }
    }
}
