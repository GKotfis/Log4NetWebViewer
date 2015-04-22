using Microsoft.AspNet.SignalR;

namespace Log4NetWebViewer
{
    public class LogHub : Hub
    {
        public static void Send(string LogName, string Message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            context.Clients.All.addMsg(LogName, Message);
        }
    }
}