﻿using Owin;

namespace Log4NetWebViewer.Services
{
    internal class OwinService
    {

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseNancy();
        }
    }
}