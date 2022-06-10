using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Infrastructure.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "parking_spots",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    spot_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    reservation_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    car_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    plate_no = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    create_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    update_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    delete_date_utc = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cars", x => x.id);
                    table.ForeignKey(
                        name: "fk_cars_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "fk_reservations_cars_car_id",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_cars_user_id",
                table: "cars",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reservations_car_id",
                table: "reservations",
                column: "car_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parking_spots");

            migrationBuilder.DropTable(
                name: "parkings");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
