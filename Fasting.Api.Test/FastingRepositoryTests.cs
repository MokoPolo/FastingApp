using Fasting.API;
using Fasting.API.Data;
using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Fasting.Api.Test;

public class FastingRepositoryTests
{
    private readonly Mock<FastingDbContext> dbContextMock;
    private readonly FastingRepository fastingRepository;

    public FastingRepositoryTests()
    {
        dbContextMock = new Mock<FastingDbContext>();
        fastingRepository = new FastingRepository(dbContextMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddAndSave()
    {
        var fastDomain = new FastDomain();
        var dbSetMock = new Mock<DbSet<FastDomain>>();

        dbContextMock.Setup(x => x.Fasts).Returns(dbSetMock.Object);

        var repo = new FastingRepository(dbContextMock.Object);

        var result = await repo.CreateAsync(fastDomain);

        dbSetMock.Verify(x => x.AddAsync(fastDomain, It.IsAny<CancellationToken>()), Times.Once);
        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(fastDomain, result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAndSave() { }
}
