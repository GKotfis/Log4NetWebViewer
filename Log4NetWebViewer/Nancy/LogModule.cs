using Nancy;

namespace Log4NetWebViewer.Nancy
{
    public class LogModule : NancyModule
    {
        public LogModule()
        {
            Get("/", prm => View[Properties.Settings.Default.ViewName ?? "log.html"]);
        }
    }
}