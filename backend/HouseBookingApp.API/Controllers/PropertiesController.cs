using HouseBookingApp.Application.Properties.Commands.CreateProperty;
using HouseBookingApp.Application.Properties.Commands.UpdateProperty;
using HouseBookingApp.Application.Properties.Commands.ActivateProperty;
using HouseBookingApp.Application.Properties.Commands.DeactivateProperty;
using HouseBookingApp.Application.Properties.Queries.GetProperty;
using HouseBookingApp.Application.Properties.Queries.GetProperties;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PropertiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperties(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] Guid? ownerId = null,
        [FromQuery] string? city = null,
        [FromQuery] string? country = null,
        [FromQuery] string? propertyType = null)
    {
        Location? location = null;
        if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
        {
            location = new Location(city, country, "", "", new GeoLocation());
        }

        PropertyType? propType = null;
        if (!string.IsNullOrEmpty(propertyType))
        {
            propType = new PropertyType(propertyType, "", PropertyCategory.Hotel);
        }

        var query = new GetPropertiesQuery(
            pageNumber,
            pageSize,
            searchTerm,
            isActive,
            ownerId,
            location,
            propType);

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProperty(Guid id)
    {
        var query = new GetPropertyQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty([FromBody] CreatePropertyRequest request)
    {
        var command = new CreatePropertyCommand(
            request.Name,
            request.Description,
            request.PropertyType,
            request.Location,
            request.OwnerId);

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProperty), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] UpdatePropertyRequest request)
    {
        var command = new UpdatePropertyCommand(
            id,
            request.Name,
            request.Description,
            request.PropertyType,
            request.Location);

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/activate")]
    public async Task<IActionResult> ActivateProperty(Guid id)
    {
        var command = new ActivatePropertyCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/deactivate")]
    public async Task<IActionResult> DeactivateProperty(Guid id)
    {
        var command = new DeactivatePropertyCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

public class CreatePropertyRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PropertyType PropertyType { get; set; } = new();
    public Location Location { get; set; } = new();
    public Guid OwnerId { get; set; }
}

public class UpdatePropertyRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PropertyType PropertyType { get; set; } = new();
    public Location Location { get; set; } = new();
}