using System;
using System.IO;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            //File.AppendAllText("../../../text.txt", message + Environment.NewLine);
            Console.WriteLine(message);
        }
    }
}
