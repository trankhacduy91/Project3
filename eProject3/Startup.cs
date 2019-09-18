using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eProject3.Startup))]

namespace eProject3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

        }
    }
}