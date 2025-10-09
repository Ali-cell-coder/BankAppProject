using BankApp.Application.Features.CreditApplications.Commands.Create;
using BankApp.Application.Features.CreditApplications.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditApplicationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCreditApplicationQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
} 