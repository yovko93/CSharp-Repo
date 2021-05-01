using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IManagerController controller;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IManagerController controller, IReader reader, IWriter writer)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "Exit")
            {
                string[] arg = command.Split().ToArray();
                string commandType = arg[0];
                string resultMsg = string.Empty;

                try
                {
                    if (commandType == "AddPlayer")
                    {
                       resultMsg = this.controller.AddPlayer(arg[1], arg[2]);
                    }
                    else if (commandType == "AddCard")
                    {
                        resultMsg = this.controller.AddCard(arg[1], arg[2]);
                    }
                    else if (commandType == "AddPlayerCard")
                    {
                        resultMsg = this.controller.AddPlayerCard(arg[1], arg[2]);
                    }
                    else if (commandType == "Fight")
                    {
                        resultMsg = this.controller.Fight(arg[1], arg[2]);
                    }
                    else if (commandType == "Report")
                    {
                        resultMsg = this.controller.Report();
                    }

                    writer.WriteLine(resultMsg);
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }

            }
        }
    }
}
