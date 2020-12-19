using System;

namespace DemoAction
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> logger = LogInfo;
            Action noParamsLogger = LogInfoNoParams;


            // няма разлика между двете
            logger("Pesho");
            LogInfo("Dimitrichko");

            noParamsLogger();
        }

        static void LogInfoNoParams()
        {
            Console.WriteLine($"Say my name no params");
        }

        static void LogInfo(string name)
        {
            Console.WriteLine($"Say my name {name}");
        }
    }
}
