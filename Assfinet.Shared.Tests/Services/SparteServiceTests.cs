using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
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
        public async Task ImportSpartenDatenAsync_EmptyList_LogsWarning()
        {
            // Arrange
            var spartenModels = new List<object>();

            // Act
            await _sparteService.ImportSpartenDatenAsync(spartenModels);

            // Assert
            _loggerMock.Verify(log => log.LogWarning("Es wurden 0 Spartendaten von der API abgerufen."), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ValidSpartenModels_ProcessesEachSparte()
        {
            // Arrange
            var spartenModels = new List<object>
                { new SparteTestModel { Key = "testKey1" }, new SparteTestModel { Key = "testKey2" } };
            var sparte = new Sparte();

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Returns(sparte);

            // Act
            await _sparteService.ImportSpartenDatenAsync(spartenModels);

            // Assert
            _loggerMock.Verify(
                log => log.LogInformation($"Es wurden {spartenModels.Count} Spartendaten von der API abgerufen."),
                Times.Once);
            _sparteParserServiceMock.Verify(p => p.ParseSparteModel(It.IsAny<object>()),
                Times.Exactly(spartenModels.Count));
            _sparteProcessingServiceMock.Verify(p => p.ValidateSparteAsync(sparte), Times.Exactly(spartenModels.Count));
            _sparteProcessingServiceMock.Verify(p => p.ProcessImportSparteAsync(sparte),
                Times.Exactly(spartenModels.Count));
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ArgumentNullException_LogsErrorAndThrows()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var argumentNullException = new ArgumentNullException(nameof(sparteModel));

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Throws(argumentNullException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<ArgumentNullException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError(
                    $"ArgumentNullException beim Importieren von den Spartendaten mit dem Key '{sparteModel.Key}': {argumentNullException.Message}",
                    argumentNullException), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_InvalidOperationException_LogsErrorAndThrows()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var invalidOperationException = new InvalidOperationException();

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>()))
                .Throws(invalidOperationException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<InvalidOperationException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError(
                    $"InvalidOperationException beim Importieren von den Spartendaten mit dem Key '{sparteModel.Key}': {invalidOperationException.Message}",
                    invalidOperationException), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_ValidationException_LogsErrorAndThrows()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var validationFailure = new ValidationFailure("Property", "Error message");
            var validationException = new ValidationException(new List<ValidationFailure> { validationFailure });

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Throws(validationException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<ValidationException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError(
                    $"Validierungsfehler bei Spartendaten mit dem Key '{sparteModel.Key}': {validationException.Message}",
                    validationException), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_UnknownSparteException_LogsErrorAndThrows()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var unknownSparteException = new UnknownSparteException();

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Throws(unknownSparteException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<UnknownSparteException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError(
                    $"UnknownSparteException beim Importieren von den Spartendaten mit dem Key '{sparteModel.Key}': {unknownSparteException.Message}",
                    unknownSparteException), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_RepositoryException_LogsErrorAndThrows()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var repositoryException = new RepositoryException();

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Throws(repositoryException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<RepositoryException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError($"Repository-Fehler beim Import von Spartendaten mit dem Key '{sparteModel.Key}'.",
                    repositoryException), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDatenAsync_GeneralException_LogsErrorAndThrowsSparteServiceException()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var spartenModels = new List<object> { sparteModel };
            var generalException = new Exception();

            _sparteParserServiceMock.Setup(p => p.ParseSparteModel(It.IsAny<object>())).Throws(generalException);

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<SparteServiceException>(() =>
                    _sparteService.ImportSpartenDatenAsync(spartenModels));
            _loggerMock.Verify(
                log => log.LogError(
                    $"Unerwarteter Fehler beim Import von Spartendaten mit dem Key '{sparteModel.Key}'.",
                    generalException), Times.Once);
        }
    }
}