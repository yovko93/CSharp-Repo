using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            result = spy.AnalyzeAcessModifiers("Stealer.Hacker");

            result = spy.RevealPrivateMethods("Stealer.Hacker");

            result = spy.CollectGettersAndSetters("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
