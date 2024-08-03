using Assfinet.Shared.Contracts;
using Assfinet.Shared.Services;
using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;
using Assfinet.Shared.Tests.Models;

namespace Assfinet.Shared.Tests.Services
{
    public class TypeMappingServiceTests
    {
        private readonly ITypeMappingService _typeMappingService;

        public TypeMappingServiceTests()
        {
            _typeMappingService = new TypeMappingService();
        }

        [Fact]
        public void GetTargetType_ValidSourceType_ReturnsTargetType()
        {
            // Arrange
            var sourceType = typeof(KrvModel);

            // Act
            var result = _typeMappingService.GetTargetType(sourceType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(KrvSparte), result);
        }

        [Fact]
        public void GetTargetType_InvalidSourceType_ThrowsInvalidOperationException()
        {
            // Arrange
            var sourceType = typeof(SparteTestModel);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _typeMappingService.GetTargetType(sourceType));
            Assert.Contains($"Kein Mapping für den Typ '{sourceType.Name}' gefunden.", exception.Message);
        }
    }
}