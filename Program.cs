// Import necessary libraries for the ASP.NET Core web application

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Define the namespace for the Fag_el_Gamous web application
namespace Fag_el_Gamous
{
    // Define the main program class
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a host builder, build it, and run the application
            CreateHostBuilder(args).Build().Run();
        }

        // Create a host builder with default configuration, logging and hosting settings
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specify the startup class for the web application
                    webBuilder.UseStartup<Startup>();
                });
    }
}
