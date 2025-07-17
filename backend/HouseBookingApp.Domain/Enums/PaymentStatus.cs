namespace HouseBookingApp.Domain.Enums;

public enum PaymentStatus
{
    Pending = 1,
    Completed = 2,
    Failed = 3,
    Refunded = 4,
    Cancelled = 5
}

public enum PaymentMethod
{
    CreditCard = 1,
    DebitCard = 2,
    PayPal = 3,
    BankTransfer = 4,
    Cash = 5,
    Cryptocurrency = 6
}

public static class PaymentStatusExtensions
{
    public static string GetDisplayName(this PaymentStatus status)
    {
        return status switch
        {
            PaymentStatus.Pending => "Pending",
            PaymentStatus.Completed => "Completed",
            PaymentStatus.Failed => "Failed",
            PaymentStatus.Refunded => "Refunded",
            PaymentStatus.Cancelled => "Cancelled",
            _ => status.ToString()
        };
    }

    public static string GetDisplayName(this PaymentMethod method)
    {
        return method switch
        {
            PaymentMethod.CreditCard => "Credit Card",
            PaymentMethod.DebitCard => "Debit Card",
            PaymentMethod.PayPal => "PayPal",
            PaymentMethod.BankTransfer => "Bank Transfer",
            PaymentMethod.Cash => "Cash",
            PaymentMethod.Cryptocurrency => "Cryptocurrency",
            _ => method.ToString()
        };
    }
}