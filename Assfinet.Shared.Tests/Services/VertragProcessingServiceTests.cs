using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class VertragProcessingServiceTests
    {
        private readonly Mock<IValidatorWrapper<Vertrag>> _validatorMock;
        private readonly Mock<IVertragRepository> _vertragRepositoryMock;
        private readonly Mock<IKundeRepository> _kundeRepositoryMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly VertragProcessingService _vertragProcessingService;

        public VertragProcessingServiceTests()
        {
            _validatorMock = new Mock<IValidatorWrapper<Vertrag>>();
            _vertragRepositoryMock = new Mock<IVertragRepository>();
            _kundeRepositoryMock = new Mock<IKundeRepository>();
            _loggerMock = new Mock<IAppLogger>();
            _vertragProcessingService = new VertragProcessingService(_validatorMock.Object, _vertragRepositoryMock.Object, _kundeRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task ValidateVertragAsync_ValidVertrag_DoesNotThrow()
        {
            // Arrange
            var vertrag = new Vertrag { AmsId = Guid.NewGuid() };
            _validatorMock.Setup(v => v.ValidateAndThrowAsync(vertrag)).Returns(Task.CompletedTask);

            // Act & Assert
            await _vertragProcessingService.ValidateVertragAsync(vertrag);

            _validatorMock.Verify(v => v.ValidateAndThrowAsync(vertrag), Times.Once);
        }

        [Fact]
        public async Task ValidateVertragAsync_InvalidVertrag_ThrowsValidationException()
        {
            // Arrange
            var vertrag = new Vertrag { AmsId = Guid.NewGuid() };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("AmsId", "Validation failed") });
            _validatorMock.Setup(v => v.ValidateAndThrowAsync(vertrag)).ThrowsAsync(new ValidationException(validationResult.Errors));

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _vertragProcessingService.ValidateVertragAsync(vertrag));

            _validatorMock.Verify(v => v.ValidateAndThrowAsync(vertrag), Times.Once);
        }

        [Fact]
        public async Task ProcessImportVertragAsync_ValidVertrag_ProcessesSuccessfully()
        {
            // Arrange
            var vertrag = new Vertrag { AmsId = Guid.NewGuid(), Key = "12345" };
            var existingKunde = new Kunde { Amsidnr = "12345" };

            _kundeRepositoryMock.Setup(k => k.GetKundeByAmsidnrAsync(vertrag.Key)).ReturnsAsync(existingKunde);
            _vertragRepositoryMock.Setup(v => v.GetVertragByAmsIdAsync(vertrag.AmsId)).ReturnsAsync((Vertrag?)null);

            // Act
            await _vertragProcessingService.ProcessImportVertragAsync(vertrag);

            // Assert
            _loggerMock.Verify(l => l.LogInformation(It.Is<string>(s => s.Contains($"Es wird versucht, den Vertrag mit der AmsId '{vertrag.AmsId}' in der Datenbank zu erstellen."))), Times.Once);
            _vertragRepositoryMock.Verify(v => v.AddVertragAsync(vertrag), Times.Once);
            _loggerMock.Verify(l => l.LogInformation(It.Is<string>(s => s.Contains($"Der Vertrag mit der AmsId '{vertrag.AmsId}' wurde erfolgreich in der Datenbank erstellt."))), Times.Once);
        }

        [Fact]
        public async Task ProcessImportVertragAsync_KundeNotFound_LogsError()
        {
            // Arrange
            var vertrag = new Vertrag { AmsId = Guid.NewGuid(), Key = "12345" };

            _kundeRepositoryMock.Setup(k => k.GetKundeByAmsidnrAsync(vertrag.Key)).ReturnsAsync((Kunde?)null);

            // Act
            await _vertragProcessingService.ProcessImportVertragAsync(vertrag);

            // Assert
            _loggerMock.Verify(l => l.LogError(It.Is<string>(s => s.Contains($"Der Vertrag mit dem Key '{vertrag.Key}' konnte nicht in der Datenbank erstellt werden, da kein Kunde mit der entsprechenden Amsidnr gefunden wurde."))), Times.Once);
            _vertragRepositoryMock.Verify(v => v.AddVertragAsync(It.IsAny<Vertrag>()), Times.Never);
        }

        [Fact]
        public async Task ProcessImportVertragAsync_VertragAlreadyExists_LogsError()
        {
            // Arrange
            var vertrag = new Vertrag { AmsId = Guid.NewGuid(), Key = "12345" };
            var existingKunde = new Kunde { Amsidnr = "12345" };
            var existingVertrag = new Vertrag { AmsId = vertrag.AmsId };

            _kundeRepositoryMock.Setup(k => k.GetKundeByAmsidnrAsync(vertrag.Key)).ReturnsAsync(existingKunde);
            _vertragRepositoryMock.Setup(v => v.GetVertragByAmsIdAsync(vertrag.AmsId)).ReturnsAsync(existingVertrag);

            // Act
            await _vertragProcessingService.ProcessImportVertragAsync(vertrag);

            // Assert
            _loggerMock.Verify(l => l.LogError(It.Is<string>(s => s.Contains($"Der Vertrag mit der AmsId '{vertrag.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert."))), Times.Once);
            _vertragRepositoryMock.Verify(v => v.AddVertragAsync(It.IsAny<Vertrag>()), Times.Never);
        }
    }
}
