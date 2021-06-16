using MyWebServer.Controllers;
using MyWebServer.Http;
using System;

namespace MyWebServer.App.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index() => Text("Hello from Yovko!");

        public HttpResponse LocalRedirect() => Redirect("/Animals/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

        public HttpResponse StaticFiles() => View();

        public HttpResponse Error() => throw new InvalidOperationException("Invalid action!");
    }
}
