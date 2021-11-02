﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.EF;

namespace Restaurant.EF.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant.Core.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("DishType")
                        .HasColumnType("int");

                    b.Property<int?>("MenuID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuID");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DishName = "Lasagne",
                            DishType = 0,
                            MenuID = 1,
                            Price = 8.20m
                        },
                        new
                        {
                            Id = 2,
                            DishName = "Fish and Chips",
                            DishType = 1,
                            MenuID = 3,
                            Price = 6.90m
                        },
                        new
                        {
                            Id = 3,
                            DishName = "Cheesecake",
                            DishType = 3,
                            MenuID = 2,
                            Price = 5.30m
                        });
                });

            modelBuilder.Entity("Restaurant.Core.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuName = "Christmas 2021 Menu"
                        },
                        new
                        {
                            Id = 2,
                            MenuName = "Summer 2021 Menu"
                        },
                        new
                        {
                            Id = 3,
                            MenuName = "Winter 2021 Menu"
                        });
                });

            modelBuilder.Entity("Restaurant.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mrossi@diner.it",
                            Password = "1234",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "pbianchi@mail.it",
                            Password = "5678",
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "gverdi@mail.it",
                            Password = "9876",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Restaurant.Core.Entities.Dish", b =>
                {
                    b.HasOne("Restaurant.Core.Entities.Menu", "Menu")
                        .WithMany("Dishes")
                        .HasForeignKey("MenuID");
                });
#pragma warning restore 612, 618
        }
    }
}
