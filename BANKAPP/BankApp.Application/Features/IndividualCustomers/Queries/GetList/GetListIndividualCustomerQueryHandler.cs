using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using BankApp.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public GetListIndividualCustomerQueryHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<GetListIndividualCustomerResponse> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
    {
        var query = _individualCustomerRepository.Query();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GetListIndividualCustomerListItemDto>(_mapper.ConfigurationProvider) // <-- Hatanın çözümü burada
            .ToListAsync(cancellationToken);

        var response = new GetListIndividualCustomerResponse
        {
            Items = items,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        return response;
    }
}
