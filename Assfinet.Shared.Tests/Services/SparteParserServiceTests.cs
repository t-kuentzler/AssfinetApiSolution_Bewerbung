using Assfinet.Shared.Contracts;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using Assfinet.Shared.Services;
using AutoMapper;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class SparteParserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly SparteParserService _sparteParserService;

        public SparteParserServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<IAppLogger>();
            _sparteParserService = new SparteParserService(_mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void ParseSparteModel_NullSparteModel_ThrowsArgumentNullException()
        {
            // Arrange
            object? sparteModel = null;

            // Act & Assert
            var exception =
                Assert.Throws<ArgumentNullException>(() => _sparteParserService.ParseSparteModel(sparteModel));
            _loggerMock.Verify(log => log.LogError(It.Is<string>(msg => msg.Contains(nameof(sparteModel)))),
                Times.Once);
            Assert.Equal("sparteModel", exception.ParamName);
        }

        [Fact]
        public void ParseSparteModel_ValidSparteModel_ReturnsSparte()
        {
            // Arrange
            var sparteModel = new VertragSparteModel { Id = Guid.NewGuid() };
            var sparte = new Sparte { Id = 1, SparteFields = new List<SparteFields>() };

            _mapperMock.Setup(m => m.Map(sparteModel, sparteModel.GetType(), typeof(Sparte))).Returns(sparte);

            // Act
            var result = _sparteParserService.ParseSparteModel(sparteModel);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Sparte>(result);
            Assert.Equal(sparte, result);
        }

        [Fact]
        public void ParseSparteModel_MapperReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var sparteModel = new VertragSparteModel { Id = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map(sparteModel, sparteModel.GetType(), typeof(Sparte))).Returns((Sparte?)null);

            // Act & Assert
            var exception =
                Assert.Throws<InvalidOperationException>(() => _sparteParserService.ParseSparteModel(sparteModel));
            _loggerMock.Verify(log => log.LogError(It.Is<string>(msg => msg.Contains("Mapping von"))), Times.Once);
        }

        [Fact]
        public void ParseSparteModel_ValidSparteModel_MapsAdditionalProperties()
        {
            // Arrange
            var sparteModel = new UnfModel()
                { Id = Guid.NewGuid(), Key = "123", Amsidnr = "345", UNF101 = "TestValue" };
            var sparte = new Sparte { Id = 1, SparteFields = new List<SparteFields>() };

            _mapperMock.Setup(m => m.Map(sparteModel, sparteModel.GetType(), typeof(Sparte))).Returns(sparte);

            // Act
            var result = _sparteParserService.ParseSparteModel(sparteModel) as Sparte;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SparteFields);
            Assert.Contains(result.SparteFields, f => f.FieldName == "UNF101" && f.FieldValue == "TestValue");
        }
    }
}