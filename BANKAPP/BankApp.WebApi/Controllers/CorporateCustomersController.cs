using BankApp.Application.Features.CorporateCustomers.Commands.Create;
using BankApp.Application.Features.CorporateCustomers.Commands.Delete;
using BankApp.Application.Features.CorporateCustomers.Commands.Update;
using BankApp.Application.Features.CorporateCustomers.Queries.GetById;
using BankApp.Application.Features.CorporateCustomers.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorporateCustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CorporateCustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Listeleme (Tümünü getir)
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCorporateCustomerQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Id ile getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdCorporateCustomerQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Ekle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCorporateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Güncelle
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCorporateCustomerCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
} 