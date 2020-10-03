using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MVC.Framework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");

            var viewContent = System.IO.File.ReadAllText("Views/"+ 
                this.GetType().Name.Replace("Controller", string.Empty)
                + "/" +viewPath 
                + ".html");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            response.Headers.Add(new Header("Server", "SUS Server 1.0"));
            return response;
        }
        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }
        public HttpResponse Redirect(string path)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", path));
            return response;
        }

    }
}
