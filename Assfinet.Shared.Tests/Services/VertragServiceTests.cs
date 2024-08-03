using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Models;
using Assfinet.Shared.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class VertragServiceTests
    {
        private readonly Mock<IVertragParserService> _vertragParserServiceMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<IVertragProcessingService> _vertragProcessingServiceMock;
        private readonly VertragService _vertragService;

        public VertragServiceTests()
        {
            _vertragParserServiceMock = new Mock<IVertragParserService>();
            _loggerMock = new Mock<IAppLogger>();
            _vertragProcessingServiceMock = new Mock<IVertragProcessingService>();
            _vertragService = new VertragService(_vertragParserServiceMock.Object, _loggerMock.Object, _vertragProcessingServiceMock.Object);
        }

        [Fact]
        public async Task ImportVertraegeAsync_NoContracts_LogsWarning()
        {
            var vertraegeModels = new List<VertragModel>();

            await _vertragService.ImportVertraegeAsync(vertraegeModels);

            _loggerMock.Verify(l => l.LogWarning("Es wurden 0 Verträge von der API abgerufen."), Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_ValidContracts_ProcessesSuccessfully()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Returns(vertrag);
            _vertragProcessingServiceMock.Setup(p => p.ValidateVertragAsync(vertrag)).Returns(Task.CompletedTask);
            _vertragProcessingServiceMock.Setup(p => p.ProcessImportVertragAsync(vertrag)).Returns(Task.CompletedTask);

            await _vertragService.ImportVertraegeAsync(vertraegeModels);

            _loggerMock.Verify(l => l.LogInformation($"Es wurden {vertraegeModels.Count} Verträge von der API abgerufen."), Times.Once);
            _vertragParserServiceMock.Verify(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>()), Times.Once);
            _vertragProcessingServiceMock.Verify(p => p.ValidateVertragAsync(vertrag), Times.Once);
            _vertragProcessingServiceMock.Verify(p => p.ProcessImportVertragAsync(vertrag), Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_ArgumentNullException_LogsError()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Throws(new ArgumentNullException());

            await Assert.ThrowsAsync<ArgumentNullException>(() => _vertragService.ImportVertraegeAsync(vertraegeModels));

            _loggerMock.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<ArgumentNullException>()), Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_InvalidOperationException_LogsError()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Throws(new InvalidOperationException());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _vertragService.ImportVertraegeAsync(vertraegeModels));

            _loggerMock.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<InvalidOperationException>()), Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_ValidationFails_LogsError()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("AmsId", "Validation failed") });

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Returns(vertrag);
            _vertragProcessingServiceMock.Setup(p => p.ValidateVertragAsync(vertrag)).ThrowsAsync(new ValidationException(validationResult.Errors));

            await Assert.ThrowsAsync<ValidationException>(() => _vertragService.ImportVertraegeAsync(vertraegeModels));

            _loggerMock.Verify(
                l => l.LogError(It.Is<string>(s => s.Contains($"Bei dem Vertrag mit der AmsId '{vertraegeModels[0].Id}' ist ein Validierungsfehler aufgetreten: Validation failed")), 
                It.IsAny<ValidationException>()), 
                Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_RepositoryException_LogsError()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Returns(vertrag);
            _vertragProcessingServiceMock.Setup(p => p.ValidateVertragAsync(vertrag)).Returns(Task.CompletedTask);
            _vertragProcessingServiceMock.Setup(p => p.ProcessImportVertragAsync(vertrag)).ThrowsAsync(new RepositoryException("Repository error"));

            await Assert.ThrowsAsync<RepositoryException>(() => _vertragService.ImportVertraegeAsync(vertraegeModels));

            _loggerMock.Verify(l => l.LogError($"Repository-Exception beim Importieren von dem Vertrag mit der AmsId '{vertraegeModels[0].Id}'.", It.IsAny<RepositoryException>()), Times.Once);
        }

        [Fact]
        public async Task ImportVertraegeAsync_UnexpectedException_LogsError()
        {
            var vertraegeModels = new List<VertragModel> { new VertragModel { Id = Guid.NewGuid() } };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _vertragParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<VertragModel>())).Returns(vertrag);
            _vertragProcessingServiceMock.Setup(p => p.ValidateVertragAsync(vertrag)).Returns(Task.CompletedTask);
            _vertragProcessingServiceMock.Setup(p => p.ProcessImportVertragAsync(vertrag)).ThrowsAsync(new Exception("Unexpected error"));

            await Assert.ThrowsAsync<VertragServiceException>(() => _vertragService.ImportVertraegeAsync(vertraegeModels));

            _loggerMock.Verify(l => l.LogError($"Es ist ein unerwarteter Fehler beim Importieren von dem Vertrag mit der AmsId '{vertraegeModels[0].Id}' aufgetreten.", It.IsAny<Exception>()), Times.Once);
        }
    }
}
