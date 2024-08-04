using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace Assfinet.Shared.Tests.Repositories
{
    public class VertragRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // Damit immer eine neue MemoryDb verwendet wird
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddVertragAsync_ValidVertrag_AddsVertragToDatabase()
        {
            // Arrange
            var context = CreateContext();
            var repository = new VertragRepository(context);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };

            // Act
            await repository.AddVertragAsync(vertrag);

            // Assert
            var entity = await context.Vertraege.FirstOrDefaultAsync(v => v.Id == vertrag.Id);
            Assert.NotNull(entity);
            Assert.Equal(vertrag.Id, entity.Id);
        }

        [Fact]
        public async Task AddVertragAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new VertragRepository(mockContext.Object);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RepositoryException>(() => repository.AddVertragAsync(vertrag));
            Assert.Contains(
                $"Ein unerwarteter Fehler ist aufgetreten beim erstellen des Vertrags. VertragId: '{vertrag.Id}', AmsId: '{vertrag.AmsId}'.",
                exception.Message);
        }

        [Fact]
        public async Task UpdateVertragAsync_ValidVertrag_UpdatesVertragInDatabase()
        {
            // Arrange
            var context = CreateContext();
            var repository = new VertragRepository(context);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };
            context.Vertraege.Add(vertrag);
            await context.SaveChangesAsync();
            vertrag.Key = "Updated Vertrag";

            // Act
            await repository.UpdateVertragAsync(vertrag);

            // Assert
            var entity = await context.Vertraege.FirstOrDefaultAsync(v => v.Id == vertrag.Id);
            Assert.NotNull(entity);
            Assert.Equal("Updated Vertrag", entity.Key);
        }

        [Fact]
        public async Task UpdateVertragAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new VertragRepository(mockContext.Object);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RepositoryException>(() => repository.UpdateVertragAsync(vertrag));
            Assert.Contains(
                $"Ein unerwarteter Fehler ist aufgetreten beim aktualisieren des Vertrags. VertragId: '{vertrag.Id}', AmsId: '{vertrag.AmsId}'.",
                exception.Message);
        }

        [Fact]
        public async Task GetVertragByAmsIdAsync_ValidAmsId_ReturnsVertrag()
        {
            // Arrange
            var context = CreateContext();
            var repository = new VertragRepository(context);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };
            context.Vertraege.Add(vertrag);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetVertragByAmsIdAsync(vertrag.AmsId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag.Id, result.Id);
        }

        [Fact]
        public async Task GetVertragByAmsIdAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new VertragRepository(mockContext.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() => repository.GetVertragByAmsIdAsync(Guid.NewGuid()));
            Assert.Contains("Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Vertrags mit AmsId",
                exception.Message);
        }

        [Fact]
        public async Task GetVertragByAmsidnrAsync_ValidAmsidnr_ReturnsVertrag()
        {
            // Arrange
            var context = CreateContext();
            var repository = new VertragRepository(context);
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Key = "Test Vertrag" };
            context.Vertraege.Add(vertrag);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetVertragByAmsidnrAsync(vertrag.Amsidnr);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag.Id, result.Id);
        }

        [Fact]
        public async Task GetVertragByAmsidnrAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new VertragRepository(mockContext.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() => repository.GetVertragByAmsidnrAsync("123"));
            Assert.Contains("Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Vertrags mit Amsidnr",
                exception.Message);
        }
    }
}