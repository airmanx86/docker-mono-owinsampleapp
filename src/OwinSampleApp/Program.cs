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
        private const string SelfHostWebAppBaseAddress = "http://*:9000/";

        private const string WebFrontEndBaseAddress = "http://localhost:8081/";

        private static string port = null;

        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                port = "9000";
            }
            else
            {
                port = args[0];
            }

            RegisterToWebFrontEnd();

            // Start OWIN host 
            using (WebApp.Start<Startup>(SelfHostWebAppBaseAddress))
            {
                using (var timer = new Timer(
                    state => Console.WriteLine("[{0}] Press ENTER to exit.", DateTime.UtcNow.ToString("s")),
                    null,
                    new TimeSpan(0, 0, 0),
                    new TimeSpan(0, 0, 3)))
                {
                    Console.ReadLine();
                    Console.WriteLine("Stopping host and exiting application.");
                }
            }
        }

        private static void DeplayThenRegisterToWebFrontEnd()
        {
            Task.Delay(new TimeSpan(0, 0, 10)).ContinueWith(t => RegisterToWebFrontEnd());
        }

        private static void RegisterToWebFrontEnd()
        {
            Console.WriteLine("[{0}] Registering itself to web front end.", DateTime.UtcNow.ToString("s"));
            var client = new HttpClient();//// { BaseAddress = new Uri(WebFrontEndBaseAddress) };
            client.GetAsync(WebFrontEndBaseAddress + "newbackend?p=" + port)
                  .ContinueWith(t => DeplayThenRegisterToWebFrontEnd(), TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
