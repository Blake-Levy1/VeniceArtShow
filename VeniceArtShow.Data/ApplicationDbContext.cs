using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
    {

    }
    public DbSet<OrderEntity> Orders { get; set;}

    public DbSet<ProductEntity> Products { get; set; }
}