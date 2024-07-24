using GoodLuck.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodLuck.Db;

class DatabaseContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Day> Days { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"
        Server=localhost;
        Database=DESKTOP-CABCDNT\GOODLUCK;
        User=SA;
        TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Days)
            .WithOne(d => d.User)
            .HasForeignKey(d => d.UserId);

        modelBuilder.Entity<Day>()
            .HasOne(d => d.User)
            .WithMany(u => u.Days)
            .HasForeignKey(d => d.UserId);
    }
}