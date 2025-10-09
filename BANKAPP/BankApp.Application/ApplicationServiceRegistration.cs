using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Features.CorporateCustomers.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        // BusinessRules sınıflarını DI konteynerine ekliyoruz
        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        
        return services;
    }
}
