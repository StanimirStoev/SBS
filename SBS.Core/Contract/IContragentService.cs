using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IContragentService
    {
        Task<IEnumerable<ContragentViewModel>> GetAll();

        Task Add(ContragentViewModel contragentViewModel);

        Task Delete(Guid id);

        Task<ContragentViewModel> Get(Guid id);

        Task Update(ContragentViewModel contragentViewModel);
    }
}
