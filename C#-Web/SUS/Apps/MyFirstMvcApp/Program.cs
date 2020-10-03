using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MVC.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
