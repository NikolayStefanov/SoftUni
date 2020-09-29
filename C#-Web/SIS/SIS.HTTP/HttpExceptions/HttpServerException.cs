using System;
namespace SIS.HTTP.HttpExceptions
{
    public class HttpServerException : Exception
    {
        public HttpServerException(string message)
            :base(message)
        {
        }
    }
}
