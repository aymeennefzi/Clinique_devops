﻿// <auto-generated />
using System;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20240621013645_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clinic.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieId"), 1L, 1);

                    b.Property<string>("CategorieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Clinic.Models.ChefDeService", b =>
                {
                    b.Property<int>("ChefDeServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChefDeServiceId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ChefDeServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ChefDeServices");
                });

            modelBuilder.Entity("Clinic.Models.DailyEmployment", b =>
                {
                    b.Property<int>("DailyEmploymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyEmploymentId"), 1L, 1);

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("DateDuJour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfWeek")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmploiId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EndHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReposId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("StartHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplementId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dayname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DailyEmploymentId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EmploiId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("DailyEmployments");
                });

            modelBuilder.Entity("Clinic.Models.Day", b =>
                {
                    b.Property<int>("Id_day")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_day"), 1L, 1);

                    b.Property<string>("Dayname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmploiId")
                        .HasColumnType("int");

                    b.HasKey("Id_day");

                    b.HasIndex("EmploiId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Clinic.Models.Emploi", b =>
                {
                    b.Property<int>("EmploiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploiId"), 1L, 1);

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("CategorieSelected")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChefDeServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfWeek")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceSelected")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmploiId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("ChefDeServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Emplois");
                });

            modelBuilder.Entity("Clinic.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int?>("ChefDeServiceId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmploiId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsChefDeService")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RecruitmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalWeeklyHours")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("ChefDeServiceId");

                    b.HasIndex("EmploiId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Clinic.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Clinic.Models.Poste", b =>
                {
                    b.Property<int>("PosteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PosteId"), 1L, 1);

                    b.Property<bool>("Actif")
                        .HasColumnType("bit");

                    b.Property<bool>("ApresMidi")
                        .HasColumnType("bit");

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int?>("EmploiId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("GardeSoir")
                        .HasColumnType("bit");

                    b.Property<bool>("Matin")
                        .HasColumnType("bit");

                    b.Property<string>("Postename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Seance1Debut")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Seance1Fin")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("Seance2Debut")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("Seance2Fin")
                        .HasColumnType("time");

                    b.HasKey("PosteId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EmploiId");

                    b.ToTable("Postes");
                });

            modelBuilder.Entity("Clinic.Models.Repos", b =>
                {
                    b.Property<int>("ReposId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReposId"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_Jours")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmploiId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ReposName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReposId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EmploiId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Repos");
                });

            modelBuilder.Entity("Clinic.Models.Service", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("ChefDeServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChefDeServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Clinic.Models.Supplement", b =>
                {
                    b.Property<int>("SupplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplementId"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int?>("EmploiId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplementId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("EmploiId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Supplements");
                });

            modelBuilder.Entity("EmployeePoste", b =>
                {
                    b.Property<int>("EmployeesEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PostesPosteId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesEmployeeId", "PostesPosteId");

                    b.HasIndex("PostesPosteId");

                    b.ToTable("EmployeePoste");
                });

            modelBuilder.Entity("Clinic.Models.ChefDeService", b =>
                {
                    b.HasOne("Clinic.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Clinic.Models.DailyEmployment", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.HasOne("Clinic.Models.Emploi", "Emploi")
                        .WithMany("DailyEmployments")
                        .HasForeignKey("EmploiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Categorie");

                    b.Navigation("Emploi");

                    b.Navigation("Employee");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Clinic.Models.Day", b =>
                {
                    b.HasOne("Clinic.Models.Emploi", null)
                        .WithMany("Days")
                        .HasForeignKey("EmploiId");
                });

            modelBuilder.Entity("Clinic.Models.Emploi", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.HasOne("Clinic.Models.ChefDeService", null)
                        .WithMany("Emplois")
                        .HasForeignKey("ChefDeServiceId");

                    b.HasOne("Clinic.Models.Service", "Service")
                        .WithMany("Emplois")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Categorie");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Clinic.Models.Employee", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.HasOne("Clinic.Models.ChefDeService", null)
                        .WithMany("Employees")
                        .HasForeignKey("ChefDeServiceId");

                    b.HasOne("Clinic.Models.Emploi", "Emploi")
                        .WithMany("Employees")
                        .HasForeignKey("EmploiId");

                    b.HasOne("Clinic.Models.Service", "Service")
                        .WithMany("Employees")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Emploi");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Clinic.Models.Poste", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany("Postes")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Emploi", "Emploi")
                        .WithMany("Postes")
                        .HasForeignKey("EmploiId");

                    b.Navigation("Categorie");

                    b.Navigation("Emploi");
                });

            modelBuilder.Entity("Clinic.Models.Repos", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany("Repos")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Emploi", "Emploi")
                        .WithMany("Repos")
                        .HasForeignKey("EmploiId");

                    b.HasOne("Clinic.Models.Employee", null)
                        .WithMany("Repos")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Categorie");

                    b.Navigation("Emploi");
                });

            modelBuilder.Entity("Clinic.Models.Service", b =>
                {
                    b.HasOne("Clinic.Models.ChefDeService", "ChefDeService")
                        .WithMany()
                        .HasForeignKey("ChefDeServiceId");

                    b.Navigation("ChefDeService");
                });

            modelBuilder.Entity("Clinic.Models.Supplement", b =>
                {
                    b.HasOne("Clinic.Models.Categorie", "Categorie")
                        .WithMany("Supplements")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Emploi", "Emploi")
                        .WithMany("Supplements")
                        .HasForeignKey("EmploiId");

                    b.HasOne("Clinic.Models.Employee", "Employee")
                        .WithMany("Supplements")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Categorie");

                    b.Navigation("Emploi");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeePoste", b =>
                {
                    b.HasOne("Clinic.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Poste", null)
                        .WithMany()
                        .HasForeignKey("PostesPosteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Models.Categorie", b =>
                {
                    b.Navigation("Postes");

                    b.Navigation("Repos");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("Clinic.Models.ChefDeService", b =>
                {
                    b.Navigation("Emplois");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Clinic.Models.Emploi", b =>
                {
                    b.Navigation("DailyEmployments");

                    b.Navigation("Days");

                    b.Navigation("Employees");

                    b.Navigation("Postes");

                    b.Navigation("Repos");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("Clinic.Models.Employee", b =>
                {
                    b.Navigation("Repos");

                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("Clinic.Models.Service", b =>
                {
                    b.Navigation("Emplois");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
