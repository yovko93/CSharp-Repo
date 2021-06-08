using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from Yovko!"))
                .MapGet("/Cats", new HtmlResponse("<h1>Hello from the cats!</h1>"))
            .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
            .Start();

    }
}
