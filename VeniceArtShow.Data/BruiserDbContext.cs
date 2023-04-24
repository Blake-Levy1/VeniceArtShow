using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// This is a file created from following kudvenkat, ASP NET Core Identity UserManager and SignInManager
// https://www.youtube.com/watch?v=TfarnVqnhX0
// Squirrel inner brackets imported from screengrab at 7:33

public class BruiserDbContext : IdentityDbContext
{
    public BruiserAppDbContext(DbContextOptions<AppDbContext> options)
        :: base (options)
        {
        }

public DbSet<UserEntity> Users(get; set; )
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Seed();
    }
}