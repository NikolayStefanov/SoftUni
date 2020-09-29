using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Request;
using SIS.HTTP.Resonse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener tcpListener;
        private readonly IList<Route> routeTable;
        private readonly IDictionary<string, IDictionary<string, string>> sessions;

        public HttpServer( int port, IList<Route> routeTable)
        {
            Console.OutputEncoding = Encoding.UTF8;
            this.tcpListener = new TcpListener(
                IPAddress.Loopback, port);
            this.routeTable = routeTable;
            this.sessions = new Dictionary<string, IDictionary<string, string>>();
        }
        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        public async Task StartAsync()
        {
            this.tcpListener.Start();
            while (true)
            {
                var client = await this.tcpListener.AcceptTcpClientAsync();
                //Task.Run(() => ProcessClientAsync(client));
                ProcessClientAsync(client);
            }
        }

        public void Stop()
        {
            this.tcpListener.Stop();
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
           
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

                string requestAsString =
                    Encoding.UTF8.GetString(buffer, 0, lenght);

                var request = new HttpRequest(requestAsString);
                var route = this.routeTable.FirstOrDefault(x => x.HttpMethod == request.Method && x.Path == request.Path);

                HttpResponse response;
                if (route == null)
                {
                    response = new HttpResponse(HttpResponseCode.NotFound, new byte[0]);
                }
                else
                {
                    response = route.Action(request);
                }
                response.Headers.Add(new Header("Server", "NikolayStServer 2020"));
                var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == GlobalConstants.SessionIdCookieName);

                //if (sessionCookie != null || this.sessions.ContainsKey(sessionCookie.Value))
                //{
                //    request.SessionData = this.sessions[sessionCookie.Value];
                //}


                if (sessionCookie == null || !this.sessions.ContainsKey(sessionCookie.Value))
                {
                    var newSessionId = Guid.NewGuid().ToString();
                    this.sessions.Add(newSessionId, new Dictionary<string, string>());
                    response.Cookies.Add(new ResponseCookie(GlobalConstants.SessionIdCookieName, newSessionId) { HttpOnly = true, MaxAge = 30*3600, });
                }

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.ToString());

                await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await stream.WriteAsync(response.Body, 0, response.Body.Length);
                Console.WriteLine($"HTTP Method: {request.Method}" + Environment.NewLine
                    + $"HTTP Version: {request.Version}" + Environment.NewLine
                    + $"Path: {request.Path}");
                Console.WriteLine(new string('=', 70));
            }
        }
    }
}
