using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.MarkAsFailed;

public record MarkAsFailedCommand(
    Guid PaymentId,
    string Reason
) : IRequest<PaymentDto>;