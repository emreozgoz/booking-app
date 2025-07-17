using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Properties;
using MediatR;

namespace HouseBookingApp.Application.Properties.Queries.GetProperty;

public class GetPropertyQueryHandler : IRequestHandler<GetPropertyQuery, PropertyDto>
{
    private readonly IPropertyRepository _propertyRepository;

    public GetPropertyQueryHandler(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<PropertyDto> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (property == null)
            throw new ArgumentException($"Property with ID {request.Id} not found");

        return new PropertyDto
        {
            Id = property.Id,
            Name = property.Name,
            Description = property.Description,
            PropertyType = property.PropertyType,
            Location = property.Location,
            OwnerId = property.OwnerId,
            IsActive = property.IsActive,
            ImageUrl = property.ImageUrl,
            Rating = property.Rating,
            ReviewCount = property.ReviewCount,
            CreatedAt = property.CreatedAt,
            UpdatedAt = property.UpdatedAt,
            Images = property.Images.Select(i => new PropertyImageDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Alt = i.Alt,
                IsMain = i.IsMain,
                Order = i.Order
            }).ToList(),
            Rooms = property.Rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                RoomType = r.RoomType,
                Price = r.PricePerNight,
                MaxGuests = r.MaxOccupancy,
                IsActive = r.IsActive
            }).ToList(),
            Reviews = property.Reviews.Where(r => r.IsVisible).Select(r => new ReviewDto
            {
                Id = r.Id,
                GuestId = r.GuestId,
                Rating = r.Rating,
                Title = r.Title,
                Comment = r.Comment,
                IsVerified = r.IsVerified,
                CreatedAt = r.CreatedAt
            }).ToList()
        };
    }
}