using Fasting.API.Data;
using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fasting.API;

public class FastingRepository : IFastingRepository
{
    private readonly FastingDbContext _dbContext;
    private readonly ILogger<FastingRepository> _logger;

    private void LogInformation(string v)
    {
        _logger.LogInformation(v);
    }

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
        try
        {
            _logger.LogInformation("Get all fasts");
            return await _dbContext.Fasts.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all fasts");
            throw;
        }
    }

    public async Task<FastDomain?> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Get fast by ID");
            return await _dbContext.Fasts.FirstOrDefaultAsync(f => f.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting fast by ID");
            throw;
        }
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
