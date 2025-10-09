using BankApp.Application.Services.Repositories;
using BankApp.Persistence.Contexts;
using BankApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BankAppDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

        services.AddScoped<IIndividualCustomerRepository, EfIndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        // services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
