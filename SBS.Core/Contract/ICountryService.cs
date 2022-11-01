using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewModel>> GetAll();

        Task Add(CountryViewModel countryViewModel);

        Task Delete(Guid id);

        Task<CountryViewModel> Get(Guid id);

        Task Update(CountryViewModel countryViewModel);
    }
}
