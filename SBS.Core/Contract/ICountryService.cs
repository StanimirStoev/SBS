using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Country
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Get list of all Countries
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CountryViewModel>> GetAll();

        /// <summary>
        /// Add country in repository
        /// </summary>
        /// <param name="countryViewModel"></param>
        /// <returns></returns>
        Task Add(CountryViewModel countryViewModel);

        /// <summary>
        /// Delete country from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets country from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CountryViewModel> Get(Guid id);

        /// <summary>
        /// Updates a country
        /// </summary>
        /// <param name="countryViewModel"></param>
        /// <returns></returns>
        Task Update(CountryViewModel countryViewModel);
    }
}
