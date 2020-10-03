using SUS.HTTP;
using SUS.MVC.Framework;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }
        public HttpResponse DoLogin(HttpRequest request)
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user
            //TODO: home page

            return this.Redirect("/");
        }
        public HttpResponse Register(HttpRequest arg)
        {
            return this.View();

        }
    }
}
