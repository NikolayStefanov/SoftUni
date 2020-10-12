using SUS.MVC.Framework;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);

        }
    }
}
