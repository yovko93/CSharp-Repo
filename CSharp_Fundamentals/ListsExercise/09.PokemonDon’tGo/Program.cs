using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfElements = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int removedElementCase1 = pokemons[0];
                    sumOfElements += removedElementCase1;
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    ReturnNewList(pokemons, removedElementCase1);
                }
                else if (index > pokemons.Count - 1)
                {
                    int removedElementCase2 = pokemons[pokemons.Count - 1];
                    sumOfElements += removedElementCase2;
                    pokemons[pokemons.Count - 1] = pokemons[0];
                    ReturnNewList(pokemons, removedElementCase2);

                }
                else if (index >= 0 && index < pokemons.Count)
                {
                    int removedElementCase3 = pokemons[index];
                    sumOfElements += removedElementCase3;
                    pokemons.RemoveAt(index);
                    ReturnNewList(pokemons, removedElementCase3);
                }
                
            }
            Console.WriteLine(sumOfElements);
        }

        static List<int> ReturnNewList (List<int> list, int currentElement)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= currentElement)
                {
                    list[i] += currentElement;
                }
                else
                {
                    list[i] -= currentElement;
                }
            }

            return list;
        }
    }
}
