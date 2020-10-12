using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MVC.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices()
        {
        }
    }
}
