using Microsoft.Owin.Hosting;
using Nancy;
using System;

namespace Log4NetWebViewer.Services
{
    internal class WebService : IDisposable
    {
        internal string Url { get; set; }

        private object webAppInstance = null;

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

    public class CustomConventionsBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(global::Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.ViewLocationConventions.Add((viewName, model, context) =>
                {
                    return string.Format("Nancy/{0}", viewName);
                });
        }
    }
}