﻿// <auto-generated />
using System;
using EventAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventAPI.Migrations
{
    [DbContext(typeof(EventCatalogContext))]
    [Migration("20211104233028_nextOne")]
    partial class nextOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventAPI.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EventAPI.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventLinkUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnlineEvent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaidEvent")
                        .HasColumnType("bit");

                    b.Property<int>("MaxOccupancy")
                        .HasColumnType("int");

                    b.Property<int>("MaxTicketsPerUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserEmailId")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserEmailId");

                    b.ToTable("EventCatalog");
                });

            modelBuilder.Entity("EventAPI.Domain.Organization", b =>
                {
                    b.Property<int>("OrganizerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmailId")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizerId");

                    b.HasIndex("UserEmailId")
                        .IsUnique()
                        .HasFilter("[UserEmailId] IS NOT NULL");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("EventAPI.Domain.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EventAPI.Domain.User", b =>
                {
                    b.Property<string>("UserEmailId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserEmailId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventAPI.Domain.Event", b =>
                {
                    b.HasOne("EventAPI.Domain.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAPI.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserEmailId");

                    b.Navigation("SubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventAPI.Domain.Organization", b =>
                {
                    b.HasOne("EventAPI.Domain.User", "User")
                        .WithOne("Organization")
                        .HasForeignKey("EventAPI.Domain.Organization", "UserEmailId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventAPI.Domain.SubCategory", b =>
                {
                    b.HasOne("EventAPI.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EventAPI.Domain.User", b =>
                {
                    b.Navigation("Organization");
                });
#pragma warning restore 612, 618
        }
    }
}
