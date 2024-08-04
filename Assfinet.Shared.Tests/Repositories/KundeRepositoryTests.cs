using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Assfinet.Shared.Tests.Repositories
{
    public class KundeRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                //Damit immer eine neue MemoryDb verwendet wird
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddKundeAsync_ValidKunde_AddsKundeToDatabase()
        {
            // Arrange
            var context = CreateContext();
            var repository = new KundeRepository(context);
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };

            // Act
            await repository.AddKundeAsync(kunde);

            // Assert
            var entity = await context.Kunden.FirstOrDefaultAsync(k => k.Id == kunde.Id);
            Assert.NotNull(entity);
            Assert.Equal(kunde.Id, entity.Id);
        }

        [Fact]
        public async Task AddKundeAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>()).Object;
            var repository = new KundeRepository(context);

            // Manually causing an exception
            var mockSet = new Mock<DbSet<Kunde>>();
            mockSet.Setup(m => m.Add(It.IsAny<Kunde>())).Throws(new Exception("Test exception"));
            context.Kunden = mockSet.Object;

            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RepositoryException>(() => repository.AddKundeAsync(kunde));
            Assert.Contains(
                $"Ein unerwarteter Fehler ist aufgetreten beim erstellen des Kunden. KundeId: '{kunde.Id}', AmsId: '{kunde.AmsId}'.",
                exception.Message);
        }

        [Fact]
        public async Task UpdateKundeAsync_ValidKunde_UpdatesKundeInDatabase()
        {
            // Arrange
            var context = CreateContext();
            var repository = new KundeRepository(context);
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };
            context.Kunden.Add(kunde);
            await context.SaveChangesAsync();
            kunde.Name = "Updated Kunde";

            // Act
            await repository.UpdateKundeAsync(kunde);

            // Assert
            var entity = await context.Kunden.FirstOrDefaultAsync(k => k.Id == kunde.Id);
            Assert.NotNull(entity);
            Assert.Equal("Updated Kunde", entity.Name);
        }

        [Fact]
        public async Task UpdateKundeAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>()).Object;
            var repository = new KundeRepository(context);

            // Manually causing an exception
            var mockSet = new Mock<DbSet<Kunde>>();
            mockSet.Setup(m => m.Update(It.IsAny<Kunde>())).Throws(new Exception("Test exception"));
            context.Kunden = mockSet.Object;

            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RepositoryException>(() => repository.UpdateKundeAsync(kunde));
            Assert.Contains(
                $"Ein unerwarteter Fehler ist aufgetreten beim aktualisieren des Kunden. KundeId: '{kunde.Id}', AmsId: '{kunde.AmsId}'.",
                exception.Message);
        }

        [Fact]
        public async Task GetKundeByAmsIdAsync_ValidAmsId_ReturnsKunde()
        {
            // Arrange
            var context = CreateContext();
            var repository = new KundeRepository(context);
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };
            context.Kunden.Add(kunde);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetKundeByAmsIdAsync(kunde.AmsId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kunde.Id, result.Id);
        }

        [Fact]
        public async Task GetKundeByAmsIdAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new KundeRepository(mockContext.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() => repository.GetKundeByAmsIdAsync(Guid.NewGuid()));
            Assert.Contains("Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Kunden mit AmsId",
                exception.Message);
        }

        [Fact]
        public async Task GetKundeByAmsidnrAsync_ValidAmsidnr_ReturnsKunde()
        {
            // Arrange
            var context = CreateContext();
            var repository = new KundeRepository(context);
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid(), Amsidnr = "123", Name = "Test Kunde" };
            context.Kunden.Add(kunde);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetKundeByAmsidnrAsync(kunde.Amsidnr);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kunde.Id, result.Id);
        }

        [Fact]
        public async Task GetKundeByAmsidnrAsync_ExceptionThrown_ThrowsRepositoryException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var mockContext = new Mock<ApplicationDbContext>(options);
            mockContext.Setup(db => db.SaveChangesAsync(default))
                .ThrowsAsync(new Exception("Test exception"));

            var repository = new KundeRepository(mockContext.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() => repository.GetKundeByAmsidnrAsync("123"));
            Assert.Contains("Ein unerwarteter Fehler ist aufgetreten beim Abrufen des Kunden mit Amsidnr",
                exception.Message);
        }
    }
}