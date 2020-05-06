﻿// <auto-generated />
using System;
using GymProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymProject.DataAccess.Migrations
{
    [DbContext(typeof(GymDbContext))]
    [Migration("20200504163927_add")]
    partial class add
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymProject.AppLogic.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassIdId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Classes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HourClass")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Corporate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanysName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NrEmployees")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Corporates");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Facilities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AbonamentFacilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("priceAbonamentIdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("priceAbonamentIdId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.PriceAbonament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MonthDuration")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("TypeAbonament")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PriceAbonament");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Progress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ArmLeft")
                        .HasColumnType("real");

                    b.Property<float>("ArmRight")
                        .HasColumnType("real");

                    b.Property<float>("Belly")
                        .HasColumnType("real");

                    b.Property<float>("Chest")
                        .HasColumnType("real");

                    b.Property<float>("Fesier")
                        .HasColumnType("real");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Kg")
                        .HasColumnType("real");

                    b.Property<float>("Legs")
                        .HasColumnType("real");

                    b.Property<float>("Shoulders")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Trainers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassIdId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Booking", b =>
                {
                    b.HasOne("GymProject.AppLogic.Models.Classes", "ClassId")
                        .WithMany()
                        .HasForeignKey("ClassIdId");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Facilities", b =>
                {
                    b.HasOne("GymProject.AppLogic.Models.PriceAbonament", "priceAbonamentId")
                        .WithMany()
                        .HasForeignKey("priceAbonamentIdId");
                });

            modelBuilder.Entity("GymProject.AppLogic.Models.Trainers", b =>
                {
                    b.HasOne("GymProject.AppLogic.Models.Classes", "ClassId")
                        .WithMany()
                        .HasForeignKey("ClassIdId");
                });
#pragma warning restore 612, 618
        }
    }
}
