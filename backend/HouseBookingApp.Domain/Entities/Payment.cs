using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;

namespace HouseBookingApp.Domain.Entities;

public class Payment : BaseEntity
{
    public string PaymentNumber { get; set; } = string.Empty;
    public Guid ReservationId { get; set; }
    public Money Amount { get; set; } = new();
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public PaymentMethod Method { get; set; } = PaymentMethod.CreditCard;
    public string? TransactionId { get; set; }
    public string? PaymentGateway { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public string? FailureReason { get; set; }
    public string? RefundReason { get; set; }
    public DateTime? RefundedAt { get; set; }

    // Navigation properties
    public virtual Reservation Reservation { get; set; } = null!;

    public Payment() { }

    public Payment(Guid reservationId, Money amount, PaymentMethod method)
    {
        if (amount.IsZero || amount.IsNegative)
            throw new ArgumentException("Payment amount must be positive");

        PaymentNumber = GeneratePaymentNumber();
        ReservationId = reservationId;
        Amount = amount;
        Method = method;
        Status = PaymentStatus.Pending;
    }

    public bool IsSuccessful()
    {
        return Status == PaymentStatus.Completed;
    }

    public bool IsPending()
    {
        return Status == PaymentStatus.Pending;
    }

    public bool IsFailed()
    {
        return Status == PaymentStatus.Failed;
    }

    public bool IsRefunded()
    {
        return Status == PaymentStatus.Refunded;
    }

    public static Payment Create(Guid reservationId, Money amount, PaymentMethod method)
    {
        if (reservationId == Guid.Empty)
            throw new ArgumentException("Reservation ID cannot be empty");

        if (amount == null)
            throw new ArgumentNullException(nameof(amount));

        if (amount.IsZero || amount.IsNegative)
            throw new ArgumentException("Payment amount must be positive");

        return new Payment(reservationId, amount, method);
    }

    public void MarkAsSuccessful(string transactionId)
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Only pending payments can be marked as successful");

        if (string.IsNullOrWhiteSpace(transactionId))
            throw new ArgumentException("Transaction ID cannot be empty");

        Status = PaymentStatus.Completed;
        TransactionId = transactionId;
        ProcessedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsCompleted(string transactionId, string paymentGateway)
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Only pending payments can be marked as completed");

        Status = PaymentStatus.Completed;
        TransactionId = transactionId;
        PaymentGateway = paymentGateway;
        ProcessedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsFailed(string reason)
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Only pending payments can be marked as failed");

        Status = PaymentStatus.Failed;
        FailureReason = reason;
        ProcessedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Refund(string reason)
    {
        if (Status != PaymentStatus.Completed)
            throw new InvalidOperationException("Only completed payments can be refunded");

        Status = PaymentStatus.Refunded;
        RefundReason = reason;
        RefundedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    private static string GeneratePaymentNumber()
    {
        return $"PAY{DateTime.UtcNow:yyyyMMdd}{DateTime.UtcNow.Ticks % 10000:D4}";
    }
}