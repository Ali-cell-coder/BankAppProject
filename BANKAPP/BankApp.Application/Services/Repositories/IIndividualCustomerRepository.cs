using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Services.Repositories
{
    public interface IIndividualCustomerRepository : IRepository<IndividualCustomer>
    {
        IQueryable<IndividualCustomer> Query();
    }
} 