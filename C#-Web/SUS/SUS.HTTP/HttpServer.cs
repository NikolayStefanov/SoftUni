using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {

        List<Route> routeTable;
        private TcpListener tcpListener;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Loopback, port);
            this.tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await this.tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using NetworkStream stream = tcpClient.GetStream();

            //TODO: research if there is faster data structure for array of bytes
            List<byte> data = new List<byte>();
            int position = 0;
            byte[] buffer = new byte[HttpConstants.BufferSize]; // called Chunck
            while (true)
            {
                int count = await stream.ReadAsync(buffer, 0, buffer.Length);
                position += count;

                if (count < buffer.Length)
                {
                    var partialBuffer = new byte[count];
                    Array.Copy(buffer, partialBuffer, count);
                    data.AddRange(partialBuffer);
                    break;
                }
                else
                {
                    data.AddRange(buffer);
                }
            }
            var requestAsString = Encoding.UTF8.GetString(data.ToArray());
            var request = new HttpRequest(requestAsString);
            Console.WriteLine($"{request.Method} {request.Path}=> {request.Headers.Count} with {request.Cookies.Count} cookies!");

            HttpResponse response;
            var route = this.routeTable.FirstOrDefault(x => string.Compare(x.Path, request.Path, true) == 0 &&
            x.HttpMethod == request.Method);
            if (route != null)
            {
                response = route.Action(request);
            }
            else
            {
                //404 Not Found
                response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
            }

            response.Headers.Add(new Header("Server", "SUS Server 1.0"));
            var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == HttpConstants.SessionCookieName);
            if (sessionCookie != null)
            {
                var responseSessionCookie = new ResponseCookie(sessionCookie.Name, sessionCookie.Value);
                responseSessionCookie.Path = "/";
                response.Cookies.Add(responseSessionCookie);
            }

            var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
            await stream.WriteAsync(response.Body, 0, response.Body.Length);
        }
    }
}
