using MediatR;
using Microsoft.AspNetCore.Mvc;
using BankApp.Application.Features.CreditTypes.Commands.Create;
using BankApp.Application.Features.CreditTypes.Queries.GetList;
namespace BankApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CreditTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] int customerType = 1)
        {
            var result = await _mediator.Send(new GetListCreditTypeQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                CustomerType = customerType
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 