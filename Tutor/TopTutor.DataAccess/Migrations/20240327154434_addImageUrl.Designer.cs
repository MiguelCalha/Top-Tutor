﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopTutor.DataAcess.Data;

#nullable disable

namespace TopTutor.DataAcess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240327154434_addImageUrl")]
    partial class addImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TopTutor.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Matemática"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Programação"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Línguas"
                        });
                });

            modelBuilder.Entity("TopTutor.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Explicações de programação",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "Programming Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Explicações de matemática",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "Math Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Explicações de inglês",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "English Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Explicações de francês",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "French Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Explicações de espanhol",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "Spanish Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Explicações de alemão",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "German Tutoring",
                            TutorName = "Miguel Calha"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Explicações de italiano",
                            ImageUrl = "",
                            ListPrice = 10.0,
                            Title = "Italian Tutoring",
                            TutorName = "Miguel Calha"
                        });
                });

            modelBuilder.Entity("TopTutor.Models.Product", b =>
                {
                    b.HasOne("TopTutor.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
