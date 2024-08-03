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
    public class KundeServiceTests
    {
        private readonly Mock<IKundeParserService> _kundeParserServiceMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<IKundeProcessingService> _kundeProcessingServiceMock;
        private readonly KundeService _kundeService;

        public KundeServiceTests()
        {
            _kundeParserServiceMock = new Mock<IKundeParserService>();
            _loggerMock = new Mock<IAppLogger>();
            _kundeProcessingServiceMock = new Mock<IKundeProcessingService>();
            _kundeService = new KundeService(_kundeParserServiceMock.Object, _loggerMock.Object, _kundeProcessingServiceMock.Object);
        }

        [Fact]
        public async Task ImportKundenAsync_NoCustomers_LogsWarning()
        {
            var kundenModels = new List<KundeModel>();
            await _kundeService.ImportKundenAsync(kundenModels);
            _loggerMock.Verify(l => l.LogWarning("Es wurden 0 Kunden von der API abgerufen."), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_ValidCustomers_ProcessesSuccessfully()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };

            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Returns(kunde);
            _kundeProcessingServiceMock.Setup(p => p.ValidateKundeAsync(kunde)).Returns(Task.CompletedTask);
            _kundeProcessingServiceMock.Setup(p => p.ProcessImportKundeAsync(kunde)).Returns(Task.CompletedTask);

            await _kundeService.ImportKundenAsync(kundenModels);

            _loggerMock.Verify(l => l.LogInformation($"Es wurden {kundenModels.Count} Kunden von der API abgerufen."), Times.Once);
            _kundeParserServiceMock.Verify(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>()), Times.Once);
            _kundeProcessingServiceMock.Verify(p => p.ValidateKundeAsync(kunde), Times.Once);
            _kundeProcessingServiceMock.Verify(p => p.ProcessImportKundeAsync(kunde), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_ValidationFails_LogsError()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };
            var validationResult = new ValidationResult(new[] { new ValidationFailure("AmsId", "Validation failed") });

            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Returns(kunde);
            _kundeProcessingServiceMock.Setup(p => p.ValidateKundeAsync(kunde)).ThrowsAsync(new ValidationException(validationResult.Errors));

            await Assert.ThrowsAsync<ValidationException>(() => _kundeService.ImportKundenAsync(kundenModels));

            _loggerMock.Verify(l => l.LogError(It.Is<string>(s => s.Contains($"Bei dem Kunden mit der AmsId '{kundenModels[0].Id}' ist ein Validierungsfehler aufgetreten: Validation failed")), It.IsAny<ValidationException>()), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_RepositoryException_LogsError()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };

            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Returns(kunde);
            _kundeProcessingServiceMock.Setup(p => p.ValidateKundeAsync(kunde)).Returns(Task.CompletedTask);
            _kundeProcessingServiceMock.Setup(p => p.ProcessImportKundeAsync(kunde)).ThrowsAsync(new RepositoryException("Repository error"));

            await Assert.ThrowsAsync<RepositoryException>(() => _kundeService.ImportKundenAsync(kundenModels));

            _loggerMock.Verify(l => l.LogError($"Repository-Exception beim Importieren von dem Kunden mit der AmsId '{kundenModels[0].Id}'.", It.IsAny<RepositoryException>()), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_UnexpectedException_LogsError()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };

            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Returns(kunde);
            _kundeProcessingServiceMock.Setup(p => p.ValidateKundeAsync(kunde)).Returns(Task.CompletedTask);
            _kundeProcessingServiceMock.Setup(p => p.ProcessImportKundeAsync(kunde)).ThrowsAsync(new Exception("Unexpected error"));

            await Assert.ThrowsAsync<KundeServiceException>(() => _kundeService.ImportKundenAsync(kundenModels));

            _loggerMock.Verify(l => l.LogError($"Es ist ein unerwarteter Fehler beim Importieren von dem Kunden mit der AmsId '{kundenModels[0].Id}' aufgetreten.", It.IsAny<Exception>()), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_ArgumentNullException_LogsError()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Throws(new ArgumentNullException());

            await Assert.ThrowsAsync<ArgumentNullException>(() => _kundeService.ImportKundenAsync(kundenModels));

            _loggerMock.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<ArgumentNullException>()), Times.Once);
        }

        [Fact]
        public async Task ImportKundenAsync_InvalidOperationException_LogsError()
        {
            var kundenModels = new List<KundeModel> { new KundeModel { Id = Guid.NewGuid() } };
            _kundeParserServiceMock.Setup(p => p.ParseKundeModelToDbEntity(It.IsAny<KundeModel>())).Throws(new InvalidOperationException());

            await Assert.ThrowsAsync<InvalidOperationException>(() => _kundeService.ImportKundenAsync(kundenModels));

            _loggerMock.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<InvalidOperationException>()), Times.Once);
        }
    }
}
