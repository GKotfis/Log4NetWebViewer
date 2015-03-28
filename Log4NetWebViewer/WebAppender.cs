using log4net.Appender;
using Log4NetWebViewer.Services;

namespace Log4NetWebViewer
{
    public class WebAppender : AppenderSkeleton
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private WebService webService = null;

        private string renderedMsg = "";

        public WebAppender()
        {
            webService = new WebService(Properties.Settings.Default.Url);
            webService.Start();
        }

        public void Close()
        {
            webService = null;
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (this.Layout == null)
                renderedMsg = loggingEvent.RenderedMessage;
            else
                renderedMsg = base.RenderLoggingEvent(loggingEvent);

            LogHub.Send(renderedMsg);
        }
    }
}