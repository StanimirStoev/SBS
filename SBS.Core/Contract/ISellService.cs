using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface ISellService
    {
        Task<IEnumerable<SellViewModel>> GetAll();

        Task Add(SellViewModel viewModel);

        Task Delete(Guid id);

        Task<SellViewModel> Get(Guid id);

        Task Update(SellViewModel viewModel);
    }
}
