﻿// <auto-generated />
using System;
using FishingSpotsTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishingSpotsTracker.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241028045544_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FishingSpotsTracker.Models.FishCatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CatchDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("LengthInInches")
                        .HasColumnType("float");

                    b.Property<string>("Lure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpotId")
                        .HasColumnType("int");

                    b.Property<double?>("WeightInPounds")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SpotId");

                    b.ToTable("FishCatches");
                });

            modelBuilder.Entity("FishingSpotsTracker.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastVisitDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("WaterBodyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("FishingSpotsTracker.Models.FishCatch", b =>
                {
                    b.HasOne("FishingSpotsTracker.Models.Spot", "Spot")
                        .WithMany("Catches")
                        .HasForeignKey("SpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("FishingSpotsTracker.Models.Spot", b =>
                {
                    b.Navigation("Catches");
                });
#pragma warning restore 612, 618
        }
    }
}
