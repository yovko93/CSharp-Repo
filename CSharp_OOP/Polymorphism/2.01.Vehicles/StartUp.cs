using _2._01.Vehicles.Core;
using _2._01.Vehicles.Core.Contracts;

namespace _2._01.Vehicles
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
