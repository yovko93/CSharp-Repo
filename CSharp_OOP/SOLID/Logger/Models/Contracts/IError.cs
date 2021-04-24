using System;

using LoggerExc.Models.Enumerations;

namespace LoggerExc.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }

    }
}
