using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.RefundPayment;

public record RefundPaymentCommand(
    Guid PaymentId,
    string Reason
) : IRequest<PaymentDto>;