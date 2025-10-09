using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Application.Features.CorporateCustomers.Queries.GetList
{
    public class GetListCorporateCustomerQuery : IRequest<GetListCorporateCustomerResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchText { get; set; }
        public string? OrderBy { get; set; }
        public bool Ascending { get; set; } = true;

        public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, GetListCorporateCustomerResponse>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetListCorporateCustomerQueryHandler(
                ICorporateCustomerRepository corporateCustomerRepository,
                IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<GetListCorporateCustomerResponse> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<CorporateCustomer, bool>>? predicate = null;
                if (!string.IsNullOrEmpty(request.SearchText))
                {
                    predicate = c => c.CompanyName.Contains(request.SearchText) ||
                                   c.TaxNumber.Contains(request.SearchText) ||
                                   c.AuthorizedPersonName.Contains(request.SearchText);
                }

                Expression<Func<CorporateCustomer, object>>? orderBy = null;
                if (!string.IsNullOrEmpty(request.OrderBy))
                {
                    orderBy = request.OrderBy.ToLower() switch
                    {
                        "companyname" => c => c.CompanyName,
                        "taxnumber" => c => c.TaxNumber,
                        "authorizedpersonname" => c => c.AuthorizedPersonName,
                        "annualrevenue" => c => c.AnnualRevenue,
                        "employeecount" => c => c.EmployeeCount,
                        _ => c => c.CompanyName
                    };
                }

                var (items, totalCount) = await _corporateCustomerRepository.GetListAsync(
                    predicate: predicate,
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize,
                    orderBy: orderBy,
                    ascending: request.Ascending);

                var response = new GetListCorporateCustomerResponse
                {
                    Items = _mapper.Map<List<GetListCorporateCustomerListItemDto>>(items),
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalCount = totalCount
                };

                return response;
            }
        }
    }
} 