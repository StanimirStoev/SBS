using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface ITransferService
    {
        Task<IEnumerable<TransferViewModel>> GetAll();

        Task<TransferViewModel> Get(Guid id);

        Task Add(TransferViewModel viewModel);
    }
}
