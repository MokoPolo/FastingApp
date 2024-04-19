using Fasting.API.Models.Domain;

namespace Fasting.API;

public interface IFastingRepository
{
    Task<FastDomain> CreateAsync(FastDomain fast);

    Task<FastDomain?> UpdateAsync(int id, FastDomain fast);
}
