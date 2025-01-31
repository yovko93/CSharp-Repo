﻿using System;

using LoggerExc.Models.Contracts;
using LoggerExc.Models.Enumerations;

namespace LoggerExc.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
           this.DateTime = dateTime;
           this.Message = message;
           this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }

    }
}
