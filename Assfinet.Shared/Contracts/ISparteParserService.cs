using Assfinet.Shared.Entities;
using Assfinet.Shared.Models;

namespace Assfinet.Shared.Contracts;

public interface ISparteParserService
{
    KrvSparte ParseSparteModelToKrvSparte(KrvModel krvModel);
}