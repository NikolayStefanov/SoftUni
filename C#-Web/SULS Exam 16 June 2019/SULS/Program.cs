using SUS.MvcFramework;
using System.Threading.Tasks;

namespace SULS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
