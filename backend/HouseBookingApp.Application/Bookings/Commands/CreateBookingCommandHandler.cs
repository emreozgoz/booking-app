using MediatR;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Application.Bookings.Commands;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
{
    private readonly IApplicationDbContext _context;

    public CreateBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var house = await _context.Houses
            .FirstOrDefaultAsync(h => h.Id == request.HouseId, cancellationToken);

        if (house == null)
        {
            throw new InvalidOperationException("House not found");
        }

        var isAvailable = await CheckAvailability(request.HouseId, request.CheckInDate, request.CheckOutDate, cancellationToken);
        if (!isAvailable)
        {
            throw new InvalidOperationException("House is not available for the selected dates");
        }

        var numberOfNights = (request.CheckOutDate - request.CheckInDate).Days;
        var totalAmount = numberOfNights * house.PricePerNight;

        var booking = new Booking
        {
            HouseId = request.HouseId,
            UserId = request.UserId,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            NumberOfGuests = request.NumberOfGuests,
            TotalAmount = totalAmount,
            SpecialRequests = request.SpecialRequests
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync(cancellationToken);

        return booking;
    }

    private async Task<bool> CheckAvailability(Guid houseId, DateTime checkIn, DateTime checkOut, CancellationToken cancellationToken)
    {
        var conflictingBookings = await _context.Bookings
            .Where(b => b.HouseId == houseId && 
                       b.Status != Domain.Enums.BookingStatus.Cancelled &&
                       ((b.CheckInDate <= checkIn && b.CheckOutDate > checkIn) ||
                        (b.CheckInDate < checkOut && b.CheckOutDate >= checkOut) ||
                        (b.CheckInDate >= checkIn && b.CheckOutDate <= checkOut)))
            .AnyAsync(cancellationToken);

        return !conflictingBookings;
    }
}