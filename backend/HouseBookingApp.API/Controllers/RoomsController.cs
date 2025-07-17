using HouseBookingApp.Application.Rooms.Commands.UpdateRoomInfo;
using HouseBookingApp.Application.Rooms.Commands.SetAvailability;
using HouseBookingApp.Application.Rooms.Commands.SetPriceOverride;
using HouseBookingApp.Application.Rooms.Queries.GetRoom;
using HouseBookingApp.Application.Rooms.Queries.GetRooms;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] Guid? propertyId = null,
        [FromQuery] string? roomType = null)
    {
        RoomType? roomTypeValue = null;
        if (!string.IsNullOrEmpty(roomType))
        {
            roomTypeValue = new RoomType(roomType, "", 1);
        }

        var query = new GetRoomsQuery(
            pageNumber,
            pageSize,
            searchTerm,
            isActive,
            propertyId,
            roomTypeValue);

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(Guid id)
    {
        var query = new GetRoomQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}/info")]
    public async Task<IActionResult> UpdateRoomInfo(Guid id, [FromBody] UpdateRoomInfoRequest request)
    {
        var command = new UpdateRoomInfoCommand(
            id,
            request.Type,
            request.Capacity,
            request.Price,
            request.IsRefundable);

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/availability")]
    public async Task<IActionResult> SetAvailability(Guid id, [FromBody] SetAvailabilityRequest request)
    {
        var command = new SetAvailabilityCommand(id, request.Date, request.IsAvailable);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/price-override")]
    public async Task<IActionResult> SetPriceOverride(Guid id, [FromBody] SetPriceOverrideRequest request)
    {
        var command = new SetPriceOverrideCommand(id, request.Date, request.Price);
        await _mediator.Send(command);
        return NoContent();
    }
}

public class UpdateRoomInfoRequest
{
    public RoomType Type { get; set; } = new();
    public int Capacity { get; set; }
    public Money Price { get; set; } = new();
    public bool IsRefundable { get; set; }
}

public class SetAvailabilityRequest
{
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; }
}

public class SetPriceOverrideRequest
{
    public DateTime Date { get; set; }
    public Money Price { get; set; } = new();
}