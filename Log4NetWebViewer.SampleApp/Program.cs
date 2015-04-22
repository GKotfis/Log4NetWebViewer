using log4net;
using log4net.Config;
using log4net.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Log4NetWebViewer.SampleApp
{
    internal class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof(Program));

        private static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            var attachable = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root as IAppenderAttachable;

            var webAppender = new Log4NetWebViewer.WebAppender()
            {
                Layout = new log4net.Layout.PatternLayout("%-4timestamp [%thread] %-5level %logger %ndc - %message%newline"),
                Name = "SampleApp"
            };

            attachable.AddAppender(webAppender);

            var randomLogTask = new Task(() =>
                {
                    AppDomain.MonitoringIsEnabled = true;

                    while (true)
                    {
                        Log.InfoFormat("MonitoringTotalAllocatedMemorySize: {0}kB", AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize / 1024);
                        Thread.Sleep(1000);
                    }
                });

            randomLogTask.Start();

            Console.ReadKey();
        }
    }
}