﻿// <auto-generated />
using System;
using Home.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Home.Api.Migrations
{
    [DbContext(typeof(HomeDbContext))]
    partial class HomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Home.Api.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Home.Api.Door", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ColorId");

                    b.Property<int>("Height");

                    b.Property<Guid>("RoomId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("ColorId")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("Home.Api.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ColorId");

                    b.Property<Guid>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("ColorId")
                        .IsUnique();

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("Home.Api.Home", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("Home.Api.LightBulb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RoomId");

                    b.Property<string>("Size");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("LightBulbs");
                });

            modelBuilder.Entity("Home.Api.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Height");

                    b.Property<Guid>("HomeId");

                    b.Property<int>("Length");

                    b.Property<string>("Name");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Home.Api.Window", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ColorId");

                    b.Property<int>("Height");

                    b.Property<Guid>("RoomId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("ColorId")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("Windows");
                });

            modelBuilder.Entity("Home.Api.Color", b =>
                {
                    b.HasOne("Home.Api.Room")
                        .WithMany("Colors")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("Home.Api.Door", b =>
                {
                    b.HasOne("Home.Api.Color", "Color")
                        .WithOne()
                        .HasForeignKey("Home.Api.Door", "ColorId");

                    b.HasOne("Home.Api.Room", "Room")
                        .WithMany("Doors")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Home.Api.Floor", b =>
                {
                    b.HasOne("Home.Api.Color", "Color")
                        .WithOne()
                        .HasForeignKey("Home.Api.Floor", "ColorId");

                    b.HasOne("Home.Api.Room", "Room")
                        .WithOne("Floor")
                        .HasForeignKey("Home.Api.Floor", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Home.Api.LightBulb", b =>
                {
                    b.HasOne("Home.Api.Room", "Room")
                        .WithMany("LightBulbs")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Home.Api.Room", b =>
                {
                    b.HasOne("Home.Api.Home", "Home")
                        .WithMany("Rooms")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Home.Api.Window", b =>
                {
                    b.HasOne("Home.Api.Color", "Color")
                        .WithOne()
                        .HasForeignKey("Home.Api.Window", "ColorId");

                    b.HasOne("Home.Api.Room", "Room")
                        .WithMany("Windows")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
