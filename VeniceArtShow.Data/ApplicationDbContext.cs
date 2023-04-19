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
    public DbSet<MediaEntity> Media { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<<MediaEntity>()
    //     .HasOne(n => n.Username)
    //     .WithMany(p => p.Media)
    //     .HasForeignKey(n => n.ArtistId);
    // }
}