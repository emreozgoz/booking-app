using HouseBookingApp.Application.Images.Commands.CreateImage;
using HouseBookingApp.Application.Images.Commands.SetAsPrimary;
using HouseBookingApp.Application.Images.Commands.MarkForDeletion;
using HouseBookingApp.Application.Images.Queries.GetImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(Guid id)
    {
        var query = new GetImageQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateImage([FromBody] CreateImageRequest request)
    {
        var command = new CreateImageCommand(
            request.Url,
            request.Alt,
            request.IsPrimary,
            request.Order);

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetImage), new { id = result.Id }, result);
    }

    [HttpPost("{id}/set-primary")]
    public async Task<IActionResult> SetAsPrimary(Guid id)
    {
        var command = new SetAsPrimaryCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/mark-for-deletion")]
    public async Task<IActionResult> MarkForDeletion(Guid id)
    {
        var command = new MarkForDeletionCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

public class CreateImageRequest
{
    public string Url { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;
    public int Order { get; set; } = 0;
}