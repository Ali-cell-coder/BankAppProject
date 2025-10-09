using BankApp.Application.Features.CorporateCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task CorporateCustomerShouldExistWhenRequested(Guid id)
        {
            var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
            if (corporateCustomer == null)
                throw new Exception(Messages.CorporateCustomerNotFound);
        }

        public async Task CorporateCustomerTaxNumberShouldBeUnique(string taxNumber)
        {
            var corporateCustomer = await _corporateCustomerRepository.GetAsync(c => c.TaxNumber == taxNumber);
            if (corporateCustomer != null)
                throw new Exception(Messages.CorporateCustomerAlreadyExists);
        }

        public void ValidateTaxNumber(string taxNumber)
        {
            if (string.IsNullOrEmpty(taxNumber) || taxNumber.Length != 10 || !taxNumber.All(char.IsDigit))
                throw new Exception(Messages.InvalidTaxNumber);
        }

        public void ValidateAnnualRevenue(decimal annualRevenue)
        {
            if (annualRevenue < 0)
                throw new Exception(Messages.InvalidAnnualRevenue);
        }

        public void ValidateEmployeeCount(int employeeCount)
        {
            if (employeeCount < 0)
                throw new Exception(Messages.InvalidEmployeeCount);
        }
    }
}
