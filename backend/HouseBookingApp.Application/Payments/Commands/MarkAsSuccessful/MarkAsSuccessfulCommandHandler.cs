using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Commands.MarkAsSuccessful;

public class MarkAsSuccessfulCommandHandler : IRequestHandler<MarkAsSuccessfulCommand, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkAsSuccessfulCommandHandler(
        IPaymentRepository paymentRepository,
        IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PaymentDto> Handle(MarkAsSuccessfulCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.PaymentId, cancellationToken);
        
        if (payment == null)
            throw new ArgumentException($"Payment with ID {request.PaymentId} not found");

        payment.MarkAsSuccessful(request.TransactionId);

        await _paymentRepository.UpdateAsync(payment, cancellationToken);
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