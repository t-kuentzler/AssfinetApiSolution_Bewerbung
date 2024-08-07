using Assfinet.Shared.Contracts;
using Assfinet.Shared.Services;
using Assfinet.Shared.Tests.Models;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Tests.Services
{
    // public class SparteProcessingServiceTests
    // {
    //     private readonly Mock<IVertragRepository> _vertragRepositoryMock;
    //     private readonly Mock<IAppLogger> _loggerMock;
    //     private readonly Mock<ISparteRepository> _sparteRepositoryMock;
    //     
    //     //Für die dynamische erstellung der validatoren
    //     private readonly Mock<IServiceProvider> _serviceProviderMock;
    //     private readonly SparteProcessingService _sparteProcessingService;
    //
    //     public SparteProcessingServiceTests()
    //     {
    //         _vertragRepositoryMock = new Mock<IVertragRepository>();
    //         _loggerMock = new Mock<IAppLogger>();
    //         _sparteRepositoryMock = new Mock<ISparteRepository>();
    //         _serviceProviderMock = new Mock<IServiceProvider>();
    //
    //         _sparteProcessingService = new SparteProcessingService(
    //             _vertragRepositoryMock.Object,
    //             _loggerMock.Object,
    //             _sparteRepositoryMock.Object,
    //             _serviceProviderMock.Object
    //         );
    //     }
    //
    //     [Fact]
    //     public async Task ValidateSparteAsync_NoValidatorFound_ThrowsInvalidOperationException()
    //     {
    //         // Arrange
    //         var sparte = new SparteTestModel { Key = "testKey" };
    //         _serviceProviderMock.Setup(sp => sp.GetService(It.IsAny<Type>())).Returns(null);
    //
    //         // Act & Assert
    //         var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _sparteProcessingService.ValidateSparteAsync(sparte));
    //         Assert.Contains("Kein Validator für den Typ 'SparteTestModel' gefunden.", exception.Message);
    //     }
    //
    //     [Fact]
    //     public async Task ValidateSparteAsync_ValidationFails_ThrowsValidationException()
    //     {
    //         // Arrange
    //         var sparte = new KrvSparte { Key = "testKey", AmsId = Guid.NewGuid() };
    //         var validatorMock = new Mock<IValidator<KrvSparte>>();
    //         var validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Key", "Validation failed") });
    //
    //         _serviceProviderMock.Setup(sp => sp.GetService(typeof(IValidator<KrvSparte>)))
    //             .Returns(validatorMock.Object);
    //
    //         validatorMock.Setup(v => v.ValidateAsync(It.IsAny<IValidationContext>(), default))
    //             .ReturnsAsync(validationResult);
    //
    //         // Act & Assert
    //         var exception = await Assert.ThrowsAsync<ValidationException>(() => _sparteProcessingService.ValidateSparteAsync(sparte));
    //         Assert.Contains("Validation failed", exception.Message);
    //     }
    //
    //
    //     [Fact]
    //     public async Task ProcessImportSparteAsync_NoKeyProperty_ThrowsInvalidOperationException()
    //     {
    //         // Arrange
    //         var sparte = new { AmsId = Guid.NewGuid() };
    //
    //         // Act & Assert
    //         var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _sparteProcessingService.ProcessImportSparteAsync(sparte));
    //         Assert.Contains("Die Eigenschaften 'Key' und 'AmsId' müssen im Typ '<>f__AnonymousType0`1' vorhanden sein.", exception.Message);
    //     }
    //
    //     [Fact]
    //     public async Task ProcessImportSparteAsync_NoAmsIdProperty_ThrowsInvalidOperationException()
    //     {
    //         // Arrange
    //         var sparte = new { Key = "testKey" };
    //
    //         // Act & Assert
    //         var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _sparteProcessingService.ProcessImportSparteAsync(sparte));
    //         Assert.Contains("Die Eigenschaften 'Key' und 'AmsId' müssen", exception.Message);
    //     }
    //
    //     [Fact]
    //     public async Task ProcessImportSparteAsync_NoVertragFound_LogsError()
    //     {
    //         // Arrange
    //         var sparte = new SparteTestEntity { Key = "testKey", AmsId = Guid.NewGuid() };
    //
    //         _vertragRepositoryMock.Setup(v => v.GetVertragByAmsidnrAsync(It.IsAny<string>())).ReturnsAsync((Vertrag?)null);
    //
    //         // Act
    //         await _sparteProcessingService.ProcessImportSparteAsync(sparte);
    //
    //         // Assert
    //         _loggerMock.Verify(l => l.LogError(It.Is<string>(s => s.Contains("Die Spartendaten mit dem Key 'testKey' im Typ 'SparteTestEntity' konnten nicht in der Datenbank erstellt werden, da kein Vertrag mit der entsprechenden Amsidnr gefunden wurde."))), Times.Once);
    //     }
    //
    //     [Fact]
    //     public async Task ProcessImportSparteAsync_SparteAlreadyExists_LogsError()
    //     {
    //         // Arrange
    //         var sparte = new SparteTestEntity { Key = "testKey", AmsId = Guid.NewGuid() };
    //         var vertrag = new Vertrag();
    //
    //         _vertragRepositoryMock.Setup(v => v.GetVertragByAmsidnrAsync(It.IsAny<string>())).ReturnsAsync(vertrag);
    //         _sparteRepositoryMock.Setup(s => s.GetSparteByAmsIdAsync(It.IsAny<Guid>(), It.IsAny<Type>())).ReturnsAsync(new object());
    //
    //         // Act
    //         await _sparteProcessingService.ProcessImportSparteAsync(sparte);
    //
    //         // Assert
    //         _loggerMock.Verify(l => l.LogError(It.Is<string>(s => s.Contains("Die Spartendaten mit der AmsId"))), Times.Once);
    //     }
    //
    //     [Fact]
    //     public async Task ProcessImportSparteAsync_SuccessfullyCreatesSparte_LogsInformation()
    //     {
    //         // Arrange
    //         var sparte = new SparteTestEntity { Key = "testKey", AmsId = Guid.NewGuid() };
    //         var vertrag = new Vertrag();
    //
    //         _vertragRepositoryMock.Setup(v => v.GetVertragByAmsidnrAsync(It.IsAny<string>())).ReturnsAsync(vertrag);
    //         _sparteRepositoryMock.Setup(s => s.GetSparteByAmsIdAsync(It.IsAny<Guid>(), It.IsAny<Type>())).ReturnsAsync((object?)null);
    //         _sparteRepositoryMock.Setup(s => s.AddAsync(It.IsAny<object>())).Returns(Task.CompletedTask);
    //
    //         // Act
    //         await _sparteProcessingService.ProcessImportSparteAsync(sparte);
    //
    //         // Assert
    //         _loggerMock.Verify(l => l.LogInformation(It.Is<string>(s => s.Contains("Die Spartendaten mit der AmsId"))), Times.Once);
    //     }
    // }
}
