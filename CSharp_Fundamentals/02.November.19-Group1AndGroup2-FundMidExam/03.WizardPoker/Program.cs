using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WizardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(':')
                .ToList();

            List<string> newDeck = new List<string>();
            string input = Console.ReadLine();
            while (input != "Ready")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    string cardName = command[1];
                    if (!(cards.Contains(cardName)))
                    {
                        Console.WriteLine("Card not found.");
                    }
                    else
                    {
                        newDeck.Add(cardName);
                    }

                }
                else if (command[0] == "Insert")
                {
                    string cardName = command[1];
                    int index = int.Parse(command[2]);

                    if (!(cards.Contains(cardName)) || index < 0 || index > newDeck.Count - 1)
                    {
                        Console.WriteLine("Error!");
                    }
                    else
                    {
                        newDeck.Insert(index, cardName);
                    }
                }
                else if (command[0] == "Remove")
                {
                    string cardName = command[1];

                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {
                    string firstCard = command[1];
                    string secondCard = command[2];
                    int firstCardIndex = newDeck.IndexOf(firstCard);
                    int secondCardIndex = newDeck.IndexOf(secondCard);

                    string temp = newDeck[firstCardIndex];
                    newDeck[firstCardIndex] = newDeck[secondCardIndex];
                    newDeck[secondCardIndex] = temp;
                }
                else if (command[0] == "Shuffle")
                {
                    //newDeck.Reverse();

                    for (int i = 0; i < newDeck.Count/2; i++)
                    {
                        string temp = newDeck[i];
                        newDeck[i] = newDeck[newDeck.Count - 1 - i];
                        newDeck[newDeck.Count - 1 - i] = temp;
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', newDeck));
        }
    }
}
