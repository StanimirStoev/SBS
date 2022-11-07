using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Core.Contract
{
    public interface IUnitService
    {
        int GetCount(UnitFilterViewModel filter);

        Task<List<UnitViewModel>> GetAll(UnitFilterViewModel filter, SortHelper sortHelper, int pageIndex = 1, int pageSize = 5);

        Task<List<UnitViewModel>> GetAll();

        Task Add(UnitViewModel unitViewModel);

        Task Delete(Guid id);

        Task<UnitViewModel> Get(Guid id);

        Task Update(UnitViewModel unitViewModel);

        public bool IsExists(string name);

        public bool IsExists(string name, Guid id);
    }
}
