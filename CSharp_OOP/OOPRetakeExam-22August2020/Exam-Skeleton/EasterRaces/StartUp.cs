using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using System.IO;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            //string pathFile = Path.Combine("..", "..", "..", "output.txt");
            //File.Create(pathFile).Close();

            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            //IWriter writer = new FileWriter(pathFile);//new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
