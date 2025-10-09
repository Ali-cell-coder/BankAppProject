using MediatR;
using BankApp.Core.Repositories;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<GetListIndividualCustomerResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
} 