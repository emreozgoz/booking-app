using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.Enums;
using HouseBookingApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Data;

public static class SeedData
{
    // Base date for all seed data to ensure static values
    private static readonly DateTime BaseDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedUsers(modelBuilder);
        SeedAmenities(modelBuilder);
        SeedProperties(modelBuilder);
        SeedRooms(modelBuilder);
        SeedImages(modelBuilder);
        SeedReservations(modelBuilder);
        SeedPayments(modelBuilder);
        //SeedReviews(modelBuilder);
        SeedRoomAmenities(modelBuilder);
        SeedPropertyImages(modelBuilder);
        SeedRoomImages(modelBuilder);
        SeedRoomAvailabilities(modelBuilder);
        SeedRoomPriceOverrides(modelBuilder);
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var users = new[]
        {
            // Admin User
            new
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                FirstName = "John",
                LastName = "Admin",
                PasswordHash = "hashed_admin_password",
                Role = UserRole.Admin,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90),
                LastLoginAt = BaseDate.AddDays(-1),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            // Property Owners
            new
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                FirstName = "Sarah",
                LastName = "Johnson",
                PasswordHash = "hashed_owner_password",
                Role = UserRole.PropertyOwner,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60),
                LastLoginAt = BaseDate.AddDays(-2),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            new
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                FirstName = "Michael",
                LastName = "Davis",
                PasswordHash = "hashed_owner_password",
                Role = UserRole.PropertyOwner,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45),
                LastLoginAt = BaseDate.AddDays(-3),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            new
            {
                Id = new Guid("44444444-4444-4444-4444-444444444444"),
                FirstName = "Emma",
                LastName = "Wilson",
                PasswordHash = "hashed_owner_password",
                Role = UserRole.PropertyOwner,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30),
                LastLoginAt = BaseDate.AddDays(-1),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            // Guests
            new
            {
                Id = new Guid("55555555-5555-5555-5555-555555555555"),
                FirstName = "David",
                LastName = "Brown",
                PasswordHash = "hashed_guest_password",
                Role = UserRole.Guest,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20),
                LastLoginAt = BaseDate.AddDays(-1),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            new
            {
                Id = new Guid("66666666-6666-6666-6666-666666666666"),
                FirstName = "Lisa",
                LastName = "Anderson",
                PasswordHash = "hashed_guest_password",
                Role = UserRole.Guest,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-15),
                UpdatedAt = BaseDate.AddDays(-15),
                LastLoginAt = BaseDate.AddDays(-2),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            new
            {
                Id = new Guid("77777777-7777-7777-7777-777777777777"),
                FirstName = "Robert",
                LastName = "Taylor",
                PasswordHash = "hashed_guest_password",
                Role = UserRole.Guest,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-10),
                UpdatedAt = BaseDate.AddDays(-10),
                LastLoginAt = BaseDate.AddDays(-3),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            },
            new
            {
                Id = new Guid("88888888-8888-8888-8888-888888888888"),
                FirstName = "Jennifer",
                LastName = "Martinez",
                PasswordHash = "hashed_guest_password",
                Role = UserRole.Guest,
                IsEmailVerified = true,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-5),
                UpdatedAt = BaseDate.AddDays(-5),
                LastLoginAt = BaseDate.AddDays(-1),
                EmailVerificationToken = (string?)null,
                EmailVerificationTokenExpiry = (DateTime?)null
            }
        };

        // Update users array to include Email as Email value object
        var usersWithEmail = new[]
        {
            // Admin User
            new
            {
                Id = users[0].Id,
                FirstName = users[0].FirstName,
                LastName = users[0].LastName,
                Email = Email.Create("admin@housebooking.com"),
                PasswordHash = users[0].PasswordHash,
                Role = users[0].Role,
                IsEmailVerified = users[0].IsEmailVerified,
                IsActive = users[0].IsActive,
                CreatedAt = users[0].CreatedAt,
                UpdatedAt = users[0].UpdatedAt,
                LastLoginAt = users[0].LastLoginAt,
                EmailVerificationToken = users[0].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[0].EmailVerificationTokenExpiry
            },
            // Property Owners
            new
            {
                Id = users[1].Id,
                FirstName = users[1].FirstName,
                LastName = users[1].LastName,
                Email = Email.Create("sarah.johnson@example.com"),
                PasswordHash = users[1].PasswordHash,
                Role = users[1].Role,
                IsEmailVerified = users[1].IsEmailVerified,
                IsActive = users[1].IsActive,
                CreatedAt = users[1].CreatedAt,
                UpdatedAt = users[1].UpdatedAt,
                LastLoginAt = users[1].LastLoginAt,
                EmailVerificationToken = users[1].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[1].EmailVerificationTokenExpiry
            },
            new
            {
                Id = users[2].Id,
                FirstName = users[2].FirstName,
                LastName = users[2].LastName,
                Email = Email.Create("michael.davis@example.com"),
                PasswordHash = users[2].PasswordHash,
                Role = users[2].Role,
                IsEmailVerified = users[2].IsEmailVerified,
                IsActive = users[2].IsActive,
                CreatedAt = users[2].CreatedAt,
                UpdatedAt = users[2].UpdatedAt,
                LastLoginAt = users[2].LastLoginAt,
                EmailVerificationToken = users[2].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[2].EmailVerificationTokenExpiry
            },
            new
            {
                Id = users[3].Id,
                FirstName = users[3].FirstName,
                LastName = users[3].LastName,
                Email = Email.Create("emma.wilson@example.com"),
                PasswordHash = users[3].PasswordHash,
                Role = users[3].Role,
                IsEmailVerified = users[3].IsEmailVerified,
                IsActive = users[3].IsActive,
                CreatedAt = users[3].CreatedAt,
                UpdatedAt = users[3].UpdatedAt,
                LastLoginAt = users[3].LastLoginAt,
                EmailVerificationToken = users[3].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[3].EmailVerificationTokenExpiry
            },
            // Guests
            new
            {
                Id = users[4].Id,
                FirstName = users[4].FirstName,
                LastName = users[4].LastName,
                Email = Email.Create("david.brown@example.com"),
                PasswordHash = users[4].PasswordHash,
                Role = users[4].Role,
                IsEmailVerified = users[4].IsEmailVerified,
                IsActive = users[4].IsActive,
                CreatedAt = users[4].CreatedAt,
                UpdatedAt = users[4].UpdatedAt,
                LastLoginAt = users[4].LastLoginAt,
                EmailVerificationToken = users[4].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[4].EmailVerificationTokenExpiry
            },
            new
            {
                Id = users[5].Id,
                FirstName = users[5].FirstName,
                LastName = users[5].LastName,
                Email = Email.Create("lisa.anderson@example.com"),
                PasswordHash = users[5].PasswordHash,
                Role = users[5].Role,
                IsEmailVerified = users[5].IsEmailVerified,
                IsActive = users[5].IsActive,
                CreatedAt = users[5].CreatedAt,
                UpdatedAt = users[5].UpdatedAt,
                LastLoginAt = users[5].LastLoginAt,
                EmailVerificationToken = users[5].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[5].EmailVerificationTokenExpiry
            },
            new
            {
                Id = users[6].Id,
                FirstName = users[6].FirstName,
                LastName = users[6].LastName,
                Email = Email.Create("robert.taylor@example.com"),
                PasswordHash = users[6].PasswordHash,
                Role = users[6].Role,
                IsEmailVerified = users[6].IsEmailVerified,
                IsActive = users[6].IsActive,
                CreatedAt = users[6].CreatedAt,
                UpdatedAt = users[6].UpdatedAt,
                LastLoginAt = users[6].LastLoginAt,
                EmailVerificationToken = users[6].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[6].EmailVerificationTokenExpiry
            },
            new
            {
                Id = users[7].Id,
                FirstName = users[7].FirstName,
                LastName = users[7].LastName,
                Email = Email.Create("jennifer.martinez@example.com"),
                PasswordHash = users[7].PasswordHash,
                Role = users[7].Role,
                IsEmailVerified = users[7].IsEmailVerified,
                IsActive = users[7].IsActive,
                CreatedAt = users[7].CreatedAt,
                UpdatedAt = users[7].UpdatedAt,
                LastLoginAt = users[7].LastLoginAt,
                EmailVerificationToken = users[7].EmailVerificationToken,
                EmailVerificationTokenExpiry = users[7].EmailVerificationTokenExpiry
            }
        };

        modelBuilder.Entity<User>().HasData(usersWithEmail);
    }

    private static void SeedAmenities(ModelBuilder modelBuilder)
    {
        var amenities = new[]
        {
            new
            {
                Id = new Guid("a1111111-1111-1111-1111-111111111111"),
                Name = "WiFi",
                Description = "High-speed wireless internet access",
                Icon = "wifi",
                Category = AmenityCategory.Technology,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a2222222-2222-2222-2222-222222222222"),
                Name = "Air Conditioning",
                Description = "Climate control system",
                Icon = "ac_unit",
                Category = AmenityCategory.Comfort,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a3333333-3333-3333-3333-333333333333"),
                Name = "Swimming Pool",
                Description = "Outdoor swimming pool",
                Icon = "pool",
                Category = AmenityCategory.Recreation,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a4444444-4444-4444-4444-444444444444"),
                Name = "Parking",
                Description = "Free parking space",
                Icon = "local_parking",
                Category = AmenityCategory.Convenience,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a5555555-5555-5555-5555-555555555555"),
                Name = "Kitchen",
                Description = "Fully equipped kitchen",
                Icon = "kitchen",
                Category = AmenityCategory.Convenience,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a6666666-6666-6666-6666-666666666666"),
                Name = "Gym",
                Description = "Fitness center",
                Icon = "fitness_center",
                Category = AmenityCategory.Recreation,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a7777777-7777-7777-7777-777777777777"),
                Name = "Balcony",
                Description = "Private balcony with view",
                Icon = "balcony",
                Category = AmenityCategory.Comfort,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a8888888-8888-8888-8888-888888888888"),
                Name = "Pet Friendly",
                Description = "Pets allowed",
                Icon = "pets",
                Category = AmenityCategory.Convenience,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("a9999999-9999-9999-9999-999999999999"),
                Name = "Washing Machine",
                Description = "In-unit laundry",
                Icon = "local_laundry_service",
                Category = AmenityCategory.Convenience,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            },
            new
            {
                Id = new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Name = "TV",
                Description = "Smart TV with streaming services",
                Icon = "tv",
                Category = AmenityCategory.Technology,
                IsActive = true,
                CreatedAt = BaseDate.AddDays(-90),
                UpdatedAt = BaseDate.AddDays(-90)
            }
        };

        modelBuilder.Entity<Amenity>().HasData(amenities);
    }

    private static void SeedProperties(ModelBuilder modelBuilder)
    {
        var properties = new[]
        {
            new
            {
                Id = new Guid("01111111-1111-1111-1111-111111111111"),
                Name = "Sunset Beach Villa",
                Description = "Luxurious beachfront villa with stunning ocean views. Perfect for families and groups seeking a premium vacation experience.",
                ImageUrl = "https://images.unsplash.com/photo-1564013799919-ab600027ffc6",
                IsActive = true,
                Rating = 4.8,
                ReviewCount = 12,
                OwnerId = new Guid("22222222-2222-2222-2222-222222222222"),
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("02222222-2222-2222-2222-222222222222"),
                Name = "Mountain Retreat Cabin",
                Description = "Cozy cabin nestled in the mountains, ideal for nature lovers and those seeking tranquility.",
                ImageUrl = "https://images.unsplash.com/photo-1582268611958-ebfd161ef9cf",
                IsActive = true,
                Rating = 4.6,
                ReviewCount = 8,
                OwnerId = new Guid("33333333-3333-3333-3333-333333333333"),
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("03333333-3333-3333-3333-333333333333"),
                Name = "Urban Luxury Apartment",
                Description = "Modern apartment in the heart of the city with all contemporary amenities.",
                ImageUrl = "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00",
                IsActive = true,
                Rating = 4.9,
                ReviewCount = 15,
                OwnerId = new Guid("44444444-4444-4444-4444-444444444444"),
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("04444444-4444-4444-4444-444444444444"),
                Name = "Countryside Farmhouse",
                Description = "Charming farmhouse surrounded by rolling hills and peaceful countryside.",
                ImageUrl = "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9",
                IsActive = true,
                Rating = 4.3,
                ReviewCount = 6,
                OwnerId = new Guid("22222222-2222-2222-2222-222222222222"),
                CreatedAt = BaseDate.AddDays(-25),
                UpdatedAt = BaseDate.AddDays(-25)
            },
            new
            {
                Id = new Guid("05555555-5555-5555-5555-555555555555"),
                Name = "Lakeside Resort",
                Description = "Resort-style property with direct lake access and recreational facilities.",
                ImageUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d",
                IsActive = true,
                Rating = 4.7,
                ReviewCount = 10,
                OwnerId = new Guid("33333333-3333-3333-3333-333333333333"),
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            }
        };

        modelBuilder.Entity<Property>().HasData(properties);

        // Seed Location value objects
        modelBuilder.Entity<Property>().OwnsOne(p => p.Location).HasData(
            new { PropertyId = properties[0].Id, City = "Miami", Country = "USA", Address = "123 Ocean Drive", PostalCode = "33139" },
            new { PropertyId = properties[1].Id, City = "Aspen", Country = "USA", Address = "456 Mountain Road", PostalCode = "81611" },
            new { PropertyId = properties[2].Id, City = "New York", Country = "USA", Address = "789 Broadway", PostalCode = "10003" },
            new { PropertyId = properties[3].Id, City = "Tuscany", Country = "Italy", Address = "321 Via Roma", PostalCode = "50100" },
            new { PropertyId = properties[4].Id, City = "Lake Tahoe", Country = "USA", Address = "654 Lakeshore Blvd", PostalCode = "96150" }
        );

        // Seed GeoLocation sub-value objects
        modelBuilder.Entity<Property>().OwnsOne(p => p.Location).OwnsOne(l => l.GeoLocation).HasData(
            new { LocationPropertyId = properties[0].Id, Latitude = 25.7617, Longitude = -80.1918 },
            new { LocationPropertyId = properties[1].Id, Latitude = 39.1911, Longitude = -106.8175 },
            new { LocationPropertyId = properties[2].Id, Latitude = 40.7128, Longitude = -74.0060 },
            new { LocationPropertyId = properties[3].Id, Latitude = 43.7696, Longitude = 11.2558 },
            new { LocationPropertyId = properties[4].Id, Latitude = 39.0968, Longitude = -120.0324 }
        );

        // Seed PropertyType value objects
        modelBuilder.Entity<Property>().OwnsOne(p => p.PropertyType).HasData(
            new { PropertyId = properties[0].Id, Name = "Villa", Description = "Luxury beachfront villa", Category = PropertyCategory.Villa },
            new { PropertyId = properties[1].Id, Name = "Cabin", Description = "Mountain retreat cabin", Category = PropertyCategory.Cabin },
            new { PropertyId = properties[2].Id, Name = "Apartment", Description = "Urban luxury apartment", Category = PropertyCategory.Apartment },
            new { PropertyId = properties[3].Id, Name = "Farmhouse", Description = "Countryside farmhouse", Category = PropertyCategory.House },
            new { PropertyId = properties[4].Id, Name = "Resort", Description = "Lakeside resort", Category = PropertyCategory.Resort }
        );
    }

    private static void SeedRooms(ModelBuilder modelBuilder)
    {
        var rooms = new[]
        {
            // Sunset Beach Villa rooms
            new
            {
                Id = new Guid("01111111-1111-1111-1111-111111111112"),
                Number = "101",
                Name = "Ocean View Master Suite",
                Description = "Spacious master bedroom with panoramic ocean views",
                PropertyId = new Guid("01111111-1111-1111-1111-111111111111"),
                MaxOccupancy = 2,
                Size = 45,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("02222222-2222-2222-2222-222222222223"),
                Number = "102",
                Name = "Garden View Suite",
                Description = "Comfortable suite overlooking the tropical gardens",
                PropertyId = new Guid("01111111-1111-1111-1111-111111111111"),
                MaxOccupancy = 2,
                Size = 40,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            // Mountain Retreat Cabin rooms
            new
            {
                Id = new Guid("03333333-3333-3333-3333-333333333334"),
                Number = "201",
                Name = "Mountain View Loft",
                Description = "Rustic loft with breathtaking mountain views",
                PropertyId = new Guid("02222222-2222-2222-2222-222222222222"),
                MaxOccupancy = 4,
                Size = 55,
                IsActive = true,
                IsRefundable = false,
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("04444444-4444-4444-4444-444444444445"),
                Number = "202",
                Name = "Forest Side Room",
                Description = "Cozy room with forest views and fireplace",
                PropertyId = new Guid("02222222-2222-2222-2222-222222222222"),
                MaxOccupancy = 2,
                Size = 30,
                IsActive = true,
                IsRefundable = false,
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            // Urban Luxury Apartment rooms
            new
            {
                Id = new Guid("05555555-5555-5555-5555-555555555556"),
                Number = "301",
                Name = "City View Penthouse",
                Description = "Luxurious penthouse with city skyline views",
                PropertyId = new Guid("03333333-3333-3333-3333-333333333333"),
                MaxOccupancy = 4,
                Size = 85,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            // Countryside Farmhouse rooms
            new
            {
                Id = new Guid("06666666-6666-6666-6666-666666666667"),
                Number = "401",
                Name = "Countryside Master",
                Description = "Spacious master bedroom with countryside views",
                PropertyId = new Guid("04444444-4444-4444-4444-444444444444"),
                MaxOccupancy = 2,
                Size = 50,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-25),
                UpdatedAt = BaseDate.AddDays(-25)
            },
            new
            {
                Id = new Guid("07777777-7777-7777-7777-777777777778"),
                Number = "402",
                Name = "Rustic Twin Room",
                Description = "Charming twin room with rustic décor",
                PropertyId = new Guid("04444444-4444-4444-4444-444444444444"),
                MaxOccupancy = 2,
                Size = 35,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-25),
                UpdatedAt = BaseDate.AddDays(-25)
            },
            // Lakeside Resort rooms
            new
            {
                Id = new Guid("08888888-8888-8888-8888-888888888889"),
                Number = "501",
                Name = "Lake View Suite",
                Description = "Premium suite with direct lake access",
                PropertyId = new Guid("05555555-5555-5555-5555-555555555555"),
                MaxOccupancy = 3,
                Size = 60,
                IsActive = true,
                IsRefundable = true,
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            }
        };

        modelBuilder.Entity<Room>().HasData(rooms);

        // Seed RoomType value objects
        modelBuilder.Entity<Room>().OwnsOne(r => r.RoomType).HasData(
            new { RoomId = rooms[0].Id, Name = "Master Suite", Description = "Luxury master suite", MaxOccupancy = 2 },
            new { RoomId = rooms[1].Id, Name = "Suite", Description = "Comfortable suite", MaxOccupancy = 2 },
            new { RoomId = rooms[2].Id, Name = "Loft", Description = "Mountain loft", MaxOccupancy = 4 },
            new { RoomId = rooms[3].Id, Name = "Standard Room", Description = "Cozy standard room", MaxOccupancy = 2 },
            new { RoomId = rooms[4].Id, Name = "Penthouse", Description = "Luxury penthouse", MaxOccupancy = 4 },
            new { RoomId = rooms[5].Id, Name = "Master Bedroom", Description = "Spacious master bedroom", MaxOccupancy = 2 },
            new { RoomId = rooms[6].Id, Name = "Twin Room", Description = "Twin bed room", MaxOccupancy = 2 },
            new { RoomId = rooms[7].Id, Name = "Suite", Description = "Lake view suite", MaxOccupancy = 3 }
        );

        // Seed Money value objects for PricePerNight
        modelBuilder.Entity<Room>().OwnsOne(r => r.PricePerNight).HasData(
            new { RoomId = rooms[0].Id, Amount = 350.00m, Currency = "USD" },
            new { RoomId = rooms[1].Id, Amount = 280.00m, Currency = "USD" },
            new { RoomId = rooms[2].Id, Amount = 220.00m, Currency = "USD" },
            new { RoomId = rooms[3].Id, Amount = 180.00m, Currency = "USD" },
            new { RoomId = rooms[4].Id, Amount = 500.00m, Currency = "USD" },
            new { RoomId = rooms[5].Id, Amount = 150.00m, Currency = "USD" },
            new { RoomId = rooms[6].Id, Amount = 120.00m, Currency = "USD" },
            new { RoomId = rooms[7].Id, Amount = 250.00m, Currency = "USD" }
        );
    }

    private static void SeedImages(ModelBuilder modelBuilder)
    {
        var images = new[]
        {
            // Property images
            new
            {
                Id = new Guid("01111111-1111-1111-1111-11111111111a"),
                Url = "https://images.unsplash.com/photo-1564013799919-ab600027ffc6",
                Alt = "Sunset Beach Villa exterior",
                IsPrimary = true,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 1,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("02222222-2222-2222-2222-22222222222b"),
                Url = "https://images.unsplash.com/photo-1582268611958-ebfd161ef9cf",
                Alt = "Mountain Retreat Cabin exterior",
                IsPrimary = true,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 1,
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("03333333-3333-3333-3333-33333333333c"),
                Url = "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00",
                Alt = "Urban Luxury Apartment exterior",
                IsPrimary = true,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 1,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("04444444-4444-4444-4444-44444444444d"),
                Url = "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9",
                Alt = "Countryside Farmhouse exterior",
                IsPrimary = true,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 1,
                CreatedAt = BaseDate.AddDays(-25),
                UpdatedAt = BaseDate.AddDays(-25)
            },
            new
            {
                Id = new Guid("05555555-5555-5555-5555-55555555555e"),
                Url = "https://images.unsplash.com/photo-1571896349842-33c89424de2d",
                Alt = "Lakeside Resort exterior",
                IsPrimary = true,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 1,
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            },
            // Room images
            new
            {
                Id = new Guid("06666666-6666-6666-6666-66666666666f"),
                Url = "https://images.unsplash.com/photo-1578683010236-d716f9a3f461",
                Alt = "Ocean View Master Suite interior",
                IsPrimary = false,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 2,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("07777777-7777-7777-7777-777777777770"),
                Url = "https://images.unsplash.com/photo-1586023492125-27b2c045efd7",
                Alt = "Garden View Suite interior",
                IsPrimary = false,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 2,
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("08888888-8888-8888-8888-888888888881"),
                Url = "https://images.unsplash.com/photo-1566665797739-1674de7a421a",
                Alt = "Mountain View Loft interior",
                IsPrimary = false,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 2,
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("09999999-9999-9999-9999-999999999992"),
                Url = "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2",
                Alt = "City View Penthouse interior",
                IsPrimary = false,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 2,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("0aaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                Url = "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9",
                Alt = "Lake View Suite interior",
                IsPrimary = false,
                IsMarkedForDeletion = false,
                MarkedForDeletionAt = (DateTime?)null,
                Order = 2,
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            }
        };

        modelBuilder.Entity<Image>().HasData(images);
    }

    private static void SeedReservations(ModelBuilder modelBuilder)
    {
        var reservations = new[]
        {
            new
            {
                Id = new Guid("0e511111-1111-1111-1111-111111111111"),
                ReservationNumber = "RES-2024-001",
                PropertyId = new Guid("01111111-1111-1111-1111-111111111111"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                GuestId = new Guid("55555555-5555-5555-5555-555555555555"),
                NumberOfGuests = 2,
                Status = ReservationStatus.Confirmed,
                SpecialRequests = "Late check-in requested",
                CancellationReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-15),
                UpdatedAt = BaseDate.AddDays(-15)
            },
            new
            {
                Id = new Guid("0e522222-2222-2222-2222-222222222222"),
                ReservationNumber = "RES-2024-002",
                PropertyId = new Guid("02222222-2222-2222-2222-222222222222"),
                RoomId = new Guid("03333333-3333-3333-3333-333333333334"),
                GuestId = new Guid("66666666-6666-6666-6666-666666666666"),
                NumberOfGuests = 3,
                Status = ReservationStatus.Confirmed,
                SpecialRequests = "Need extra towels",
                CancellationReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-12),
                UpdatedAt = BaseDate.AddDays(-12)
            },
            new
            {
                Id = new Guid("0e533333-3333-3333-3333-333333333333"),
                ReservationNumber = "RES-2024-003",
                PropertyId = new Guid("03333333-3333-3333-3333-333333333333"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                GuestId = new Guid("77777777-7777-7777-7777-777777777777"),
                NumberOfGuests = 1,
                Status = ReservationStatus.Completed,
                SpecialRequests = (string?)null,
                CancellationReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-5)
            },
            new
            {
                Id = new Guid("0e544444-4444-4444-4444-444444444444"),
                ReservationNumber = "RES-2024-004",
                PropertyId = new Guid("04444444-4444-4444-4444-444444444444"),
                RoomId = new Guid("06666666-6666-6666-6666-666666666667"),
                GuestId = new Guid("88888888-8888-8888-8888-888888888888"),
                NumberOfGuests = 2,
                Status = ReservationStatus.Cancelled,
                SpecialRequests = (string?)null,
                CancellationReason = "Change of travel plans",
                CreatedAt = BaseDate.AddDays(-8),
                UpdatedAt = BaseDate.AddDays(-3)
            }
        };

        modelBuilder.Entity<Reservation>().HasData(reservations);

        // Seed Period value objects
        modelBuilder.Entity<Reservation>().OwnsOne(r => r.Period).HasData(
            new { ReservationId = reservations[0].Id, CheckInDate = BaseDate.AddDays(10), CheckOutDate = BaseDate.AddDays(15) },
            new { ReservationId = reservations[1].Id, CheckInDate = BaseDate.AddDays(5), CheckOutDate = BaseDate.AddDays(10) },
            new { ReservationId = reservations[2].Id, CheckInDate = BaseDate.AddDays(-25), CheckOutDate = BaseDate.AddDays(-20) },
            new { ReservationId = reservations[3].Id, CheckInDate = BaseDate.AddDays(20), CheckOutDate = BaseDate.AddDays(25) }
        );

        // Seed TotalAmount value objects
        modelBuilder.Entity<Reservation>().OwnsOne(r => r.TotalAmount).HasData(
            new { ReservationId = reservations[0].Id, Amount = 1750.00m, Currency = "USD" },
            new { ReservationId = reservations[1].Id, Amount = 1100.00m, Currency = "USD" },
            new { ReservationId = reservations[2].Id, Amount = 2500.00m, Currency = "USD" },
            new { ReservationId = reservations[3].Id, Amount = 750.00m, Currency = "USD" }
        );
    }

    private static void SeedPayments(ModelBuilder modelBuilder)
    {
        var payments = new[]
        {
            new
            {
                Id = new Guid("0a411111-1111-1111-1111-111111111111"),
                PaymentNumber = "PAY-2024-001",
                ReservationId = new Guid("0e511111-1111-1111-1111-111111111111"),
                Status = PaymentStatus.Completed,
                Method = PaymentMethod.CreditCard,
                TransactionId = "txn_1234567890",
                PaymentGateway = "Stripe",
                FailureReason = (string?)null,
                RefundReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-15),
                UpdatedAt = BaseDate.AddDays(-15)
            },
            new
            {
                Id = new Guid("0a422222-2222-2222-2222-222222222222"),
                PaymentNumber = "PAY-2024-002",
                ReservationId = new Guid("0e522222-2222-2222-2222-222222222222"),
                Status = PaymentStatus.Completed,
                Method = PaymentMethod.PayPal,
                TransactionId = "txn_0987654321",
                PaymentGateway = "PayPal",
                FailureReason = (string?)null,
                RefundReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-12),
                UpdatedAt = BaseDate.AddDays(-12)
            },
            new
            {
                Id = new Guid("0a433333-3333-3333-3333-333333333333"),
                PaymentNumber = "PAY-2024-003",
                ReservationId = new Guid("0e533333-3333-3333-3333-333333333333"),
                Status = PaymentStatus.Completed,
                Method = PaymentMethod.BankTransfer,
                TransactionId = "txn_1122334455",
                PaymentGateway = "Bank",
                FailureReason = (string?)null,
                RefundReason = (string?)null,
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("0a444444-4444-4444-4444-444444444444"),
                PaymentNumber = "PAY-2024-004",
                ReservationId = new Guid("0e544444-4444-4444-4444-444444444444"),
                Status = PaymentStatus.Refunded,
                Method = PaymentMethod.CreditCard,
                TransactionId = "txn_5566778899",
                PaymentGateway = "Stripe",
                FailureReason = (string?)null,
                RefundReason = "Reservation cancelled",
                CreatedAt = BaseDate.AddDays(-8),
                UpdatedAt = BaseDate.AddDays(-3)
            }
        };

        modelBuilder.Entity<Payment>().HasData(payments);

        // Seed Amount value objects
        modelBuilder.Entity<Payment>().OwnsOne(p => p.Amount).HasData(
            new { PaymentId = payments[0].Id, Amount = 1750.00m, Currency = "USD" },
            new { PaymentId = payments[1].Id, Amount = 1100.00m, Currency = "USD" },
            new { PaymentId = payments[2].Id, Amount = 2500.00m, Currency = "USD" },
            new { PaymentId = payments[3].Id, Amount = 750.00m, Currency = "USD" }
        );
    }

    //private static void SeedReviews(ModelBuilder modelBuilder)
    //{
    //    var reviews = new
    //    {
    //        new
    //        {
    //            Id = new Guid("rev11111-1111-1111-1111-111111111111"),
    //            PropertyId = new Guid("01111111-1111-1111-1111-111111111111"),
    //            GuestId = new Guid("77777777-7777-7777-7777-777777777777"),
    //            ReservationId = new Guid("0e533333-3333-3333-3333-333333333333"),
    //            Rating = 5,
    //            Title = "Amazing Ocean View!",
    //            Comment = "The villa exceeded all expectations. The ocean view was breathtaking and the amenities were top-notch.",
    //            IsDeleted = false,
    //            IsInappropriate = false,
    //            DeletedAt = (DateTime?)null,
    //            MarkedInappropriateAt = (DateTime?)null,
    //            CreatedAt = BaseDate.AddDays(-4),
    //            UpdatedAt = BaseDate.AddDays(-4)
    //        },
    //        new
    //        {
    //            Id = new Guid("rev22222-2222-2222-2222-222222222222"),
    //            PropertyId = new Guid("02222222-2222-2222-2222-222222222222"),
    //            GuestId = new Guid("55555555-5555-5555-5555-555555555555"),
    //            ReservationId = (Guid?)null,
    //            Rating = 4,
    //            Title = "Great Mountain Retreat",
    //            Comment = "Perfect location for a peaceful getaway. The cabin was clean and comfortable.",
    //            IsDeleted = false,
    //            IsInappropriate = false,
    //            DeletedAt = (DateTime?)null,
    //            MarkedInappropriateAt = (DateTime?)null,
    //            CreatedAt = BaseDate.AddDays(-7),
    //            UpdatedAt = BaseDate.AddDays(-7)
    //        },
    //        new
    //        {
    //            Id = new Guid("rev33333-3333-3333-3333-333333333333"),
    //            PropertyId = new Guid("03333333-3333-3333-3333-333333333333"),
    //            GuestId = new Guid("66666666-6666-6666-6666-666666666666"),
    //            ReservationId = (Guid?)null,
    //            Rating = 5,
    //            Title = "Luxury in the City",
    //            Comment = "Absolutely stunning apartment with incredible city views. Will definitely book again!",
    //            IsDeleted = false,
    //            IsInappropriate = false,
    //            DeletedAt = (DateTime?)null,
    //            MarkedInappropriateAt = (DateTime?)null,
    //            CreatedAt = BaseDate.AddDays(-2),
    //            UpdatedAt = BaseDate.AddDays(-2)
    //        },
    //        new
    //        {
    //            Id = new Guid("rev44444-4444-4444-4444-444444444444"),
    //            PropertyId = new Guid("04444444-4444-4444-4444-444444444444"),
    //            GuestId = new Guid("88888888-8888-8888-8888-888888888888"),
    //            ReservationId = (Guid?)null,
    //            Rating = 3,
    //            Title = "Nice but Remote",
    //            Comment = "Beautiful farmhouse but quite far from amenities. Good for complete disconnection.",
    //            IsDeleted = false,
    //            IsInappropriate = false,
    //            DeletedAt = (DateTime?)null,
    //            MarkedInappropriateAt = (DateTime?)null,
    //            CreatedAt = BaseDate.AddDays(-6),
    //            UpdatedAt = BaseDate.AddDays(-6)
    //        }
    //    };

    //    modelBuilder.Entity<Review>().HasData(reviews);
    //}

    private static void SeedRoomAmenities(ModelBuilder modelBuilder)
    {
        var roomAmenities = new[]
        {
            // Ocean View Master Suite amenities
            new
            {
                Id = new Guid("0a111111-1111-1111-1111-111111111111"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                AmenityId = new Guid("a1111111-1111-1111-1111-111111111111"), // WiFi
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("0a222222-2222-2222-2222-222222222222"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                AmenityId = new Guid("a2222222-2222-2222-2222-222222222222"), // Air Conditioning
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("0a333333-3333-3333-3333-333333333333"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                AmenityId = new Guid("a7777777-7777-7777-7777-777777777777"), // Balcony
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            // Mountain View Loft amenities
            new
            {
                Id = new Guid("0a444444-4444-4444-4444-444444444445"),
                RoomId = new Guid("03333333-3333-3333-3333-333333333334"),
                AmenityId = new Guid("a1111111-1111-1111-1111-111111111111"), // WiFi
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("0a555555-5555-5555-5555-555555555555"),
                RoomId = new Guid("03333333-3333-3333-3333-333333333334"),
                AmenityId = new Guid("a5555555-5555-5555-5555-555555555555"), // Kitchen
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            // City View Penthouse amenities
            new
            {
                Id = new Guid("0a666666-6666-6666-6666-666666666666"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                AmenityId = new Guid("a1111111-1111-1111-1111-111111111111"), // WiFi
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("0a777777-7777-7777-7777-777777777777"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                AmenityId = new Guid("a2222222-2222-2222-2222-222222222222"), // Air Conditioning
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("0a888888-8888-8888-8888-888888888888"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                AmenityId = new Guid("a6666666-6666-6666-6666-666666666666"), // Gym
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            }
        };

        modelBuilder.Entity<RoomAmenity>().HasData(roomAmenities);
    }

    private static void SeedPropertyImages(ModelBuilder modelBuilder)
    {
        var propertyImages = new[]
        {
            new
            {
                Id = new Guid("01111111-1111-1111-1111-111111111113"),
                PropertyId = new Guid("01111111-1111-1111-1111-111111111111"),
                ImageId = new Guid("01111111-1111-1111-1111-11111111111a"),
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("02222222-2222-2222-2222-222222222224"),
                PropertyId = new Guid("02222222-2222-2222-2222-222222222222"),
                ImageId = new Guid("02222222-2222-2222-2222-22222222222b"),
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("03333333-3333-3333-3333-333333333335"),
                PropertyId = new Guid("03333333-3333-3333-3333-333333333333"),
                ImageId = new Guid("03333333-3333-3333-3333-33333333333c"),
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("04444444-4444-4444-4444-444444444446"),
                PropertyId = new Guid("04444444-4444-4444-4444-444444444444"),
                ImageId = new Guid("04444444-4444-4444-4444-44444444444d"),
                CreatedAt = BaseDate.AddDays(-25),
                UpdatedAt = BaseDate.AddDays(-25)
            },
            new
            {
                Id = new Guid("05555555-5555-5555-5555-555555555557"),
                PropertyId = new Guid("05555555-5555-5555-5555-555555555555"),
                ImageId = new Guid("05555555-5555-5555-5555-55555555555e"),
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            }
        };

        modelBuilder.Entity<PropertyImageV2>().HasData(propertyImages);
    }

    private static void SeedRoomImages(ModelBuilder modelBuilder)
    {
        var roomImages = new[]
        {
            new
            {
                Id = new Guid("01111111-1111-1111-1111-111111111114"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                ImageId = new Guid("06666666-6666-6666-6666-66666666666f"),
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("02222222-2222-2222-2222-222222222225"),
                RoomId = new Guid("02222222-2222-2222-2222-222222222223"),
                ImageId = new Guid("07777777-7777-7777-7777-777777777770"),
                CreatedAt = BaseDate.AddDays(-60),
                UpdatedAt = BaseDate.AddDays(-60)
            },
            new
            {
                Id = new Guid("03333333-3333-3333-3333-333333333336"),
                RoomId = new Guid("03333333-3333-3333-3333-333333333334"),
                ImageId = new Guid("08888888-8888-8888-8888-888888888881"),
                CreatedAt = BaseDate.AddDays(-45),
                UpdatedAt = BaseDate.AddDays(-45)
            },
            new
            {
                Id = new Guid("04444444-4444-4444-4444-444444444447"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                ImageId = new Guid("09999999-9999-9999-9999-999999999992"),
                CreatedAt = BaseDate.AddDays(-30),
                UpdatedAt = BaseDate.AddDays(-30)
            },
            new
            {
                Id = new Guid("05555555-5555-5555-5555-555555555558"),
                RoomId = new Guid("08888888-8888-8888-8888-888888888889"),
                ImageId = new Guid("0aaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                CreatedAt = BaseDate.AddDays(-20),
                UpdatedAt = BaseDate.AddDays(-20)
            }
        };

        modelBuilder.Entity<RoomImageV2>().HasData(roomImages);
    }

    private static void SeedRoomAvailabilities(ModelBuilder modelBuilder)
    {
        var availabilities = new List<object>();
        
        // Generate availability for next 30 days for each room
        var rooms = new[]
        {
            new Guid("01111111-1111-1111-1111-111111111112"),
            new Guid("02222222-2222-2222-2222-222222222223"),
            new Guid("03333333-3333-3333-3333-333333333334"),
            new Guid("04444444-4444-4444-4444-444444444445"),
            new Guid("05555555-5555-5555-5555-555555555556"),
            new Guid("06666666-6666-6666-6666-666666666667"),
            new Guid("07777777-7777-7777-7777-777777777778"),
            new Guid("08888888-8888-8888-8888-888888888889")
        };

        // Predefined availability pattern (80% available)
        var availabilityPattern = new[]
        {
            true, true, true, true, false, true, true, true, true, true,
            true, false, true, true, true, true, true, true, false, true,
            true, true, true, true, true, false, true, true, true, true
        };

        int guidCounter = 1;
        foreach (var roomId in rooms)
        {
            for (int i = 0; i < 30; i++)
            {
                var date = BaseDate.AddDays(i);
                var isAvailable = availabilityPattern[i];

                availabilities.Add(new
                {
                    Id = new Guid($"{guidCounter:D8}-0000-0000-0000-000000000000"),
                    RoomId = roomId,
                    Date = date,
                    IsAvailable = isAvailable,
                    CreatedAt = BaseDate.AddDays(-30),
                    UpdatedAt = BaseDate.AddDays(-30)
                });
                guidCounter++;
            }
        }

        modelBuilder.Entity<RoomAvailability>().HasData(availabilities.ToArray());
    }

    private static void SeedRoomPriceOverrides(ModelBuilder modelBuilder)
    {
        var priceOverrides = new[]
        {
            // Weekend price increases
            new
            {
                Id = new Guid("00111111-1111-1111-1111-111111111111"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                Date = BaseDate.AddDays(7), // Next Saturday
                CreatedAt = BaseDate.AddDays(-1),
                UpdatedAt = BaseDate.AddDays(-1)
            },
            new
            {
                Id = new Guid("00222222-2222-2222-2222-222222222222"),
                RoomId = new Guid("01111111-1111-1111-1111-111111111112"),
                Date = BaseDate.AddDays(8), // Next Sunday
                CreatedAt = BaseDate.AddDays(-1),
                UpdatedAt = BaseDate.AddDays(-1)
            },
            // Holiday pricing
            new
            {
                Id = new Guid("00333333-3333-3333-3333-333333333333"),
                RoomId = new Guid("05555555-5555-5555-5555-555555555556"),
                Date = BaseDate.AddDays(14), // Holiday period
                CreatedAt = BaseDate.AddDays(-1),
                UpdatedAt = BaseDate.AddDays(-1)
            }
        };

        modelBuilder.Entity<RoomPriceOverride>().HasData(priceOverrides);

        // Seed Price value objects for overrides
        modelBuilder.Entity<RoomPriceOverride>().OwnsOne(rpo => rpo.Price).HasData(
            new { RoomPriceOverrideId = priceOverrides[0].Id, Amount = 420.00m, Currency = "USD" }, // 20% increase
            new { RoomPriceOverrideId = priceOverrides[1].Id, Amount = 420.00m, Currency = "USD" }, // 20% increase
            new { RoomPriceOverrideId = priceOverrides[2].Id, Amount = 650.00m, Currency = "USD" }  // 30% increase
        );
    }
}