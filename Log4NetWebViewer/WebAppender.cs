using log4net;
using log4net.Appender;
using Log4NetWebViewer.Services;
using System;

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
            try
            {
                this.Name = this.GetType().Name;
                webService = new WebService(Properties.Settings.Default.Url);
                webService.Start();

            }
            catch (Exception ex)
            {
                var loggers = LogManager.GetCurrentLoggers();
                foreach (var logger in loggers)
                {
                    logger.Error("Init WebViewer failed!", ex);
                }
            }
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

