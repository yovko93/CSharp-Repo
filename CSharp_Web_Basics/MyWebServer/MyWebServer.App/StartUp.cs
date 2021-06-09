using MyWebServer.App.Controllers;
using MyWebServer.Controllers;
using MyWebServer;
using System.Threading.Tasks;

namespace MyWebServer.App
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<AnimalsController>("/Cats", c => c.Cats())
                .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
            .Start();

    }
}
