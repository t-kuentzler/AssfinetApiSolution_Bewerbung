using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface IKundeParserService
{
    Kunde ParseKundeModelToDbEntity(KundeModel kundeModel);
}