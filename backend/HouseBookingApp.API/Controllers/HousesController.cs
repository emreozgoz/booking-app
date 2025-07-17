using Microsoft.AspNetCore.Mvc;
using MediatR;
using HouseBookingApp.Application.Houses.Commands;
using HouseBookingApp.Application.Houses.Queries;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly IMediator _mediator;

    public HousesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetHouses([FromQuery] GetHousesQuery query)
    {
        var houses = await _mediator.Send(query);
        return Ok(houses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHouseById(Guid id)
    {
        var house = await _mediator.Send(new GetHouseByIdQuery(id));
        if (house == null)
        {
            return NotFound();
        }
        return Ok(house);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHouse([FromBody] CreateHouseCommand command)
    {
        var house = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetHouseById), new { id = house.Id }, house);
    }
}