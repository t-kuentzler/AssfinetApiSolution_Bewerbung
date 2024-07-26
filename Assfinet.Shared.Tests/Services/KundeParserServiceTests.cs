using Xunit;
using Moq;
using AutoMapper;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using Assfinet.Shared.Services;
using System;
using System.Collections.Generic;

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
        public void ParseKundeModelToDbEntity_ShouldMapKundeModelToKundeEntity()
        {
            // Arrange
            var kundeModel = new KundeModel
            {
                // Initialize properties here
            };
            var kunde = new Kunde();
            var personenDetails = new KundePersonenDetails();
            var finanzen = new KundeFinanzen();
            var kontakt = new KundeKontakt();
            var vertraege = new List<Vertrag>();

            _mapperMock.Setup(m => m.Map<Kunde>(kundeModel)).Returns(kunde);
            _mapperMock.Setup(m => m.Map<KundePersonenDetails>(kundeModel)).Returns(personenDetails);
            _mapperMock.Setup(m => m.Map<KundeFinanzen>(kundeModel)).Returns(finanzen);
            _mapperMock.Setup(m => m.Map<KundeKontakt>(kundeModel)).Returns(kontakt);
            _mapperMock.Setup(m => m.Map<ICollection<Vertrag>>(kundeModel)).Returns(vertraege);

            // Act
            var result = _kundeParserService.ParseKundeModelToDbEntity(kundeModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(kunde, result);
            Assert.Equal(personenDetails, result.PersonenDetails);
            Assert.Equal(finanzen, result.Finanzen);
            Assert.Equal(kontakt, result.Kontakt);
            Assert.Equal(vertraege, result.Vertraege);

            _mapperMock.Verify(m => m.Map<Kunde>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundePersonenDetails>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundeFinanzen>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundeKontakt>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<ICollection<Vertrag>>(kundeModel), Times.Once);
        }

        [Fact]
        public void ParseKundeModelToDbEntity_ShouldThrowArgumentNullException_WhenKundeModelIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _kundeParserService.ParseKundeModelToDbEntity(null));
        }

        [Fact]
        public void ParseKundeModelToDbEntity_ShouldThrowInvalidOperationException_WhenMappingFails()
        {
            // Arrange
            var kundeModel = new KundeModel();
            _mapperMock.Setup(m => m.Map<Kunde>(kundeModel)).Returns((Kunde)null);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _kundeParserService.ParseKundeModelToDbEntity(kundeModel));
        }

        [Fact]
        public void ParseKundeModelToDbEntity_ShouldInitializeEntities_WhenMappedEntitiesAreNull()
        {
            // Arrange
            var kundeModel = new KundeModel
            {
                Amsidnr = "TEST"
            };
            var kunde = new Kunde();

            _mapperMock.Setup(m => m.Map<Kunde>(kundeModel)).Returns(kunde);
            _mapperMock.Setup(m => m.Map<KundePersonenDetails>(kundeModel)).Returns((KundePersonenDetails)null);
            _mapperMock.Setup(m => m.Map<KundeFinanzen>(kundeModel)).Returns((KundeFinanzen)null);
            _mapperMock.Setup(m => m.Map<KundeKontakt>(kundeModel)).Returns((KundeKontakt)null);
            _mapperMock.Setup(m => m.Map<ICollection<Vertrag>>(kundeModel)).Returns((ICollection<Vertrag>)null);

            // Act
            var result = _kundeParserService.ParseKundeModelToDbEntity(kundeModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.PersonenDetails);
            Assert.NotNull(result.Finanzen);
            Assert.NotNull(result.Kontakt);
            Assert.NotNull(result.Vertraege);

            _mapperMock.Verify(m => m.Map<Kunde>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundePersonenDetails>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundeFinanzen>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<KundeKontakt>(kundeModel), Times.Once);
            _mapperMock.Verify(m => m.Map<ICollection<Vertrag>>(kundeModel), Times.Once);
        }
    }
}
