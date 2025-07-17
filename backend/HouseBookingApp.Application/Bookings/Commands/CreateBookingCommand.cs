using MediatR;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Bookings.Commands;

public class CreateBookingCommand : IRequest<Booking>
{
    public Guid HouseId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string? SpecialRequests { get; set; }
}