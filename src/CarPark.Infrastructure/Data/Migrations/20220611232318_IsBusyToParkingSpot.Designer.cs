﻿// <auto-generated />
using System;
using CarPark.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarPark.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CarParkDbContext))]
    [Migration("20220611232318_IsBusyToParkingSpot")]
    partial class IsBusyToParkingSpot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarPark.Core.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_date_utc");

                    b.Property<DateTimeOffset?>("DeleteDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("delete_date_utc");

                    b.Property<string>("PlateNo")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("plate_no");

                    b.Property<DateTimeOffset?>("UpdateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_date_utc");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_cars");

                    b.HasIndex("PlateNo")
                        .HasDatabaseName("ix_cars_plate_no");

                    b.ToTable("cars", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("111111b4-8f3c-4c93-8556-de4d805fe120"),
                            CreateDateUtc = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PlateNo = "AGG-23-34",
                            UserId = new Guid("222222b4-8f3c-4c93-8556-de4d805fe120")
                        },
                        new
                        {
                            Id = new Guid("999999b4-8f3c-4c93-8556-de4d805fe120"),
                            CreateDateUtc = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PlateNo = "APP-12-28",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("CarPark.Core.Entities.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<Guid>("CarId")
                        .HasColumnType("char(36)")
                        .HasColumnName("car_id");

                    b.Property<DateTimeOffset>("CreateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_date_utc");

                    b.Property<DateTimeOffset?>("DeleteDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("delete_date_utc");

                    b.Property<DateTimeOffset>("DriveInAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("drive_in_at");

                    b.Property<DateTimeOffset>("DriveOutAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("drive_out_at");

                    b.Property<Guid>("ParkingSpotId")
                        .HasColumnType("char(36)")
                        .HasColumnName("parking_spot_id");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("char(36)")
                        .HasColumnName("reservation_id");

                    b.Property<DateTimeOffset?>("UpdateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_date_utc");

                    b.HasKey("Id")
                        .HasName("pk_parkings");

                    b.HasIndex("CarId")
                        .HasDatabaseName("ix_parkings_car_id");

                    b.ToTable("parkings", (string)null);
                });

            modelBuilder.Entity("CarPark.Core.Entities.ParkingSpot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_date_utc");

                    b.Property<DateTimeOffset?>("DeleteDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("delete_date_utc");

                    b.Property<bool>("InProcess")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("in_process");

                    b.Property<DateTimeOffset>("InProcessExpireAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("in_process_expire_at");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_busy");

                    b.Property<Guid?>("ReservationId")
                        .HasColumnType("char(36)")
                        .HasColumnName("reservation_id");

                    b.Property<string>("SpotName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("spot_name");

                    b.Property<DateTimeOffset?>("UpdateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_date_utc");

                    b.HasKey("Id")
                        .HasName("pk_parking_spots");

                    b.ToTable("parking_spots", (string)null);
                });

            modelBuilder.Entity("CarPark.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("CarId")
                        .HasColumnType("char(36)")
                        .HasColumnName("car_id");

                    b.Property<DateTimeOffset>("CreateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_date_utc");

                    b.Property<DateTimeOffset?>("DeleteDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("delete_date_utc");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end");

                    b.Property<Guid?>("ParkingSpotId")
                        .HasColumnType("char(36)")
                        .HasColumnName("parking_spot_id");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_date_utc");

                    b.HasKey("Id")
                        .HasName("pk_reservations");

                    b.HasIndex("CarId")
                        .HasDatabaseName("ix_reservations_car_id");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("CarPark.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_date_utc");

                    b.Property<DateTimeOffset?>("DeleteDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("delete_date_utc");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("OtherName")
                        .HasColumnType("longtext")
                        .HasColumnName("other_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.Property<DateTimeOffset?>("UpdateDateUtc")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_date_utc");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_type");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("222222b4-8f3c-4c93-8556-de4d805fe120"),
                            CreateDateUtc = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "John",
                            LastName = "Doe",
                            OtherName = "oiu",
                            PhoneNumber = "23480812212121",
                            UserType = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}