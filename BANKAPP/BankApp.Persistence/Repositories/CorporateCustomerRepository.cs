using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories
{
    public class CorporateCustomerRepository : EfAsyncRepository<CorporateCustomer, Guid>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BankAppDbContext context) : base(context)
        {
        }
    }
} 