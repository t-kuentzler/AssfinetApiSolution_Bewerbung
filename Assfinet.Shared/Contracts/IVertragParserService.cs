using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IVertragParserService
{
    Vertrag ParseKundeModelToDbEntity(VertragModel vertragModel);
}