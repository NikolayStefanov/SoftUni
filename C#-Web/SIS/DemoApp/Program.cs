using SIS.HTTP;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Resonse;
using SIS.MVC.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/users/login", Login));
            routeTable.Add(new Route(HttpMethodType.Post, "/users/login", DoLogin));
            routeTable.Add(new Route(HttpMethodType.Get, "/contacts", Contacts));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));



            var httpServer = new HttpServer(555, routeTable);
            await httpServer.StartAsync();
        }

        private static HttpResponse FavIcon(HttpRequest request)
        {
            byte[] favIcon = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(favIcon, "image/x-icon");
        }

        private static HttpResponse Contacts(HttpRequest request)
        {
            var content = SharedContent() + "<h1>CONTACTS PAGE</h1>";
            return new HtmlResponse(content);
        }

        public static string SharedContent()
        {
            return $"<h1>Hello from NikiServer {DateTime.Now}</h1>" +
                $"<form action=/tweet method=post><input name=username /><input name=password />" +
                $"<input type=submit /></form>";
        }
        public static HttpResponse Index(HttpRequest request)
        {
            var content = SharedContent() + "<h1>HOME PAGE</h1>";
            return new HtmlResponse(content);
        }
        public static HttpResponse Login(HttpRequest request)
        {
            var content = SharedContent() + "<h1>LOGIN PAGE</h1>";
            return new HtmlResponse(content);

        }
        public static HttpResponse DoLogin(HttpRequest request)
        {
            var content = SharedContent() + "<h1>LOGIN PAGE</h1>";
            return new HtmlResponse(content);

        }
    }
}
