﻿using System;
using LoggerExc.IOManagement;
using LoggerExc.Models.Contracts;
using LoggerExc.Models.Enumerations;
using LoggerExc.IOManagement.Contracts;

namespace LoggerExc.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;

        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;

            this.writer = new FileWriter(this.File.Path);
        }


        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formattedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
