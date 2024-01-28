﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "m@gmail.com",
                            FullName = "Morgan Freeman",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 2,
                            Email = "d@gmail.com",
                            FullName = "Denzel Washington",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 3,
                            Email = "t@gmail.com",
                            FullName = "Tom Hanks",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 4,
                            Email = "a@gmail.com",
                            FullName = "Al Pacino",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 5,
                            Email = "s@gmail.com",
                            FullName = "Samuel L. Jackson",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 6,
                            Email = "r@gmail.com",
                            FullName = "Robert Downey Jr.",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 7,
                            Email = "g@gmail.com",
                            FullName = "George Gerdes",
                            Password = "123456"
                        },
                        new
                        {
                            Id = 8,
                            Email = "p@gmail.com",
                            FullName = "Paul Geoffrey",
                            Password = "123456"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
