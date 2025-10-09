using AutoMapper;
using BankApp.Application.Services.Repositories;
using BankApp.Domain.Entities;
using MediatR;
using System;

namespace BankApp.Application.Features.CreditApplications.Commands.Create
{
    public class CreateCreditApplicationCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid CreditTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int Term { get; set; }
        public string Purpose { get; set; }

        public class CreateCreditApplicationCommandHandler : IRequestHandler<CreateCreditApplicationCommand, Guid>
        {
            private readonly ICreditApplicationRepository _creditApplicationRepository;
            private readonly IMapper _mapper;

            public CreateCreditApplicationCommandHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
            {
                _creditApplicationRepository = creditApplicationRepository;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
            {
                var creditApplication = new CreditApplication
                {
                    Id = Guid.NewGuid(),
                    CustomerId = request.CustomerId,
                    CreditTypeId = request.CreditTypeId,
                    RequestedAmount = request.RequestedAmount,
                    Term = request.Term,
                    Purpose = request.Purpose,
                    Status = "Pending",
                    ApplicationDate = DateTime.UtcNow
                };

                await _creditApplicationRepository.AddAsync(creditApplication);
                await _creditApplicationRepository.SaveChangesAsync();

                return creditApplication.Id;
            }
        }
    }
} 