using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<MediaEntity> Medias { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    // As suggesed by Trev, here: https://www.bing.com/videos/riverview/relatedvideo?q=seeding+in+info+in+WebAPi&mid=8E56DC8DDFCED058834A8E56DC8DDFCED058834A
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity
        {
            Id = 1,
            UserName = "bricksRnotUs",
            Email = "unbricker@veniceart.show",
            Password = "openSesame32211!",
            FirstName = "Horace",
            LastName = "Greenbottom",
            Biography = "Retired from a life fishing along the Mississippi, Horace began his unique sandbar drawings and they quiclky became popular on Instagram.",
            DateCreated = DateTime.Now
        },
        new UserEntity
        {
            Id = 2,
            UserName = "LotsOfThingsToPaint",
            Email = "thingPainter@veniceart.show",
            Password = "8dj23jdjdj1++",
            FirstName = "Holly",
            LastName = "Janedie",
            Biography = "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.",
            DateCreated = DateTime.Now
        },
        new UserEntity
        {
            Id = 3,
            UserName = "artLover4",
            Email = "artlover4@veniceart.show",
            Password = "password",
            FirstName = "Lorraine",
            LastName = "Lansbury",
            Biography = "A Fourth Grade Teacher who loves sunsets and Animal Kingdom art.",
            DateCreated = DateTime.Now
        },
        new UserEntity
        {
            Id = 4,
            UserName = "TowersForArt",
            Email = "towers4art@veniceart.show",
            Password = "password",
            FirstName = "John",
            LastName = "Jingleheimerschmit",
            Biography = "'Whenever I go out the people always shout'.",
            DateCreated = DateTime.Now
        },
        new UserEntity
        {
            Id = 5,
            UserName = "VersaceArt",
            Email = "versaceart@veniceart.show",
            Password = "password",
            FirstName = "L.S.",
            LastName = "Ayres",
            Biography = "Heir of the famous store, now dabbles in photography.",
            DateCreated = DateTime.Now
        },
        new UserEntity
        {
            Id = 6,
            UserName = "BentleyInTheHouse",
            Email = "bentleyinthehouse@veniceart.show",
            Password = "password!",
            FirstName = "Beastly",
            LastName = "Gentle",
            Biography = "Loves to go on walks and set up his easel.",
            DateCreated = DateTime.Now
        });

        modelBuilder.Entity<MediaEntity>().HasData(
        new MediaEntity
        {
            Id = 1,
            MediaType = "Painting"
        },
        new MediaEntity
        {
            Id = 2,
            MediaType = "Photograph"
        },
        new MediaEntity
        {
            Id = 3,
            MediaType = "Ceramics"
        },
        new MediaEntity
        {
            Id = 4,
            MediaType = "Digital"
        },
        new MediaEntity
        {
            Id = 5,
            MediaType = "Glass"
        });

        modelBuilder.Entity<ProductEntity>().HasData(
        new ProductEntity
        {
            Id = 1,
            Title = "Nighthawks Nona Lisa",
            ImageUrl = "https://effinghamdailynews.com/today",
            Description = "Painting of Mona Lisa in style of Edward Hopper",
            ArtistId = 1,
            Price = 4.99,
            DateListed = DateTime.Now,
            MediaId = 1,
        },
        new ProductEntity
        {
            Id = 2,
            Title = "Sirens That Make You Scream",
            ImageUrl = "https://hollyjanedie.com",
            Description = "A depiction of sound which is like but not the same as that Scream painting by Edward Munch",
            ArtistId = 2,
            Price = 40.53,
            DateListed = DateTime.Now,
            MediaId = 2,
        },
        new ProductEntity
        {
            Id = 3,
            Title = "Call It V",
            ImageUrl = "www.ikea.com/us/en/cat/vases-10776/",
            Description = "A set of three hand-blown vases.",
            ArtistId = 3,
            Price = 983.33,
            DateListed = DateTime.Now,
            MediaId = 5,
        },
        new ProductEntity
        {
            Id = 4,
            Title = "Sunsets to Fall Asleep To",
            ImageUrl = "https://wallpapers.com",
            Description = "A collection of dreamy sunsets on hazy days.",
            ArtistId = 4,
            Price = 763.83,
            DateListed = DateTime.Now,
            MediaId = 4,
        },
        new ProductEntity
        {
            Id = 5,
            Title = "Three Faces of Eve",
            ImageUrl = "https://clevelandmuseumofart.org",
            Description = "A sculpture of the three faces of eve.",
            ArtistId = 5,
            Price = 73333.00,
            DateListed = DateTime.Now,
            MediaId = 3,
        },
        new ProductEntity
        {
            Id = 6,
            Title = "On The Tahoe Slopes",
            ImageUrl = "https://andersart.com",
            Description = "Color photographs of skiers in Tahoe circa 1964.",
            ArtistId = 6,
            Price = 400.01,
            DateListed = DateTime.Now,
            MediaId = 2,
        },
        new ProductEntity
        {
            Id = 7,
            Title = "The Scream",
            ImageUrl = "https://nationalmuseumofoslo",
            Description = "You already know it. We have it. The Scream painting by Edward Munch",
            ArtistId = 1,
            Price = 392822.98,
            DateListed = DateTime.Now,
            MediaId = 1,
        },
        new ProductEntity
        {
            Id = 8,
            Title = "3D Masters in Virtual Reality",
            ImageUrl = "https://metaverse.com",
            Description = "Vr ripoffs of famous art.",
            ArtistId = 2,
            Price = 1000.00,
            DateListed = DateTime.Now,
            MediaId = 4,
        });

        modelBuilder.Entity<OrderEntity>().HasData(
        new OrderEntity
        {
            Id = 1,
            CreatedUtc = DateTime.Now,
            BuyerId = 3,
            ProductId = 1,
            ArtistId = 1,
            Price = 4.99
        },
        new OrderEntity
        {
            Id = 2,
            CreatedUtc = DateTime.Now,
            BuyerId = 4,
            ProductId = 2,
            ArtistId = 2,
            Price = 40.53
        },
        new OrderEntity
        {
            Id = 3,
            CreatedUtc = DateTime.Now,
            BuyerId = 4,
            ProductId = 3,
            ArtistId = 3,
            Price = 983.33
        });
    }
   //New seed
}