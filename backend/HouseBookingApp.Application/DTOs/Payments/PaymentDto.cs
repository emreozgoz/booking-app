using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;

namespace HouseBookingApp.Application.DTOs.Payments;

public class PaymentDto
{
    public Guid Id { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public Guid ReservationId { get; set; }
    public Money Amount { get; set; } = new();
    public PaymentStatus Status { get; set; }
    public PaymentMethod Method { get; set; }
    public string? TransactionId { get; set; }
    public string? PaymentGateway { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public string? FailureReason { get; set; }
    public string? RefundReason { get; set; }
    public DateTime? RefundedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class PaymentSummaryDto
{
    public Guid Id { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public Guid ReservationId { get; set; }
    public Money Amount { get; set; } = new();
    public PaymentStatus Status { get; set; }
    public PaymentMethod Method { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}