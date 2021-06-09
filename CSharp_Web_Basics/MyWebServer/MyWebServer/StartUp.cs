﻿using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from Yovko!"))
                .MapGet("/Cats", request =>
                {
                    const string nameKey = "Name";

                    var query = request.Query;

                    var catName = query.ContainsKey(nameKey)
                    ? query[nameKey]
                    : "the cats";

                    var result = $"<h1>Hello from {catName}!</h1>";

                    return new HtmlResponse(result);

                })
            .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
            .Start();

    }
}
