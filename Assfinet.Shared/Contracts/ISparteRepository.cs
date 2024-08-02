namespace Assfinet.Shared.Contracts;

public interface ISparteRepository
{
    Task SaveSpartenDatenAsync<T>(List<T> spartenDaten) where T : class;

}