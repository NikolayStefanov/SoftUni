﻿using SUS.MvcFramework;
using System.Threading.Tasks;

namespace SharedTrip
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}