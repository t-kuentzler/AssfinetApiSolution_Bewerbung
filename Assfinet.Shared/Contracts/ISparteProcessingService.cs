namespace Assfinet.Shared.Contracts;

public interface ISparteProcessingService
{
    Task ValidateAsync<T>(T sparte) where T : class, IVertragKeyProvider;
    Task ProcessImportSparteAsync<T>(T sparte) where T : class, IVertragKeyProvider;
}