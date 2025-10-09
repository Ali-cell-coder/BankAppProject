using BankApp.Application.Services.Repositories;
using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories
{
    public class IndividualCustomerRepository : EfAsyncRepository<IndividualCustomer, Guid>, IIndividualCustomerRepository
    {
        private readonly BankAppDbContext _context;

        public IndividualCustomerRepository(BankAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<IndividualCustomer> Query()
        {
            return _context.Set<IndividualCustomer>();
        }

        public new async Task<IndividualCustomer?> GetAsync(Expression<Func<IndividualCustomer, bool>> predicate)
        {
            return await base.GetAsync(predicate);
        }

        public new async Task<List<IndividualCustomer>> GetListAsync(Expression<Func<IndividualCustomer, bool>>? predicate = null)
        {
            var result = await base.GetListAsync(predicate);
            return result.ToList();
        }
    }
} 