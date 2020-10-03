using SUS.HTTP;
using System.Collections.Generic;

namespace SUS.MVC.Framework
{
    public interface IMvcApplication
    {
        void ConfigureServices();
        void Configure(List<Route> routeTable);
    }
}
