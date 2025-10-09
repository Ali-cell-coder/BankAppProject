using MediatR;
using System;
using System.Collections.Generic;

namespace BankApp.Application.Features.CreditTypes.Queries.GetList
{
    public class GetListCreditTypeQuery : IRequest<List<CreditTypeDto>>
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public int CustomerType { get; set; } = 1;
    }

    public class CreditTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int MinTerm { get; set; }
        public int MaxTerm { get; set; }
        public decimal InterestRate { get; set; }
        public decimal BaseInterestRate { get; set; }
        public string CreditTypeCategory { get; set; }
    }
} 