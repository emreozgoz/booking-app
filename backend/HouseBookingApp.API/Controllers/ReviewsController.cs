using HouseBookingApp.Application.Reviews.Commands.LeaveReview;
using HouseBookingApp.Application.Reviews.Commands.UpdateComment;
using HouseBookingApp.Application.Reviews.Commands.DeleteReview;
using HouseBookingApp.Application.Reviews.Commands.MarkAsInappropriate;
using HouseBookingApp.Application.Reviews.Queries.GetReview;
using HouseBookingApp.Application.Reviews.Queries.GetReviews;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetReviews(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] Guid? propertyId = null,
        [FromQuery] Guid? guestId = null,
        [FromQuery] bool? isVerified = null,
        [FromQuery] bool? isVisible = null,
        [FromQuery] bool? isDeleted = null,
        [FromQuery] bool? isInappropriate = null,
        [FromQuery] int? minRating = null,
        [FromQuery] int? maxRating = null)
    {
        var query = new GetReviewsQuery(
            pageNumber,
            pageSize,
            propertyId,
            guestId,
            isVerified,
            isVisible,
            isDeleted,
            isInappropriate,
            minRating,
            maxRating);

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReview(Guid id)
    {
        var query = new GetReviewQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> LeaveReview([FromBody] LeaveReviewRequest request)
    {
        var command = new LeaveReviewCommand(
            request.UserId,
            request.PropertyId,
            request.Rating,
            request.Comment);

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetReview), new { id = result.Id }, result);
    }

    [HttpPut("{id}/comment")]
    public async Task<IActionResult> UpdateComment(Guid id, [FromBody] UpdateCommentRequest request)
    {
        var command = new UpdateCommentCommand(id, request.Comment);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        var command = new DeleteReviewCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/mark-inappropriate")]
    public async Task<IActionResult> MarkAsInappropriate(Guid id)
    {
        var command = new MarkAsInappropriateCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

public class LeaveReviewRequest
{
    public Guid UserId { get; set; }
    public Guid PropertyId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

public class UpdateCommentRequest
{
    public string Comment { get; set; } = string.Empty;
}