using SUS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace WowBattleCards
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
