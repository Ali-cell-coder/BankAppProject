using BankApp.Application.Features.CreditApplications.Commands.Create;
using BankApp.Application.Features.CreditApplications.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BankApp.Application.Features.CreditApplications.Queries.GetByCustomerId;

namespace BankApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreditApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetListCreditApplicationQuery());
            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(Guid customerId)
        {
            var result = await _mediator.Send(new GetCreditApplicationsByCustomerIdQuery { CustomerId = customerId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditApplicationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 