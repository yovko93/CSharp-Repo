﻿using MyWebServer.Server;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Program
    {
        public static async Task Main()
        {
            // http://localhost:9090

            var server = new HttpServer("127.0.0.1", 9090);

            await server.Start();
            
        }
    }
}
