using Microsoft.AspNet.SignalR;

namespace Log4NetWebViewer
{
    public class LogHub : Hub
    {
        public static void Send(string msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            context.Clients.All.addMsg(msg);
        }
    }
}