using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agm.Startup))]

namespace Agm
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {          
            app.MapSignalR();
        }
    }
}
