﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using course.Infrastructure.Data;

#nullable disable

namespace course.Infrastructure.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    partial class CourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("course.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Development"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Language"
                        });
                });

            modelBuilder.Entity("course.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "ASP.NET Core ile web geliştirmeyi öğrenin",
                            Duration = 200,
                            ImageUrl = "https://placehold.co/300x200",
                            Title = "Temel ASP.NET Core"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "ASP.NET Core ile web geliştirmeyi öğrenin",
                            Duration = 200,
                            ImageUrl = "https://placehold.co/300x200",
                            Title = "İleri ASP.NET Core"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Güzel sanatlar...",
                            Duration = 200,
                            ImageUrl = "https://placehold.co/300x200",
                            Title = "Resim"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "İngilizce",
                            Duration = 200,
                            ImageUrl = "https://placehold.co/300x200",
                            Title = "İngilizce"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Fransızca",
                            Duration = 200,
                            ImageUrl = "https://placehold.co/300x200",
                            Title = "Fransızca"
                        });
                });

            modelBuilder.Entity("course.Entities.Course", b =>
                {
                    b.HasOne("course.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("course.Entities.Category", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
