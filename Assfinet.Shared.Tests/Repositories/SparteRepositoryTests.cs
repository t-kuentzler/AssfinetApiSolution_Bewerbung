using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Repositories;
using Assfinet.Shared.Tests.Models;
using Moq;

namespace Assfinet.Shared.Tests.Repositories
{
    public class SparteRepositoryTests
    {
        private readonly Mock<IServiceProvider> _serviceProviderMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly SparteRepository _sparteRepository;

        public SparteRepositoryTests()
        {
            _serviceProviderMock = new Mock<IServiceProvider>();
            _loggerMock = new Mock<IAppLogger>();
            _sparteRepository = new SparteRepository(_serviceProviderMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task AddAsync_UnknownSparte_ThrowsUnknownSparteException()
        {
            // Arrange
            var sparte = new SparteTestModel { Key = "testKey" };

            _serviceProviderMock.Setup(sp => sp.GetService(It.IsAny<Type>())).Returns(null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<UnknownSparteException>(() => _sparteRepository.AddAsync(sparte));
            Assert.Contains($"Die Sparte '{sparte.GetType().FullName}' ist unbekannt.", exception.Message);
        }

        [Fact]
        public async Task AddAsync_ValidSparte_AddsEntity()
        {
            // Arrange
            var sparte = new SparteTestEntity { AmsId = Guid.NewGuid(), Key = "testKey" };
            var repositoryMock = new Mock<IGenericSparteRepository<SparteTestEntity>>();

            _serviceProviderMock.Setup(sp => sp.GetService(typeof(IGenericSparteRepository<SparteTestEntity>)))
                .Returns(repositoryMock.Object);

            // Act
            await _sparteRepository.AddAsync(sparte);

            // Assert
            repositoryMock.Verify(r => r.AddAsync(sparte), Times.Once);
        }

        [Fact]
        public async Task AddAsync_RepositoryException_ThrowsRepositoryException()
        {
            // Arrange
            var sparte = new SparteTestEntity { AmsId = Guid.NewGuid(), Key = "testKey" };
            var repositoryMock = new Mock<IGenericSparteRepository<SparteTestEntity>>();

            repositoryMock.Setup(r => r.AddAsync(It.IsAny<SparteTestEntity>()))
                .Throws(new RepositoryException("Test repository exception"));

            _serviceProviderMock.Setup(sp => sp.GetService(typeof(IGenericSparteRepository<SparteTestEntity>)))
                .Returns(repositoryMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<RepositoryException>(() => _sparteRepository.AddAsync(sparte));
            Assert.Contains("Test repository exception", exception.Message);
        }

        [Fact]
        public async Task GetSparteByAmsIdAsync_UnknownSparte_ThrowsUnknownSparteException()
        {
            // Arrange
            var amsId = Guid.NewGuid();
            var sparteType = typeof(SparteTestEntity);

            _serviceProviderMock.Setup(sp => sp.GetService(It.IsAny<Type>())).Returns(null);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<UnknownSparteException>(() =>
                    _sparteRepository.GetSparteByAmsIdAsync(amsId, sparteType));
            Assert.Contains("Unbekannte Sparte", exception.Message);
            _loggerMock.Verify(
                l => l.LogError(It.Is<string>(s => s.Contains($"Unbekannter Repository-Typ '{sparteType.FullName}'."))),
                Times.Once);
        }

        [Fact]
        public async Task GetSparteByAmsIdAsync_ValidSparte_ReturnsEntity()
        {
            // Arrange
            var amsId = Guid.NewGuid();
            var sparteType = typeof(SparteTestEntity);
            var sparte = new SparteTestEntity { AmsId = amsId, Key = "testKey" };
            var repositoryMock = new Mock<IGenericSparteRepository<SparteTestEntity>>();

            repositoryMock.Setup(r => r.GetSparteByAmsIdAsync(It.IsAny<Guid>())).ReturnsAsync(sparte);

            _serviceProviderMock.Setup(sp => sp.GetService(typeof(IGenericSparteRepository<SparteTestEntity>)))
                .Returns(repositoryMock.Object);

            // Act
            var result = await _sparteRepository.GetSparteByAmsIdAsync(amsId, sparteType);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SparteTestEntity>(result);
            Assert.Equal(amsId, ((SparteTestEntity)result).AmsId);
        }

        [Fact]
        public async Task GetSparteByAmsIdAsync_RepositoryException_ThrowsRepositoryException()
        {
            // Arrange
            var amsId = Guid.NewGuid();
            var sparteType = typeof(SparteTestEntity);
            var repositoryMock = new Mock<IGenericSparteRepository<SparteTestEntity>>();

            repositoryMock.Setup(r => r.GetSparteByAmsIdAsync(It.IsAny<Guid>()))
                .Throws(new RepositoryException("Test repository exception"));

            _serviceProviderMock.Setup(sp => sp.GetService(typeof(IGenericSparteRepository<SparteTestEntity>)))
                .Returns(repositoryMock.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() =>
                    _sparteRepository.GetSparteByAmsIdAsync(amsId, sparteType));
            Assert.Contains("Test repository exception", exception.Message);

            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s =>
                        s.Contains(
                            $"Ein Fehler ist beim Abrufen von '{sparteType.Name}' mit AmsId '{amsId}' aufgetreten.")),
                    It.IsAny<RepositoryException>()),
                Times.Once);
        }

        [Fact]
        public async Task GetSparteByAmsIdAsync_UnexpectedException_ThrowsRepositoryException()
        {
            // Arrange
            var amsId = Guid.NewGuid();
            var sparteType = typeof(SparteTestEntity);
            var repositoryMock = new Mock<IGenericSparteRepository<SparteTestEntity>>();

            repositoryMock.Setup(r => r.GetSparteByAmsIdAsync(It.IsAny<Guid>()))
                .Throws(new Exception("Test exception"));

            _serviceProviderMock.Setup(sp => sp.GetService(typeof(IGenericSparteRepository<SparteTestEntity>)))
                .Returns(repositoryMock.Object);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() =>
                    _sparteRepository.GetSparteByAmsIdAsync(amsId, sparteType));
            Assert.Contains(
                $"Ein unerwarteter Fehler ist beim Abrufen von '{sparteType.Name}' mit AmsId '{amsId}' aufgetreten.",
                exception.Message);

            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s =>
                        s.Contains(
                            $"Ein unerwarteter Fehler ist beim Abrufen von '{sparteType.Name}' mit AmsId '{amsId}' aufgetreten.")),
                    It.IsAny<Exception>()),
                Times.Once);
        }
    }
}