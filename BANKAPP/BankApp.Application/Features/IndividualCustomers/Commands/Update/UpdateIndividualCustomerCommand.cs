using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Update
{
    public class UpdateIndividualCustomerCommand : IRequest<UpdatedIndividualCustomerResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdatedIndividualCustomerResponse>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _businessRules;

            public UpdateIndividualCustomerCommandHandler(
                IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper,
                IndividualCustomerBusinessRules businessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
                await _businessRules.IndividualCustomerShouldExistWhenRequested(individualCustomer);
                await _businessRules.IndividualCustomerIdentityNumberShouldBeUnique(request.IdentityNumber);
                _businessRules.ValidateIdentityNumber(request.IdentityNumber);
                _businessRules.ValidateDateOfBirth(request.DateOfBirth);
                _businessRules.ValidateMonthlyIncome(request.MonthlyIncome);

                _mapper.Map(request, individualCustomer);
                var updatedIndividualCustomer = await _individualCustomerRepository.UpdateAsync(individualCustomer);

                var response = _mapper.Map<UpdatedIndividualCustomerResponse>(updatedIndividualCustomer);
                return response;
            }
        }
    }
} 