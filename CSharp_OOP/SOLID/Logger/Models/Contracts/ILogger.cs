using System.Collections.Generic;

namespace LoggerExc.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error); 
    }
}
