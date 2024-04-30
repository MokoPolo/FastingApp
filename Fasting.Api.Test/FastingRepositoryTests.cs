// using System.Collections.Generic;
// using System.Linq;
using Fasting.API;
using Fasting.API.Data;
using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Fasting.Api.Test;

public class FastingRepositoryTests
{
    private readonly Mock<FastingDbContext> dbContextMock;
    private readonly FastingRepository fastingRepository;
    private readonly Mock<ILogger<FastingRepository>> loggerMock;

    public FastingRepositoryTests()
    {
        dbContextMock = new Mock<FastingDbContext>();
        loggerMock = new Mock<ILogger<FastingRepository>>();
        fastingRepository = new FastingRepository(dbContextMock.Object, loggerMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddAndSave()
    {
        var fastDomain = new FastDomain();
        var dbSetMock = new Mock<DbSet<FastDomain>>();

        dbContextMock.Setup(x => x.Fasts).Returns(dbSetMock.Object);

        var repo = new FastingRepository(dbContextMock.Object, loggerMock.Object);

        var result = await repo.CreateAsync(fastDomain);

        dbSetMock.Verify(x => x.AddAsync(fastDomain, It.IsAny<CancellationToken>()), Times.Once);
        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(fastDomain, result);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllFasts()
    {
        // Arrange
        var data = new List<FastDomain>
        {
            new FastDomain { Id = 1 },
            new FastDomain { Id = 2 },
            new FastDomain { Id = 3 }
        };

        var mockSet = new Mock<DbSet<FastDomain>>();

        var mockContext = new Mock<FastingDbContext>();
        mockContext.Setup(c => c.Fasts).ReturnsDbSet(data);

        // Act
        var service = new FastingRepository(mockContext.Object, loggerMock.Object);
        var fasts = await service.GetAllAsync();

        // Assert
        Assert.Equal(3, fasts.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFast()
    {
        // Arrange
        var data = new List<FastDomain>
        {
            new FastDomain { Id = 1 },
            new FastDomain { Id = 2 },
            new FastDomain { Id = 3 }
        };

        var mockContext = new Mock<FastingDbContext>();
        mockContext.Setup(c => c.Fasts).ReturnsDbSet(data);

        // Act
        var service = new FastingRepository(mockContext.Object, loggerMock.Object);
        var fast = await service.GetByIdAsync(2);

        // Assert
        Assert.Equal(2, fast?.Id);
    }

    [Fact]
    public async Task DeleteById_ShouldRemoveItem()
    {
        // Arrange
        var data = new List<FastDomain>()
        {
            new FastDomain { Id = 1 },
            new FastDomain { Id = 2 },
            new FastDomain { Id = 3 }
        };

        // Act
        var mockContext = new Mock<FastingDbContext>();
        var mockLogger = new Mock<ILogger<FastingRepository>>();

        var service = new FastingRepository(mockContext.Object, loggerMock.Object);
        mockContext.Setup(c => c.Fasts).ReturnsDbSet(data);

        var foo = await service.DeleteAsync(2);

        // Assert
        Assert.Equal(2, foo?.Id);
    }
}




// https://www.thereformedprogrammer.net/using-in-memory-databases-for-unit-testing-ef-core-applications/
// https://medium.com/codenx/ef-core-in-memory-database-unit-testing-02d4658a9c78
