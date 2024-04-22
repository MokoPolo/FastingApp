using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fasting.API.Data;

public class FastingDbContext : DbContext
{
    // public FastingDbContext()
    //     : base() { }

    public FastingDbContext()
        : base() { }

    public FastingDbContext(DbContextOptions<FastingDbContext> options)
        : base(options) { }

    public virtual DbSet<FastDomain> Fasts { get; set; }

    public DbSet<DurationDomain> Durations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add default duration values
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<DurationDomain>()
            .HasData(
                new DurationDomain
                {
                    Id = 1,
                    Name = "12",
                    Length = 12
                },
                new DurationDomain
                {
                    Id = 2,
                    Name = "16",
                    Length = 16
                },
                new DurationDomain
                {
                    Id = 3,
                    Name = "18",
                    Length = 18
                },
                new DurationDomain
                {
                    Id = 4,
                    Name = "72",
                    Length = 72
                },
                new DurationDomain
                {
                    Id = 5,
                    Name = "84",
                    Length = 84
                },
                new DurationDomain
                {
                    Id = 6,
                    Name = "96",
                    Length = 96
                },
                new DurationDomain { Id = 7, Name = "Custom" }
            );
    }
}
