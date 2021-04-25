using _2._03.Raiding.Core;

namespace _2._03.Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
