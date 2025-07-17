using MediatR;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Interfaces;

namespace HouseBookingApp.Application.Houses.Commands;

public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, House>
{
    private readonly IApplicationDbContext _context;

    public CreateHouseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<House> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {
        var house = new House
        {
            Title = request.Title,
            Description = request.Description,
            Address = request.Address,
            PricePerNight = request.PricePerNight,
            MaxGuests = request.MaxGuests,
            Bedrooms = request.Bedrooms,
            Bathrooms = request.Bathrooms,
            ImageUrl = request.ImageUrl,
            OwnerId = request.OwnerId
        };

        _context.Houses.Add(house);
        await _context.SaveChangesAsync(cancellationToken);

        return house;
    }
}