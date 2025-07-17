using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Rooms;
using HouseBookingApp.Domain.Entities;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Queries.GetRoom;

public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomDto>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<RoomDto> Handle(GetRoomQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (room == null)
            throw new ArgumentException($"Room with ID {request.Id} not found");

        return MapToDto(room);
    }

    private static RoomDto MapToDto(Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Number = room.Number,
            Name = room.Name,
            Description = room.Description,
            RoomType = room.RoomType,
            PricePerNight = room.PricePerNight,
            MaxOccupancy = room.MaxOccupancy,
            Size = room.Size,
            IsActive = room.IsActive,
            IsRefundable = room.IsRefundable,
            PropertyId = room.PropertyId,
            CreatedAt = room.CreatedAt,
            UpdatedAt = room.UpdatedAt,
            Images = room.Images.Select(i => new RoomImageDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Alt = i.Alt,
                IsMain = i.IsMain,
                Order = i.Order
            }).ToList(),
            Amenities = room.RoomAmenities.Select(ra => new AmenityDto
            {
                Id = ra.Amenity.Id,
                Name = ra.Amenity.Name,
                Description = ra.Amenity.Description,
                Icon = ra.Amenity.Icon,
                Category = ra.Amenity.Category,
                IsActive = ra.Amenity.IsActive
            }).ToList(),
            Availabilities = room.Availabilities.Select(a => new RoomAvailabilityDto
            {
                Id = a.Id,
                Date = a.Date,
                IsAvailable = a.IsAvailable
            }).ToList(),
            PriceOverrides = room.PriceOverrides.Select(po => new RoomPriceOverrideDto
            {
                Id = po.Id,
                Date = po.Date,
                Price = po.Price
            }).ToList()
        };
    }
}