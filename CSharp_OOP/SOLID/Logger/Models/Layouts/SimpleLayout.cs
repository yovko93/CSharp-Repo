using LoggerExc.Models.Contracts;

namespace LoggerExc.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
