using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Application.Features.CreditTypes.Queries.GetList
{
    public class GetListCreditTypeQueryHandler : IRequestHandler<GetListCreditTypeQuery, List<CreditTypeDto>>
    {
        public async Task<List<CreditTypeDto>> Handle(GetListCreditTypeQuery request, CancellationToken cancellationToken)
        {
            // Dummy data for demonstration
            return await Task.FromResult(new List<CreditTypeDto>
            {
                new CreditTypeDto { Id = Guid.NewGuid(), Name = "Konut Kredisi" },
                new CreditTypeDto { Id = Guid.NewGuid(), Name = "İhtiyaç Kredisi" }
            });
        }
    }
} 