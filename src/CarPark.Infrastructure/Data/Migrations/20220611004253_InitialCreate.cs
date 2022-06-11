using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    plate_no = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cars", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parking_spots",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    spot_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    reservation_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    in_process = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    in_process_expire_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parking_spots", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parkings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    car_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    drive_in_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    drive_out_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    parking_spot_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    reservation_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parkings", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    car_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    parking_spot_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    start = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    end = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservations", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    phone_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    other_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "id", "create_date_utc", "delete_date_utc", "plate_no", "update_date_utc", "user_id" },
                values: new object[] { new Guid("111111b4-8f3c-4c93-8556-de4d805fe120"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AGG-23-34", null, new Guid("222222b4-8f3c-4c93-8556-de4d805fe120") });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "id", "create_date_utc", "delete_date_utc", "plate_no", "update_date_utc", "user_id" },
                values: new object[] { new Guid("999999b4-8f3c-4c93-8556-de4d805fe120"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "APP-12-28", null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "create_date_utc", "delete_date_utc", "first_name", "last_name", "other_name", "phone_number", "update_date_utc", "user_type" },
                values: new object[] { new Guid("222222b4-8f3c-4c93-8556-de4d805fe120"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "John", "Doe", "oiu", "23480812212121", null, "" });

            migrationBuilder.CreateIndex(
                name: "ix_cars_plate_no",
                table: "cars",
                column: "plate_no");

            migrationBuilder.CreateIndex(
                name: "ix_parkings_car_id",
                table: "parkings",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "ix_reservations_car_id",
                table: "reservations",
                column: "car_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "parking_spots");

            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
