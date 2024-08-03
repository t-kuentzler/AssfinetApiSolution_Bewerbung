using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using Assfinet.Shared.Services;
using AutoMapper;
using Moq;

namespace Assfinet.Shared.Tests.Services
{
    public class KundeParserServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly KundeParserService _kundeParserService;

        public KundeParserServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _kundeParserService = new KundeParserService(_mapperMock.Object);
        }

        [Fact]
        public void ParseKundeModelToDbEntity_NullKundeModel_ThrowsArgumentNullException()
        {
            // Arrange
            KundeModel? kundeModel = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _kundeParserService.ParseKundeModelToDbEntity(kundeModel));
        }

        [Fact]
        public void ParseKundeModelToDbEntity_ValidKundeModel_ReturnsKunde()
        {
            // Arrange
            var kundeModel = new KundeModel { Id = Guid.NewGuid() };
            var kunde = new Kunde { Id = 1, AmsId = Guid.NewGuid() };
            var personenDetails = new KundePersonenDetails();
            var finanzen = new KundeFinanzen();
            var kontakt = new KundeKontakt();

            _mapperMock.Setup(m => m.Map<Kunde>(kundeModel)).Returns(kunde);
            _mapperMock.Setup(m => m.Map<KundePersonenDetails>(kundeModel)).Returns(personenDetails);
            _mapperMock.Setup(m => m.Map<KundeFinanzen>(kundeModel)).Returns(finanzen);
            _mapperMock.Setup(m => m.Map<KundeKontakt>(kundeModel)).Returns(kontakt);

            // Act
            var result = _kundeParserService.ParseKundeModelToDbEntity(kundeModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kunde, result);
            Assert.Equal(personenDetails, result.PersonenDetails);
            Assert.Equal(finanzen, result.Finanzen);
            Assert.Equal(kontakt, result.Kontakt);
        }

        [Fact]
        public void ParseKundeModelToDbEntity_MapperReturnsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var kundeModel = new KundeModel { Id = Guid.NewGuid() };

            _mapperMock.Setup(m => m.Map<Kunde?>(kundeModel)).Returns((Kunde?)null);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _kundeParserService.ParseKundeModelToDbEntity(kundeModel));
        }
    }
}
