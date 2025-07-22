using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseBookingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesWithLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Icon", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "High-speed wireless internet access", "wifi", true, "WiFi", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), 2, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Climate control system", "ac_unit", true, "Air Conditioning", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), 9, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Outdoor swimming pool", "pool", true, "Swimming Pool", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), 10, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Free parking space", "local_parking", true, "Parking", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a5555555-5555-5555-5555-555555555555"), 10, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Fully equipped kitchen", "kitchen", true, "Kitchen", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a6666666-6666-6666-6666-666666666666"), 9, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Fitness center", "fitness_center", true, "Gym", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a7777777-7777-7777-7777-777777777777"), 2, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Private balcony with view", "balcony", true, "Balcony", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a8888888-8888-8888-8888-888888888888"), 10, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Pets allowed", "pets", true, "Pet Friendly", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a9999999-9999-9999-9999-999999999999"), 10, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "In-unit laundry", "local_laundry_service", true, "Washing Machine", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Smart TV with streaming services", "tv", true, "TV", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "IsMarkedForDeletion", "IsPrimary", "MarkedForDeletionAt", "Order", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { new Guid("01111111-1111-1111-1111-11111111111a"), "Sunset Beach Villa exterior", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, true, null, 1, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1564013799919-ab600027ffc6" },
                    { new Guid("02222222-2222-2222-2222-22222222222b"), "Mountain Retreat Cabin exterior", new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), false, true, null, 1, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1582268611958-ebfd161ef9cf" },
                    { new Guid("03333333-3333-3333-3333-33333333333c"), "Urban Luxury Apartment exterior", new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, true, null, 1, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00" },
                    { new Guid("04444444-4444-4444-4444-44444444444d"), "Countryside Farmhouse exterior", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, true, null, 1, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9" },
                    { new Guid("05555555-5555-5555-5555-55555555555e"), "Lakeside Resort exterior", new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, true, null, 1, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1571896349842-33c89424de2d" },
                    { new Guid("06666666-6666-6666-6666-66666666666f"), "Ocean View Master Suite interior", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, false, null, 2, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1578683010236-d716f9a3f461" },
                    { new Guid("07777777-7777-7777-7777-777777777770"), "Garden View Suite interior", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, false, null, 2, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1586023492125-27b2c045efd7" },
                    { new Guid("08888888-8888-8888-8888-888888888881"), "Mountain View Loft interior", new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), false, false, null, 2, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1566665797739-1674de7a421a" },
                    { new Guid("09999999-9999-9999-9999-999999999992"), "City View Penthouse interior", new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), false, false, null, 2, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2" },
                    { new Guid("0aaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), "Lake View Suite interior", new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, false, null, 2, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "EmailVerificationToken", "EmailVerificationTokenExpiry", "FirstName", "IsActive", "IsEmailVerified", "LastLoginAt", "LastName", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), "admin@housebooking.com", null, null, "John", true, true, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Admin", "hashed_admin_password", 3, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "sarah.johnson@example.com", null, null, "Sarah", true, true, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Johnson", "hashed_owner_password", 2, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "michael.davis@example.com", null, null, "Michael", true, true, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Davis", "hashed_owner_password", 2, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "emma.wilson@example.com", null, null, "Emma", true, true, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Wilson", "hashed_owner_password", 2, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "david.brown@example.com", null, null, "David", true, true, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Brown", "hashed_guest_password", 1, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "lisa.anderson@example.com", null, null, "Lisa", true, true, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Anderson", "hashed_guest_password", 1, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), "robert.taylor@example.com", null, null, "Robert", true, true, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Taylor", "hashed_guest_password", 1, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), "jennifer.martinez@example.com", null, null, "Jennifer", true, true, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Martinez", "hashed_guest_password", 1, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "OwnerId", "Rating", "ReviewCount", "UpdatedAt", "Location_Address", "Location_City", "Location_Country", "Location_PostalCode", "Location_GeoLocation_Latitude", "Location_GeoLocation_Longitude", "PropertyType_Category", "PropertyType_Description", "PropertyType_Name" },
                values: new object[,]
                {
                    { new Guid("01111111-1111-1111-1111-111111111111"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Luxurious beachfront villa with stunning ocean views. Perfect for families and groups seeking a premium vacation experience.", "https://images.unsplash.com/photo-1564013799919-ab600027ffc6", true, "Sunset Beach Villa", new Guid("22222222-2222-2222-2222-222222222222"), 4.7999999999999998, 12, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "123 Ocean Drive", "Miami", "USA", "33139", 25.761700000000001, -80.191800000000001, 8, "Luxury beachfront villa", "Villa" },
                    { new Guid("02222222-2222-2222-2222-222222222222"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy cabin nestled in the mountains, ideal for nature lovers and those seeking tranquility.", "https://images.unsplash.com/photo-1582268611958-ebfd161ef9cf", true, "Mountain Retreat Cabin", new Guid("33333333-3333-3333-3333-333333333333"), 4.5999999999999996, 8, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "456 Mountain Road", "Aspen", "USA", "81611", 39.191099999999999, -106.8175, 9, "Mountain retreat cabin", "Cabin" },
                    { new Guid("03333333-3333-3333-3333-333333333333"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Modern apartment in the heart of the city with all contemporary amenities.", "https://images.unsplash.com/photo-1545324418-cc1a3fa10c00", true, "Urban Luxury Apartment", new Guid("44444444-4444-4444-4444-444444444444"), 4.9000000000000004, 15, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "789 Broadway", "New York", "USA", "10003", 40.748399999999997, -73.985699999999994, 2, "Urban luxury apartment", "Apartment" },
                    { new Guid("04444444-4444-4444-4444-444444444444"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Charming farmhouse surrounded by rolling hills and peaceful countryside.", "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9", true, "Countryside Farmhouse", new Guid("22222222-2222-2222-2222-222222222222"), 4.2999999999999998, 6, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "321 Via Roma", "Tuscany", "Italy", "50100", 43.769599999999997, 11.255800000000001, 3, "Countryside farmhouse", "Farmhouse" },
                    { new Guid("05555555-5555-5555-5555-555555555555"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Resort-style property with direct lake access and recreational facilities.", "https://images.unsplash.com/photo-1571896349842-33c89424de2d", true, "Lakeside Resort", new Guid("33333333-3333-3333-3333-333333333333"), 4.7000000000000002, 10, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "654 Lakeshore Blvd", "Lake Tahoe", "USA", "96150", 39.096800000000002, -120.0324, 4, "Lakeside resort", "Resort" },
                    { new Guid("06666666-6666-6666-6666-666666666666"), new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant apartment in the heart of Paris, walking distance to Eiffel Tower.", "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688", true, "Paris City Center Apartment", new Guid("44444444-4444-4444-4444-444444444444"), 4.7999999999999998, 20, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "789 Avenue des Champs-Élysées", "Paris", "France", "75008", 48.8566, 2.3521999999999998, 2, "City center apartment", "Apartment" },
                    { new Guid("07777777-7777-7777-7777-777777777777"), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Contemporary loft in Shibuya district with stunning city views.", "https://images.unsplash.com/photo-1586023492125-27b2c045efd7", true, "Tokyo Modern Loft", new Guid("22222222-2222-2222-2222-222222222222"), 4.5, 12, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), "1-2-3 Shibuya", "Tokyo", "Japan", "150-0002", 35.676200000000001, 139.65029999999999, 2, "Modern urban loft", "Loft" },
                    { new Guid("08888888-8888-8888-8888-888888888888"), new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), "Luxury villa with stunning Bosphorus views and private garden.", "https://images.unsplash.com/photo-1564013799919-ab600027ffc6", true, "Istanbul Bosphorus Villa", new Guid("33333333-3333-3333-3333-333333333333"), 4.9000000000000004, 18, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), "456 Bosphorus Caddesi", "Istanbul", "Turkey", "34349", 41.008200000000002, 28.978400000000001, 8, "Luxury Bosphorus villa", "Villa" },
                    { new Guid("09999999-9999-9999-9999-999999999999"), new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Spectacular penthouse with panoramic harbour views and modern amenities.", "https://images.unsplash.com/photo-1613977257363-707ba9348227", true, "Sydney Harbour Penthouse", new Guid("44444444-4444-4444-4444-444444444444"), 4.5999999999999996, 14, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), "123 Harbour Bridge Road", "Sydney", "Australia", "2000", -33.8688, 151.20930000000001, 2, "Harbour view penthouse", "Penthouse" }
                });

            // PropertyImagesV2 seed data removed

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "IsRefundable", "MaxOccupancy", "Name", "Number", "PropertyId", "Size", "UpdatedAt", "PricePerNight_Amount", "PricePerNight_Currency", "RoomType_Description", "RoomType_MaxOccupancy", "RoomType_Name" },
                values: new object[,]
                {
                    { new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Spacious master bedroom with panoramic ocean views", true, true, 2, "Ocean View Master Suite", "101", new Guid("01111111-1111-1111-1111-111111111111"), 45, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), 350.00m, "USD", "Luxury master suite", 2, "Master Suite" },
                    { new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable suite overlooking the tropical gardens", true, true, 2, "Garden View Suite", "102", new Guid("01111111-1111-1111-1111-111111111111"), 40, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), 280.00m, "USD", "Comfortable suite", 2, "Suite" },
                    { new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Rustic loft with breathtaking mountain views", true, false, 4, "Mountain View Loft", "201", new Guid("02222222-2222-2222-2222-222222222222"), 55, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), 220.00m, "USD", "Mountain loft", 4, "Loft" },
                    { new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Cozy room with forest views and fireplace", true, false, 2, "Forest Side Room", "202", new Guid("02222222-2222-2222-2222-222222222222"), 30, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), 180.00m, "USD", "Cozy standard room", 2, "Standard Room" },
                    { new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Luxurious penthouse with city skyline views", true, true, 4, "City View Penthouse", "301", new Guid("03333333-3333-3333-3333-333333333333"), 85, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), 500.00m, "USD", "Luxury penthouse", 4, "Penthouse" },
                    { new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Spacious master bedroom with countryside views", true, true, 2, "Countryside Master", "401", new Guid("04444444-4444-4444-4444-444444444444"), 50, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), 150.00m, "USD", "Spacious master bedroom", 2, "Master Bedroom" },
                    { new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Charming twin room with rustic décor", true, true, 2, "Rustic Twin Room", "402", new Guid("04444444-4444-4444-4444-444444444444"), 35, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), 120.00m, "USD", "Twin bed room", 2, "Twin Room" },
                    { new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Premium suite with direct lake access", true, true, 3, "Lake View Suite", "501", new Guid("05555555-5555-5555-5555-555555555555"), 60, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), 250.00m, "USD", "Lake view suite", 3, "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CancellationDate", "CancellationReason", "CheckInTime", "CheckOutTime", "CreatedAt", "GuestId", "NumberOfGuests", "PropertyId", "ReservationNumber", "RoomId", "SpecialRequests", "Status", "UpdatedAt", "Period_CheckInDate", "Period_CheckOutDate", "TotalAmount_Amount", "TotalAmount_Currency" },
                values: new object[,]
                {
                    { new Guid("0e511111-1111-1111-1111-111111111111"), null, null, null, null, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("55555555-5555-5555-5555-555555555555"), 2, new Guid("01111111-1111-1111-1111-111111111111"), "RES-2024-001", new Guid("01111111-1111-1111-1111-111111111112"), "Late check-in requested", 2, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 1750.00m, "USD" },
                    { new Guid("0e522222-2222-2222-2222-222222222222"), null, null, null, null, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("66666666-6666-6666-6666-666666666666"), 3, new Guid("02222222-2222-2222-2222-222222222222"), "RES-2024-002", new Guid("03333333-3333-3333-3333-333333333334"), "Need extra towels", 2, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), 1100.00m, "USD" },
                    { new Guid("0e533333-3333-3333-3333-333333333333"), null, null, null, null, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("77777777-7777-7777-7777-777777777777"), 1, new Guid("03333333-3333-3333-3333-333333333333"), "RES-2024-003", new Guid("05555555-5555-5555-5555-555555555556"), null, 5, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2500.00m, "USD" },
                    { new Guid("0e544444-4444-4444-4444-444444444444"), null, "Change of travel plans", null, null, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("88888888-8888-8888-8888-888888888888"), 2, new Guid("04444444-4444-4444-4444-444444444444"), "RES-2024-004", new Guid("06666666-6666-6666-6666-666666666667"), null, 6, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), 750.00m, "USD" }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "Id", "AmenityId", "CreatedAt", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a222222-2222-2222-2222-222222222222"), new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a333333-3333-3333-3333-333333333333"), new Guid("a7777777-7777-7777-7777-777777777777"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a444444-4444-4444-4444-444444444445"), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a555555-5555-5555-5555-555555555555"), new Guid("a5555555-5555-5555-5555-555555555555"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a666666-6666-6666-6666-666666666666"), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a777777-7777-7777-7777-777777777777"), new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("0a888888-8888-8888-8888-888888888888"), new Guid("a6666666-6666-6666-6666-666666666666"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "RoomAvailabilities",
                columns: new[] { "Id", "CreatedAt", "Date", "IsAvailable", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000002-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000003-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000004-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000005-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000006-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000007-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000008-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000009-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000010-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000011-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000012-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000013-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000014-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000015-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000016-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000017-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000018-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000019-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000020-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000021-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000022-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000023-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000024-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000025-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000026-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000027-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000028-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000029-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000030-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000031-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000032-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000033-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000034-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000035-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000036-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000037-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000038-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000039-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000040-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000041-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000042-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000043-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000044-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000045-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000046-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000047-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000048-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000049-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000050-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000051-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000052-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000053-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000054-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000055-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000056-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000057-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000058-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000059-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000060-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("02222222-2222-2222-2222-222222222223"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000061-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000062-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000063-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000064-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000065-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000066-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000067-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000068-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000069-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000070-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000071-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000072-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000073-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000074-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000075-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000076-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000077-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000078-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000079-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000080-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000081-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000082-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000083-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000084-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000085-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000086-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000087-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000088-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000089-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000090-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("03333333-3333-3333-3333-333333333334"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000091-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000092-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000093-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000094-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000095-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000096-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000097-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000098-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000099-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000100-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000101-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000102-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000103-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000104-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000105-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000106-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000107-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000108-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000109-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000110-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000111-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000112-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000113-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000114-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000115-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000116-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000117-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000118-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000119-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000120-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("04444444-4444-4444-4444-444444444445"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000121-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000122-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000123-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000124-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000125-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000126-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000127-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000128-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000129-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000130-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000131-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000132-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000133-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000134-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000135-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000136-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000137-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000138-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000139-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000140-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000141-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000142-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000143-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000144-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000145-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000146-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000147-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000148-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000149-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000150-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000151-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000152-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000153-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000154-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000155-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000156-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000157-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000158-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000159-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000160-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000161-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000162-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000163-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000164-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000165-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000166-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000167-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000168-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000169-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000170-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000171-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000172-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000173-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000174-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000175-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000176-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000177-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000178-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000179-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000180-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("06666666-6666-6666-6666-666666666667"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000181-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000182-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000183-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000184-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000185-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000186-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000187-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000188-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000189-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000190-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000191-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000192-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000193-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000194-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000195-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000196-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000197-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000198-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000199-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000200-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000201-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000202-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000203-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000204-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000205-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000206-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000207-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000208-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000209-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000210-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("07777777-7777-7777-7777-777777777778"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000211-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000212-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000213-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000214-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000215-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000216-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000217-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000218-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000219-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000220-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000221-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000222-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000223-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000224-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000225-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000226-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000227-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000228-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000229-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000230-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000231-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000232-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000233-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000234-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000235-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000236-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000237-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000238-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000239-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("00000240-0000-0000-0000-000000000000"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("08888888-8888-8888-8888-888888888889"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            // RoomImagesV2 seed data removed

            migrationBuilder.InsertData(
                table: "RoomPriceOverrides",
                columns: new[] { "Id", "CreatedAt", "Date", "RoomId", "UpdatedAt", "Price_Amount", "Price_Currency" },
                values: new object[,]
                {
                    { new Guid("00111111-1111-1111-1111-111111111111"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), 420.00m, "USD" },
                    { new Guid("00222222-2222-2222-2222-222222222222"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("01111111-1111-1111-1111-111111111112"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), 420.00m, "USD" },
                    { new Guid("00333333-3333-3333-3333-333333333333"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("05555555-5555-5555-5555-555555555556"), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), 650.00m, "USD" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "FailureReason", "Method", "PaymentGateway", "PaymentNumber", "ProcessedAt", "RefundReason", "RefundedAt", "ReservationId", "Status", "TransactionId", "UpdatedAt", "Amount_Amount", "Amount_Currency" },
                values: new object[,]
                {
                    { new Guid("0a411111-1111-1111-1111-111111111111"), new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, "Stripe", "PAY-2024-001", null, null, null, new Guid("0e511111-1111-1111-1111-111111111111"), 2, "txn_1234567890", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1750.00m, "USD" },
                    { new Guid("0a422222-2222-2222-2222-222222222222"), new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, 3, "PayPal", "PAY-2024-002", null, null, null, new Guid("0e522222-2222-2222-2222-222222222222"), 2, "txn_0987654321", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1100.00m, "USD" },
                    { new Guid("0a433333-3333-3333-3333-333333333333"), new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), null, 4, "Bank", "PAY-2024-003", null, null, null, new Guid("0e533333-3333-3333-3333-333333333333"), 2, "txn_1122334455", new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2500.00m, "USD" },
                    { new Guid("0a444444-4444-4444-4444-444444444444"), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, 1, "Stripe", "PAY-2024-004", null, "Reservation cancelled", null, new Guid("0e544444-4444-4444-4444-444444444444"), 4, "txn_5566778899", new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), 750.00m, "USD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a8888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a9999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0a411111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0a422222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0a433333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("0a444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("06666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("07777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("08888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("09999999-9999-9999-9999-999999999999"));

            // PropertyImagesV2 delete operations removed

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a444444-4444-4444-4444-444444444445"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumn: "Id",
                keyValue: new Guid("0a888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000008-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000011-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000012-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000013-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000014-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000015-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000016-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000017-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000018-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000019-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000021-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000022-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000023-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000024-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000025-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000026-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000027-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000028-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000029-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000031-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000032-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000033-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000034-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000035-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000036-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000037-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000038-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000039-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000041-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000042-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000043-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000044-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000045-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000046-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000047-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000048-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000049-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000051-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000052-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000053-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000054-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000055-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000056-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000057-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000058-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000059-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000061-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000062-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000063-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000064-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000065-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000066-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000067-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000068-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000069-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000071-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000072-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000073-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000074-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000075-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000076-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000077-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000078-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000079-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000081-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000082-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000083-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000084-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000085-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000086-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000087-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000088-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000089-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000091-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000092-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000093-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000094-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000095-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000096-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000097-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000098-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000099-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000101-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000102-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000103-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000104-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000105-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000106-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000107-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000108-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000109-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000110-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000111-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000112-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000113-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000114-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000115-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000116-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000117-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000118-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000119-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000120-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000121-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000122-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000123-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000124-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000125-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000126-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000127-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000128-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000129-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000130-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000131-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000132-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000133-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000134-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000135-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000136-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000137-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000138-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000139-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000140-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000141-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000142-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000143-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000144-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000145-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000146-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000147-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000148-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000149-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000150-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000151-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000152-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000153-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000154-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000155-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000156-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000157-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000158-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000159-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000160-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000161-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000162-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000163-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000164-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000165-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000166-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000167-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000168-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000169-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000170-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000171-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000172-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000173-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000174-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000175-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000176-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000177-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000178-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000179-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000180-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000181-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000182-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000183-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000184-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000185-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000186-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000187-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000188-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000189-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000190-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000191-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000192-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000193-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000194-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000195-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000196-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000197-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000198-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000199-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000200-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000201-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000202-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000203-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000204-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000205-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000206-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000207-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000208-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000209-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000210-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000211-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000212-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000213-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000214-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000215-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000216-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000217-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000218-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000219-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000220-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000221-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000222-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000223-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000224-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000225-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000226-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000227-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000228-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000229-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000230-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000231-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000232-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000233-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000234-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000235-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000236-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000237-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000238-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000239-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "RoomAvailabilities",
                keyColumn: "Id",
                keyValue: new Guid("00000240-0000-0000-0000-000000000000"));

            // RoomImagesV2 delete operations removed

            migrationBuilder.DeleteData(
                table: "RoomPriceOverrides",
                keyColumn: "Id",
                keyValue: new Guid("00111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "RoomPriceOverrides",
                keyColumn: "Id",
                keyValue: new Guid("00222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RoomPriceOverrides",
                keyColumn: "Id",
                keyValue: new Guid("00333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: new Guid("a7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("01111111-1111-1111-1111-11111111111a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("02222222-2222-2222-2222-22222222222b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("03333333-3333-3333-3333-33333333333c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("04444444-4444-4444-4444-44444444444d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("05555555-5555-5555-5555-55555555555e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("06666666-6666-6666-6666-66666666666f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("07777777-7777-7777-7777-777777777770"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("08888888-8888-8888-8888-888888888881"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("09999999-9999-9999-9999-999999999992"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("0aaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0e511111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0e522222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0e533333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0e544444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("02222222-2222-2222-2222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("04444444-4444-4444-4444-444444444445"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("07777777-7777-7777-7777-777777777778"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("08888888-8888-8888-8888-888888888889"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("05555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("01111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("03333333-3333-3333-3333-333333333334"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("05555555-5555-5555-5555-555555555556"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("06666666-6666-6666-6666-666666666667"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("01111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("02222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("03333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("04444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));
        }
    }
}
