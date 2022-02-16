﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartphoneShop.Data;

namespace SmartphoneShop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20220216170245_ExtendedModel")]
    partial class ExtendedModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartphoneShop.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SmartphoneID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("SmartphoneID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Smartphone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.ToTable("Smartphone");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("SmartphoneShop.Models.StoreSmartphone", b =>
                {
                    b.Property<int>("SmartphoneID")
                        .HasColumnType("int");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("SmartphoneID", "StoreID");

                    b.HasIndex("StoreID");

                    b.ToTable("Smartphone Store");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Order", b =>
                {
                    b.HasOne("SmartphoneShop.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartphoneShop.Models.Smartphone", "Smartphone")
                        .WithMany("Orders")
                        .HasForeignKey("SmartphoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Smartphone");
                });

            modelBuilder.Entity("SmartphoneShop.Models.StoreSmartphone", b =>
                {
                    b.HasOne("SmartphoneShop.Models.Smartphone", "Smarphone")
                        .WithMany("StoreSmartphones")
                        .HasForeignKey("SmartphoneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartphoneShop.Models.Store", "Store")
                        .WithMany("StoreSmartphones")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Smarphone");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Smartphone", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("StoreSmartphones");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Store", b =>
                {
                    b.Navigation("StoreSmartphones");
                });
#pragma warning restore 612, 618
        }
    }
}
