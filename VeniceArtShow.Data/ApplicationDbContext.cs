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
            Email = "unbricker@efa.org",
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
            Email = "thingPainter@efa.org",
            Password = "8dj23jdjdj1++",
            FirstName = "Holly",
            LastName = "Janedie",
            Biography = "Holly, a friend of Go Lightly, decided one day to aim her Hollywood lights at 3 mirrors. The rest is history.",
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
        });
    }
    // {
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     //This looks/feels like a mess says Mike
    //     //Explanation: modelBuider instance takes an OrderEntity, saying a user/buyer...
    //     modelBuilder.Entity<OrderEntity>()
    //     .HasOne(n => n.Buyer)
    //     .WithMany(p => p.Orders)
    //     .HasForeignKey(n => n.Id);
    // }
}