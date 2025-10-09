using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankApp.Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankAppDbContext>
    {
        public BankAppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<BankAppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new BankAppDbContext(builder.Options);
        }
    }
} 