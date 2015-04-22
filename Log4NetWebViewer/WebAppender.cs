using log4net;
using log4net.Appender;
using Log4NetWebViewer.Services;
using System;

namespace Log4NetWebViewer
{
    public class WebAppender : AppenderSkeleton, IDisposable
    {

        private WebService webService = null;
        private LogHub logHub = null;
        private string renderedMsg = "";

        public WebAppender()
        {
            Init();
        }

        public void Close()
        {
            webService = null;
        }

        private void Init()
        {
            try
            {
                this.Name = this.GetType().Name;

                logHub = new LogHub();

                webService = new WebService(Properties.Settings.Default.Url);
                webService.Start();

            }
            catch (Exception ex)
            {
                var loggers = LogManager.GetCurrentLoggers();

                foreach (var logger in loggers)
                {
                    logger.Error("Init WebAppender failed!", ex);
                }
            }
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (this.Layout == null)
                renderedMsg = loggingEvent.RenderedMessage;
            else
                renderedMsg = base.RenderLoggingEvent(loggingEvent);

            logHub.Send(Name, renderedMsg);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (webService != null)
                {
                    webService.Dispose();
                    webService = null;
                }
            }
        }
    }
}

