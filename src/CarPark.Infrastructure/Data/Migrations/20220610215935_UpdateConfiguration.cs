using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Infrastructure.Data.Migrations
{
    public partial class UpdateConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reservations_cars_car_id",
                table: "reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "reservation_id",
                table: "parking_spots",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "plate_no",
                table: "cars",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_parkings_car_id",
                table: "parkings",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "ix_cars_plate_no",
                table: "cars",
                column: "plate_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_parkings_car_id",
                table: "parkings");

            migrationBuilder.DropIndex(
                name: "ix_cars_plate_no",
                table: "cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "reservation_id",
                table: "parking_spots",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "plate_no",
                table: "cars",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_cars_car_id",
                table: "reservations",
                column: "car_id",
                principalTable: "cars",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
