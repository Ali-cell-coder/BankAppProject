using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Services.Repositories;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using BankApp.Domain.Entities;

namespace BankApp.Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task IndividualCustomerShouldExistWhenRequested(IndividualCustomer? individualCustomer)
        {
            if (individualCustomer == null) throw new BusinessException("Individual customer not found");
        }

        public async Task IndividualCustomerIdentityNumberShouldBeUnique(string identityNumber)
        {
            var individualCustomer = await _individualCustomerRepository.GetAsync(x => x.IdentityNumber == identityNumber);
            if (individualCustomer != null) throw new BusinessException("Identity number already exists");
        }

        public void ValidateIdentityNumber(string identityNumber)
        {
            if (string.IsNullOrEmpty(identityNumber) || identityNumber.Length != 11)
                throw new BusinessException("Invalid identity number");
        }

        public void ValidateDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Now)
                throw new BusinessException("Date of birth cannot be in the future");
        }

        public void ValidateMonthlyIncome(decimal monthlyIncome)
        {
            if (monthlyIncome < 0)
                throw new BusinessException("Monthly income cannot be negative");
        }
    }
} 