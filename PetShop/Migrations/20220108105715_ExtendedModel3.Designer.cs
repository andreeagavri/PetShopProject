﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShopModel.Data;

namespace PetShop.Migrations
{
    [DbContext(typeof(PetShopContext))]
    [Migration("20220108105715_ExtendedModel3")]
    partial class ExtendedModel3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetShopModel.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("PetShopModel.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ProductID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PetShopModel.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("PetShopModel.Models.SuppliedProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "SupplierID");

                    b.HasIndex("SupplierID");

                    b.ToTable("SuppliedProduct");
                });

            modelBuilder.Entity("PetShopModel.Models.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("PetShopModel.Models.Order", b =>
                {
                    b.HasOne("PetShopModel.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetShopModel.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PetShopModel.Models.SuppliedProduct", b =>
                {
                    b.HasOne("PetShopModel.Models.Product", "Product")
                        .WithMany("SuppliedProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetShopModel.Models.Supplier", "Supplier")
                        .WithMany("SuppliedProducts")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PetShopModel.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PetShopModel.Models.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("SuppliedProducts");
                });

            modelBuilder.Entity("PetShopModel.Models.Supplier", b =>
                {
                    b.Navigation("SuppliedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
