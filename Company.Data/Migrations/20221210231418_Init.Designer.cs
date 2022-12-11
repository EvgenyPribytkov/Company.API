﻿// <auto-generated />
using Company.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Data.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20221210231418_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Company.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentsName = "Marketing",
                            OrganisationId = 1
                        },
                        new
                        {
                            Id = 2,
                            DepartmentsName = "Sales",
                            OrganisationId = 1
                        },
                        new
                        {
                            Id = 3,
                            DepartmentsName = "Customer Service",
                            OrganisationId = 1
                        },
                        new
                        {
                            Id = 4,
                            DepartmentsName = "IT",
                            OrganisationId = 1
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsUnionMember")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            FirstName = "Kenny",
                            IsUnionMember = true,
                            LastName = "Todd",
                            Salary = 2500m
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            FirstName = "Natasha",
                            IsUnionMember = false,
                            LastName = "Parrish",
                            Salary = 2200m
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            FirstName = "Brendon",
                            IsUnionMember = true,
                            LastName = "Yates",
                            Salary = 2800m
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 4,
                            FirstName = "Terry",
                            IsUnionMember = true,
                            LastName = "Patrick",
                            Salary = 3000m
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeesJobTitle", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "JobTitleId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("EmployeesJobTitles");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            JobTitleId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            JobTitleId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            JobTitleId = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            JobTitleId = 4
                        },
                        new
                        {
                            EmployeeId = 4,
                            JobTitleId = 5
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("JobTitleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            JobTitleName = "Marketing Assistant"
                        },
                        new
                        {
                            Id = 2,
                            JobTitleName = "Sales Manager"
                        },
                        new
                        {
                            Id = 3,
                            JobTitleName = "Customer Service Representative"
                        },
                        new
                        {
                            Id = 4,
                            JobTitleName = "Team Lead"
                        },
                        new
                        {
                            Id = 5,
                            JobTitleName = "Developer"
                        });
                });

            modelBuilder.Entity("Company.Data.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Organisations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrganisationName = "Apple"
                        },
                        new
                        {
                            Id = 2,
                            OrganisationName = "Google"
                        },
                        new
                        {
                            Id = 3,
                            OrganisationName = "Facebook"
                        });
                });

            modelBuilder.Entity("EmployeeJobTitle", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("JobTitlesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "JobTitlesId");

                    b.HasIndex("JobTitlesId");

                    b.ToTable("EmployeeJobTitle");
                });

            modelBuilder.Entity("Company.Data.Entities.Department", b =>
                {
                    b.HasOne("Company.Data.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Company.Data.Entities.Employee", b =>
                {
                    b.HasOne("Company.Data.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Company.Data.Entities.EmployeesJobTitle", b =>
                {
                    b.HasOne("Company.Data.Entities.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("EmployeeJobTitle", b =>
                {
                    b.HasOne("Company.Data.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Data.Entities.JobTitle", null)
                        .WithMany()
                        .HasForeignKey("JobTitlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
