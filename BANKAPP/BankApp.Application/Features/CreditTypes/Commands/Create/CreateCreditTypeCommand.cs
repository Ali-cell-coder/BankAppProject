using MediatR;
using System;
using BankApp.Application.Features.CreditTypes.Queries.GetList;

namespace BankApp.Application.Features.CreditTypes.Commands.Create
{
    public class CreateCreditTypeCommand : IRequest<CreditTypeDto>
    {
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