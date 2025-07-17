using Microsoft.EntityFrameworkCore;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<House> Houses { get; set; }
    DbSet<Booking> Bookings { get; set; }
    DbSet<HouseBookingApp.Domain.Entities.User> Users { get; set; }
    DbSet<Property> Properties { get; set; }
    DbSet<Room> Rooms { get; set; }
    DbSet<Reservation> Reservations { get; set; }
    DbSet<Payment> Payments { get; set; }
    DbSet<Review> Reviews { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}