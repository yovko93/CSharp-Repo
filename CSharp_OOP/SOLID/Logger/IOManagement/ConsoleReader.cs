using System;

using LoggerExc.IOManagement.Contracts;

namespace LoggerExc.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
