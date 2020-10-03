using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
        }
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                throw new ArgumentNullException("Body cannot be n");
            }
            this.StatusCode = statusCode;
            this.Body = body;
            this.Version = HttpVersion.HTTP10;
            this.Headers = new List<Header>()
            {
                {new Header("Content-Type", contentType) },
                {new Header("Content-Length", body.Length.ToString()) },
            };
            this.Cookies = new List<Cookie>();
        }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();
            var httpVersianAsString = this.Version switch
            {
                HttpVersion.HTTP10 => "HTTP/1.0",
                HttpVersion.HTTP11 => "HTTP/1.1",
                HttpVersion.HTTP20 => "HTTP/2.0",
                _ => "HTTP/1.0"
            };
            responseBuilder.Append($"{httpVersianAsString} {(int)this.StatusCode} {this.StatusCode}" + HttpConstants.NewLine);
            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }
            foreach (var cookie in this.Cookies)
            {
                responseBuilder.Append($"Set-Cookie: {cookie.ToString()}" + HttpConstants.NewLine);
            }
            responseBuilder.Append(HttpConstants.NewLine);
            return responseBuilder.ToString();
        }
        public ICollection<Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public HttpVersion Version { get; set; }
        public byte[] Body { get; set; }
    }
}
