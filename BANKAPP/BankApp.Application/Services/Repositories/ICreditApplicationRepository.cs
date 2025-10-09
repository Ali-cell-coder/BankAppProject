using BankApp.Core.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Repositories
{
    public interface ICreditApplicationRepository : IAsyncRepository<CreditApplication, Guid>
    {
    }
} 