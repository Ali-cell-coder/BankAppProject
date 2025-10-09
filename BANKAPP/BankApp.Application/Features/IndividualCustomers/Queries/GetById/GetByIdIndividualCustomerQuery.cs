using MediatR;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQuery : IRequest<GetByIdIndividualCustomerResponse>
{
    public Guid Id { get; set; }
} 