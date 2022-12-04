using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for City
    /// </summary>
    public interface ICityService
    {
        /// <summary>
        /// Get list of all Cities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CityViewModel>> GetAll();
        /// <summary>
        /// Get all cities for country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<CityViewModel>> GetForCountry(Guid id);
        /// <summary>
        /// Add city in repository
        /// </summary>
        /// <param name="cityViewModel"></param>
        /// <returns></returns>
        Task Add(CityViewModelCreate cityViewModel);
        /// <summary>
        /// Delete city from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// Gets city from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CityViewModel> Get(Guid id);
        /// <summary>
        /// Updates a city
        /// </summary>
        /// <param name="cityViewModel"></param>
        /// <returns></returns>
        Task Update(CityViewModelEdit cityViewModel);
        /// <summary>
        ///  Get list of all countries
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CountryViewModel>> GetAllCountries();

    }
}
