﻿// <auto-generated />
using System;
using Fasting.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fasting.API.Migrations
{
    [DbContext(typeof(FastingDbContext))]
    [Migration("20240418235752_Field updates")]
    partial class Fieldupdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fasting.API.Models.Domain.DurationDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Durations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Length = 12,
                            Name = "12"
                        },
                        new
                        {
                            Id = 2,
                            Length = 16,
                            Name = "16"
                        },
                        new
                        {
                            Id = 3,
                            Length = 18,
                            Name = "18"
                        },
                        new
                        {
                            Id = 4,
                            Length = 72,
                            Name = "72"
                        },
                        new
                        {
                            Id = 5,
                            Length = 84,
                            Name = "84"
                        },
                        new
                        {
                            Id = 6,
                            Length = 96,
                            Name = "96"
                        },
                        new
                        {
                            Id = 7,
                            Length = 0,
                            Name = "Custom"
                        });
                });

            modelBuilder.Entity("Fasting.API.Models.Domain.FastDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DurationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.ToTable("Fasts");
                });

            modelBuilder.Entity("Fasting.API.Models.Domain.FastDomain", b =>
                {
                    b.HasOne("Fasting.API.Models.Domain.DurationDomain", "Duration")
                        .WithMany()
                        .HasForeignKey("DurationId");

                    b.Navigation("Duration");
                });
#pragma warning restore 612, 618
        }
    }
}
