using HouseBookingApp.Application.Payments.Commands.CreatePayment;
using HouseBookingApp.Application.Payments.Commands.MarkAsSuccessful;
using HouseBookingApp.Application.Payments.Commands.MarkAsFailed;
using HouseBookingApp.Application.Payments.Commands.RefundPayment;
using HouseBookingApp.Application.Payments.Queries.GetPayment;
using HouseBookingApp.Application.Payments.Queries.GetPayments;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBookingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPayments(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] Guid? reservationId = null,
        [FromQuery] PaymentStatus? status = null,
        [FromQuery] PaymentMethod? method = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null)
    {
        var query = new GetPaymentsQuery(
            pageNumber,
            pageSize,
            reservationId,
            status,
            method,
            fromDate,
            toDate);

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(Guid id)
    {
        var query = new GetPaymentQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
    {
        var command = new CreatePaymentCommand(
            request.ReservationId,
            request.Amount,
            request.Method);

        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPayment), new { id = result.Id }, result);
    }

    [HttpPost("{id}/mark-successful")]
    public async Task<IActionResult> MarkAsSuccessful(Guid id, [FromBody] MarkAsSuccessfulRequest request)
    {
        var command = new MarkAsSuccessfulCommand(id, request.TransactionId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/mark-failed")]
    public async Task<IActionResult> MarkAsFailed(Guid id, [FromBody] MarkAsFailedRequest request)
    {
        var command = new MarkAsFailedCommand(id, request.Reason);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/refund")]
    public async Task<IActionResult> RefundPayment(Guid id, [FromBody] RefundPaymentRequest request)
    {
        var command = new RefundPaymentCommand(id, request.Reason);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

public class CreatePaymentRequest
{
    public Guid ReservationId { get; set; }
    public Money Amount { get; set; } = new();
    public PaymentMethod Method { get; set; }
}

public class MarkAsSuccessfulRequest
{
    public string TransactionId { get; set; } = string.Empty;
}

public class MarkAsFailedRequest
{
    public string Reason { get; set; } = string.Empty;
}

public class RefundPaymentRequest
{
    public string Reason { get; set; } = string.Empty;
}