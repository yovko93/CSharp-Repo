using System;

using SillyGame.IO.Contracts;

namespace SillyGame.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
