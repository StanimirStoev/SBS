using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressViewModel>> GetAll();

        Task Add(AddressViewModel addressViewModel);

        Task Delete(Guid id);

        Task<AddressViewModel> Get(Guid id);

        Task Update(AddressViewModel addressViewModel);
    }
}
