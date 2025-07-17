using MediatR;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Application.Houses.Queries;

public class GetHousesQueryHandler : IRequestHandler<GetHousesQuery, List<House>>
{
    private readonly IApplicationDbContext _context;

    public GetHousesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<House>> Handle(GetHousesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Houses
            .Where(h => h.IsAvailable)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(h => h.Title.Contains(request.SearchTerm) || 
                                   h.Description.Contains(request.SearchTerm) ||
                                   h.Address.Contains(request.SearchTerm));
        }

        if (request.MinPrice.HasValue)
        {
            query = query.Where(h => h.PricePerNight >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(h => h.PricePerNight <= request.MaxPrice.Value);
        }

        return await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
    }
}