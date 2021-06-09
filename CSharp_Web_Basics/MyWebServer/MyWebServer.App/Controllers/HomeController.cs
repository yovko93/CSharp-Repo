using MyWebServer.Controllers;
using MyWebServer.Http;

namespace MyWebServer.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Index()
            => Text("Hello from Yovko!");

        public HttpResponse LocalRedirect() => Redirect("/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");
    }
}
