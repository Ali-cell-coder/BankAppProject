using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using System.Threading.Tasks;

namespace BankApp.Persistence.Repositories
{
    public class CreditTypeRepository : ICreditTypeRepository
    {
        private readonly BankAppDbContext _context;

        public CreditTypeRepository(BankAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CreditType entity)
        {
            _context.CreditTypes.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
} 