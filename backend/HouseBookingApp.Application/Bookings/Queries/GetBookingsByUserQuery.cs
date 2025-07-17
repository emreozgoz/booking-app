using MediatR;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Bookings.Queries;

public class GetBookingsByUserQuery : IRequest<List<Booking>>
{
    public Guid UserId { get; set; }

    public GetBookingsByUserQuery(Guid userId)
    {
        UserId = userId;
    }
}