using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] command = input.Split();
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    MergeElements(data, startIndex, endIndex);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    DivideElements(data, index, partitions);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', data));
        }

        static List<string> MergeElements(List<string> list, int start, int end)
        {    // abc def ghi  -> merge 0 1 -> {abcdef, ghi}
            if (start < 0 || start > list.Count - 1)
            {
                start = 0;
            }
            if (end > list.Count - 1)
            {
                end = list.Count - 1;
            }

            int count = end - start + 1;
            string concatData = string.Empty;
            for (int i = start; i <= end; i++)
            {
                concatData += list[i];
            }

            list.RemoveRange(start, count);
            list.Insert(start, concatData);
            return list;
        }

        static List<string> DivideElements(List<string> list, int index, int partitions)
        {   //{abcdef ghi jkl} -> divide 0 3 -> {ab, cd, ef, ghi, jkl}

            string word = list[index]; 
            List<string> dividedWords = new List<string>();
            int stringLengthToAdd = word.Length / partitions;
            int startIndex = 0;

            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    dividedWords.Add(word.Substring(startIndex, word.Length - startIndex));
                    break;
                }
                dividedWords.Add(word.Substring(startIndex, stringLengthToAdd));
                startIndex += stringLengthToAdd;

            }

            list.RemoveAt(index);
            list.InsertRange(index, dividedWords);
            return list;
        }
    }
}
