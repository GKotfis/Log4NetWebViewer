using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Nancy;
using Owin;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;

namespace Log4NetWebViewer
{
    class OwinService
    {
        public OwinService()
        {

        }

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseNancy();
        }
    }
}
