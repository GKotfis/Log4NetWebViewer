using Microsoft.Owin.Hosting;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.ViewEngines;
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
            
            //nancyConventions.ViewLocationConventions.Add((viewName, model, context) =>
            //    {
            //        return string.Format("Nancy/{0}", viewName);
            //    });

            nancyConventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                return string.Format("{0}", viewName);
            });
                
        }

        protected override void ConfigureApplicationContainer(global::Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var assembly = GetType().Assembly;
            ResourceViewLocationProvider.RootNamespaces.Add(assembly, "Log4NetWebViewer.Nancy.Views");
        }

        protected override Func<ITypeCatalog, NancyInternalConfiguration> InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder);
            }
        }

        void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
        }
    }
}