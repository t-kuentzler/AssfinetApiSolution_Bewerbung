namespace Assfinet.Shared.Contracts;

public interface ISparteService
{
    Task ImportSpartenDatenAsync(List<object> spartenModels);
}