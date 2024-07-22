using Assfinet.Shared.Entities;

namespace Assfinet.Shared.Contracts;

public interface IKundeRepository
{
    Task AddKundeAsync(Kunde kunde);
}