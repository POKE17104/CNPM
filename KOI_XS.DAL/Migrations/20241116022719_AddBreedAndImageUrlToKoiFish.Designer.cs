﻿// <auto-generated />
using System;
using KOI_XS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KOI_XS.DAL.Migrations
{
    [DbContext(typeof(KoiContext))]
    [Migration("20241116022719_AddBreedAndImageUrlToKoiFish")]
    partial class AddBreedAndImageUrlToKoiFish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KOI_XS.DAL.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123/34 Lê Văn Thọ, p15, Gò vấp,TP-HCM",
                            Email = "nguyenvana@example.com",
                            Name = "Nguyen Van A",
                            Password = "password123",
                            PhoneNumber = "0123456789",
                            Username = "nguyenvana"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "456 Nguyễn Thị Minh Khai,p1,Quận 1, Tp-HCM",
                            Email = "tranthib@example.com",
                            Name = "Tran Thi B",
                            Password = "password456",
                            PhoneNumber = "0987654321",
                            Username = "tranthib"
                        });
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.Koi", b =>
                {
                    b.Property<int>("KoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KoiId"));

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("KoiId");

                    b.ToTable("Kois");
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.KoiFish", b =>
                {
                    b.Property<int>("KoiFishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KoiFishId"));

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("KoiFishId");

                    b.ToTable("KoiFishes");

                    b.HasData(
                        new
                        {
                            KoiFishId = 1,
                            Breed = "Dragon",
                            Color = "Red",
                            ImageUrl = "http://example.com/koi-red-dragon.jpg",
                            Name = "Koi Red Dragon",
                            Price = 150.00m
                        },
                        new
                        {
                            KoiFishId = 2,
                            Breed = "Beauty",
                            Color = "Black",
                            ImageUrl = "http://example.com/koi-black-beauty.jpg",
                            Name = "Koi Black Beauty",
                            Price = 200.00m
                        },
                        new
                        {
                            KoiFishId = 3,
                            Breed = "Pearl",
                            Color = "White",
                            ImageUrl = "http://example.com/koi-white-pearl.jpg",
                            Name = "Koi White Pearl",
                            Price = 180.00m
                        });
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2024, 11, 6, 9, 27, 17, 673, DateTimeKind.Local).AddTicks(8306)
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2024, 11, 11, 9, 27, 17, 673, DateTimeKind.Local).AddTicks(8346)
                        });
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.OrderKoi", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("KoiFishId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "KoiFishId");

                    b.HasIndex("KoiFishId");

                    b.ToTable("OrderKois");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            KoiFishId = 1,
                            Quantity = 1,
                            UnitPrice = 150.00m
                        },
                        new
                        {
                            OrderId = 1,
                            KoiFishId = 2,
                            Quantity = 1,
                            UnitPrice = 200.00m
                        },
                        new
                        {
                            OrderId = 2,
                            KoiFishId = 3,
                            Quantity = 1,
                            UnitPrice = 180.00m
                        });
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.Order", b =>
                {
                    b.HasOne("KOI_XS.DAL.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.OrderKoi", b =>
                {
                    b.HasOne("KOI_XS.DAL.Entities.KoiFish", "KoiFish")
                        .WithMany("OrderKois")
                        .HasForeignKey("KoiFishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KOI_XS.DAL.Entities.Order", "Order")
                        .WithMany("OrderKois")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KoiFish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.KoiFish", b =>
                {
                    b.Navigation("OrderKois");
                });

            modelBuilder.Entity("KOI_XS.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderKois");
                });
#pragma warning restore 612, 618
        }
    }
}