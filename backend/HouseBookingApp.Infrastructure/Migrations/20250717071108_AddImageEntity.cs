using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBookingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    IsMarkedForDeletion = table.Column<bool>(type: "boolean", nullable: false),
                    MarkedForDeletionAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Alt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            // PropertyImagesV2 table creation removed

            // RoomImagesV2 table creation removed

            // V2 indexes removed
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // V2 table drops removed

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
