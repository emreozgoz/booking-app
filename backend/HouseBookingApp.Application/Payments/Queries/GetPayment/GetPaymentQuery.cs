using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Queries.GetPayment;

public record GetPaymentQuery(Guid Id) : IRequest<PaymentDto>;