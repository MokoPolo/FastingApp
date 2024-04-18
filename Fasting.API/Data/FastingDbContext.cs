using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fasting.API.Data;

public class FastingDbContext : DbContext
{
    public FastingDbContext(DbContextOptions<FastingDbContext> options)
        : base(options) { }

    public DbSet<Fasting.API.Models.Domain.Fast> Fasts { get; set; }

    public DbSet<Duration> Durations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add default duration values
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Duration>()
            .HasData(
                new Duration
                {
                    Id = 1,
                    Name = "12",
                    Length = 12
                },
                new Duration
                {
                    Id = 2,
                    Name = "16",
                    Length = 16
                },
                new Duration
                {
                    Id = 3,
                    Name = "18",
                    Length = 18
                },
                new Duration
                {
                    Id = 4,
                    Name = "72",
                    Length = 72
                },
                new Duration
                {
                    Id = 5,
                    Name = "84",
                    Length = 84
                },
                new Duration
                {
                    Id = 6,
                    Name = "96",
                    Length = 96
                },
                new Duration { Id = 7, Name = "Custom" }
            );
    }
}
