using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.HttpExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Request
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            var lines = httpRequestAsString.Split(new string[] { GlobalConstants.NewLine }, System.StringSplitOptions.None);

            var httpInfoHeader = lines[0];
            var infoHeaderParts = httpInfoHeader.Split(' ');
            if (infoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line!");
            }
            
            var httpMethod = infoHeaderParts[0];
            //Enum.TryParse(httpMethod, out HttpMethodType type);
            //this.Method = type;
            this.Method = httpMethod switch
            {
                "POST" => HttpMethodType.Post,
                "GET" => HttpMethodType.Get,
                "PUT" => HttpMethodType.Put,
                "DELETE" => HttpMethodType.Delete,
            };

            this.Path = infoHeaderParts[1];

            var httpVersion = infoHeaderParts[2];
            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.HTTP10,
                "HTTP/1.1" => HttpVersionType.HTTP11,
                "HTTP/2.0" => HttpVersionType.HTTP20,
                _=> HttpVersionType.HTTP11,
            };

            bool isInHeader = true;
            var bodyStringBuilder = new StringBuilder();
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }
                if (isInHeader)
                {
                    var headerParts = line.Split(new string[] { ": " }, 2, StringSplitOptions.None);
                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException($"Invalid header: {line}");
                    }
                    var headerName = headerParts[0];
                    var headerValue = headerParts[1];
                    var header = new Header(headerName, headerValue);
                    this.Headers.Add(header);
                    if (headerParts[0]=="Cookie")
                    {
                        var cookiesAsString = headerValue;
                        var cookies = cookiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var cookie in cookies)
                        {
                            var cookieParts = cookie.Split(new char[] { '=' }, 2);
                            this.Cookies.Add(new Cookie(cookieParts[0], cookieParts[1]));
                        }
                    }
                }
                else
                {
                    bodyStringBuilder.AppendLine(line);
                }
            }

        }
        public HttpMethodType Method { get; set; }
        public string Path { get; set; }
        public HttpVersionType Version  { get; set; }
        public IList<Header> Headers { get; set; }
        public IList<Cookie> Cookies { get; set; }
        public string Body { get; set; }
        public IDictionary<string, string> SessionData { get; set; }
    }

}
