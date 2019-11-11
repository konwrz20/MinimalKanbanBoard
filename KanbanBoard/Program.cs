using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace KanbanBoard {
    public class Program {
        static IConfiguration Configuration => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try {
                Log.Information("Starting up");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex) {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally {
                Log.CloseAndFlush();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(Configuration)
                .UseSerilog()
                .UseStartup<Startup>();
    }
}