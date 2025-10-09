using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BankApp.Application.Features.CreditApplications.Queries.GetList
{
    public class GetListCreditApplicationQuery : IRequest<List<CreditApplicationDto>>
    {
        public string? SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? OrderBy { get; set; }
        public bool Ascending { get; set; } = true;
    }

    public class CreditApplicationDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        // Add other properties as needed
    }

    public class GetListCreditApplicationQueryHandler : IRequestHandler<GetListCreditApplicationQuery, List<CreditApplicationDto>>
    {
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly IMapper _mapper;

        public GetListCreditApplicationQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
        {
            _creditApplicationRepository = creditApplicationRepository;
            _mapper = mapper;
        }

        public async Task<List<CreditApplicationDto>> Handle(GetListCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<CreditApplication, bool>>? predicate = null;
            if (!string.IsNullOrEmpty(request.SearchText))
            {
                predicate = c => c.Purpose.Contains(request.SearchText) || c.Status.Contains(request.SearchText);
            }

            Expression<Func<CreditApplication, object>>? orderBy = null;
            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                switch (request.OrderBy.ToLower())
                {
                    case "purpose": orderBy = c => c.Purpose; break;
                    case "status": orderBy = c => c.Status; break;
                    case "requestedamount": orderBy = c => c.RequestedAmount; break;
                    case "term": orderBy = c => c.Term; break;
                    default: orderBy = c => c.CreatedAt; break;
                }
            }

            (List<CreditApplication> items, int totalCount) = await _creditApplicationRepository.GetListAsync(
                predicate: predicate,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                orderBy: orderBy,
                ascending: request.Ascending,
                include: x => x.Include(c => c.CreditType));

            return items.Select(c => new CreditApplicationDto
            {
                Id = c.Id,
                CustomerId = c.CustomerId,
                CreditTypeId = c.CreditTypeId,
                RequestedAmount = c.RequestedAmount
            }).ToList();
        }
    }
} 