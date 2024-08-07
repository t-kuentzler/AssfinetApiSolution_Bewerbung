using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Assfinet.Shared.Tests.Repositories
{
    // public class GenericSparteRepositoryTests
    // {
    //     private readonly ApplicationDbContext _dbContext;
    //     private readonly GenericSparteRepository<KrvSparte> _repository;
    //
    //     public GenericSparteRepositoryTests()
    //     {
    //         var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //             .UseInMemoryDatabase(databaseName: "TestDatabase")
    //             .Options;
    //
    //         _dbContext = new ApplicationDbContext(options);
    //         _repository = new GenericSparteRepository<KrvSparte>(_dbContext);
    //     }
    //
    //     [Fact]
    //     public async Task AddAsync_ValidEntity_AddsEntityToDatabase()
    //     {
    //         // Arrange
    //         var sparte = new KrvSparte { AmsId = Guid.NewGuid(), Key = "testKey", Amsidnr = "123", Typ = "KRV" };
    //
    //         // Act
    //         await _repository.AddAsync(sparte);
    //
    //         // Assert
    //         var entity = await _dbContext.Set<KrvSparte>().FirstOrDefaultAsync(s => s.AmsId == sparte.AmsId);
    //         Assert.NotNull(entity);
    //         Assert.Equal(sparte.AmsId, entity.AmsId);
    //     }
    //
    //     [Fact]
    //     public async Task AddAsync_ExceptionThrown_ThrowsRepositoryException()
    //     {
    //         // Arrange
    //         var mockDbSet = new Mock<DbSet<KrvSparte>>();
    //         mockDbSet.Setup(m => m.AddAsync(It.IsAny<KrvSparte>(), default)).Throws(new Exception("Test exception"));
    //
    //         var mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
    //         mockContext.Setup(m => m.Set<KrvSparte>()).Returns(mockDbSet.Object);
    //
    //         var repository = new GenericSparteRepository<KrvSparte>(mockContext.Object);
    //
    //         var sparte = new KrvSparte { AmsId = Guid.NewGuid(), Key = "testKey" };
    //
    //         // Act & Assert
    //         var exception = await Assert.ThrowsAsync<RepositoryException>(() => repository.AddAsync(sparte));
    //         Assert.Contains("Ein unerwarteter Fehler ist beim Hinzufügen von 'KrvSparte' aufgetreten.",
    //             exception.Message);
    //     }
    //
    //     [Fact]
    //     public async Task GetSparteByAmsIdAsync_ValidAmsId_ReturnsEntity()
    //     {
    //         // Arrange
    //         var sparte = new KrvSparte { AmsId = Guid.NewGuid(), Key = "testKey", Amsidnr = "123", Typ = "KRV" };
    //         _dbContext.Set<KrvSparte>().Add(sparte);
    //         await _dbContext.SaveChangesAsync();
    //
    //         // Act
    //         var result = await _repository.GetSparteByAmsIdAsync(sparte.AmsId);
    //
    //         // Assert
    //         Assert.NotNull(result);
    //         Assert.Equal(sparte.AmsId, result.AmsId);
    //     }
    //
    //     [Fact]
    //     public async Task GetSparteByAmsIdAsync_InvalidAmsId_ReturnsNull()
    //     {
    //         // Arrange
    //         var invalidAmsId = Guid.NewGuid();
    //
    //         // Act
    //         var result = await _repository.GetSparteByAmsIdAsync(invalidAmsId);
    //
    //         // Assert
    //         Assert.Null(result);
    //     }
    //
    //     [Fact]
    //     public async Task GetSparteByAmsIdAsync_ExceptionThrown_ThrowsRepositoryException()
    //     {
    //         // Arrange
    //         var mockDbSet = new Mock<DbSet<KrvSparte>>();
    //         mockDbSet.Setup(m => m.Add(It.IsAny<KrvSparte>())).Throws(new Exception("Test exception"));
    //
    //         var mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
    //         mockContext.Setup(m => m.Set<KrvSparte>()).Returns(mockDbSet.Object);
    //
    //         var repository = new GenericSparteRepository<KrvSparte>(mockContext.Object);
    //
    //         // Act & Assert
    //         var exception =
    //             await Assert.ThrowsAsync<RepositoryException>(() => repository.GetSparteByAmsIdAsync(Guid.NewGuid()));
    //         Assert.Contains("Ein unerwarteter Fehler ist beim Abrufen von 'KrvSparte' mit AmsId", exception.Message);
    //     }
    // }
}