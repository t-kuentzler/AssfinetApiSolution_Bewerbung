namespace Assfinet.Shared.Contracts;

public interface ISparteParserService
{
    IVertragKeyProvider ParseModelToDbEntity(object model);
}