using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Address
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Get list of all Addresses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AddressViewModel>> GetAll();
        /// <summary>
        /// Add Address in repository
        /// </summary>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        Task Add(AddressViewModel addressViewModel);
        /// <summary>
        /// Delete address from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// Gets address from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AddressViewModel> Get(Guid id);
        /// <summary>
        /// Updates an Address
        /// </summary>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        Task Update(AddressViewModel addressViewModel);
    }
}
