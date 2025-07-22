using MediatR;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Application.Bookings.Queries;

public class GetBookingsByUserQueryHandler : IRequestHandler<GetBookingsByUserQuery, List<Booking>>
{
    private readonly IApplicationDbContext _context;

    public GetBookingsByUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Booking>> Handle(GetBookingsByUserQuery request, CancellationToken cancellationToken)
    {
        return await _context.Bookings
            .Include(b => b.House)
            .Where(b => b.UserId == request.UserId)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}