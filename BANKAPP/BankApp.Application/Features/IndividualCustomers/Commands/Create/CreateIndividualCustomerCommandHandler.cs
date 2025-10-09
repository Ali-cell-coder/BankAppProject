using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Domain.Entities;
using BankApp.Application.Services.Repositories;

namespace BankApp.Application.Features.IndividualCustomers.Commands.Create
{
    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerDto>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task<CreatedIndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new IndividualCustomer
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdentityNumber = request.IdentityNumber,
                DateOfBirth = request.DateOfBirth,
                Nationality = request.Nationality,
                Occupation = request.Occupation,
                MonthlyIncome = request.MonthlyIncome,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address
            };

            await _individualCustomerRepository.AddAsync(entity);
            return new CreatedIndividualCustomerDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                IdentityNumber = entity.IdentityNumber,
                DateOfBirth = entity.DateOfBirth,
                Nationality = entity.Nationality,
                Occupation = entity.Occupation,
                MonthlyIncome = entity.MonthlyIncome,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Address = entity.Address
            };
        }
    }
} 