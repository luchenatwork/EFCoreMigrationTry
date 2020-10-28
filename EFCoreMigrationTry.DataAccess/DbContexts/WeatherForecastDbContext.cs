using EFCoreMigrationTry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationTry.DataAccess.DbContexts
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecastDbContext).Assembly);
        }
    }
}
