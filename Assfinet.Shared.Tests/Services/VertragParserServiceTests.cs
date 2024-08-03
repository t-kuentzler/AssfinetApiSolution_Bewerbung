using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using Assfinet.Shared.Services;
using AutoMapper;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class VertragParserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly VertragParserService _vertragParserService;

        public VertragParserServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _vertragParserService = new VertragParserService(_mapperMock.Object);
        }

        [Fact]
        public void ParseVertragModelToDbEntity_NullVertragModel_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _vertragParserService.ParseKundeModelToDbEntity(null));
        }

        [Fact]
        public void ParseVertragModelToDbEntity_ValidVertragModel_ReturnsVertrag()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag>(vertragModel)).Returns(vertrag);
            _mapperMock.Setup(m => m.Map<VertragFinanzen>(vertragModel)).Returns(new VertragFinanzen());
            _mapperMock.Setup(m => m.Map<VertragDetails>(vertragModel)).Returns(new VertragDetails());
            _mapperMock.Setup(m => m.Map<VertragHistorie>(vertragModel)).Returns(new VertragHistorie());
            _mapperMock.Setup(m => m.Map<VertragBank>(vertragModel)).Returns(new VertragBank());

            // Act
            var result = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag, result);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.VertragDetails);
            Assert.NotNull(result.Historie);
            Assert.NotNull(result.BankDetails);
        }

        [Fact]
        public void ParseVertragModelToDbEntity_MappingFails_ThrowsInvalidOperationException()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag?>(vertragModel)).Returns((Vertrag?)null);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => _vertragParserService.ParseKundeModelToDbEntity(vertragModel));
        }

        [Fact]
        public void ParseVertragModelToDbEntity_MappingFinanzenFails_ReturnsVertragWithDefaultFinanzen()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag>(vertragModel)).Returns(vertrag);
            _mapperMock.Setup(m => m.Map<VertragFinanzen?>(vertragModel)).Returns((VertragFinanzen?)null);
            _mapperMock.Setup(m => m.Map<VertragDetails>(vertragModel)).Returns(new VertragDetails());
            _mapperMock.Setup(m => m.Map<VertragHistorie>(vertragModel)).Returns(new VertragHistorie());
            _mapperMock.Setup(m => m.Map<VertragBank>(vertragModel)).Returns(new VertragBank());

            // Act
            var result = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag, result);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.VertragDetails);
            Assert.NotNull(result.Historie);
            Assert.NotNull(result.BankDetails);
        }

        [Fact]
        public void ParseVertragModelToDbEntity_MappingDetailsFails_ReturnsVertragWithDefaultDetails()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag>(vertragModel)).Returns(vertrag);
            _mapperMock.Setup(m => m.Map<VertragFinanzen>(vertragModel)).Returns(new VertragFinanzen());
            _mapperMock.Setup(m => m.Map<VertragDetails?>(vertragModel)).Returns((VertragDetails?)null);
            _mapperMock.Setup(m => m.Map<VertragHistorie>(vertragModel)).Returns(new VertragHistorie());
            _mapperMock.Setup(m => m.Map<VertragBank>(vertragModel)).Returns(new VertragBank());

            // Act
            var result = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag, result);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.VertragDetails);
            Assert.NotNull(result.Historie);
            Assert.NotNull(result.BankDetails);
        }

        [Fact]
        public void ParseVertragModelToDbEntity_MappingHistorieFails_ReturnsVertragWithDefaultHistorie()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag>(vertragModel)).Returns(vertrag);
            _mapperMock.Setup(m => m.Map<VertragFinanzen>(vertragModel)).Returns(new VertragFinanzen());
            _mapperMock.Setup(m => m.Map<VertragDetails>(vertragModel)).Returns(new VertragDetails());
            _mapperMock.Setup(m => m.Map<VertragHistorie?>(vertragModel)).Returns((VertragHistorie?)null);
            _mapperMock.Setup(m => m.Map<VertragBank>(vertragModel)).Returns(new VertragBank());

            // Act
            var result = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag, result);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.VertragDetails);
            Assert.NotNull(result.Historie);
            Assert.NotNull(result.BankDetails);
        }

        [Fact]
        public void ParseVertragModelToDbEntity_MappingBankDetailsFails_ReturnsVertragWithDefaultBankDetails()
        {
            // Arrange
            var vertragModel = new VertragModel { Id = Guid.NewGuid() };
            var vertrag = new Vertrag { Id = 1, AmsId = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Vertrag>(vertragModel)).Returns(vertrag);
            _mapperMock.Setup(m => m.Map<VertragFinanzen>(vertragModel)).Returns(new VertragFinanzen());
            _mapperMock.Setup(m => m.Map<VertragDetails>(vertragModel)).Returns(new VertragDetails());
            _mapperMock.Setup(m => m.Map<VertragHistorie>(vertragModel)).Returns(new VertragHistorie());
            _mapperMock.Setup(m => m.Map<VertragBank?>(vertragModel)).Returns((VertragBank?)null);

            // Act
            var result = _vertragParserService.ParseKundeModelToDbEntity(vertragModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vertrag, result);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.VertragDetails);
            Assert.NotNull(result.Historie);
            Assert.NotNull(result.BankDetails);
        }
    }
}