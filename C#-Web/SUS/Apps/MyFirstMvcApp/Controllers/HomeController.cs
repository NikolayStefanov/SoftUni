using SUS.HTTP;
using SUS.MVC.Framework;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {

        public  HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
      
    }
}
