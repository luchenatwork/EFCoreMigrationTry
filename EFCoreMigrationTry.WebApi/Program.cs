using System.Threading.Tasks;
using EFCoreMigrationTry.DataAccess.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreMigrationTry.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await RunDbMigrationAsync(host);
            await host.RunAsync();
        }

        private static async Task RunDbMigrationAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var weatherForecastDbContext = scope.ServiceProvider.GetRequiredService<WeatherForecastDbContext>();

                await weatherForecastDbContext.Database.MigrateAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
