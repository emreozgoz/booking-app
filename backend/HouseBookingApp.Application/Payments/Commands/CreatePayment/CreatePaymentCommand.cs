using HouseBookingApp.Application.DTOs.Payments;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.CreatePayment;

public record CreatePaymentCommand(
    Guid ReservationId,
    Money Amount,
    PaymentMethod Method
) : IRequest<PaymentDto>;