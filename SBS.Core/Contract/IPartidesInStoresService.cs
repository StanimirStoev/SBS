using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IPartidesInStoresService
    {
        Task<IEnumerable<PartidesInStoreViewModel>> GetAll();
    }
}
