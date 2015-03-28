using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Microsoft.AspNet.SignalR;

namespace Log4NetWebViewer.Nancy
{
    public class LogModule : NancyModule
    {
        public LogModule()
        {
            Get["/"] = prm =>
            {
                return View["log"];
            };
        }
    }
}
