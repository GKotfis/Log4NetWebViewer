using log4net;
using log4net.Config;
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

            var randomLogTask = new Task(() =>
                {
                    AppDomain.MonitoringIsEnabled = true;
                        
                    while (true)
                    {
                        Log.InfoFormat("MonitoringTotalProcessorTime: {0}kB", AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize / 1024);
                        Thread.Sleep(1000);
                    }
                });

            randomLogTask.Start();

            Console.ReadKey();
        }
    }
}