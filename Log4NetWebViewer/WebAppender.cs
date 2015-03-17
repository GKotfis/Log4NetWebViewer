using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using Microsoft.AspNet.SignalR;

namespace Log4NetWebViewer
{
    public class WebAppender : Hub, IAppender
    {
        string _name;
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

        WebService webService = null;

        public WebAppender()
        {
            webService = new WebService(Properties.Settings.Default.Url);
            webService.Start();

        }

        public void Close()
        {
            webService = null;
        }

        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            Send(loggingEvent.RenderedMessage);
        }

        public void Send(string msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<WebAppender>();
            context.Clients.All.addMsg(msg);
        }

    }
}
