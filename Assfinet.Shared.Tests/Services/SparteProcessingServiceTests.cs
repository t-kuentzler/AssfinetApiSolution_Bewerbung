using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Services;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class SparteProcessingServiceTests
    {
        private readonly Mock<IVertragRepository> _vertragRepositoryMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<ISparteRepository> _sparteRepositoryMock;
        private readonly Mock<IValidatorWrapper<Sparte>> _sparteValidatorMock;
        private readonly SparteProcessingService _sparteProcessingService;

        public SparteProcessingServiceTests()
        {
            _vertragRepositoryMock = new Mock<IVertragRepository>();
            _loggerMock = new Mock<IAppLogger>();
            _sparteRepositoryMock = new Mock<ISparteRepository>();
            _sparteValidatorMock = new Mock<IValidatorWrapper<Sparte>>();
            _sparteProcessingService = new SparteProcessingService(
                _vertragRepositoryMock.Object,
                _loggerMock.Object,
                _sparteRepositoryMock.Object,
                _sparteValidatorMock.Object
            );
        }

        [Fact]
        public async Task ValidateSparteAsync_ValidSparte_CallsValidator()
        {
            // Arrange
            var sparte = new Sparte();

            // Act
            await _sparteProcessingService.ValidateSparteAsync(sparte);

            // Assert
            _sparteValidatorMock.Verify(v => v.ValidateAndThrowAsync(sparte), Times.Once);
        }

        [Fact]
        public async Task ProcessImportSparteAsync_VertragNotFound_LogsError()
        {
            // Arrange
            var sparte = new Sparte { Key = "testKey" };

            _vertragRepositoryMock.Setup(r => r.GetVertragByAmsidnrAsync(sparte.Key)).ReturnsAsync((Vertrag?)null);

            // Act
            await _sparteProcessingService.ProcessImportSparteAsync(sparte);

            // Assert
            _loggerMock.Verify(l => l.LogError(It.Is<string>(msg => msg.Contains($"Die Spartendaten mit dem Key '{sparte.Key}' konnten nicht in der Datenbank erstellt werden, da kein Vertrag mit der entsprechenden Amsidnr gefunden wurde."))), Times.Once);
        }

        [Fact]
        public async Task ProcessImportSparteAsync_SparteExists_LogsError()
        {
            // Arrange
            var sparte = new Sparte { AmsId = new Guid(), Key = "testKey" };
            var vertrag = new Vertrag();

            _vertragRepositoryMock.Setup(r => r.GetVertragByAmsidnrAsync(sparte.Key)).ReturnsAsync(vertrag);
            _sparteRepositoryMock.Setup(r => r.GetSparteByAmsIdAsync(sparte.AmsId)).ReturnsAsync(new Sparte());

            // Act
            await _sparteProcessingService.ProcessImportSparteAsync(sparte);

            // Assert
            _loggerMock.Verify(l => l.LogError(It.Is<string>(msg => msg.Contains($"Die Spartendaten mit der AmsId '{sparte.AmsId}' konnten nicht in der Datenbank erstellt werden, da schon ein Datensatz mit der AmsId existiert."))), Times.Once);
        }

        [Fact]
        public async Task ProcessImportSparteAsync_ValidSparte_AddsSparteAndLogsInfo()
        {
            // Arrange
            var sparte = new Sparte { AmsId = new Guid(), Key = "testKey" };
            var vertrag = new Vertrag();

            _vertragRepositoryMock.Setup(r => r.GetVertragByAmsidnrAsync(sparte.Key)).ReturnsAsync(vertrag);
            _sparteRepositoryMock.Setup(r => r.GetSparteByAmsIdAsync(sparte.AmsId)).ReturnsAsync((Sparte?)null);

            // Act
            await _sparteProcessingService.ProcessImportSparteAsync(sparte);

            // Assert
            _sparteRepositoryMock.Verify(r => r.AddSparteAsync(sparte), Times.Once);
            _loggerMock.Verify(l => l.LogInformation(It.Is<string>(msg => msg.Contains($"Die Spartendaten mit der AmsId '{sparte.AmsId}' wurden erfolgreich in der Datenbank erstellt."))), Times.Once);
        }
    }
}
