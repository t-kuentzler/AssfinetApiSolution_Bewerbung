using Assfinet.Shared.Contracts;
using Assfinet.Shared.Services;
using Assfinet.Shared.Tests.Models;
using AutoMapper;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class SparteParserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<ITypeMappingService> _typeMappingServiceMock;

        public SparteParserServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<IAppLogger>();
            _typeMappingServiceMock = new Mock<ITypeMappingService>();
        }

        [Fact]
        public void ParseSparteModel_NullModel_ThrowsArgumentNullException()
        {
            // Arrange
            object sparteModel = null;
            var sparteParserService =
                new SparteParserService(_mapperMock.Object, _loggerMock.Object, _typeMappingServiceMock.Object);

            // Act & Assert
            var exception =
                Assert.Throws<ArgumentNullException>(() => sparteParserService.ParseSparteModel(sparteModel));
            _loggerMock.Verify(
                l => l.LogError(It.Is<string>(s => s.Contains("sparteModel darf beim parsen nicht null sein."))),
                Times.Once);
        }

        [Fact]
        public void ParseSparteModel_InvalidMapping_ThrowsInvalidOperationException()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var sparteParserService =
                new SparteParserService(_mapperMock.Object, _loggerMock.Object, _typeMappingServiceMock.Object);

            _typeMappingServiceMock.Setup(t => t.GetTargetType(It.IsAny<Type>())).Returns(typeof(SparteTestEntity));
            _mapperMock.Setup(m => m.Map(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<Type>())).Returns((object)null);

            // Act & Assert
            var exception =
                Assert.Throws<InvalidOperationException>(() => sparteParserService.ParseSparteModel(sparteModel));
            _loggerMock.Verify(
                l => l.LogError(It.Is<string>(s =>
                    s.Contains($"Mapping von 'SparteTestModel' zu 'SparteTestEntity' fehlgeschlagen."))), Times.Once);
        }

        [Fact]
        public void ParseSparteModel_SuccessfulMapping_ReturnsMappedObject()
        {
            // Arrange
            var sparteModel = new SparteTestModel { Key = "testKey" };
            var sparteEntity = new SparteTestEntity { Key = sparteModel.Key };
            var sparteParserService =
                new SparteParserService(_mapperMock.Object, _loggerMock.Object, _typeMappingServiceMock.Object);

            _typeMappingServiceMock.Setup(t => t.GetTargetType(It.IsAny<Type>())).Returns(typeof(SparteTestEntity));
            _mapperMock.Setup(m => m.Map(sparteModel, typeof(SparteTestModel), typeof(SparteTestEntity)))
                .Returns(sparteEntity);

            // Act
            var result = sparteParserService.ParseSparteModel(sparteModel);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SparteTestEntity>(result);
            Assert.Equal(sparteEntity, result);
        }
    }
}