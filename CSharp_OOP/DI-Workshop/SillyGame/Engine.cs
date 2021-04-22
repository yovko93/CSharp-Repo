using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame
{
    class Engine
    {
        private IWriter writer;
        private IReader reader;

        public Engine(IReader reader, IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                writer.Write("Working");
            }
        }
    }
}
