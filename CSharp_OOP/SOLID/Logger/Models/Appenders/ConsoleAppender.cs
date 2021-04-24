using System;

using LoggerExc.Common;
using LoggerExc.IOManagement;
using LoggerExc.Models.Contracts;
using LoggerExc.Models.Enumerations;
using LoggerExc.IOManagement.Contracts;

namespace LoggerExc.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            :base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = String
                .Format(format,
                dateTime.ToString(GlobalConstants.DateTimeFormat),
                level.ToString(),
                message);

            this.writer.WriteLine(formattedString);
            this.messagesAppended++;
        }

       
    }
}
