using AutoMapper;
using MediatR;
using BankApp.Application.Services.Repositories;
using BankApp.Application.Features.IndividualCustomers.Rules;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetByIdIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public GetByIdIndividualCustomerQueryHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetByIdIndividualCustomerResponse> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
    {
        var individualCustomer = await _individualCustomerRepository.GetAsync(x => x.Id == request.Id);
        await _businessRules.IndividualCustomerShouldExistWhenRequested(individualCustomer);

        var response = _mapper.Map<GetByIdIndividualCustomerResponse>(individualCustomer);
        return response;
    }
} 