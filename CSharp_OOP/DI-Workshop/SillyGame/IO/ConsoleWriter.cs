using System;

using SillyGame.IO.Contracts;

namespace SillyGame.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
