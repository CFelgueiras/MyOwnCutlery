using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MDFabricaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:5000");
                .UseUrls("https://mdf3nbgrp5.azurewebsites.net");
    }
}
