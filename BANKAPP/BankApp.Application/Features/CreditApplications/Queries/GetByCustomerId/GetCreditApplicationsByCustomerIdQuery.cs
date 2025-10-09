using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BankApp.Application.Features.CreditApplications.Queries.GetByCustomerId
{
    public class GetCreditApplicationsByCustomerIdQuery : IRequest<List<CreditApplicationDto>>
    {
        public Guid CustomerId { get; set; }
    }

    public class CreditApplicationDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        // Add other properties as needed
    }
} 