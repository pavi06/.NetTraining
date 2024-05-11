﻿// <auto-generated />
using System;
using EmployeeTrackerModelLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeTrackerModelLibrary.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    [Migration("20240510050510_requestSolution")]
    partial class requestSolution
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeTrackerModelLibrary.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Name = "Ramu",
                            Password = "ramu123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 102,
                            Name = "Somu",
                            Password = "somu123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 103,
                            Name = "Bimu",
                            Password = "bimu123",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.Request", b =>
                {
                    b.Property<int>("RequestNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestNumber"), 1L, 1);

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestClosedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestRaisedBy")
                        .HasColumnType("int");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestNumber");

                    b.HasIndex("RequestClosedBy");

                    b.HasIndex("RequestRaisedBy");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.RequestSolution", b =>
                {
                    b.Property<int>("SolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolutionId"), 1L, 1);

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("RequestRaiserComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("SolvedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SolutionId");

                    b.HasIndex("RequestId");

                    b.HasIndex("SolvedBy");

                    b.ToTable("RequestSolution");
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.Request", b =>
                {
                    b.HasOne("EmployeeTrackerModelLibrary.Employee", "RequestClosedByEmployee")
                        .WithMany("RequestsClosed")
                        .HasForeignKey("RequestClosedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeTrackerModelLibrary.Employee", "RaisedByEmployee")
                        .WithMany("RequestsRaised")
                        .HasForeignKey("RequestRaisedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RaisedByEmployee");

                    b.Navigation("RequestClosedByEmployee");
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.RequestSolution", b =>
                {
                    b.HasOne("EmployeeTrackerModelLibrary.Request", "RequestRaised")
                        .WithMany("RequestSolutions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeTrackerModelLibrary.Employee", "SolvedByEmployee")
                        .WithMany("SolutionsProvided")
                        .HasForeignKey("SolvedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RequestRaised");

                    b.Navigation("SolvedByEmployee");
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.Employee", b =>
                {
                    b.Navigation("RequestsClosed");

                    b.Navigation("RequestsRaised");

                    b.Navigation("SolutionsProvided");
                });

            modelBuilder.Entity("EmployeeTrackerModelLibrary.Request", b =>
                {
                    b.Navigation("RequestSolutions");
                });
#pragma warning restore 612, 618
        }
    }
}