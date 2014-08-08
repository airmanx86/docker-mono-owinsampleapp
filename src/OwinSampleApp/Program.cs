namespace OwinSampleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Owin;
    using Microsoft.Owin.Hosting;

    class Program
    {
        private static volatile bool stop = false;

        static void Main(string[] args)
        {
            const string baseAddress = "http://*:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                using (var timer = new Timer(
                    state => Console.WriteLine("[{0}] Press any key to exit.", DateTime.UtcNow.ToString("s")),
                    null,
                    new TimeSpan(0, 0, 0),
                    new TimeSpan(0, 0, 3)))
                {
                    Console.ReadKey();
                    Console.WriteLine("Stopping host and exiting application.");
                }
            }
        }
    }
}
