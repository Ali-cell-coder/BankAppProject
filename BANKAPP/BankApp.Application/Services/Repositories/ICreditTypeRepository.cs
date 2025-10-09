using BankApp.Domain.Entities;
using System.Threading.Tasks;

namespace BankApp.Application.Services.Repositories
{
    public interface ICreditTypeRepository
    {
        Task AddAsync(CreditType entity);
        // Diğer gerekli metotlar eklenebilir
    }
} 