using BankApp.Application.Features.IndividualCustomers.Constants;
using BankApp.Application.Features.IndividualCustomers.Rules;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Delete
{
    public class DeleteIndividualCustomerCommand : IRequest<DeletedIndividualCustomerResponse>
    {
        public Guid Id { get; set; }

        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeletedIndividualCustomerResponse>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _businessRules;

            public DeleteIndividualCustomerCommandHandler(
                IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper,
                IndividualCustomerBusinessRules businessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletedIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
                await _businessRules.IndividualCustomerShouldExistWhenRequested(individualCustomer);
                await _individualCustomerRepository.DeleteAsync(individualCustomer);

                var response = _mapper.Map<DeletedIndividualCustomerResponse>(individualCustomer);
                return response;
            }
        }
    }
} 