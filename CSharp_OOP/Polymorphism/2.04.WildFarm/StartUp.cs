using _2._04.WildFarm.Core;
using _2._04.WildFarm.Core.Contracts;

namespace _2._04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
