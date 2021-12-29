﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211229024633_change-AR-table-name")]
    partial class changeARtablename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OTP")
                        .HasColumnType("int");

                    b.Property<DateTime?>("expiredToken")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isUsed")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("Tb_m_Accounts");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountsNIK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsNIK");

                    b.HasIndex("RolesId");

                    b.ToTable("Tb_tr_AccountRoles");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("GPA")
                        .HasColumnType("real");

                    b.Property<string>("UniversityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Tb_m_Educations");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("Tb_m_Employees");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EducationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NIK");

                    b.HasIndex("EducationId");

                    b.ToTable("Tb_tr_Profilings");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tb_m_Roles");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tb_m_Universities");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Profiling", "Profiling")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Accounts")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountsNIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Role", "Roles")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.HasOne("API.Models.University", "University")
                        .WithMany("Education")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Employee")
                        .HasForeignKey("API.Models.Employee", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.HasOne("API.Models.Education", "Education")
                        .WithMany("Profiling")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Navigation("Education");
                });
#pragma warning restore 612, 618
        }
    }
}
