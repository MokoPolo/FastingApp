using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fasting.API.Data;

public class FastingDbContext : DbContext
{
    public FastingDbContext(DbContextOptions<FastingDbContext> options)
        : base(options) { }

    public DbSet<Fasting.API.Models.Domain.Fast> Fasts { get; set; }

    public DbSet<Duration> Durations { get; set; }
}
