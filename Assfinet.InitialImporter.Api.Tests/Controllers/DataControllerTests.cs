using Assfinet.Shared.Contracts;
using Assfinet.Shared.Enums;
using Assfinet.Shared.Models;
using Assfinet.InitialImporter.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Assfinet.InitialImporter.Api.Tests.Controllers
{
    public class DataControllerTests
    {
        private readonly Mock<IApiService> _apiServiceMock;
        private readonly Mock<IKundeService> _kundeServiceMock;
        private readonly Mock<IVertragService> _vertragServiceMock;
        private readonly Mock<IAppLogger> _loggerMock;
        private readonly Mock<ISparteService> _sparteServiceMock;
        private readonly DataController _controller;

        public DataControllerTests()
        {
            _apiServiceMock = new Mock<IApiService>();
            _kundeServiceMock = new Mock<IKundeService>();
            _vertragServiceMock = new Mock<IVertragService>();
            _loggerMock = new Mock<IAppLogger>();
            _sparteServiceMock = new Mock<ISparteService>();
            _controller = new DataController(
                _apiServiceMock.Object,
                _kundeServiceMock.Object,
                _vertragServiceMock.Object,
                _loggerMock.Object,
                _sparteServiceMock.Object
            );
        }

        [Fact]
        public async Task ImportKunden_ReturnsOkResult_WhenImportIsSuccessful()
        {
            // Arrange
            var kunden = new List<KundeModel> { new KundeModel() };
            _apiServiceMock.SetupSequence(s => s.GetKundenAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(kunden)
                .ReturnsAsync(new List<KundeModel>());
            _kundeServiceMock.Setup(s => s.ImportKundenAsync(It.IsAny<List<KundeModel>>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.ImportKunden();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Import abgeschlossen.", okResult.Value);
            _loggerMock.Verify(l => l.LogInformation("Es wurden insgesamt 1 Kunden importiert."), Times.Once);
        }

        [Fact]
        public async Task ImportKunden_ReturnsInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _apiServiceMock.Setup(s => s.GetKundenAsync(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.ImportKunden();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Interner Serverfehler", statusCodeResult.Value);
        }

        [Fact]
        public async Task ImportVertraege_ReturnsOkResult_WhenImportIsSuccessful()
        {
            // Arrange
            var vertraege = new List<VertragModel> { new VertragModel() };
            _apiServiceMock.SetupSequence(s => s.GetVertraegeAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(vertraege)
                .ReturnsAsync(new List<VertragModel>());
            _vertragServiceMock.Setup(s => s.ImportVertraegeAsync(It.IsAny<List<VertragModel>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.ImportVertraege();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Import abgeschlossen.", okResult.Value);
            _loggerMock.Verify(l => l.LogInformation("Es wurden insgesamt 1 Verträge importiert."), Times.Once);
        }

        [Fact]
        public async Task ImportVertraege_ReturnsInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _apiServiceMock.Setup(s => s.GetVertraegeAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.ImportVertraege();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Interner Serverfehler", statusCodeResult.Value);
        }

        [Fact]
        public async Task ImportSpartenDaten_ReturnsBadRequest_WhenNoSpartentypIsProvided()
        {
            // Act
            var result = await _controller.ImportSpartenDaten(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Kein gültiger Spartentyp ausgewählt.", badRequestResult.Value);
        }

        [Fact]
        public async Task ImportSpartenDaten_ReturnsOkResult_WhenImportIsSuccessful()
        {
            // Arrange
            var spartenDaten = new List<object> { new object() };
            _apiServiceMock.SetupSequence(s =>
                    s.GetSpartenDatenAsync(It.IsAny<Spartentypen>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(spartenDaten)
                .ReturnsAsync(new List<object>());
            _sparteServiceMock.Setup(s => s.ImportSpartenDatenAsync(It.IsAny<List<object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.ImportSpartenDaten(Spartentypen.KRV);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Import abgeschlossen.", okResult.Value);
            _loggerMock.Verify(l => l.LogInformation("Import abgeschlossen."), Times.Once);
        }

        [Fact]
        public async Task ImportSpartenDaten_ReturnsInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            _apiServiceMock
                .Setup(s => s.GetSpartenDatenAsync(It.IsAny<Spartentypen>(), It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _controller.ImportSpartenDaten(Spartentypen.KRV);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("Interner Serverfehler", statusCodeResult.Value);
        }
    }
}