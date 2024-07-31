using System.Threading.Tasks;

namespace Assfinet.Shared.Contracts
{
    public interface ISparteRepository<T>
    {
        Task AddSparteAsync(T sparte);
        Task<T?> GetSparteByAmsidnrAsync(string amsidnr);
    }
}