using EFCoreMigrationTry.DataAccess.DbContexts;
using EFCoreMigrationTry.DataMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContentServices.DataMigration.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<WeatherForecastDbContext>(optionBuilder =>
                    {
                        optionBuilder.UseSqlServer(
                            hostContext.Configuration["weatherForecastConnectionString"],
                            sqlServerOption => sqlServerOption.MigrationsAssembly(typeof(MigrationPlaceHolder).Assembly.FullName));
                    });
                });
    }
}
