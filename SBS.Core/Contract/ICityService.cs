﻿using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface ICityService
    {
        Task<IEnumerable<CityViewModel>> GetAll();

        Task<IEnumerable<CityViewModel>> GetForCountry(Guid id);

        Task Add(CityViewModelCreate cityViewModel);

        Task Delete(Guid id);

        Task<CityViewModel> Get(Guid id);

        Task Update(CityViewModelEdit cityViewModel);

        Task<IEnumerable<CountryViewModel>> GetAllCountries();

    }
}
