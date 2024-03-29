﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShoppingCart.SharedKernel.Persistence;

#nullable disable

namespace ShoppingCart.SharedKernel.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230717105604_AddAddressNAvigationProperty")]
    partial class AddAddressNAvigationProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<int>("PartId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("PartId");

                    b.ToTable("CartItem", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Part", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Store", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.StoreState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PartId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreState", (string)null);
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Cart", b =>
                {
                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Employee", "Employee")
                        .WithMany("Carts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.CartItem", b =>
                {
                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Part", "Part")
                        .WithMany("CartItems")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ShoppingCart.SharedKernel.Persistence.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("CartItemId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Cost")
                                .HasColumnType("numeric")
                                .HasColumnName("PriceCost");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("character varying(5)")
                                .HasColumnName("PriceCurrency");

                            b1.HasKey("CartItemId");

                            b1.ToTable("CartItem");

                            b1.WithOwner()
                                .HasForeignKey("CartItemId");
                        });

                    b.Navigation("Cart");

                    b.Navigation("Part");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Customer", b =>
                {
                    b.OwnsMany("ShoppingCart.SharedKernel.Persistence.ValueObjects.Address", "Addresses", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("CustomerId")
                                .HasColumnType("integer");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Customer_Addresses");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Employee", b =>
                {
                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Part", b =>
                {
                    b.OwnsOne("ShoppingCart.SharedKernel.Persistence.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<int>("PartId")
                                .HasColumnType("integer");

                            b1.Property<decimal>("Cost")
                                .HasColumnType("numeric")
                                .HasColumnName("PriceCost");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("character varying(5)")
                                .HasColumnName("PriceCurrency");

                            b1.HasKey("PartId");

                            b1.ToTable("Part");

                            b1.WithOwner()
                                .HasForeignKey("PartId");
                        });

                    b.OwnsOne("ShoppingCart.SharedKernel.Persistence.ValueObjects.Manufacturer", "Manufacturer", b1 =>
                        {
                            b1.Property<int>("PartId")
                                .HasColumnType("integer");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("ManufacturerName");

                            b1.HasKey("PartId");

                            b1.ToTable("Part");

                            b1.WithOwner()
                                .HasForeignKey("PartId");
                        });

                    b.Navigation("Manufacturer")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Store", b =>
                {
                    b.OwnsOne("ShoppingCart.SharedKernel.Persistence.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StoreId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Address_City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Address_Country");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("character varying(5)")
                                .HasColumnName("Address_Number");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Address_Street");

                            b1.HasKey("StoreId");

                            b1.ToTable("Store");

                            b1.WithOwner()
                                .HasForeignKey("StoreId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.StoreState", b =>
                {
                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Part", "Part")
                        .WithMany("StoreStates")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCart.SharedKernel.Persistence.Entities.Store", "Store")
                        .WithMany("StoreStates")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Customer", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Employee", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Part", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("StoreStates");
                });

            modelBuilder.Entity("ShoppingCart.SharedKernel.Persistence.Entities.Store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("StoreStates");
                });
#pragma warning restore 612, 618
        }
    }
}
