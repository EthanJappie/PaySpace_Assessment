﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySpace.Api;

#nullable disable

namespace PaySpace.Api.Migrations
{
    [DbContext(typeof(PaySpaceDbContext))]
    [Migration("20230515141711_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PaySpace.Api.Entities.TaxBand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Lower")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Upper")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaxBands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lower = 0m,
                            Rate = 10m,
                            Upper = 8350m
                        },
                        new
                        {
                            Id = 2,
                            Lower = 8351m,
                            Rate = 15m,
                            Upper = 33950m
                        },
                        new
                        {
                            Id = 3,
                            Lower = 33951m,
                            Rate = 25m,
                            Upper = 82250m
                        },
                        new
                        {
                            Id = 4,
                            Lower = 82251m,
                            Rate = 28m,
                            Upper = 171550m
                        },
                        new
                        {
                            Id = 5,
                            Lower = 171551m,
                            Rate = 33m,
                            Upper = 372950m
                        },
                        new
                        {
                            Id = 6,
                            Lower = 372951m,
                            Rate = 35m,
                            Upper = 79228162514264337593543950335m
                        });
                });

            modelBuilder.Entity("PaySpace.Api.Entities.TaxEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaxMap");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostalCode = "7441",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            PostalCode = "A100",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            PostalCode = "7000",
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            PostalCode = "1000",
                            Type = 1
                        });
                });

            modelBuilder.Entity("PaySpace.Api.Entities.TaxResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AnnualIncome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AppliedRate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CalculationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("TaxType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaxResults");
                });
#pragma warning restore 612, 618
        }
    }
}