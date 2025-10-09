using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankApp.Domain.Entities;
using BankApp.Application.Services.Repositories;
using BankApp.Application.Features.CreditTypes.Queries.GetList;

namespace BankApp.Application.Features.CreditTypes.Commands.Create
{
    public class CreateCreditTypeCommandHandler : IRequestHandler<CreateCreditTypeCommand, CreditTypeDto>
    {
        private readonly ICreditTypeRepository _creditTypeRepository;
        private readonly IMapper _mapper;

        public CreateCreditTypeCommandHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
        {
            _creditTypeRepository = creditTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreditTypeDto> Handle(CreateCreditTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new CreditType
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                MinAmount = request.MinAmount,
                MaxAmount = request.MaxAmount,
                MinTerm = request.MinTerm,
                MaxTerm = request.MaxTerm,
                InterestRate = request.InterestRate,
                BaseInterestRate = request.BaseInterestRate,
                CreditTypeCategory = request.CreditTypeCategory
            };

            await _creditTypeRepository.AddAsync(entity);

            return _mapper.Map<CreditTypeDto>(entity);
        }
    }
} 