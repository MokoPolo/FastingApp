using Fasting.API.Data;
using Fasting.API.Models.Domain;

namespace Fasting.API;

public class FastingRepository : IFastingRepository
{
    private readonly FastingDbContext dbContext;

    public FastingRepository(FastingDbContext context)
    {
        dbContext = context;
    }

    public async Task<FastDomain> CreateAsync(FastDomain fast)
    {
        await dbContext.Fasts.AddAsync(fast);
        await dbContext.SaveChangesAsync();

        return fast;
    }

    public async Task<FastDomain?> UpdateAsync(int id, FastDomain fast)
    {
        var existingFast = dbContext.Fasts.FirstOrDefault(f => fast.Id == id);

        if (existingFast == null)
        {
            return null;
        }

        existingFast.Start = fast.Start;
        existingFast.End = fast.End;
        existingFast.Duration = fast.Duration;

        await dbContext.SaveChangesAsync();

        return existingFast;
    }
}
