using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Infrastructure.Data.Migrations
{
    public partial class IsBusyToParkingSpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_busy",
                table: "parking_spots",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_busy",
                table: "parking_spots");
        }
    }
}
