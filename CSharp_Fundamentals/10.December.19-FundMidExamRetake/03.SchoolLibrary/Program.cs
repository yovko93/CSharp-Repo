using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> booksOnShelf = Console.ReadLine()
                 .Split('&')
                 .ToList();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] command = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Add Book")
                {
                    string bookName = command[1];

                    if (!(booksOnShelf.Contains(bookName)))
                    {
                        booksOnShelf.Insert(0, bookName);
                    }
                }
                else if (command[0] == "Take Book")
                {
                    string bookName = command[1];

                    if (booksOnShelf.Contains(bookName))
                    {
                        booksOnShelf.Remove(bookName);
                    }
                }
                else if (command[0] == "Swap Books")
                {
                    string firstBook = command[1];
                    string secondBook = command[2];

                    if (booksOnShelf.Contains(firstBook))
                    {
                        if (booksOnShelf.Contains(secondBook))
                        {
                            int firstBookIndex = booksOnShelf.IndexOf(firstBook);
                            int secondBookIndex = booksOnShelf.IndexOf(secondBook);
                            string tempBook = booksOnShelf[firstBookIndex];
                            booksOnShelf[firstBookIndex] = booksOnShelf[secondBookIndex];
                            booksOnShelf[secondBookIndex] = tempBook;
                        }
                    }
                }
                else if (command[0] == "Insert Book")
                {
                    string bookName = command[1];
                    booksOnShelf.Add(bookName);
                }
                else if (command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < booksOnShelf.Count)
                    {
                        Console.WriteLine(booksOnShelf[index]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", booksOnShelf));
        }
    }
}
