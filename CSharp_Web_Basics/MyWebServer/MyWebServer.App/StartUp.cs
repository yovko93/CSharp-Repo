using MyWebServer.App.Controllers;
using MyWebServer.App.Data;
using MyWebServer.Controllers;
using System.Threading.Tasks;

namespace MyWebServer.App
{
    public class StartUp
    {
        public static async Task Main()
           => await HttpServer
               .WithRoutes(routes => routes
                   .MapStaticFiles()
                   .MapControllers()
                   .MapGet<HomeController>("/ToCats", c => c.LocalRedirect()))
               .WithServices(services => services
                   .Add<IData, MyDbContext>())
               .Start();

    }
}
