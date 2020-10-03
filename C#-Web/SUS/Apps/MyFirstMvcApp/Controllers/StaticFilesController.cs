using SUS.HTTP;
using SUS.MVC.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse FavIcon(HttpRequest arg)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon"); 
        }
        internal HttpResponse CustomCss(HttpRequest arg)
        {
            return this.File("wwwroot/css/custom.css", "text/css");
        }
        internal HttpResponse CustomJs(HttpRequest arg)
        {
            return this.File("wwwroot/js/custom.js", "text/css");
        }
        internal HttpResponse BootstrapCss(HttpRequest arg)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }
        internal HttpResponse BootstrapJs(HttpRequest arg)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/css");
        }
    }
}
