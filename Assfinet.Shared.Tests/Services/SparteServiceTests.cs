using Assfinet.Shared.Contracts;
using Assfinet.Shared.Exceptions;
using Assfinet.Shared.Services;
using Assfinet.Shared.Tests.Models;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class SparteServiceTests
    {
        private readonly Mock<ISparteParserService> _sparteParserServiceMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<ISparteProcessingService> _sparteProcessingServiceMock;
        private readonly SparteService _sparteService;

        public SparteServiceTests()
        {
            _sparteParserServiceMock = new Mock<ISparteParserService>();
            _loggerMock = new Mock<IAppLogger>();
            _sparteProcessingServiceMock = new Mock<ISparteProcessingService>();
            _sparteService = new SparteService(
                _sparteParserServiceMock.Object,
                _loggerMock.Object,
                _sparteProcessingServiceMock.Object
            );
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_NoSparten_LogsWarning()
        {
            // Arrange
            var spartenModels = new List<object>();

            // Act
            await _sparteService.ImportSpartenDatenAsync(spartenModels);

            // Assert
            _loggerMock.Verify(l => l.LogWarning("Es wurden 0 Spartendaten von der API abgerufen."), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ValidSparten_ProcessesSuccessfully()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };
            var parsedSparte = new { Key = "testKey" };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(parsedSparte);
            _sparteProcessingServiceMock.Setup(p => p.ValidateSparteAsync(parsedSparte)).Returns(Task.CompletedTask);
            _sparteProcessingServiceMock.Setup(p => p.ProcessImportSparteAsync(parsedSparte))
                .Returns(Task.CompletedTask);

            // Act
            await _sparteService.ImportSpartenDatenAsync(spartenModels);

            // Assert
            _loggerMock.Verify(
                l => l.LogInformation($"Es wurden {spartenModels.Count} Spartendaten von der API abgerufen."),
                Times.Once);
            _sparteParserServiceMock.Verify(p => p.ParseSparteModel(It.IsAny<object>()), Times.Once);
            _sparteProcessingServiceMock.Verify(p => p.ValidateSparteAsync(parsedSparte), Times.Once);
            _sparteProcessingServiceMock.Verify(p => p.ProcessImportSparteAsync(parsedSparte), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ArgumentNullException_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>()))
                .Throws(new ArgumentNullException());

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s =>
                        s.Contains("ArgumentNullException beim Importieren von den Spartendaten mit dem Key")),
                    It.IsAny<ArgumentNullException>()), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_InvalidOperationException_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>()))
                .Throws(new InvalidOperationException());

            // Act
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s =>
                        s.Contains("InvalidOperationException beim Importieren von den Spartendaten mit dem Key")),
                    It.IsAny<InvalidOperationException>()), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ValidationFails_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };
            var parsedSparte = new { Key = "testKey" };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("Key", "Validation failed") });

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(parsedSparte);
            _sparteProcessingServiceMock.Setup(p => p.ValidateSparteAsync(parsedSparte))
                .ThrowsAsync(new ValidationException(validationResult.Errors));

            // Act
            await Assert.ThrowsAsync<ValidationException>(() => _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(It.Is<string>(s => s.Contains("Validierungsfehler bei Spartendaten mit dem Key")),
                    It.IsAny<ValidationException>()), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_UnknownSparteException_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };
            var parsedSparte = new { Key = "testKey" };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(parsedSparte);
            _sparteProcessingServiceMock.Setup(p => p.ValidateSparteAsync(parsedSparte)).Returns(Task.CompletedTask);
            _sparteProcessingServiceMock.Setup(p => p.ProcessImportSparteAsync(parsedSparte))
                .ThrowsAsync(new UnknownSparteException("Unknown sparte error"));

            // Act
            await Assert.ThrowsAsync<UnknownSparteException>(
                () => _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s =>
                        s.Contains("UnknownSparteException beim Importieren von den Spartendaten mit dem Key")),
                    It.IsAny<UnknownSparteException>()), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_RepositoryException_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };
            var parsedSparte = new { Key = "testKey" };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(parsedSparte);
            _sparteProcessingServiceMock.Setup(p => p.ValidateSparteAsync(parsedSparte)).Returns(Task.CompletedTask);
            _sparteProcessingServiceMock.Setup(p => p.ProcessImportSparteAsync(parsedSparte))
                .ThrowsAsync(new RepositoryException("Repository error"));

            // Act
            await Assert.ThrowsAsync<RepositoryException>(() => _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s => s.Contains("Repository-Fehler beim Import von Spartendaten mit dem Key")),
                    It.IsAny<RepositoryException>()), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_UnexpectedException_LogsError()
        {
            // Arrange
            var spartenModels = new List<object> { new SparteTestModel { Key = "testKey" } };
            var parsedSparte = new { Key = "testKey" };

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(parsedSparte);
            _sparteProcessingServiceMock.Setup(p => p.ValidateSparteAsync(parsedSparte)).Returns(Task.CompletedTask);
            _sparteProcessingServiceMock.Setup(p => p.ProcessImportSparteAsync(parsedSparte))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            await Assert.ThrowsAsync<SparteServiceException>(
                () => _sparteService.ImportSpartenDatenAsync(spartenModels));

            // Assert
            _loggerMock.Verify(
                l => l.LogError(
                    It.Is<string>(s => s.Contains("Unerwarteter Fehler beim Import von Spartendaten mit dem Key")),
                    It.IsAny<Exception>()), Times.Once);
        }
    }
}