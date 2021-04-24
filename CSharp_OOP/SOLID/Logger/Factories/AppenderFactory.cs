using System;

using LoggerExc.Common;
using LoggerExc.Models.Appenders;
using LoggerExc.Models.Contracts;
using LoggerExc.Models.Enumerations;

namespace LoggerExc.Factories
{
    public class AppenderFactory
    {

        public AppenderFactory()
        {

        }

        public IAppender CreateAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);

            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.InvalidAppenderType);
            }

            return appender;
        }
    }
}
