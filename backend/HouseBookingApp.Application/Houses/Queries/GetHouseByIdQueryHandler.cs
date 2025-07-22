using MediatR;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Application.Houses.Queries;

public class GetHouseByIdQueryHandler : IRequestHandler<GetHouseByIdQuery, House?>
{
    private readonly IApplicationDbContext _context;

    public GetHouseByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<House?> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Houses
            .Include(h => h.Bookings)
            .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken);
    }
}