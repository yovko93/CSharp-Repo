using System;
using System.Linq;

namespace P05.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Quicksort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left += 1;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right -= 1;
                }
            }

            Swap(numbers, pivot, right);

            var isSubLeftArraySmaller = right - 1 - start < end - (right + 1);

            if (isSubLeftArraySmaller)
            {
                Quicksort(numbers, start, right - 1);
                Quicksort(numbers, right + 1, end);
            }
            else
            {
                Quicksort(numbers, right + 1, end);
                Quicksort(numbers, start, right - 1);
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;

        }
    }
}
