using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.MarkAsSuccessful;

public record MarkAsSuccessfulCommand(
    Guid PaymentId,
    string TransactionId
) : IRequest<PaymentDto>;