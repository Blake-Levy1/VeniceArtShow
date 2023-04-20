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

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //This looks/feels like a mess says Mike
        modelBuilder.Entity<OrderEntity>()
        .HasOne(n => n.Buyer)
        .WithMany(p => p.Orders)
        .HasForeignKey(n => n.ArtistId);
    }
}