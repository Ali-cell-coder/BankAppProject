using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Commands.Update;
using BankApp.Application.Features.IndividualCustomers.Commands.Delete;
using BankApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    private readonly IMediator _mediator;

    public IndividualCustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetByIdIndividualCustomerQuery { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListIndividualCustomerQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteIndividualCustomerCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
