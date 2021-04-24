using LoggerExc.Models.Enumerations;

namespace LoggerExc.Models.Contracts
{
    public interface IAppender
    {

        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
