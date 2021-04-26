namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using System.IO;
    using System.Linq;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall, 1, 6);
            Engine engine = new Engine(snake, wall);
            Console.SetCursorPosition(0, wall.TopY + 2);

            var result = File.ReadAllLines("../../../Database/scores.txt")
                .OrderByDescending(x => int.Parse(x.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1]))
                .ToList();
            
            Console.WriteLine(String.Join(Environment.NewLine, result));

            engine.Run();
        }
    }
}
