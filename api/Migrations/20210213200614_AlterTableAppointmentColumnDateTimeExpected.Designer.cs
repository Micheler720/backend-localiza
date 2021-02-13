﻿// <auto-generated />
using System;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace api.Migrations
{
    [DbContext(typeof(ContextEntity))]
    [Migration("20210213200614_AlterTableAppointmentColumnDateTimeExpected")]
    partial class AlterTableAppointmentColumnDateTimeExpected
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AdditionalCosts")
                        .HasColumnType("float");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateTimeCollected")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeDelivery")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeExpectedCollected")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeExpectedDelivery")
                        .HasColumnType("datetime2");

                    b.Property<int>("HourLocation")
                        .HasColumnType("int");

                    b.Property<double>("HourPrice")
                        .HasColumnType("float");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int?>("IdCheckList")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdOperator")
                        .HasColumnType("int");

                    b.Property<bool>("Inspected")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("datetime2");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdCheckList")
                        .IsUnique()
                        .HasFilter("[IdCheckList] IS NOT NULL");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdOperator");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Board")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<double>("HourPrice")
                        .HasColumnType("float");

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdFuel")
                        .HasColumnType("int");

                    b.Property<int>("IdModel")
                        .HasColumnType("int");

                    b.Property<int>("LuggageCapacity")
                        .HasColumnType("int");

                    b.Property<int>("TankCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdFuel");

                    b.HasIndex("IdModel");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("Entities.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("car_brands");
                });

            modelBuilder.Entity("Entities.CarCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("car_categories");
                });

            modelBuilder.Entity("Entities.CarFuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("car_fuels");
                });

            modelBuilder.Entity("Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("car_models");
                });

            modelBuilder.Entity("Entities.CheckList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CleanCar")
                        .HasColumnType("bit");

                    b.Property<bool>("Crumpled")
                        .HasColumnType("bit");

                    b.Property<bool>("FullTank")
                        .HasColumnType("bit");

                    b.Property<bool>("Scratches")
                        .HasColumnType("bit");

                    b.Property<bool>("TankLightsPendant")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("checklists");
                });

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Entities.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Registration")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("operators");
                });

            modelBuilder.Entity("Entities.Appointment", b =>
                {
                    b.HasOne("Entities.Car", "Car")
                        .WithMany("Appointments")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.CheckList", "CheckList")
                        .WithOne("Appointment")
                        .HasForeignKey("Entities.Appointment", "IdCheckList");

                    b.HasOne("Entities.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Operator", "Operator")
                        .WithMany("Appointments")
                        .HasForeignKey("IdOperator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("CheckList");

                    b.Navigation("Client");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Entities.Car", b =>
                {
                    b.HasOne("Entities.CarBrand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.CarCategory", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.CarFuel", "Fuel")
                        .WithMany("Cars")
                        .HasForeignKey("IdFuel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.CarModel", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("IdModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Fuel");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Entities.Car", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.CarBrand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.CarCategory", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.CarFuel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Entities.CheckList", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Operator", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
