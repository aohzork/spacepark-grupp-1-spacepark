﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceParkAPI.Db_Context;

namespace SpaceParkAPI.Migrations
{
    [DbContext(typeof(SpaceParkContext))]
    partial class SpaceParkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("SpaceParkAPI.Models.ParkingLotModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("TotalAmount")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("ParkingLots");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            TotalAmount = 15L
                        },
                        new
                        {
                            ID = 2L,
                            TotalAmount = 14L
                        });
                });

            modelBuilder.Entity("SpaceParkAPI.Models.ParkingSpaceModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ParkingLotID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ParkingLotID");

                    b.ToTable("ParkingSpaces");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            ParkingLotID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            ParkingLotID = 1L
                        });
                });

            modelBuilder.Entity("SpaceParkAPI.Models.PersonModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SpaceshipID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("SpaceshipID")
                        .IsUnique();

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "sebastian",
                            SpaceshipID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            Name = "Eric",
                            SpaceshipID = 2L
                        });
                });

            modelBuilder.Entity("SpaceParkAPI.Models.SpaceshipModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ParkingSpaceID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ParkingSpaceID")
                        .IsUnique();

                    b.ToTable("Spaceships");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            ParkingSpaceID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            ParkingSpaceID = 2L
                        });
                });

            modelBuilder.Entity("SpaceParkAPI.Models.ParkingSpaceModel", b =>
                {
                    b.HasOne("SpaceParkAPI.Models.ParkingLotModel", "ParkingLot")
                        .WithMany("ParkingSpaces")
                        .HasForeignKey("ParkingLotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("SpaceParkAPI.Models.PersonModel", b =>
                {
                    b.HasOne("SpaceParkAPI.Models.SpaceshipModel", "Spaceship")
                        .WithOne("Person")
                        .HasForeignKey("SpaceParkAPI.Models.PersonModel", "SpaceshipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spaceship");
                });

            modelBuilder.Entity("SpaceParkAPI.Models.SpaceshipModel", b =>
                {
                    b.HasOne("SpaceParkAPI.Models.ParkingSpaceModel", "ParkingSpace")
                        .WithOne("Spaceship")
                        .HasForeignKey("SpaceParkAPI.Models.SpaceshipModel", "ParkingSpaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpace");
                });

            modelBuilder.Entity("SpaceParkAPI.Models.ParkingLotModel", b =>
                {
                    b.Navigation("ParkingSpaces");
                });

            modelBuilder.Entity("SpaceParkAPI.Models.ParkingSpaceModel", b =>
                {
                    b.Navigation("Spaceship");
                });

            modelBuilder.Entity("SpaceParkAPI.Models.SpaceshipModel", b =>
                {
                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
