using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Payments;
using HouseBookingApp.Domain.Entities;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.CreatePayment;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentCommandHandler(
        IPaymentRepository paymentRepository,
        IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = Payment.Create(
            request.ReservationId,
            request.Amount,
            request.Method);

        await _paymentRepository.AddAsync(payment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new PaymentDto
        {
            Id = payment.Id,
            PaymentNumber = payment.PaymentNumber,
            ReservationId = payment.ReservationId,
            Amount = payment.Amount,
            Status = payment.Status,
            Method = payment.Method,
            TransactionId = payment.TransactionId,
            PaymentGateway = payment.PaymentGateway,
            ProcessedAt = payment.ProcessedAt,
            FailureReason = payment.FailureReason,
            RefundReason = payment.RefundReason,
            RefundedAt = payment.RefundedAt,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt
        };
    }
}