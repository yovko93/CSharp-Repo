﻿using System;
using System.Linq;
using System.Collections.Generic;

using LoggerExc.Core;
using LoggerExc.Models;
using LoggerExc.Common;
using LoggerExc.Factories;
using LoggerExc.IOManagement;
using LoggerExc.Models.Files;
using LoggerExc.Core.Contracts;
using LoggerExc.Models.Contracts;
using LoggerExc.Models.Enumerations;
using LoggerExc.Models.PathManagement;
using LoggerExc.IOManagement.Contracts;

namespace LoggerExc
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(); ;
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);

            ILogger logger = SetUpLogger(n, reader, writer, file, layoutFactory, appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);

            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCnt, IReader reader, IWriter writer, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCnt; i++)
            {
                string[] appendersArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];

                bool hasError = false;
                Level level = ParseLevel(appendersArgs, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);

                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level, file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);

                }
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }

        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine
                        (GlobalConstants.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumParsed;
            }

            return appenderLevel;
        }
    }
}
