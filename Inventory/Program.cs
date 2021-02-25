using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Inventory.Models;
using Inventory.Data;
using System;
using ElectronNET.API;

namespace Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<InventoryContext>();
                    context.Database.EnsureCreated();
                    // DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseElectron(args);
                    //webBuilder.UseEnvironment("Development");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
