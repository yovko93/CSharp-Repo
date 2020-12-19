using System;
using System.Linq;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToList();
            
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    input.RemoveAt(i);
                    i--;
                }
            }
            
            Console.WriteLine(string.Join("", input));
        }
    }
}
