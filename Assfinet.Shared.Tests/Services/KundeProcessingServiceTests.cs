using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Services;
using Moq;

namespace Assfinet.Shared.Tests.Services;

public class KundeProcessingServiceTests
{
    private readonly Mock<IValidatorWrapper<Kunde>> _kundeValidatorMock;
    private readonly Mock<IKundeRepository> _kundeRepositoryMock;
    private readonly Mock<IAppLogger> _loggerMock;

    private readonly KundeProcessingService _kundeProcessingService;

    public KundeProcessingServiceTests()
    {
        _kundeValidatorMock = new Mock<IValidatorWrapper<Kunde>>();
        _kundeRepositoryMock = new Mock<IKundeRepository>();
        _loggerMock = new Mock<IAppLogger>();

        _kundeProcessingService = new KundeProcessingService(
            _kundeValidatorMock.Object,
            _kundeRepositoryMock.Object,
            _loggerMock.Object
        );
    }

    //ValidateKundeAsync
    [Fact]
    public async Task ValidateKundeAsync_ValidKunde_Success()
    {
        // Arrange
        var kunde = new Kunde { AmsId = Guid.NewGuid() };

        _kundeValidatorMock.Setup(v => v.ValidateAndThrowAsync(kunde)).Returns(Task.CompletedTask);

        // Act
        await _kundeProcessingService.ValidateKundeAsync(kunde);

        // Assert
        _kundeValidatorMock.Verify(v => v.ValidateAndThrowAsync(kunde), Times.Once);
    }

    //ProcessImportKundeAsync
    [Fact]
    public async Task ProcessImportKundeAsync_KundeDoesNotExist_AddsKunde()
    {
        // Arrange
        var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };

        _kundeRepositoryMock.Setup(r => r.GetKundeByAmsIdAsync(kunde.AmsId)).ReturnsAsync((Kunde?)null);

        // Act
        await _kundeProcessingService.ProcessImportKundeAsync(kunde);

        // Assert
        _kundeRepositoryMock.Verify(r => r.AddKundeAsync(kunde), Times.Once);
        _loggerMock.Verify(l => l.LogInformation(It.Is<string>(msg => msg.Contains($"Es wird versucht, den Kunden mit der AmsId '{kunde.AmsId}' in der Datenbank zu erstellen."))), Times.Once);
        _loggerMock.Verify(l => l.LogInformation(It.Is<string>(msg => msg.Contains($"Der Kunde mit der AmsId '{kunde.AmsId}' wurde erfolgreich in der Datenbank erstellt."))), Times.Once);
    }

    [Fact]
    public async Task ProcessImportKundeAsync_KundeExists_LogsError()
    {
        // Arrange
        var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };
        var existingKunde = new Kunde { Id = 1, AmsId = kunde.AmsId };

        _kundeRepositoryMock.Setup(r => r.GetKundeByAmsIdAsync(kunde.AmsId)).ReturnsAsync(existingKunde);

        // Act
        await _kundeProcessingService.ProcessImportKundeAsync(kunde);

        // Assert
        _kundeRepositoryMock.Verify(r => r.AddKundeAsync(It.IsAny<Kunde>()), Times.Never);
        _loggerMock.Verify(l => l.LogError(It.Is<string>(msg => msg.Contains($"Der Kunde mit der AmsId '{kunde.AmsId}' konnte nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert."))), Times.Once);
    }
}