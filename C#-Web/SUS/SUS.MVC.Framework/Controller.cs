using SUS.HTTP;
using SUS.MVC.Framework.ViewEngine;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MVC.Framework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }
        public HttpResponse View( object viewModel = null,[CallerMemberName]string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = this.viewEngine.GetHtml(layout, viewModel);

            var viewContent = System.IO.File.ReadAllText("Views/"+ 
                this.GetType().Name.Replace("Controller", string.Empty)
                + "/" +viewPath 
                + ".cshtml");

            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);

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
