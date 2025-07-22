using Microsoft.EntityFrameworkCore;
using DomainUser = HouseBookingApp.Domain.Entities.User;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<House> Houses { get; }
    DbSet<DomainUser> Users { get; }
    DbSet<Property> Properties { get; }
    DbSet<Room> Rooms { get; }
    DbSet<Booking> Bookings { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Image> Images { get; }
    DbSet<PropertyImage> PropertyImages { get; }
    DbSet<RoomImage> RoomImages { get; }
    DbSet<Amenity> Amenities { get; }
    DbSet<RoomAmenity> RoomAmenities { get; }
    DbSet<RoomAvailability> RoomAvailabilities { get; }
    DbSet<RoomPriceOverride> RoomPriceOverrides { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}