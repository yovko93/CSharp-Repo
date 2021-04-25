using _2._02.VehiclesExtension.Core;
using _2._02.VehiclesExtension.Core.Contracts;

namespace _2._02.VehiclesExtension
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
