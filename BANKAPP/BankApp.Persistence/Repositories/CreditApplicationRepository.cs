using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories
{
    public class CreditApplicationRepository : EfAsyncRepository<CreditApplication, Guid>, ICreditApplicationRepository
    {
        private readonly BankAppDbContext _context;

        public CreditApplicationRepository(BankAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CreditApplication> Query()
        {
            return _context.Set<CreditApplication>();
        }
    }
} 