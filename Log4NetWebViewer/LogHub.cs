using Microsoft.AspNet.SignalR;

namespace Log4NetWebViewer
{
    public class LogHub : Hub
    {
        IHubContext context;

        public LogHub()
        {
            context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
        }
        public void Send(string LogName, string Message)
        {
            context.Clients.All.addMsg(LogName, Message);
        }
    }
}