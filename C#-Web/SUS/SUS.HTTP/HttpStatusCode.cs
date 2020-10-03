namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        Ok = 200,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501
    }
}
