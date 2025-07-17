using Microsoft.EntityFrameworkCore;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Application.Interfaces;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
    }

    public DbSet<House> Houses { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    public DbSet<RoomImage> RoomImages { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<RoomAvailability> RoomAvailabilities { get; set; }
    public DbSet<RoomPriceOverride> RoomPriceOverrides { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<PropertyImageV2> PropertyImagesV2 { get; set; }
    public DbSet<RoomImageV2> RoomImagesV2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure seed data
        SeedData.Seed(modelBuilder);

        // User Entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            
            // Configure Email Value Object
            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasConversion(
                    email => email.Value,
                    value => Email.Create(value));
            
            entity.Property(u => u.Role).IsRequired();
            entity.Property(u => u.CreatedAt).IsRequired();
            entity.Property(u => u.UpdatedAt).IsRequired();

            entity.HasIndex(u => u.Email).IsUnique();
        });

        // Property Entity
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Description).HasMaxLength(2000);
            entity.Property(p => p.CreatedAt).IsRequired();
            entity.Property(p => p.UpdatedAt).IsRequired();

            // Configure Location Value Object
            entity.OwnsOne(p => p.Location, location =>
            {
                location.Property(l => l.City).HasMaxLength(100);
                location.Property(l => l.Country).HasMaxLength(100);
                location.Property(l => l.Address).HasMaxLength(500);
                location.Property(l => l.PostalCode).HasMaxLength(20);
                location.OwnsOne(l => l.GeoLocation, geo =>
                {
                    geo.Property(g => g.Latitude);
                    geo.Property(g => g.Longitude);
                });
            });

            // Configure PropertyType Value Object
            entity.OwnsOne(p => p.PropertyType, pt =>
            {
                pt.Property(t => t.Name).HasMaxLength(100);
                pt.Property(t => t.Description).HasMaxLength(500);
                pt.Property(t => t.Category);
            });

            entity.HasOne(p => p.Owner)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Room Entity
        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Number).IsRequired().HasMaxLength(50);
            entity.Property(r => r.Name).IsRequired().HasMaxLength(200);
            entity.Property(r => r.Description).HasMaxLength(1000);
            entity.Property(r => r.CreatedAt).IsRequired();
            entity.Property(r => r.UpdatedAt).IsRequired();

            // Configure RoomType Value Object
            entity.OwnsOne(r => r.RoomType, rt =>
            {
                rt.Property(t => t.Name).HasMaxLength(100);
                rt.Property(t => t.Description).HasMaxLength(500);
                rt.Property(t => t.MaxOccupancy);
            });

            // Configure Money Value Object
            entity.OwnsOne(r => r.PricePerNight, price =>
            {
                price.Property(p => p.Amount).HasColumnType("decimal(18,2)");
                price.Property(p => p.Currency).HasMaxLength(3);
            });

            entity.HasOne(r => r.Property)
                .WithMany(p => p.Rooms)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // PropertyImage Entity
        modelBuilder.Entity<PropertyImage>(entity =>
        {
            entity.HasKey(pi => pi.Id);
            entity.Property(pi => pi.ImageUrl).IsRequired().HasMaxLength(500);
            entity.Property(pi => pi.Alt).HasMaxLength(200);
            entity.Property(pi => pi.CreatedAt).IsRequired();
            entity.Property(pi => pi.UpdatedAt).IsRequired();

            entity.HasOne(pi => pi.Property)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // RoomImage Entity
        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(ri => ri.Id);
            entity.Property(ri => ri.ImageUrl).IsRequired().HasMaxLength(500);
            entity.Property(ri => ri.Alt).HasMaxLength(200);
            entity.Property(ri => ri.CreatedAt).IsRequired();
            entity.Property(ri => ri.UpdatedAt).IsRequired();

            entity.HasOne(ri => ri.Room)
                .WithMany(r => r.Images)
                .HasForeignKey(ri => ri.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Amenity Entity
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Description).HasMaxLength(500);
            entity.Property(a => a.Icon).HasMaxLength(100);
            entity.Property(a => a.Category).IsRequired();
            entity.Property(a => a.CreatedAt).IsRequired();
            entity.Property(a => a.UpdatedAt).IsRequired();
        });

        // RoomAmenity Entity
        modelBuilder.Entity<RoomAmenity>(entity =>
        {
            entity.HasKey(ra => ra.Id);
            entity.Property(ra => ra.CreatedAt).IsRequired();
            entity.Property(ra => ra.UpdatedAt).IsRequired();

            entity.HasOne(ra => ra.Room)
                .WithMany(r => r.RoomAmenities)
                .HasForeignKey(ra => ra.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ra => ra.Amenity)
                .WithMany()
                .HasForeignKey(ra => ra.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(ra => new { ra.RoomId, ra.AmenityId }).IsUnique();
        });

        // RoomAvailability Entity
        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(ra => ra.Id);
            entity.Property(ra => ra.Date).IsRequired();
            entity.Property(ra => ra.CreatedAt).IsRequired();
            entity.Property(ra => ra.UpdatedAt).IsRequired();

            entity.HasOne(ra => ra.Room)
                .WithMany(r => r.Availabilities)
                .HasForeignKey(ra => ra.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(ra => new { ra.RoomId, ra.Date }).IsUnique();
        });

        // RoomPriceOverride Entity
        modelBuilder.Entity<RoomPriceOverride>(entity =>
        {
            entity.HasKey(rpo => rpo.Id);
            entity.Property(rpo => rpo.Date).IsRequired();
            entity.Property(rpo => rpo.CreatedAt).IsRequired();
            entity.Property(rpo => rpo.UpdatedAt).IsRequired();

            // Configure Money Value Object
            entity.OwnsOne(rpo => rpo.Price, price =>
            {
                price.Property(p => p.Amount).HasColumnType("decimal(18,2)");
                price.Property(p => p.Currency).HasMaxLength(3);
            });

            entity.HasOne(rpo => rpo.Room)
                .WithMany(r => r.PriceOverrides)
                .HasForeignKey(rpo => rpo.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(rpo => new { rpo.RoomId, rpo.Date }).IsUnique();
        });

        // Image Entity
        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Url).IsRequired().HasMaxLength(1000);
            entity.Property(i => i.Alt).HasMaxLength(200);
            entity.Property(i => i.CreatedAt).IsRequired();
            entity.Property(i => i.UpdatedAt).IsRequired();
        });

        // PropertyImageV2 Entity
        modelBuilder.Entity<PropertyImageV2>(entity =>
        {
            entity.HasKey(pi => pi.Id);
            entity.Property(pi => pi.CreatedAt).IsRequired();
            entity.Property(pi => pi.UpdatedAt).IsRequired();

            entity.HasOne(pi => pi.Property)
                .WithMany()
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pi => pi.Image)
                .WithMany()
                .HasForeignKey(pi => pi.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(pi => new { pi.PropertyId, pi.ImageId }).IsUnique();
        });

        // RoomImageV2 Entity
        modelBuilder.Entity<RoomImageV2>(entity =>
        {
            entity.HasKey(ri => ri.Id);
            entity.Property(ri => ri.CreatedAt).IsRequired();
            entity.Property(ri => ri.UpdatedAt).IsRequired();

            entity.HasOne(ri => ri.Room)
                .WithMany()
                .HasForeignKey(ri => ri.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ri => ri.Image)
                .WithMany()
                .HasForeignKey(ri => ri.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(ri => new { ri.RoomId, ri.ImageId }).IsUnique();
        });

        // Reservation Entity
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.ReservationNumber).IsRequired().HasMaxLength(50);
            entity.Property(r => r.Status).IsRequired();
            entity.Property(r => r.SpecialRequests).HasMaxLength(1000);
            entity.Property(r => r.CancellationReason).HasMaxLength(500);
            entity.Property(r => r.CreatedAt).IsRequired();
            entity.Property(r => r.UpdatedAt).IsRequired();

            // Configure Period Value Object
            entity.OwnsOne(r => r.Period, period =>
            {
                period.Property(p => p.CheckInDate).IsRequired();
                period.Property(p => p.CheckOutDate).IsRequired();
            });

            // Configure Money Value Object
            entity.OwnsOne(r => r.TotalAmount, amount =>
            {
                amount.Property(a => a.Amount).HasColumnType("decimal(18,2)");
                amount.Property(a => a.Currency).HasMaxLength(3);
            });

            entity.HasOne(r => r.Property)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Guest)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Payment Entity
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.PaymentNumber).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Status).IsRequired();
            entity.Property(p => p.Method).IsRequired();
            entity.Property(p => p.TransactionId).HasMaxLength(100);
            entity.Property(p => p.PaymentGateway).HasMaxLength(100);
            entity.Property(p => p.FailureReason).HasMaxLength(500);
            entity.Property(p => p.RefundReason).HasMaxLength(500);
            entity.Property(p => p.CreatedAt).IsRequired();
            entity.Property(p => p.UpdatedAt).IsRequired();

            // Configure Money Value Object
            entity.OwnsOne(p => p.Amount, amount =>
            {
                amount.Property(a => a.Amount).HasColumnType("decimal(18,2)");
                amount.Property(a => a.Currency).HasMaxLength(3);
            });

            entity.HasOne(p => p.Reservation)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Review Entity
        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Rating).IsRequired();
            entity.Property(r => r.Title).IsRequired().HasMaxLength(200);
            entity.Property(r => r.Comment).HasMaxLength(2000);
            entity.Property(r => r.CreatedAt).IsRequired();
            entity.Property(r => r.UpdatedAt).IsRequired();

            entity.HasOne(r => r.Property)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Guest)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Reservation)
                .WithMany()
                .HasForeignKey(r => r.ReservationId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Legacy entities (for backward compatibility)
        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Title).IsRequired().HasMaxLength(200);
            entity.Property(h => h.Description).HasMaxLength(2000);
            entity.Property(h => h.CreatedAt).IsRequired();
            entity.Property(h => h.UpdatedAt).IsRequired();

            // Configure Location Value Object
            entity.OwnsOne(h => h.Location, location =>
            {
                location.Property(l => l.City).HasMaxLength(100);
                location.Property(l => l.Country).HasMaxLength(100);
                location.Property(l => l.Address).HasMaxLength(500);
                location.Property(l => l.PostalCode).HasMaxLength(20);
                location.OwnsOne(l => l.GeoLocation, geo =>
                {
                    geo.Property(g => g.Latitude);
                    geo.Property(g => g.Longitude);
                });
            });

            // Configure Money Value Object
            entity.OwnsOne(h => h.PricePerNight, price =>
            {
                price.Property(p => p.Amount).HasColumnType("decimal(18,2)");
                price.Property(p => p.Currency).HasMaxLength(3);
            });
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.CreatedAt).IsRequired();
            entity.Property(b => b.UpdatedAt).IsRequired();

            // Configure Period Value Object
            entity.OwnsOne(b => b.Period, period =>
            {
                period.Property(p => p.CheckInDate).IsRequired();
                period.Property(p => p.CheckOutDate).IsRequired();
            });

            // Configure Money Value Object
            entity.OwnsOne(b => b.TotalAmount, amount =>
            {
                amount.Property(a => a.Amount).HasColumnType("decimal(18,2)");
                amount.Property(a => a.Currency).HasMaxLength(3);
            });

            entity.HasOne(b => b.House)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HouseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}