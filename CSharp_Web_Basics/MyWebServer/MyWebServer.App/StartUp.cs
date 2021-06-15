﻿using MyWebServer.App.Controllers;
using MyWebServer.Controllers;
using System.Threading.Tasks;

namespace MyWebServer.App
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                .MapGet<HomeController>("/Softuni", c => c.ToSoftUni())
                .MapGet<HomeController>("/Error", c => c.Error())
                .MapGet<AnimalsController>("/Cats", c => c.Cats())
                .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                .MapGet<AccountController>("/Cookies", c => c.ActionWithCookies())
                .MapGet<AccountController>("/Session", c => c.ActionWithSession())
                .MapGet<CatsController>("/Cats/Create", c => c.Create())
                .MapPost<CatsController>("/Cats/Save", c => c.Save()))
            .Start();

    }
}
