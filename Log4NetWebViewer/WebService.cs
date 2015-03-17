using System;
using Microsoft.Owin.Hosting;

namespace Log4NetWebViewer
{
    internal class WebService : IDisposable
    {
        internal string Url { get; set; }
        object webAppInstance = null;

        public WebService(string Url = null)
        {
            this.Url = Url ?? Properties.Settings.Default.Url; ;
        }

        internal void Start()
        {
            webAppInstance = WebApp.Start<OwinService>(this.Url);  
        }

        public void Dispose()
        {
            webAppInstance = null;
        }
    }
}