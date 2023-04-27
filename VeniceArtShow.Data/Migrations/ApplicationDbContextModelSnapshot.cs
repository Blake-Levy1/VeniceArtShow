﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace VeniceArtShow.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MediaType = "Painting"
                        },
                        new
                        {
                            Id = 2,
                            MediaType = "Photograph"
                        });
                });

            modelBuilder.Entity("OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateListed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MediaId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            DateListed = new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3472),
                            Description = "Painting of Mona Lisa in style of Edward Hopper",
                            ImageUrl = "https://effinghamdailynews.com/today",
                            IsSold = false,
                            MediaId = 1,
                            Price = 4.9900000000000002,
                            Title = "Nighthawks Nona Lisa"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 2,
                            DateListed = new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3475),
                            Description = "A depiction of sound which is like but not the same as that Scream painting by Edward Munch",
                            ImageUrl = "https://hollyjanedie.com",
                            IsSold = false,
                            MediaId = 2,
                            Price = 40.530000000000001,
                            Title = "Sirens That Make You Scream"
                        });
                });

            modelBuilder.Entity("UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Retired from a life fishing along the Mississippi, Horace began his unique sandbar drawings and they quiclky became popular on Instagram.",
                            DateCreated = new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3244),
                            Email = "unbricker@efa.org",
                            FirstName = "Horace",
                            LastName = "Greenbottom",
                            Password = "openSesame32211!",
                            UserName = "bricksRnotUs"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.",
                            DateCreated = new DateTime(2023, 4, 27, 10, 15, 49, 889, DateTimeKind.Local).AddTicks(3296),
                            Email = "thingPainter@efa.org",
                            FirstName = "Holly",
                            LastName = "Janedie",
                            Password = "8dj23jdjdj1++",
                            UserName = "LotsOfThingsToPaint"
                        });
                });

            modelBuilder.Entity("OrderEntity", b =>
                {
                    b.HasOne("UserEntity", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserEntity", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductEntity", b =>
                {
                    b.HasOne("UserEntity", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaEntity", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Media");
                });
#pragma warning restore 612, 618
        }
    }
}
