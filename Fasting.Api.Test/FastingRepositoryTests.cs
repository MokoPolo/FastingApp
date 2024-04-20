using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Fasting.API;
using Fasting.API.Data;
using Fasting.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

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
    public void TestName() { }

    [Fact]
    public async Task CreateAsync_ShouldAddAndSave()
    {
        var fast = new FastDomain();
        var dbSetMock = new Mock<DbSet<FastDomain>>();

        dbContextMock.Setup(x => x.Fasts).Returns(dbSetMock.Object);

        var result = await fastingRepository.CreateAsync(fast);

        dbSetMock.Verify(x => x.AddAsync(fast, It.IsAny<CancellationToken>()), Times.Once);
        dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(fast, result);
    }

    // [Fact]
    // public async Task UpdateAsync_ShouldUpdateAndSave()
    // {
    //     var fast = new FastDomain
    //     {
    //         Id = 1,
    //         Start = DateTime.Now,
    //         End = DateTime.Now.AddHours(1),
    //         Duration = 1
    //     };
    //     var dbSetMock = new Mock<DbSet<FastDomain>>();
    //     dbSetMock
    //         .As<IQueryable<FastDomain>>()
    //         .Setup(m => m.Provider)
    //         .Returns(
    //             new List<FastDomain> { fast }
    //                 .AsQueryable()
    //                 .Provider
    //         );
    //     dbSetMock
    //         .As<IQueryable<FastDomain>>()
    //         .Setup(m => m.Expression)
    //         .Returns(
    //             new List<FastDomain> { fast }
    //                 .AsQueryable()
    //                 .Expression
    //         );
    //     dbSetMock
    //         .As<IQueryable<FastDomain>>()
    //         .Setup(m => m.ElementType)
    //         .Returns(
    //             new List<FastDomain> { fast }
    //                 .AsQueryable()
    //                 .ElementType
    //         );
    //     dbSetMock
    //         .As<IQueryable<FastDomain>>()
    //         .Setup(m => m.GetEnumerator())
    //         .Returns(
    //             new List<FastDomain> { fast }
    //                 .AsQueryable()
    //                 .GetEnumerator()
    //         );

    //     dbContextMock.Setup(x => x.Fasts).Returns(dbSetMock.Object);

    //     var updatedFast = new FastDomain
    //     {
    //         Id = 1,
    //         Start = DateTime.Now.AddHours(2),
    //         End = DateTime.Now.AddHours(3),
    //         Duration = 1
    //     };
    //     var result = await fastingRepository.UpdateAsync(1, updatedFast);

    //     dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    //     Assert.Equal(updatedFast.Start, result.Start);
    //     Assert.Equal(updatedFast.End, result.End);
    //     Assert.Equal(updatedFast.Duration, result.Duration);
    // }
}
