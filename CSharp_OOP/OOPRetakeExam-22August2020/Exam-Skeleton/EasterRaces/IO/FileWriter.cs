using EasterRaces.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasterRaces.IO
{
    public class FileWriter : IWriter
    {
        private readonly string filePath;

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(this.filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(this.filePath, message + Environment.NewLine);

        }
    }
}
