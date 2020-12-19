using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Piece> pieces = new SortedDictionary<string, Piece>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('|').ToArray();

                string piece = data[0];
                string composer = data[1];
                string key = data[2];

                Piece currentPiece = new Piece(composer, key);

                pieces.Add(piece, currentPiece);
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                var command = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string piece = command[1];

                if (command[0] == "Add")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        string composer = command[2];
                        string key = command[3];
                        pieces.Add(piece, new Piece(composer, key));
                        
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        string newKey = command[2];

                        pieces[piece].Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }

        public class Piece
        {
            public string Composer { get; set; }

            public string Key { get; set; }

            public Piece(string composer, string key)
            {
                this.Composer = composer;
                this.Key = key;
            }
        }
    }
}
