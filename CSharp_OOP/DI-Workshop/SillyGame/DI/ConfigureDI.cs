﻿using SillyGame.IO;
using DIContainer.Modules;
using SillyGame.IO.Contracts;

namespace SillyGame.DI
{
    class ConfigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
        }
    }
}
