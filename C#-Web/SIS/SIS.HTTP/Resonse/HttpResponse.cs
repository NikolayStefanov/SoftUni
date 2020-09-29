using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SIS.HTTP.Resonse
{
    public class HttpResponse
    {
        public HttpResponse(HttpResponseCode statusCode, byte[] body)
            :this()
        {
            this.Version = HttpVersionType.HTTP10;
            this.StatusCode = statusCode;
         
            this.Body = body;
            if (body?.Length > 0)
            {
                this.Headers.Add(new Header("Content-Length", body.Length.ToString()));
            }
        }
        internal HttpResponse()
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();
        }
        public HttpVersionType Version { get; set; }
        public HttpResponseCode StatusCode { get; set; }
        public IList<Header> Headers { get; set; }
        public IList<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            var responseAsString = new StringBuilder();
            var httpVersianAsString = this.Version switch
            {
                HttpVersionType.HTTP10 => "HTTP/1.0",
                HttpVersionType.HTTP11 => "HTTP/1.1",
                HttpVersionType.HTTP20 => "HTTP/2.0",
                _=> "HTTP/1.0"
            };

            responseAsString.Append($"{httpVersianAsString} {(int)this.StatusCode} {this.StatusCode}" + GlobalConstants.NewLine);

            foreach (var header in this.Headers)
            {
                responseAsString.Append(header.ToString() + GlobalConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseAsString.Append($"Set-Cookie: " + cookie.ToString() + GlobalConstants.NewLine);
            }
            responseAsString.Append(GlobalConstants.NewLine);
            return responseAsString.ToString();
        }

    }
}
