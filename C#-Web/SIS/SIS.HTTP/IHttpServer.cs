using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync();
        void Stop();
        Task ResetAsync();
    }
}
