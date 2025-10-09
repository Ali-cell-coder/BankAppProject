using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Persistence.Repositories;

public class EfIndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, BankAppDbContext>, IIndividualCustomerRepository
{
    public EfIndividualCustomerRepository(BankAppDbContext context) : base(context)
    {
    }

    public IQueryable<IndividualCustomer> Query()
    {
        return Context.Set<IndividualCustomer>();
    }
} 