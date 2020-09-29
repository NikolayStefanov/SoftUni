using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Resonse
{
    public class HtmlResponse : HttpResponse
    {
        public HtmlResponse(string html) : base()
        {
            this.StatusCode = HttpResponseCode.Ok;
            byte[] byteData = Encoding.UTF8.GetBytes(html);
            this.Body = byteData;
            this.Headers.Add(new Header("Content-Type", "text/html; charset=utf-8"));
            this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));

        }
    }
}
