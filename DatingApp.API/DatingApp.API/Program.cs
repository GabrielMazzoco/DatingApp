using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var h = new WebHostBuilder();
            //var environment = h.GetSetting("environment");
            //var conf = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", true, true)
            //    .AddJsonFile($"appsettings.{environment}.json", true)
            //    .AddEnvironmentVariables()
            //    .Build();

            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
        }
    }
}
