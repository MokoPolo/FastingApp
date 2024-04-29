using Fasting.API.Models.Domain;

namespace Fasting.API;

public interface IFastingRepository
{
    Task<FastDomain> CreateAsync(FastDomain fast);
    Task<List<FastDomain>> GetAllAsync();

    Task<FastDomain?> GetByIdAsync(int id);
    Task<FastDomain?> UpdateAsync(FastDomain fast);
}
