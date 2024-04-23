using Fasting.API.Data;
using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fasting.API;

public class FastingRepository : IFastingRepository
{
    private readonly FastingDbContext _dbContext;
    private readonly ILogger<FastingRepository> _logger;

    public FastingRepository(FastingDbContext context, ILogger<FastingRepository> logger)
    {
        _dbContext = context;
        _logger = logger;
    }

    public async Task<FastDomain> CreateAsync(FastDomain fast)
    {
        try
        {
            _logger.LogInformation("Creating fast");
            await _dbContext.Fasts.AddAsync(fast);
            await _dbContext.SaveChangesAsync();

            return fast;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating fast");
            throw;
        }
    }

    public async Task<List<FastDomain>> GetAllAsync()
    {
        return await _dbContext.Fasts.ToListAsync();
    }

    public async Task<FastDomain?> GetByIdAsync(int id)
    {
        return await _dbContext.Fasts.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<FastDomain?> UpdateAsync(int id, FastDomain fast)
    {
        try
        {
            _logger.LogInformation("Updating fast");
            var existingFast = _dbContext.Fasts.FirstOrDefault(f => fast.Id == id);

            if (existingFast == null)
            {
                return null;
            }

            existingFast.Start = fast.Start;
            existingFast.End = fast.End;
            existingFast.Duration = fast.Duration;

            await _dbContext.SaveChangesAsync();

            return existingFast;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating fast");
            throw;
        }
    }
}
