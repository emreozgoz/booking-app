using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Data;

public static class DbSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        // Check if data already exists
        if (context.Users.Any() || context.Properties.Any())
        {
            return; // Database has been seeded
        }

        Console.WriteLine("Seeding database with initial data...");

        // Create Users
        var users = new List<HouseBookingApp.Domain.Entities.User>
        {
            HouseBookingApp.Domain.Entities.User.Create(
                UserId.Create(),
                Email.Create("ahmet@example.com"),
                BCrypt.Net.BCrypt.HashPassword("password123"),
                "Ahmet",
                "Yılmaz"
            ),
            HouseBookingApp.Domain.Entities.User.Create(
                UserId.Create(),
                Email.Create("mehmet@example.com"),
                BCrypt.Net.BCrypt.HashPassword("password123"),
                "Mehmet",
                "Demir"
            ),
            HouseBookingApp.Domain.Entities.User.Create(
                UserId.Create(),
                Email.Create("ayse@example.com"),
                BCrypt.Net.BCrypt.HashPassword("password123"),
                "Ayşe",
                "Kaya"
            ),
            HouseBookingApp.Domain.Entities.User.Create(
                UserId.Create(),
                Email.Create("fatma@example.com"),
                BCrypt.Net.BCrypt.HashPassword("password123"),
                "Fatma",
                "Özdemir"
            ),
            HouseBookingApp.Domain.Entities.User.Create(
                UserId.Create(),
                Email.Create("admin@example.com"),
                BCrypt.Net.BCrypt.HashPassword("admin123"),
                "Admin",
                "User"
            )
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var owner1 = users.First(u => u.Email.Value == "ahmet@example.com");
        var owner2 = users.First(u => u.Email.Value == "mehmet@example.com");
        var guest1 = users.First(u => u.Email.Value == "ayse@example.com");
        var guest2 = users.First(u => u.Email.Value == "fatma@example.com");

        // Create Properties
        var properties = new List<Property>
        {
            new Property
            {
                Id = Guid.NewGuid(),
                Name = "Lüks Villa Bodrum",
                Description = "Bodrum'da deniz manzaralı lüks villa. Özel havuz ve bahçe ile.",
                Location = new Location("Bodrum", "Türkiye", "Yalıkavak Mahallesi, Deniz Caddesi No:15", "48990", new GeoLocation(37.0982, 27.2685)),
                PropertyType = new PropertyType("Villa", "Müstakil villa", PropertyCategory.House),
                OwnerId = owner1.Id,
                IsActive = true,
                ImageUrl = "https://example.com/villa1.jpg",
                Rating = 4.8,
                ReviewCount = 12,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Property
            {
                Id = Guid.NewGuid(),
                Name = "Şehir Merkezi Apartman",
                Description = "İstanbul Taksim'de merkezi konumda modern apartman dairesi.",
                Location = new Location("İstanbul", "Türkiye", "Taksim Mahallesi, İstiklal Caddesi No:25", "34437", new GeoLocation(41.0370, 28.9869)),
                PropertyType = new PropertyType("Apartman", "Şehir merkezi apartman", PropertyCategory.Apartment),
                OwnerId = owner2.Id,
                IsActive = true,
                ImageUrl = "https://example.com/apartment1.jpg",
                Rating = 4.5,
                ReviewCount = 8,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Property
            {
                Id = Guid.NewGuid(),
                Name = "Dağ Evi Kapadokya",
                Description = "Kapadokya'da otantik taş ev. Balon turu manzarası ile.",
                Location = new Location("Nevşehir", "Türkiye", "Göreme Mahallesi, Taş Sokak No:8", "50180", new GeoLocation(38.6424, 34.8291)),
                PropertyType = new PropertyType("Taş Ev", "Geleneksel taş ev", PropertyCategory.House),
                OwnerId = owner1.Id,
                IsActive = true,
                ImageUrl = "https://example.com/stonehouse1.jpg",
                Rating = 4.9,
                ReviewCount = 15,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Properties.AddRange(properties);
        context.SaveChanges();

        // Create Rooms
        var rooms = new List<Room>();
        foreach (var property in properties)
        {
            for (int i = 1; i <= 3; i++)
            {
                rooms.Add(new Room
                {
                    Id = Guid.NewGuid(),
                    Number = $"R{i:D3}",
                    Name = $"Oda {i}",
                    Description = $"{property.Name} - {i}. oda",
                    RoomType = new RoomType($"Standard Room {i}", "Standart oda", i + 1),
                    PricePerNight = new Money(150 + (i * 50), "TRY"),
                    MaxOccupancy = i + 1,
                    Size = 25 + (i * 5),
                    IsActive = true,
                    PropertyId = property.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }
        }

        context.Rooms.AddRange(rooms);
        context.SaveChanges();

        // Create Reservations
        var reservations = new List<Reservation>();
        var random = new Random();
        
        for (int i = 0; i < 5; i++)
        {
            var room = rooms[random.Next(rooms.Count)];
            var guest = i % 2 == 0 ? guest1 : guest2;
            var checkIn = DateTime.UtcNow.AddDays(random.Next(1, 30));
            var checkOut = checkIn.AddDays(random.Next(2, 7));
            
            reservations.Add(new Reservation
            {
                Id = Guid.NewGuid(),
                ReservationNumber = $"RSV{DateTime.UtcNow.Ticks.ToString().Substring(0, 8)}",
                PropertyId = room.PropertyId,
                RoomId = room.Id,
                GuestId = guest.Id,
                Period = new Period(checkIn, checkOut),
                NumberOfGuests = random.Next(1, room.MaxOccupancy + 1),
                TotalAmount = new Money(room.PricePerNight.Amount * (decimal)(checkOut - checkIn).Days, "TRY"),
                Status = ReservationStatus.Confirmed,
                SpecialRequests = i % 2 == 0 ? "Geç check-in" : null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        }

        context.Reservations.AddRange(reservations);
        context.SaveChanges();

        // Create Payments
        var payments = new List<Payment>();
        foreach (var reservation in reservations)
        {
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                PaymentNumber = $"PAY{DateTime.UtcNow.Ticks.ToString().Substring(0, 8)}",
                ReservationId = reservation.Id,
                Amount = reservation.TotalAmount,
                Status = PaymentStatus.Completed,
                Method = PaymentMethod.CreditCard,
                TransactionId = Guid.NewGuid().ToString(),
                PaymentGateway = "Iyzico",
                ProcessedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        }

        context.Payments.AddRange(payments);
        context.SaveChanges();

        // Create Reviews
        var reviews = new List<Review>();
        var reviewComments = new[]
        {
            "Harika bir deneyimdi! Kesinlikle tavsiye ederim.",
            "Temiz ve konforlu. Personel çok ilgili.",
            "Manzara muhteşemdi. Tekrar geleceğim.",
            "Fiyat performans açısından çok iyi.",
            "Konum mükemmel, her yere yakın."
        };

        for (int i = 0; i < reviewComments.Length; i++)
        {
            var reservation = reservations[i % reservations.Count];
            var property = properties.First(p => p.Id == reservation.PropertyId);
            
            reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                PropertyId = property.Id,
                GuestId = reservation.GuestId,
                ReservationId = reservation.Id,
                Rating = random.Next(4, 6),
                Title = $"Mükemmel konaklama",
                Comment = reviewComments[i],
                IsVerified = true,
                IsVisible = true,
                VerifiedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
        }

        context.Reviews.AddRange(reviews);
        context.SaveChanges();

        // Create Legacy Houses for backward compatibility
        var houses = new List<House>
        {
            new House
            {
                Id = Guid.NewGuid(),
                Title = "Sahil Evi Antalya",
                Description = "Antalya'da deniz kenarında müstakil ev",
                Location = new Location("Antalya", "Türkiye", "Konyaaltı Sahil Caddesi No:100", "07100", new GeoLocation(36.8841, 30.6959)),
                PricePerNight = new Money(300, "TRY"),
                MaxGuests = 6,
                Bedrooms = 3,
                Bathrooms = 2,
                IsAvailable = true,
                ImageUrl = "https://example.com/house1.jpg",
                OwnerId = owner1.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new House
            {
                Id = Guid.NewGuid(),
                Title = "Dağ Evi Bursa",
                Description = "Bursa Uludağ'da dağ evi",
                Location = new Location("Bursa", "Türkiye", "Uludağ Milli Parkı içi", "16370", new GeoLocation(40.0919, 29.1244)),
                PricePerNight = new Money(250, "TRY"),
                MaxGuests = 4,
                Bedrooms = 2,
                Bathrooms = 1,
                IsAvailable = true,
                ImageUrl = "https://example.com/house2.jpg",
                OwnerId = owner2.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Houses.AddRange(houses);
        context.SaveChanges();

        // Create Legacy Bookings
        var bookings = new List<Booking>
        {
            new Booking
            {
                Id = Guid.NewGuid(),
                HouseId = houses[0].Id,
                UserId = guest1.Id,
                Period = new Period(DateTime.UtcNow.AddDays(10), DateTime.UtcNow.AddDays(13)),
                NumberOfGuests = 4,
                TotalAmount = new Money(900, "TRY"),
                Status = BookingStatus.Confirmed,
                SpecialRequests = "Havalimanı transferi",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Booking
            {
                Id = Guid.NewGuid(),
                HouseId = houses[1].Id,
                UserId = guest2.Id,
                Period = new Period(DateTime.UtcNow.AddDays(20), DateTime.UtcNow.AddDays(22)),
                NumberOfGuests = 2,
                TotalAmount = new Money(500, "TRY"),
                Status = BookingStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Bookings.AddRange(bookings);
        context.SaveChanges();

        Console.WriteLine("Database seeding completed successfully!");
        Console.WriteLine($"Created {users.Count} users, {properties.Count} properties, {rooms.Count} rooms, {reservations.Count} reservations, {payments.Count} payments, {reviews.Count} reviews, {houses.Count} houses, {bookings.Count} bookings");
    }
}